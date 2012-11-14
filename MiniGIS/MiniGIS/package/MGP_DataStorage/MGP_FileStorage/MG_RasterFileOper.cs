/***********************************************************************
 * Module:  MG_GDALReader.cs
 * Author:  ke
 * Purpose: Definition of the Class MGP_DataStorage.MGP_FileStorage.MiniGIS.MG_GDALReader
 ***********************************************************************/

using System;
using OSGeo.GDAL; // gdal
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

namespace MGP_DataStorage.MGP_FileStorage
{
    class MG_RasterFileOper
    {
        public static void Test()
        {
            try
            {
                // Register
                Gdal.AllRegister(); // Only works for reading data but not for creating datasets.
                // string strFilePath = @"C:\Users\Administrator\minigis2\data\gdal_data\092b05.tif"; 
                string strFilePath = @"C:\1.bmp";
                //String strFormatCode = "GTiff";
                //Driver driver=Gdal.GetDriverByName(strFormatCode);
                //driver.Register(); // Works for reading and creating datasets.

                // Open dataset
                Dataset ds = Gdal.Open(strFilePath, Access.GA_ReadOnly);
                if (ds != null)
                {
                    // Get Raster Parameters
                    int xSize = ds.RasterXSize;
                    int ySize = ds.RasterYSize;
                    int bands = ds.RasterCount;
                    string strProjectionRef = ds.GetProjectionRef();
                    MessageBox.Show("image width=" + xSize + ",height=" + ySize + ", bands=" + bands);

                    // Get Transform
                    double[] adfGeoTransform = new double[6];
                    ds.GetGeoTransform(adfGeoTransform);
                    double originX = adfGeoTransform[0];
                    double originY = adfGeoTransform[3];
                    double pixelWidth = adfGeoTransform[1];
                    double pixelHeight = adfGeoTransform[5];
                    // xOffset=int((x-originX)/pixelWidth)
                    // yOffset=int((y-originY)/pixelHeight)
                }

                // Get Driver
                OSGeo.GDAL.Driver driver = ds.GetDriver();
                if (driver != null)
                {
                    string strDescription = driver.GetDescription();
                    string strLongName = driver.LongName;
                    string strShortName = driver.ShortName;
                }

                // Get Raster Band
                for (int iBand = 1; iBand <= ds.RasterCount; iBand++)
                {
                    // 1-based
                    Band band = ds.GetRasterBand(iBand);
                    string dataType = band.DataType.ToString();
                    int xSize = band.XSize;
                    int ySize = band.YSize;
                    string colorInterp = band.GetRasterColorInterpretation().ToString();
                    for (int iOver = 0; iOver < band.GetOverviewCount(); iOver++)
                    {
                        Band over = band.GetOverview(iOver);
                        string overDataType = over.DataType.ToString();
                        int overXSize = over.XSize;
                        int overYSize = over.YSize;
                        string overColorInterp = over.GetRasterColorInterpretation().ToString();
                    }

                }

                // Processing the raster data
                //SaveBitmapBuffered(ds, @"C:\1new.jpg");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        // PaletteIndex   GrayIndex(R=G=B)   RGB
        public static Bitmap LoadRasterFile(string filePath)
        {
            Dataset ds = null;
            try
            {
                Gdal.AllRegister();
                ds = Gdal.Open(filePath, Access.GA_ReadOnly);

                Band redBand = ds.GetRasterBand(1);
                if (redBand.GetColorInterpretation() == ColorInterp.GCI_PaletteIndex)
                {
                    return getBitmapPaletteBuffered(ds);
                }
                if (redBand.GetColorInterpretation() == ColorInterp.GCI_GrayIndex)
                {
                    return getBitmapGrayBuffered(ds);
                }

                // RGB
                if (ds.RasterCount < 3)
                    return null;
                if (redBand.GetColorInterpretation() != ColorInterp.GCI_RedBand)
                    return null;
                Band greenBand = ds.GetRasterBand(2);
                if (greenBand.GetColorInterpretation() != ColorInterp.GCI_GreenBand)
                    return null;
                Band blueBand = ds.GetRasterBand(3);
                if (blueBand.GetColorInterpretation() != ColorInterp.GCI_BlueBand)
                    return null;

                return getBitmapRGBBandBuffered(ds);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                return null;
            }
        }


        private static Bitmap getBitmapRGBBandBuffered(Dataset ds)
        {
            Band redBand = ds.GetRasterBand(1);
            Band greenBand = ds.GetRasterBand(2);
            Band blueBand = ds.GetRasterBand(3);

            int width = redBand.XSize;
            int height = redBand.YSize;

            DateTime start = DateTime.Now;
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppRgb);

            byte[] r = new byte[width * height];
            byte[] g = new byte[width * height];
            byte[] b = new byte[width * height];

            redBand.ReadRaster(0, 0, width, height, r, width, height, 0, 0);
            greenBand.ReadRaster(0, 0, width, height, g, width, height, 0, 0);
            blueBand.ReadRaster(0, 0, width, height, b, width, height, 0, 0);

            int i, j;
            for (i = 0; i < width; i++)
            {
                for (j = 0; j < height; j++)
                {
                    // r g b
                    int rColor = Convert.ToInt32(r[i + j * width]);
                    int gColor = Convert.ToInt32(g[i + j * width]);
                    int bColor = Convert.ToInt32(b[i + j * width]);
                    Color newColor = Color.FromArgb(rColor, gColor, bColor);
                    bitmap.SetPixel(i, j, newColor);
                }
            }

            TimeSpan renderTime = DateTime.Now - start;
            double milliSeconds = renderTime.TotalMilliseconds; // ms

            //MessageBox.Show("GCI_RGB");
            return bitmap;
        }

        private static Bitmap getBitmapPaletteBuffered(Dataset ds)
        {

            Band band = ds.GetRasterBand(1);

            ColorTable ct = band.GetRasterColorTable();
            if (ct == null)
            {
                return null;
            }

            if (ct.GetPaletteInterpretation() != PaletteInterp.GPI_RGB)
            {
                //MessageBox.Show(" Only RGB palette interp is supported by this sample!");
                return null;
            }

            int width = band.XSize;
            int height = band.YSize;

            DateTime start = DateTime.Now;
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppRgb);

            byte[] r = new byte[width * height];

            band.ReadRaster(0, 0, width, height, r, width, height, 0, 0);

            int i, j;
            for (i = 0; i < width; i++)
            {
                for (j = 0; j < height; j++)
                {
                    // entry c1 c2 c3
                    ColorEntry entry = ct.GetColorEntry(r[i + j * width]);
                    int rColor = Convert.ToInt32(entry.c1);
                    int gColor = Convert.ToInt32(entry.c2);
                    int bColor = Convert.ToInt32(entry.c3);
                    Color newColor = Color.FromArgb(rColor, gColor, bColor);
                    bitmap.SetPixel(i, j, newColor);
                }
            }

            TimeSpan renderTime = DateTime.Now - start;
            double milliSeconds = renderTime.TotalMilliseconds; // ms

            //MessageBox.Show("GCI_PaletteIndex");
            return bitmap;
        }

        private static Bitmap getBitmapGrayBuffered(Dataset ds)
        {
            Band band = ds.GetRasterBand(1);

            int width = band.XSize;
            int height = band.YSize;

            DateTime start = DateTime.Now;
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppRgb);

            byte[] r = new byte[width * height];

            band.ReadRaster(0, 0, width, height, r, width, height, 0, 0);

            int i, j;
            for (i = 0; i < width; i++)
            {
                for (j = 0; j < height; j++)
                {
                    // r=g=b
                    int rColor = Convert.ToInt32(r[i + j * width]);
                    int gColor = Convert.ToInt32(r[i + j * width]);
                    int bColor = Convert.ToInt32(r[i + j * width]);
                    Color newColor = Color.FromArgb(rColor, gColor, bColor);
                    bitmap.SetPixel(i, j, newColor);
                }
            }

            TimeSpan renderTime = DateTime.Now - start;
            double milliSeconds = renderTime.TotalMilliseconds; // ms

            //MessageBox.Show("GCI_GrayIndex");
            return bitmap;
        }
    }
}