using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;// Graphics Rectangle
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using System.IO;// test
// postgresql
using Npgsql;
using OSGeo.OGR;
using OSGeo.GDAL;
using OSGeo.OSR;
// User defined Package
using MGP_BasicObject;
using MGP_Analysis;
using MGP_Display;
using MGP_DataStorage.MGP_DatabaseStorage;
using MGP_DataStorage.MGP_FileStorage;
using MGP_UI;
using MGP_UI.MGP_Dialog;
using MGP_UI.MGP_Menu;
using MGP_UI.MGP_Tool;
using System.Drawing.Drawing2D;

namespace MiniGIS
{
    public partial class MainForm : Form
    {
        #region initialize_and_erase
        private void Initialize()
        {
            this.KeyPreview = true;// left right up down key
            m_gMaps = new MG_MapSet(); // store all maps
            m_gConnStr = new MG_ConnectionString();// store conn string

            
        }

        private string getDataPath()
        { //  HOME\\xxx\\MiniGIS.exe   (xxx= bin/Release)
            //  HOME\\xxx\\data
            string releaseDir = AppDomain.CurrentDomain.BaseDirectory;
            string data = "data\\";
            string dataPath = releaseDir + data;
            return dataPath;
        }

        private void SetStyle()
        {
            // Set the value of the double-buffering style bits to true.
            this.SetStyle(ControlStyles.DoubleBuffer |
            ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint,
            true);

            this.UpdateStyles();
        }

        public MainForm()
        {
            InitializeComponent();

            // do initialize
            this.Initialize();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {// init --->resize--->load
            // max window
            this.WindowState = FormWindowState.Maximized;

            // initialize state
            this.setInitialState();

            //Rectangle rect1 = this.panel1.DisplayRectangle;
            //Rectangle rect2 = this.panel1.ClientRectangle;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.disConnect();
        }
        #endregion

        #region set_button_state


        // Button    ContextMenu   (Button2 --->depend on ContextMenu)
        // StatusBar

        private void setInitialButtonState()
        {
            // map_button (always true)
            this.ribbonButton_NewMap.Enabled = true;
            this.ribbonButton_OpenMap.Enabled = true;
            // tool_button
            this.ribbonButton_ConnectDB.Enabled = true;
            this.ribbonButton_DisConnectDB.Enabled = false;
            this.ribbonButton_ImportToDB.Enabled = false;
            this.ribbonButton_ExportToFile.Enabled = false;

            // draw_button--->depend on new layer / open map
            this.ribbonButton_Pointer.Enabled = false;
            this.ribbonButton_DrawPoint.Enabled = false;
            this.ribbonButton_DrawLineString.Enabled = false;
            this.ribbonButton_DrawDoubleLineString.Enabled = false;
            this.ribbonButton_DrawPolygon.Enabled = false;
            this.ribbonButton_DrawRectangle.Enabled = false;
        }

        private void setInitialMenuState()
        {
            // contextMenu_Map
            this.removeMap.Enabled = false;
            this.removeAllMap.Enabled = false;
            this.renameMap.Enabled = false;
            this.propetryMap.Enabled = false;
            this.saveMap.Enabled = false;// map_menu_to_button
            this.saveAsMap.Enabled = false;
            this.newLayer.Enabled = false;
            this.addShapeFile.Enabled = false;
            this.addPostGIS.Enabled = false;
            this.addRasterFile.Enabled = false;

            // contextMenu_Layer
            this.removeLayer.Enabled = false;
            this.removeAllLayer.Enabled = false;
            this.renameLayer.Enabled = false;
            this.saveLayer.Enabled = false;
            this.saveAsLayer.Enabled = false;
            this.newField.Enabled = false;
            this.viewFields.Enabled = false;
            this.toggleLayer.Enabled = false;
            this.zoomToLayer.Enabled = false;
            this.propetryLayer.Enabled = false;

            // contextMenu_MapView
            this.zoomIn.Enabled = false;
            this.zoomOut.Enabled = false;
            this.pan.Enabled = false;
            this.fullExtent.Enabled = false;
            this.firstExtent.Enabled = false;
            this.previousExtent.Enabled = false;
            this.nextExtent.Enabled = false;
            this.lastExtent.Enabled = false;

            // last to do is set button state by menu state
            this.setButton2State_ByMenu();
        }

        private void setButton2State_ByMenu()
        {// button2 state ---> menu state
            // set button by context menu
            this.ribbonButton_SaveMap.Enabled = this.saveMap.Enabled;
            this.ribbonButton_NewLayer.Enabled = this.newLayer.Enabled;
            this.ribbonButton_AddShapeFileLayer.Enabled = this.addShapeFile.Enabled;
            // layer--->depend on connect & new map
            this.ribbonButton_AddPostGISLayer.Enabled = this.addPostGIS.Enabled;
            this.ribbonButton_AddRasterFileLayer.Enabled = this.addRasterFile.Enabled;

            // set button by context menu
            this.ribbonButton_ZoomIn.Enabled = this.zoomIn.Enabled;
            this.ribbonButton_ZoomOut.Enabled = this.zoomOut.Enabled;
            this.ribbonButton_Pan.Enabled = this.pan.Enabled;
            this.ribbonButton_FullExtent.Enabled = this.fullExtent.Enabled;
            this.ribbonButton_FirstExtent.Enabled = this.firstExtent.Enabled;
            this.ribbonButton_PreviousExtent.Enabled = this.previousExtent.Enabled;
            this.ribbonButton_NextExtent.Enabled = this.nextExtent.Enabled;
            this.ribbonButton_LastExtent.Enabled = this.lastExtent.Enabled;
        }

        private void setInitialStatusBar()
        {
            this.statusLabel_Zoom.Text = "Welcome to MiniGIS.";
            this.statusLabel_Scale.Text = "";
            this.statusLabel_ScreenPoint.Text = "";
            this.statusLabel_MapPoint.Text = "";
            this.statusLabel_Extent.Text = "";
        }

        private void setInitialState()
        {
            this.setInitialButtonState();
            this.setInitialMenuState();
            this.setInitialStatusBar();
        }

        private void setButtonState()
        {
            // map_button (always true)
            this.ribbonButton_NewMap.Enabled = true;
            this.ribbonButton_OpenMap.Enabled = true;

            // tool_button (connect disconnect importtodb exporttofile)
            this.set4ToolButtonState();

            // draw_button(pointer point linestring polygon rectangle)
            this.set4DrawButtonEnableState();
            this.set4DrawButtonCheckState();
        }

        private void setMenuState()
        {
            //ACTION: new map/ open map / remove map/remove all map
            MG_Map selectedMap = this.getSelectedMap();
            bool mapEnabled = (selectedMap != null);
            // contextMenu_Map
            this.removeMap.Enabled = mapEnabled;
            this.removeAllMap.Enabled = mapEnabled;
            this.renameMap.Enabled = mapEnabled;
            this.propetryMap.Enabled = mapEnabled;
            this.saveMap.Enabled = (selectedMap != null) && (selectedMap.HasFeature());
            this.saveAsMap.Enabled = (selectedMap != null) && (selectedMap.HasFeature());
            this.newLayer.Enabled = mapEnabled;
            this.addShapeFile.Enabled = mapEnabled;
            this.addPostGIS.Enabled = (m_bConnected && mapEnabled);
            this.addRasterFile.Enabled = mapEnabled;

            //ACTION: new layer/add layer /remove layer /remove all layer
            MG_Layer layer = this.getSelectedLayer();
            bool layerEnabled = (layer != null);
            // contextMenu_Layer
            this.removeLayer.Enabled = layerEnabled;
            this.removeAllLayer.Enabled = layerEnabled;
            this.renameLayer.Enabled = layerEnabled;
            this.saveLayer.Enabled = (layer != null) && (layer.HasFeature());
            this.saveAsLayer.Enabled = (layer != null) && (layer.HasFeature());
            this.newField.Enabled = layerEnabled;
            this.viewFields.Enabled = layerEnabled;
            this.toggleLayer.Enabled = layerEnabled;
            this.zoomToLayer.Enabled = layerEnabled;
            this.propetryLayer.Enabled = layerEnabled;

            // map
            bool viewEnabled = (selectedMap != null) && (!selectedMap.GetMapExtent().Empty());
            // contextMenu_MapView
            this.zoomIn.Enabled = viewEnabled;
            this.zoomOut.Enabled = viewEnabled;
            this.pan.Enabled = viewEnabled;
            this.fullExtent.Enabled = viewEnabled;
            // first previous next last
            this.set4ExtentMenuState();

            // last to do is set button state by menu state
            this.setButton2State_ByMenu();
        }

        private void setStatusBar()
        {
            // zoom
            MG_Map map = this.getSelectedMap();
            if (map != null)
            {
                string zoom = String.Format("Zoom/Count: {0}/{1}", map.CurrentZoomIndex + 1, map.GetZoomHistory().Count());
                this.statusLabel_Zoom.Text = zoom;
            }
            else
            {
                this.statusLabel_Zoom.Text = "Welcome to MiniGIS.";
            }

            // scale
            if (map != null)
            {
                MG_MapView mapview = map.GetMapView();
                if (mapview != null)
                {
                    string scale = String.Format("Scale:{0}", mapview.GetScale());
                    this.statusLabel_Scale.Text = scale;
                }
            }
            else
            {
                this.statusLabel_Scale.Text = "";
            }

            // screen point
            if (this.m_gScreenPoint != null)
            {
                string sp = String.Format("Screen({0},{1})", this.m_gScreenPoint.X, this.m_gScreenPoint.Y);
                this.statusLabel_ScreenPoint.Text = sp;
            }
            else
            {
                this.statusLabel_ScreenPoint.Text = "";
            }

            // map point
            if (this.m_gMapPoint != null)
            {
                string mp = String.Format("Map({0},{1})", this.m_gMapPoint.x, this.m_gMapPoint.y);
                this.statusLabel_MapPoint.Text = mp;
            }
            else
            {
                this.statusLabel_MapPoint.Text = "";
            }

            // extent
            if (map != null)
            {
                MG_MapExtent mapExt = map.GetMapExtent();
                string extent = String.Format("MapExtent: {0} {1} {2} {3}", mapExt.MinX, mapExt.MinY, mapExt.MaxX, mapExt.MaxY);
                this.statusLabel_Extent.Text = extent;
            }
            else
            {
                this.statusLabel_Extent.Text = "";
            }
        }

        private void setState()
        {
            this.setButtonState();
            this.setMenuState();
            this.setStatusBar();
        }

        #endregion

        #region test


        //private void testSQL()
        //{
        //    MG_CommonDbOper test = new MG_CommonDbOper();
        //    string table = "line";

        //    MG_FieldSet fieldSet = new MG_FieldSet();
        //    fieldSet.SetName(table);

        //    MG_Field field = new MG_Field("name", MG_FieldDBType.VARCHAR);
        //    fieldSet.Add(field);
        //    field = new MG_Field("no", MG_FieldDBType.INTEGER);
        //    fieldSet.Add(field);
        //    field = new MG_Field("length", MG_FieldDBType.FLOAT8);
        //    fieldSet.Add(field);


        //    test.CreateTable(fieldSet, MG_GeometryType.LINESTRING);

        //    ArrayList columns = test.GetColumnNames(table);
        //    test.DropTable(table);

        //    test.CreateTable(fieldSet, MG_GeometryType.LINESTRING);// table exist
        //    test.DropTable("ke"); // table does not exist

        //    NpgsqlDataReader reader;
        //    reader = test.SelectAll("point");
        //    test.testDataReader(reader);
        //    reader = test.SelectByOid("point", 110);
        //    test.testDataReader(reader);
        //    reader = test.SelectByName("point", "POINT1");
        //    test.testDataReader(reader);

        //    int count = test.Count("point");
        //    test.Delete("point", 110);

        //    test.UpdateTable_SelectAll("point", this.dataGridView1, out da, out ds);
        //    //test.UpdateTable_SelectByOid("point", 109, this.dataGridView1, out da, out ds);
        //    //test.UpdateTable_SelectByName("point", "POINT1", this.dataGridView1, out da, out ds);

        //    test.UpdateGeom("point", 120, "POINT (9 9)");
        //    test.UpdateString("point", 120, "name", "HELLOWORLD!");
        //    test.UpdateNumber("point", 120, "cityno", 110);
        //    test.UpdateNumber("point", 120, "kkk", 3.14); // kkk not exist

        //    test.AddColumn("point", "c1", "varchar");
        //    test.RenameColumn("point", "c1", "c2");
        //    test.DropColumn("point", "c2");

        //    test.RenameTable("point", "point2");
        //    test.RenameTable("point2", "point");
        //    test.RenameTable("point", "linestring"); // linestring exist
        //    test.RenameTable("KKK", "linestring"); // KKK not exist

        //    // oid name geom cityno length
        //    // name cityno length
        //    MG_ValueSet valueSet = new MG_ValueSet();
        //    MG_Value value = new MG_Value(0, "MINIGIS");
        //    valueSet.Add(value);
        //    value = new MG_Value(1, 112);
        //    valueSet.Add(value);
        //    value = new MG_Value(2, 112.888);
        //    valueSet.Add(value);

        //    MG_Geometry g = new MG_Point(188, 288);
        //    test.Insert("point", valueSet, g);

        //    test.InsertNameGeom("point", "WWW.BAIDU.COM", g.AsWKT());

        //    ArrayList tables = test.GetTableNames();
        //    string geomtype = test.GetGeomType("point");

        private void testPath()
        {
            string path = @"F:\MiniKe\MiniGIS\code\MiniGIS_V2.2.6\MiniGIS\bin\Release\MiniGIS.exe";

            string extension = Path.GetExtension(path);
            string filename = Path.GetFileName(path);
            string filenameNoExtension = Path.GetFileNameWithoutExtension(path);
            string root = Path.GetPathRoot(path);
            string directory = Path.GetDirectoryName(path);

            string startupDir = Application.StartupPath;
            string releaseDir = AppDomain.CurrentDomain.BaseDirectory;
            string exePath = Application.ExecutablePath;
        }

        //    ArrayList columntypes = test.GetColumnTypes("point");

        private void testAsGeometry()
        {
            Geometry g = Geometry.CreateFromWkt("POINT (100 200)");
            MG_Geometry mg = MG_ShapeFileOper.AsGeometry(g);
            string wkt = mg.AsWKT();

            g = Geometry.CreateFromWkt("MULTIPOINT (10 20, 30 40, 50 60)");
            mg = MG_ShapeFileOper.AsGeometry(g);
            wkt = mg.AsWKT();

            g = Geometry.CreateFromWkt("LINESTRING (10 20, 30 40, 50 60)");
            mg = MG_ShapeFileOper.AsGeometry(g);
            wkt = mg.AsWKT();

            g = Geometry.CreateFromWkt("MULTILINESTRING ((10 10, 20 20, 10 40), (40 40, 30 30, 40 20, 30 10), (40 40, 30 30, 40 20, 30 10))");
            mg = MG_ShapeFileOper.AsGeometry(g);
            wkt = mg.AsWKT();

            g = Geometry.CreateFromWkt("POLYGON ((10 10, 20 20, 10 40), (40 40, 30 30, 40 20, 30 10), (40 40, 30 30, 40 20, 30 10))");
            mg = MG_ShapeFileOper.AsGeometry(g);
            wkt = mg.AsWKT();

            g = Geometry.CreateFromWkt("MULTIPOLYGON (((10 10, 20 20, 10 40), (40 40, 30 30, 40 20, 30 10), (40 40, 30 30, 40 20, 30 10)))");
            mg = MG_ShapeFileOper.AsGeometry(g);
            wkt = mg.AsWKT();
        }
        private void testGeometry()
        {
            MG_Point p = new MG_Point(100, 200);
            string type = p.Type.ToString();
            string wkt = p.AsWKT();
            string wkt_reduced = p.AsWKT_Reduced();
            byte[] wkb = p.AsWKB();

            MG_MultiPoint mp = new MG_MultiPoint();
            for (int i = 0; i < 10; i++)
            {
                MG_Point pp = new MG_Point(i, i);
                mp.Add(pp);
            }
            type = mp.Type.ToString();
            wkt = mp.AsWKT();
            wkt_reduced = mp.AsWKT_Reduced();
            wkb = mp.AsWKB();

            MG_LineString l = new MG_LineString();
            for (int i = 0; i < 10; i++)
            {
                MG_Point pp = new MG_Point(i, i);
                l.Add(pp);
            }
            type = l.Type.ToString();
            wkt = l.AsWKT();
            wkt_reduced = l.AsWKT_Reduced();
            wkb = l.AsWKB();

            MG_MultiLineString ml = new MG_MultiLineString();
            for (int i = 0; i < 5; i++)
            {
                MG_LineString l2 = new MG_LineString();
                for (int j = 0; j < 3; j++)
                {
                    MG_Point pp = new MG_Point(i, j);
                    l2.Add(pp);
                }
                ml.Add(l2);
            }
            type = ml.Type.ToString();
            wkt = ml.AsWKT();
            wkt_reduced = ml.AsWKT_Reduced();
            wkb = ml.AsWKB();

            MG_Polygon pg = new MG_Polygon();
            for (int i = 0; i < 5; i++)
            {
                MG_LineString l2 = new MG_LineString();
                for (int j = 0; j < 3; j++)
                {
                    MG_Point pp = new MG_Point(i, j);
                    l2.Add(pp);
                }
                pg.Add(l2);
            }
            type = pg.Type.ToString();
            wkt = pg.AsWKT();
            wkt_reduced = pg.AsWKT_Reduced();
            wkb = pg.AsWKB();

        }

        void drawGraphics(PaintEventArgs e)
        {
            // references to object we will use
            Graphics graphicsObject = e.Graphics;

            // ellipse rectangle and gradient brush
            Rectangle drawArea1 = new Rectangle(5, 35, 30, 100);
            LinearGradientBrush linearBrush =
               new LinearGradientBrush(drawArea1, Color.Blue,
                  Color.Yellow, LinearGradientMode.ForwardDiagonal);

            // draw ellipse filled with a blue-yellow gradient
            graphicsObject.FillEllipse(linearBrush, 5, 30, 65, 100);

            // pen and location for red outline rectangle
            Pen thickRedPen = new Pen(Color.Red, 10);
            Rectangle drawArea2 = new Rectangle(80, 30, 65, 100);

            // draw thick rectangle outline in red
            graphicsObject.DrawRectangle(thickRedPen, drawArea2);

            // bitmap texture
            Bitmap textureBitmap = new Bitmap(10, 10);

            // get bitmap graphics
            Graphics graphicsObject2 =
               Graphics.FromImage(textureBitmap);

            // brush and pen used throughout program
            SolidBrush solidColorBrush =
               new SolidBrush(Color.Red);
            Pen coloredPen = new Pen(solidColorBrush);

            // fill textureBitmap with yellow
            solidColorBrush.Color = Color.Yellow;
            graphicsObject2.FillRectangle(solidColorBrush, 0, 0, 10, 10);

            // draw small black rectangle in textureBitmap
            coloredPen.Color = Color.Black;
            graphicsObject2.DrawRectangle(coloredPen, 1, 1, 6, 6);

            // draw small blue rectangle in textureBitmap 
            solidColorBrush.Color = Color.Blue;
            graphicsObject2.FillRectangle(solidColorBrush, 1, 1, 3, 3);

            // draw small red square in textureBitmap
            solidColorBrush.Color = Color.Red;
            graphicsObject2.FillRectangle(solidColorBrush, 4, 4, 3, 3);

            // create textured brush and 
            // display textured rectangle
            TextureBrush texturedBrush =
               new TextureBrush(textureBitmap);
            graphicsObject.FillRectangle(texturedBrush, 155, 30, 75, 100);

            // draw pie-shaped arc in white
            coloredPen.Color = Color.White;
            coloredPen.Width = 6;
            graphicsObject.DrawPie(coloredPen, 240, 30, 75, 100, 0, 270);

            // draw lines in green and yellow
            coloredPen.Color = Color.Green;
            coloredPen.Width = 5;
            graphicsObject.DrawLine(coloredPen, 395, 30, 320, 150);

            // draw a rounded, dashed yellow line
            coloredPen.Color = Color.Yellow;
            coloredPen.DashCap = DashCap.Round;
            coloredPen.DashStyle = DashStyle.Dash;
            graphicsObject.DrawLine(coloredPen, 320, 30, 395, 150);
        }

        private void drawBitmap(Graphics g, string filepath)
        {
            Bitmap bitmap = new Bitmap(filepath);
            g.DrawImage(bitmap, Point.Empty);
            //bitmap.Save(filepath);
        }

        private void draw(Graphics g)
        {
            Rectangle r = new Rectangle(50, 50, 100, 100);
            g.DrawEllipse(Pens.Black, r);
            g.DrawRectangle(Pens.Red, r);
        }
        #endregion

        #region map

        private MG_MapSet m_gMaps;
        //private MG_MapView m_gMapView;

        private void updateMapView()
        {// !mapExtent.Empty
            // open map/new layer/add shapefile/add postgis
            // resize 
            // fullextent

            MG_Map map = this.getSelectedMap();
            if (map == null || map.GetMapExtent().Empty())
            {
                return;
            }

            // init m_gMapView
            if (map.GetMapView() == null)
            {
                map.InitMapView(this.panel1.ClientRectangle, map.GetMapExtent());
                // add to zoom history 
                map.AddZoomToHistory(map.GetMapView());
            }

        }

        private void ribbonButton_NewMap_Click(object sender, EventArgs e)
        {
            // new map
            MG_Map map = new MG_Map();

            // get map name
            MG_DlgNewMap dlg = new MG_DlgNewMap();
            dlg.InitializeMapName(map.GetMapName());
            dlg.ShowDialog();
            map.SetMapName(dlg.GetMapName());

            // save map to list
            this.m_gMaps.Add(map);

            TreeNode mapNode = new TreeNode();
            mapNode.Text = map.GetMapName();
            mapNode.Checked = false;
            this.treeViewContent.Nodes.Add(mapNode);
            // set selectedNode 
            this.m_gSelectedNode = mapNode;
            this.treeViewContent.SelectedNode = this.m_gSelectedNode;

            this.Refresh();
            // set state
            this.setState();
        }

        private void ribbonButton_OpenMap_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = this.getDataPath() + "map\\";
            openFileDialog1.Filter = "User Defined Map Files|*.map";
            openFileDialog1.Title = "Select map";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string openPath = openFileDialog1.FileName;
                MG_Map map = MG_ShapeFileOper.LoadMap(openPath);

                // save map to list
                this.m_gMaps.Add(map);

                // add map node
                TreeNode mapNode = new TreeNode();
                mapNode.Text = map.GetMapName();
                mapNode.Checked = false;
                this.treeViewContent.Nodes.Add(mapNode);

                // add layer node to map node
                for (int i = 0; i < map.GetLayerCount(); i++)
                {
                    TreeNode layerNode = new TreeNode();
                    layerNode.Text = map.GetLayer(i).GetLayerName();
                    layerNode.Checked = true;
                    mapNode.Nodes.Add(layerNode);
                }
                mapNode.ExpandAll();
                // set selectedNode 
                this.m_gSelectedNode = mapNode;
                this.treeViewContent.SelectedNode = this.m_gSelectedNode;

                // update m_gMapView
                this.updateMapView();

                this.Refresh();
            }

            // set state
            this.setState();
        }

        private void ribbonButton_SaveMap_Click(object sender, EventArgs e)
        {
            this.saveMap_Click(sender, e);
        }
        #endregion

        #region layer

        private void ribbonButton_NewLayer_Click(object sender, EventArgs e)
        {
            this.newLayer_Click(sender, e);
        }

        private void ribbonButton_AddShapeFileLayer_Click(object sender, EventArgs e)
        {
            this.addShapeFile_Click(sender, e);
        }

        private void ribbonButton_AddRasterFileLayer_Click(object sender, EventArgs e)
        {
            this.addRasterFile_Click(sender, e);
        }
        #endregion

        #region connect

        private MG_ConnectionString m_gConnStr;
        private NpgsqlConnection m_gConn;
        private MG_PostgreSQLDbOper m_pgOper;
        private bool m_bConnected = false;
        private void connection(string connstr)
        {
            m_gConn = new NpgsqlConnection(connstr);
            try
            {
                m_gConn.Open();// open the connection
                m_pgOper = new MG_PostgreSQLDbOper(m_gConn);
                MessageBox.Show("Connect to database successfully!");
                m_bConnected = true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void disConnect()
        {
            try
            {
                if (m_gConn != null && m_gConn.State == ConnectionState.Open)
                {
                    m_gConn.Close();
                    MessageBox.Show("Disconnect to database successfully!");
                    m_bConnected = false;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void set4ToolButtonState()
        {
            if (m_bConnected)
            {
                this.ribbonButton_ConnectDB.Enabled = false;
                this.ribbonButton_DisConnectDB.Enabled = true;

                this.ribbonButton_ExportToFile.Enabled = true;
                this.ribbonButton_ImportToDB.Enabled = true;
            }
            else
            {
                this.ribbonButton_ConnectDB.Enabled = true;
                this.ribbonButton_DisConnectDB.Enabled = false;

                this.ribbonButton_ExportToFile.Enabled = false;
                this.ribbonButton_ImportToDB.Enabled = false;
            }
        }

        private void ribbonButton_ConnectDB_Click(object sender, EventArgs e)
        {
            // set conn string
            MG_DlgSetConnectionString dlg = new MG_DlgSetConnectionString();
            dlg.InitalizeConnString(m_gConnStr);
            dlg.ShowDialog();
            m_gConnStr = dlg.GetConnString();

            // connect to database
            this.connection(m_gConnStr.ToString());

            // set state
            this.setState();
        }

        private void ribbonButton_DisConnectDB_Click(object sender, EventArgs e)
        {
            // disconnect to database
            this.disConnect();

            // set state
            this.setState();
        }

        private void ribbonButton_AddPostGISLayer_Click(object sender, EventArgs e)
        {
            this.addPostGIS_Click(sender, e);
        }

        private void ribbonButton_ImportToDB_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = this.getDataPath();
            openFileDialog1.Filter = "ArcGIS Shape Files|*.shp";
            openFileDialog1.Title = "Select a Shape File";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                m_pgOper.ImportToDB(filePath);
                MessageBox.Show("Import to DB successfully!");
            }

            // set state
            this.setState();
        }

        private void ribbonButton_ExportToFile_Click(object sender, EventArgs e)
        {
            ArrayList tables = m_pgOper.GetTableNames();
            MG_DlgListTableNames dlg = new MG_DlgListTableNames();
            dlg.InitializeTableNames(tables);
            dlg.ShowDialog();
            string selectedTable = dlg.GetSelectedTableName();
            if (selectedTable != null)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = this.getDataPath();
                saveFileDialog1.Filter = "ArcGIS Shape Files|*.shp";
                saveFileDialog1.Title = "Input file name";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string savePath = saveFileDialog1.FileName;
                    m_pgOper.ExportToFile(selectedTable, savePath);
                    MessageBox.Show("Import to DB successfully!");
                }
            }

            // set state
            this.setState();
        }
        #endregion

        #region panel

        #region draw_on_panel

        private Bitmap bmp;
        private void drawRaster_OnBitmap_ToScreen(Graphics g)
        {
            if (bmp != null)
            {
                g.DrawImage(bmp, this.panel1.ClientRectangle); // NOT Point.Empty 
            }
        }

        private void drawMap_OnBitmap_ToScreen2(Graphics g)
        {// g must be  PaintEventArgs e.Graphics |  this.panel1.CreateGraphics
            if (this.getSelectedMap() != null && this.getSelectedMap().GetLayerCount() > 0)
            {
                MG_MapRender.RenderMap(this.getSelectedMap(), this.getSelectedMap().GetMapView(), BufferGraphics);// draw on bitmap BackBuffer
                //g.DrawImageUnscaled(BackBuffer, Point.Empty); // draw bitmap to screen
                g.DrawImage(BackBuffer, this.panel1.ClientRectangle); // draw bitmap to screen
                //g.DrawImage(BackBuffer, Point.Empty); // draw bitmap to screen
            }
        }

        private void drawMap_OnBitmap_ToScreen(Graphics g)
        {// g must be  PaintEventArgs e.Graphics |  this.panel1.CreateGraphics
            if (this.getSelectedMap() != null && this.getSelectedMap().GetLayerCount() > 0)
            {
                MG_MapRender.RenderMap(this.getSelectedMap(), this.getSelectedMap().GetMapView(), g);// draw on bitmap BackBuffer
                //g.DrawImageUnscaled(BackBuffer, Point.Empty); // draw bitmap to screen
                //g.DrawImage(BackBuffer, this.panel1.ClientRectangle); // draw bitmap to screen
                //g.DrawImage(BackBuffer, Point.Empty); // draw bitmap to screen
            }
        }
        #endregion



        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // all data is stored in map, so just need to draw map.
            e.Graphics.Clear(this.panel1.BackColor);// must be here 
            // all user defined drawing
            this.drawRaster_OnBitmap_ToScreen(e.Graphics); //this.panel1.CreateGraphics()
            this.drawMap_OnBitmap_ToScreen(e.Graphics); //this.panel1.CreateGraphics()
        }

        private Bitmap BackBuffer;
        private Graphics BufferGraphics;
        private void panel1_Resize(object sender, EventArgs e)
        {
            // init buffer
            if (this.panel1.Width > 0 && this.panel1.Height > 0)
            {
                BackBuffer = new Bitmap(this.panel1.Width, this.panel1.Height);
                BufferGraphics = Graphics.FromImage(BackBuffer);
            }

            // update m_gMapView
            this.updateMapView();

            this.Refresh();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.m_gBaseTool != null)
            {
                this.m_gBaseTool.MouseDown(sender, e);
            }
        }

        private Point m_gScreenPoint;
        private MG_Point m_gMapPoint;

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.m_gBaseTool != null)
            {
                this.m_gBaseTool.MouseMove(sender, e);
            }

            // screen and map point
            this.m_gScreenPoint = new Point(e.X, e.Y);
            MG_Map map = this.getSelectedMap();
            if (map != null && map.GetMapView() != null)
            {
                this.m_gMapPoint = map.GetMapView().Screent2Map(this.m_gScreenPoint);
            }
            else
            {
                this.m_gMapPoint = null;
            }

            // set status bar
            this.setStatusBar();
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.m_gBaseTool != null)
            {
                this.m_gBaseTool.MouseUp(sender, e);
            }

            // pop up menu for m_gMapView 
            if (this.m_gBaseTool != null &&
                this.m_gBaseTool.GetToolType() == MG_ToolType.Tool_None &&
                e.Button == MouseButtons.Right)
            {
                if (this.getSelectedMap() != null && this.getSelectedMap().GetLayerCount() > 0)
                {
                    Panel panel = (Panel)sender;
                    Point pos = panel.PointToScreen(new Point(e.X, e.Y));
                    this.contextMenu_MapView.Show(pos);
                }
            }
        }
        #endregion

        #region draw


        private MG_BaseTool m_gBaseTool;

        private void set4DrawButtonEnableState()
        {
            MG_Layer layer = this.getSelectedLayer();
            if (layer == null)
            {
                // draw_button
                this.ribbonButton_Pointer.Enabled = false;
                this.ribbonButton_DrawPoint.Enabled = false;
                this.ribbonButton_DrawLineString.Enabled = false;
                this.ribbonButton_DrawDoubleLineString.Enabled = false;
                this.ribbonButton_DrawPolygon.Enabled = false;
                this.ribbonButton_DrawRectangle.Enabled = false;
                return;
            }

            switch (layer.GetLayerType())
            {
                case MG_GeometryType.POINT:
                    this.ribbonButton_Pointer.Enabled = true;
                    this.ribbonButton_DrawPoint.Enabled = true;
                    this.ribbonButton_DrawLineString.Enabled = false;
                    this.ribbonButton_DrawDoubleLineString.Enabled = false;
                    this.ribbonButton_DrawPolygon.Enabled = false;
                    this.ribbonButton_DrawRectangle.Enabled = false;
                    break;
                case MG_GeometryType.LINESTRING:
                    this.ribbonButton_Pointer.Enabled = true;
                    this.ribbonButton_DrawPoint.Enabled = false;
                    this.ribbonButton_DrawLineString.Enabled = true;
                    this.ribbonButton_DrawDoubleLineString.Enabled = true;
                    this.ribbonButton_DrawPolygon.Enabled = false;
                    this.ribbonButton_DrawRectangle.Enabled = false;
                    break;
                case MG_GeometryType.POLYGON:
                    this.ribbonButton_Pointer.Enabled = true;
                    this.ribbonButton_DrawPoint.Enabled = false;
                    this.ribbonButton_DrawLineString.Enabled = false;
                    this.ribbonButton_DrawDoubleLineString.Enabled = false;
                    this.ribbonButton_DrawPolygon.Enabled = true;
                    this.ribbonButton_DrawRectangle.Enabled = true;
                    break;
                default:
                    this.ribbonButton_Pointer.Enabled = false;
                    this.ribbonButton_DrawPoint.Enabled = false;
                    this.ribbonButton_DrawLineString.Enabled = false;
                    this.ribbonButton_DrawDoubleLineString.Enabled = false;
                    this.ribbonButton_DrawPolygon.Enabled = false;
                    this.ribbonButton_DrawRectangle.Enabled = false;
                    break;
            }
        }

        private void set4DrawButtonCheckState()
        {
            if (this.m_gBaseTool == null)
                return;

            MG_ToolType type = this.m_gBaseTool.GetToolType();
            switch (type)
            {
                case MG_ToolType.Tool_None:
                    this.ribbonButton_DrawPoint.Checked = false;
                    this.ribbonButton_DrawLineString.Checked = false;
                    this.ribbonButton_DrawDoubleLineString.Checked = false;
                    this.ribbonButton_DrawPolygon.Checked = false;
                    this.ribbonButton_DrawRectangle.Checked = false;
                    break;
                case MG_ToolType.Tool_DrawPoint:
                    this.ribbonButton_DrawPoint.Checked = true;
                    this.ribbonButton_DrawLineString.Checked = false;
                    this.ribbonButton_DrawDoubleLineString.Checked = false;
                    this.ribbonButton_DrawPolygon.Checked = false;
                    this.ribbonButton_DrawRectangle.Checked = false;
                    break;
                case MG_ToolType.Tool_DrawLineString:
                    this.ribbonButton_DrawPoint.Checked = false;
                    this.ribbonButton_DrawLineString.Checked = true;
                    this.ribbonButton_DrawDoubleLineString.Checked = false;
                    this.ribbonButton_DrawPolygon.Checked = false;
                    this.ribbonButton_DrawRectangle.Checked = false;
                    break;
                case MG_ToolType.Tool_DrawDoubleLineString:
                    this.ribbonButton_DrawPoint.Checked = false;
                    this.ribbonButton_DrawLineString.Checked = false;
                    this.ribbonButton_DrawDoubleLineString.Checked = true;
                    this.ribbonButton_DrawPolygon.Checked = false;
                    this.ribbonButton_DrawRectangle.Checked = false;
                    break;
                case MG_ToolType.Tool_DrawPolygon:
                    this.ribbonButton_DrawPoint.Checked = false;
                    this.ribbonButton_DrawLineString.Checked = false;
                    this.ribbonButton_DrawDoubleLineString.Checked = false;
                    this.ribbonButton_DrawPolygon.Checked = true;
                    this.ribbonButton_DrawRectangle.Checked = false;
                    break;
                case MG_ToolType.Tool_DrawRectangle:
                    this.ribbonButton_DrawPoint.Checked = false;
                    this.ribbonButton_DrawLineString.Checked = false;
                    this.ribbonButton_DrawDoubleLineString.Checked = false;
                    this.ribbonButton_DrawPolygon.Checked = false;
                    this.ribbonButton_DrawRectangle.Checked = true;
                    break;
            }
        }

        private void ribbonButton_Pointer_Click(object sender, EventArgs e)
        {
            this.m_gBaseTool = new MG_BaseTool(MG_ToolType.Tool_None, this.getSelectedLayer(), this.getSelectedMap().GetMapView());
            //set state
            this.setState();
        }

        private void ribbonButton_DrawPoint_Click(object sender, EventArgs e)
        {
            this.m_gBaseTool = new MG_ToolDrawPoint(this.getSelectedLayer(), this.getSelectedMap().GetMapView());
            //set state
            this.setState();
        }

        private void ribbonButton_DrawLineString_Click(object sender, EventArgs e)
        {
            this.m_gBaseTool = new MG_ToolDrawLineString(this.getSelectedLayer(), this.getSelectedMap().GetMapView());
            //set state
            this.setState();
        }

        private void ribbonButton_DrawDoubleLineString_Click(object sender, EventArgs e)
        {
            this.m_gBaseTool = new MG_ToolDrawDoubleLineString(this.getSelectedLayer(), this.getSelectedMap().GetMapView());

            //set state
            this.setState();
        }

        private void ribbonButton_DrawPolygon_Click(object sender, EventArgs e)
        {
            this.m_gBaseTool = new MG_ToolDrawPolygon(this.getSelectedLayer(), this.getSelectedMap().GetMapView());
            //set state
            this.setState();
        }


        private void ribbonButton_DrawRectangle_Click(object sender, EventArgs e)
        {
            this.m_gBaseTool = new MG_ToolDrawRectangle(this.getSelectedLayer(), this.getSelectedMap().GetMapView());

            //set state
            this.setState();
        }
        #endregion

        #region treeViewContent

        private TreeNode m_gSelectedNode; // current selected node(map or layer)
        // mousedown/ new map/open map/remove(all) map/ new layer/add shapefile/add postgis/remove(all) layer
        private void treeViewContent_MouseDown(object sender, MouseEventArgs e)
        {// maintain selected node
            this.m_gSelectedNode = this.treeViewContent.GetNodeAt(e.X, e.Y);
            this.treeViewContent.SelectedNode = this.m_gSelectedNode;

            if (e.Button == MouseButtons.Right)
            {

            }
            else
            {
                //this.updateMapView();
                this.Refresh();
            }

            //set state
            this.setState();
        }

        private void treeViewContent_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (this.m_gSelectedNode.Level == 0) // map
            {

            }
            else if (this.m_gSelectedNode.Level == 1)// layer
            {
                int layerIndex = this.m_gSelectedNode.Index;

                if (this.m_gSelectedNode.Checked)
                {
                    if (layerIndex >= 0)
                    {
                        MG_Layer layer = this.getSelectedMap().GetLayer(layerIndex);
                        if (layer != null)
                        {
                            layer.SetVisible(true);
                            this.Refresh();
                        }
                    }
                }
                else
                {
                    if (layerIndex >= 0)
                    {
                        MG_Layer layer = this.getSelectedMap().GetLayer(layerIndex);
                        if (layer != null)
                        {
                            layer.SetVisible(false);
                            this.Refresh();
                        }
                    }
                }
            }

            //set state
            this.setState();
        }

        private void treeViewContent_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // pop up menu for map or layer 
            if (e.Button == MouseButtons.Right)
            {
                Point pos = this.treeViewContent.PointToScreen(new Point(e.X, e.Y));

                if (this.m_gSelectedNode.Level == 0) // map
                {
                    this.contextMenu_Map.Show(pos);

                }
                else if (this.m_gSelectedNode.Level == 1)// layer
                {
                    this.contextMenu_Layer.Show(pos);
                }
            }

            //set state
            this.setState();
        }

        private void treeViewContent_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label != null)
            {
                if (e.Label.Length > 0)
                {
                    if (e.Label.IndexOfAny(new char[] { '@', '.', ',', '!' }) == -1)
                    {
                        // Stop editing without canceling the label change.
                        e.Node.EndEdit(false);
                        this.treeViewContent.LabelEdit = false;
                        // Save label to map or layer
                        if (this.m_gSelectedNode.Level == 0)
                        {
                            this.getSelectedMap().SetMapName(e.Label);
                        }
                        else if (this.m_gSelectedNode.Level == 1)
                        {
                            this.getSelectedLayer().SetLayerName(e.Label);
                        }
                    }
                    else
                    {
                        /* Cancel the label edit action, inform the user, and 
                           place the node in edit mode again. */
                        e.CancelEdit = true;
                        MessageBox.Show("Invalid tree node label.\n" +
                           "The invalid characters are: '@','.', ',', '!'",
                           "Node Label Edit");
                        e.Node.BeginEdit();
                    }
                }
                else
                {
                    /* Cancel the label edit action, inform the user, and 
                       place the node in edit mode again. */
                    e.CancelEdit = true;
                    MessageBox.Show("Invalid tree node label.\nThe label cannot be blank",
                       "Node Label Edit");
                    e.Node.BeginEdit();
                }
            }
        }

        private void treeViewContent_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.treeViewContent.LabelEdit = true;
            if (!this.m_gSelectedNode.IsEditing)
            {
                this.m_gSelectedNode.BeginEdit();
                // treeViewContent_AfterLabelEdit
            }

            this.m_gSelectedNode.ExpandAll();
        }

        #endregion

        #region contextMenu_Map

        //private TreeNode m_gActivatedMapNode; // current activated map node
        private MG_Map getSelectedMap()
        {
            if (this.m_gSelectedNode == null)
                return null;
            if (this.m_gSelectedNode.Level == 1) // layer
            {
                int mapIndex = this.m_gSelectedNode.Parent.Index; // map index
                return this.m_gMaps.GetAt(mapIndex);
            }
            else
            {
                int mapIndex = this.m_gSelectedNode.Index; // map index
                return this.m_gMaps.GetAt(mapIndex);
            }
        }

        private void forceSelectedNodeToMap()
        {// new layer/add shapefile/add postgis
            if (this.m_gSelectedNode != null && this.m_gSelectedNode.Level == 1) // layer
            {
                this.m_gSelectedNode = this.m_gSelectedNode.Parent; // set to map node
            }
        }

        private void removeMap_Click(object sender, EventArgs e)
        {
            int mapIndex = this.m_gSelectedNode.Index; // map index

            this.m_gMaps.RemoveAt(mapIndex);
            this.treeViewContent.Nodes.RemoveAt(mapIndex);

            this.m_gSelectedNode = null;
            this.treeViewContent.SelectedNode = this.m_gSelectedNode;

            this.bmp = null;// NOTICE
            this.updateMapView();

            this.Refresh();
            // set state
            this.setState();
        }

        private void removeAllMap_Click(object sender, EventArgs e)
        {
            // remove all map node
            this.treeViewContent.Nodes.Clear();

            // remove all map
            this.m_gMaps.Clear();

            // set selected node 
            this.m_gSelectedNode = null;
            this.treeViewContent.SelectedNode = this.m_gSelectedNode;

            this.bmp = null;// NOTICE
            this.updateMapView();

            this.Refresh();

            // set state
            this.setState();
        }

        private void renameMap_Click(object sender, EventArgs e)
        {
            this.treeViewContent.LabelEdit = true;
            if (!this.m_gSelectedNode.IsEditing)
            {
                this.m_gSelectedNode.BeginEdit();
                // treeViewContent_AfterLabelEdit
            }

            // set state
            this.setState();
        }

        #region map_menu_to_button

        // since this menu is pop up , m_gSelectedNode !=null
        private void saveMap_Click(object sender, EventArgs e)
        {
            // get selected map first
            MG_Map map = this.getSelectedMap();
            if (map.GetMapPath() != null)
            {
                MG_ShapeFileOper.CreateMap(map, map.GetMapPath());
                return;
            }
            // the first time to save
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = this.getDataPath() + "map\\";
            saveFileDialog1.Filter = "User Defined Map Files|*.map";
            saveFileDialog1.Title = "Input map name";
            saveFileDialog1.FileName = map.GetMapName(); // init map name
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string savePath = saveFileDialog1.FileName;
                MG_ShapeFileOper.CreateMap(map, savePath);

                string str = String.Format("Successfully save map to {0}.", savePath);
                MessageBox.Show(str);
            }

            // set state
            this.setState();
        }

        private void saveAsMap_Click(object sender, EventArgs e)
        {
            // get selected map first
            MG_Map map = this.getSelectedMap();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = this.getDataPath() + "map\\";
            saveFileDialog1.Filter = "User Defined Map Files|*.map";
            saveFileDialog1.Title = "Input map name";
            saveFileDialog1.FileName = "copy_" + map.GetMapName(); // init map name
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string savePath = saveFileDialog1.FileName;
                MG_ShapeFileOper.CreateMap(map, savePath);

                string str = String.Format("Successfully save map to {0}.", savePath);
                MessageBox.Show(str);
            }

            // set state
            this.setState();
        }

        private void newLayer_Click(object sender, EventArgs e)
        {
            // get selected map first
            MG_Map map = this.getSelectedMap();

            // new layer
            MG_Layer layer = new MG_Layer();
            //set layer extent
            MG_MapExtent mapExt = map.GetMapExtent();
            if (mapExt.Empty())
            {
                layer.Extent = new MG_MapExtent(this.panel1.ClientRectangle);
            }
            else
            {
                layer.Extent = mapExt;
            }

            // get layer name AND type
            MG_DlgNewLayer dlg = new MG_DlgNewLayer();
            dlg.InitializeLayerName(layer.GetLayerName());
            dlg.InitializeLayerType(MG_GeometryType.LINESTRING);
            dlg.ShowDialog();
            layer.SetLayerName(dlg.GetLayerName());
            layer.SetLayerType(dlg.GetLayerType());

            // add layer to map
            map.AddLayer(layer);

            // update m_gMapView
            this.updateMapView();

            // add to treeview
            TreeNode layerNode = new TreeNode();
            layerNode.Text = layer.GetLayerName();
            layerNode.Checked = true;
            this.forceSelectedNodeToMap();
            this.m_gSelectedNode.Nodes.Add(layerNode);
            this.m_gSelectedNode.ExpandAll();

            // set selected node to layer node
            this.m_gSelectedNode = layerNode;
            this.treeViewContent.SelectedNode = this.m_gSelectedNode;

            this.Refresh();
            // set state
            this.setState();
        }

        private void addShapeFile_Click(object sender, EventArgs e)
        {
            // get selected map first
            MG_Map map = this.getSelectedMap();
            if (map == null)
                return;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = this.getDataPath();
            openFileDialog1.Filter = "ArcGIS Shape Files|*.shp";
            openFileDialog1.Title = "Select a Shape File";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                string fileName = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                MG_Layer layer = MG_ShapeFileOper.LoadShapeFile(filePath);
                map.AddLayer(layer);

                // update m_gMapView
                this.updateMapView();

                // add to treeview
                TreeNode layerNode = new TreeNode();
                layerNode.Text = layer.GetLayerName();
                layerNode.Checked = true;
                this.forceSelectedNodeToMap();
                this.m_gSelectedNode.Nodes.Add(layerNode);
                this.m_gSelectedNode.ExpandAll();
                // set selected node to layer node
                this.m_gSelectedNode = layerNode;
                this.treeViewContent.SelectedNode = this.m_gSelectedNode;
            }

            this.Refresh();
            // set state
            this.setState();
        }

        private void addPostGIS_Click(object sender, EventArgs e)
        {
            // get selected map first
            MG_Map map = this.getSelectedMap();
            ArrayList tables = m_pgOper.GetTableNames();
            MG_DlgListTableNames dlg = new MG_DlgListTableNames();
            dlg.InitializeTableNames(tables);
            dlg.ShowDialog();
            string selectedTable = dlg.GetSelectedTableName();
            if (selectedTable != null)
            {
                MG_Layer layer = new MG_Layer();
                layer = m_pgOper.ExportLayer(selectedTable);
                map.AddLayer(layer);

                // update m_gMapView
                this.updateMapView();

                // add to treeview
                TreeNode layerNode = new TreeNode();
                layerNode.Text = layer.GetLayerName();
                layerNode.Checked = true;
                this.forceSelectedNodeToMap();
                this.m_gSelectedNode.Nodes.Add(layerNode);
                this.m_gSelectedNode.ExpandAll();
                // set selected node to layer node
                this.m_gSelectedNode = layerNode;
                this.treeViewContent.SelectedNode = this.m_gSelectedNode;
            }

            this.Refresh();
            // set state
            this.setState();
        }

        private void addRasterFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = this.getDataPath();
            openFileDialog1.Filter = "PNG|*.png|Jpeg|*.jpg|BMP|*.bmp|Tiff|*.tif|All files (*.*)|*.*";
            openFileDialog1.Title = "Select a Raster File";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                string fileName = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                bmp = MG_RasterFileOper.LoadRasterFile(filePath);
            }

            this.Refresh();
            // set state
            this.setState();
        }
        #endregion

        private void propetryMap_Click(object sender, EventArgs e)
        {
            MG_Map map = this.getSelectedMap();

            MG_MapExtent mapExt = (map == null) ? new MG_MapExtent() : map.GetMapExtent();
            string extent = String.Format("MapExtent:\n[{0} {1}]\n[{2} {3}]\n", mapExt.MinX, mapExt.MinY, mapExt.MaxX, mapExt.MaxY);

            int count = map.GetLayerCount();
            string str = String.Format("{0} has total {1} layer(s)\n", map.GetMapName(), count);
            for (int i = 0; i < count; i++)
            {
                MG_Layer layer = map.GetLayer(i);
                str += String.Format("[{0}]{1} {2} {3} feature(s)\n", (i + 1), layer.GetLayerName(), layer.GetLayerType(), layer.GetFeatureCount());
            }
            MessageBox.Show(extent + str);

            // set state
            this.setState();
        }
        #endregion

        #region contextMenu_Layer

        //private TreeNode m_gActivatedLayerNode; // current activated layer node
        private MG_Layer getSelectedLayer()
        {
            if (this.m_gSelectedNode == null)
                return null;
            if (this.m_gSelectedNode.Level == 1)
            {
                int layerIndex = this.m_gSelectedNode.Index; // layer index
                int mapIndex = this.m_gSelectedNode.Parent.Index;// correspond map index
                MG_Layer layer = this.m_gMaps.GetAt(mapIndex).GetLayer(layerIndex);
                return layer;
            }
            else
            {
                return null;
            }
        }

        private void removeLayer_Click(object sender, EventArgs e)
        {
            int layerIndex = this.m_gSelectedNode.Index; // layer index

            // set selected node to map node
            this.m_gSelectedNode = this.m_gSelectedNode.Parent;
            this.treeViewContent.SelectedNode = this.m_gSelectedNode;

            int mapIndex = this.m_gSelectedNode.Index;// correspond map index
            this.m_gMaps.GetAt(mapIndex).RemoveLayer(layerIndex);
            if (this.m_gMaps.GetAt(mapIndex).GetLayerCount() < 1)
            {
                this.m_gMaps.GetAt(mapIndex).GetZoomHistory().Clear();
            }

            this.m_gSelectedNode.Nodes.RemoveAt(layerIndex);

            this.updateMapView();

            this.Refresh();
            // set state
            this.setState();
        }

        private void removeAllLayer_Click(object sender, EventArgs e)
        {
            // set selected node to map node
            this.m_gSelectedNode = this.m_gSelectedNode.Parent;
            this.treeViewContent.SelectedNode = this.m_gSelectedNode;

            // remove all layer node
            this.m_gSelectedNode.Nodes.Clear();

            // remove all layer
            int mapIndex = this.m_gSelectedNode.Index;// correspond map index
            this.m_gMaps.GetAt(mapIndex).Clear();

            this.updateMapView();

            this.Refresh();
            // set state
            this.setState();
        }

        private void renameLayer_Click(object sender, EventArgs e)
        {
            this.treeViewContent.LabelEdit = true;
            if (!this.m_gSelectedNode.IsEditing)
            {
                this.m_gSelectedNode.BeginEdit();
                // treeViewContent_AfterLabelEdit
            }

            // set state
            this.setState();
        }


        private void saveLayer_Click(object sender, EventArgs e)
        {
            MG_Layer layer = this.getSelectedLayer();
            if (layer.GetLayerPath() != null)
            {
                MG_ShapeFileOper.CreateShapeFile(layer, layer.GetLayerPath());
                return;
            }
            // the first time to save
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = this.getDataPath();
            saveFileDialog1.Filter = "ArcGIS Shape Files|*.shp";
            saveFileDialog1.Title = "Input layer name";
            saveFileDialog1.FileName = layer.GetLayerName(); // init layer name
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string savePath = saveFileDialog1.FileName;
                MG_ShapeFileOper.CreateShapeFile(layer, savePath);

                string str = String.Format("Successfully save {0} feature(s) to {1}!", layer.GetFeatureCount(), savePath);
                MessageBox.Show(str);
            }

            // set state
            this.setState();
        }

        private void saveAsLayer_Click(object sender, EventArgs e)
        {
            MG_Layer layer = this.getSelectedLayer();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = this.getDataPath();
            saveFileDialog1.Filter = "ArcGIS Shape Files|*.shp";
            saveFileDialog1.Title = "Input layer name";
            saveFileDialog1.FileName = "copy_" + layer.GetLayerName(); // init layer name
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string savePath = saveFileDialog1.FileName;
                MG_ShapeFileOper.CreateShapeFile(layer, savePath);

                string str = String.Format("Successfully save {0} feature(s) to {1}!", layer.GetFeatureCount(), savePath);
                MessageBox.Show(str);
            }

            // set state
            this.setState();
        }

        private void newField_Click(object sender, EventArgs e)
        {
            MG_Layer layer = this.getSelectedLayer();

            // new a field
            MG_Field field = new MG_Field();
            MG_DlgNewField dlg = new MG_DlgNewField();
            dlg.InitializeFieldName(field.Name);
            dlg.InitializeFieldTypes();
            dlg.ShowDialog();
            field.Name = dlg.GetFieldName();
            field.Type = dlg.GetFieldType();

            //add field to layer
            layer.AddField(field);

            // set state
            this.setState();
        }

        private void viewFields_Click(object sender, EventArgs e)
        {
            MG_Layer layer = this.getSelectedLayer();

            MG_MapExtent layerExt = (layer == null) ? new MG_MapExtent() : layer.Extent;
            string extent = String.Format("LayerExtent:\n[{0} {1}]\n[{2} {3}]\n", layerExt.MinX, layerExt.MinY, layerExt.MaxX, layerExt.MaxY);

            int count = layer.GetFieldSet().Count();
            string str = String.Format("{0} {1} has total {2} Field(s)\n", layer.GetLayerName(), layer.GetLayerType(), count);
            for (int i = 0; i < count; i++)
            {
                MG_Field field = layer.GetFieldSet().GetAt(i);
                str += String.Format("[{0}]{1}---{2}\n", (i + 1), field.Name, field.Type);
            }
            MessageBox.Show(extent + str);

            // set state
            this.setState();
        }

        private void toggleLayer_Click(object sender, EventArgs e)
        {
            this.m_gSelectedNode.Checked = !this.m_gSelectedNode.Checked;

            // set state
            this.setState();
        }

        private void zoomToLayer_Click(object sender, EventArgs e)
        {// fullextent /zoom to layer
            MG_MapView mapview = this.getSelectedMap().GetMapView();
            mapview.Update(this.panel1.ClientRectangle, this.getSelectedLayer().Extent);

            this.getSelectedMap().AddZoomToHistory(mapview);

            this.Refresh();
            // set state
            this.setState();
        }

        private void propetryLayer_Click(object sender, EventArgs e)
        {
            MG_Layer layer = this.getSelectedLayer();

            MG_DlgViewAttribute dlg = new MG_DlgViewAttribute();
            dlg.SetLayer(layer);
            dlg.ShowDialog();

            // set state
            this.setState();
        }
        #endregion

        #region contextMenu_MapView

        private static double SCALE_FACTOR = 1.2;
        private static int PAN_PIXEL = 5;

        private double panOffset()
        {
            MG_MapView mapview = this.getSelectedMap().GetMapView();
            return mapview.GetValue(PAN_PIXEL);
        }

        private void zoomIn_Click(object sender, EventArgs e)
        {
            MG_MapView mapview = this.getSelectedMap().GetMapView();
            mapview.Scalex(1 / SCALE_FACTOR);

            this.getSelectedMap().AddZoomToHistory(mapview);
            this.Refresh();

            // set state
            this.setState();
        }

        private void zoomOut_Click(object sender, EventArgs e)
        {
            MG_MapView mapview = this.getSelectedMap().GetMapView();
            mapview.Scalex(SCALE_FACTOR);
            this.getSelectedMap().AddZoomToHistory(mapview);
            this.Refresh();

            // set state
            this.setState();
        }

        private void pan_Click(object sender, EventArgs e)
        {
            this.m_gBaseTool = new MG_ToolPan(this.getSelectedMap(), this.getSelectedMap().GetMapView());
            //set state
            this.setState();
        }

        private void fullExtent_Click(object sender, EventArgs e)
        {// fullextent /zoom to layer
            MG_MapView mapview = this.getSelectedMap().GetMapView();
            mapview.Update(this.panel1.ClientRectangle, this.getSelectedMap().GetMapExtent());

            this.getSelectedMap().AddZoomToHistory(mapview);

            this.Refresh();
            // set state
            this.setState();
        }

        private void setMapView()
        {
            int zoomIndex = this.getSelectedMap().CurrentZoomIndex;
            MG_ZoomHistory zoomHistory = this.getSelectedMap().GetZoomHistory();
            if (zoomIndex >= 0 && zoomIndex < zoomHistory.Count())
            {
                MG_ZoomRecord zoom = zoomHistory.GetAt(zoomIndex);
                // set m_gMapView
                MG_MapView mapview = this.getSelectedMap().GetMapView();
                //mapview.Scale = zoom.scale;
                mapview.SetScale(zoom.scale);
                mapview.SetCenterX(zoom.centermapx);
                mapview.SetCenterY(zoom.centermapy);
                this.Refresh();
            }
            else if (zoomIndex < 0)
            {
                zoomIndex = 0;
            }
            else
            {
                zoomIndex = zoomHistory.Count() - 1;
            }
        }

        private void set4ExtentMenuState()
        {//  0<=index<count-1
            // m_gCurrentZoomIndex count
            MG_Map map = this.getSelectedMap();
            if (map == null)
            {
                this.firstExtent.Enabled = false;
                this.lastExtent.Enabled = false;
                this.previousExtent.Enabled = false;
                this.nextExtent.Enabled = false;
                return;
            }

            MG_ZoomHistory zoom = map.GetZoomHistory();
            int index = map.CurrentZoomIndex;
            int count = zoom.Count();

            if (count <= 1)
            {
                this.firstExtent.Enabled = false;
                this.lastExtent.Enabled = false;
                this.previousExtent.Enabled = false;
                this.nextExtent.Enabled = false;
            }
            else // >=2
            {
                if (index == 0)
                {
                    this.firstExtent.Enabled = false;
                    this.previousExtent.Enabled = false;

                    this.nextExtent.Enabled = true;
                    this.lastExtent.Enabled = true;
                }
                else if (index == count - 1)
                {
                    this.firstExtent.Enabled = true;
                    this.previousExtent.Enabled = true;

                    this.nextExtent.Enabled = false;
                    this.lastExtent.Enabled = false;
                }
                else
                {
                    this.firstExtent.Enabled = true;
                    this.previousExtent.Enabled = true;

                    this.nextExtent.Enabled = true;
                    this.lastExtent.Enabled = true;
                }
            }
        }

        private void previousExtent_Click(object sender, EventArgs e)
        {
            this.getSelectedMap().CurrentZoomIndex--;
            this.setMapView();

            // set state
            this.setState();
        }

        private void nextExtent_Click(object sender, EventArgs e)
        {
            this.getSelectedMap().CurrentZoomIndex++;
            this.setMapView();

            // set state
            this.setState();
        }

        private void firstExtent_Click(object sender, EventArgs e)
        {
            this.getSelectedMap().CurrentZoomIndex = 0;
            this.setMapView();

            // set state
            this.setState();
        }

        private void lastExtent_Click(object sender, EventArgs e)
        {
            this.getSelectedMap().CurrentZoomIndex = this.getSelectedMap().GetZoomHistory().Count() - 1; // at least >=0
            this.setMapView();

            // set state
            this.setState();
        }

        // override IsInputKey
        // form.KeyPreview = true;
        //protected override bool IsInputKey(System.Windows.Forms.Keys keyData)
        //{
        //    if (keyData == System.Windows.Forms.Keys.Left ||
        //        keyData == System.Windows.Forms.Keys.Right ||
        //        keyData == System.Windows.Forms.Keys.Up ||
        //        keyData == System.Windows.Forms.Keys.Down)
        //        return true;
        //    return base.IsInputKey(keyData);
        //}


        #region user_defined_click
        private void left_Click(object sender, KeyEventArgs e)
        {
            MG_MapView mapview = this.getSelectedMap().GetMapView();
            mapview.Xoff(panOffset());
            this.getSelectedMap().AddZoomToHistory(mapview);
            this.Refresh();
        }
        private void right_Click(object sender, KeyEventArgs e)
        {
            MG_MapView mapview = this.getSelectedMap().GetMapView();
            mapview.Xoff(-panOffset());
            this.getSelectedMap().AddZoomToHistory(mapview);
            this.Refresh();
        }
        private void up_Click(object sender, KeyEventArgs e)
        {
            MG_MapView mapview = this.getSelectedMap().GetMapView();
            mapview.Yoff(-panOffset());
            this.getSelectedMap().AddZoomToHistory(mapview);
            this.Refresh();
        }
        private void down_Click(object sender, KeyEventArgs e)
        {
            MG_MapView mapview = this.getSelectedMap().GetMapView();
            mapview.Yoff(panOffset());
            this.getSelectedMap().AddZoomToHistory(mapview);
            this.Refresh();
        }
        #endregion

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {// left right up down F5 zoomin F6 zoomout F7 pan F8 fullextent
            switch (e.KeyData)
            {
                case Keys.Left:
                    this.left_Click(sender, e);
                    break;
                case Keys.Right:
                    this.right_Click(sender, e);
                    break;
                case Keys.Up:
                    this.up_Click(sender, e);
                    break;
                case Keys.Down:
                    this.down_Click(sender, e);
                    break;
                case Keys.F5:
                    this.zoomIn_Click(sender, e);
                    break;
                case Keys.F6:
                    this.zoomOut_Click(sender, e);
                    break;
                case Keys.F7:
                    this.pan_Click(sender, e);
                    break;
                case Keys.F8:
                    this.fullExtent_Click(sender, e);
                    break;
            }

            if (this.m_gBaseTool != null)
            {
                this.m_gBaseTool.KeyDown(sender, e);
            }

            // set state
            this.setState();
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.m_gBaseTool != null)
            {
                //this.m_gBaseTool.KeyPress(sender, e);
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.m_gBaseTool != null)
            {
                this.m_gBaseTool.KeyUp(sender, e);
            }
        }

        #endregion

    }
}
