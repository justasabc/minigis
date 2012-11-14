using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MGP_BasicObject
{
    public class MG_Constant
    {
        public static int LineWidth = 1;
        public static int PointRadius = 5;
        public static Color FillColor = Color.Red;
        public static Color OutlineColor = Color.Red;

        public static string Server = "localhost";
        public static string Port = "5432";
        public static string UserId = "postgres";
        public static string Password = "111";
        public static string Database = "postgis";
    }

}
