using MGP_UI;// MG_TreeView

namespace MiniGIS
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonTab_Start = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton_NewMap = new System.Windows.Forms.RibbonButton();
            this.ribbonButton_OpenMap = new System.Windows.Forms.RibbonButton();
            this.ribbonButton_SaveMap = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton_ZoomIn = new System.Windows.Forms.RibbonButton();
            this.ribbonButton_ZoomOut = new System.Windows.Forms.RibbonButton();
            this.ribbonButton_Pan = new System.Windows.Forms.RibbonButton();
            this.ribbonButton_FullExtent = new System.Windows.Forms.RibbonButton();
            this.ribbonButton_FirstExtent = new System.Windows.Forms.RibbonButton();
            this.ribbonButton_PreviousExtent = new System.Windows.Forms.RibbonButton();
            this.ribbonButton_NextExtent = new System.Windows.Forms.RibbonButton();
            this.ribbonButton_LastExtent = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton_AddShapeFileLayer = new System.Windows.Forms.RibbonButton();
            this.ribbonButton_NewLayer = new System.Windows.Forms.RibbonButton();
            this.ribbonButton_AddRasterFileLayer = new System.Windows.Forms.RibbonButton();
            this.ribbonButton_AddPostGISLayer = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel4 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton_ConnectDB = new System.Windows.Forms.RibbonButton();
            this.ribbonButtonList1 = new System.Windows.Forms.RibbonButtonList();
            this.ribbonButtonList2 = new System.Windows.Forms.RibbonButtonList();
            this.ribbonButtonList3 = new System.Windows.Forms.RibbonButtonList();
            this.ribbonSeparator1 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonSeparator2 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonButton_DisConnectDB = new System.Windows.Forms.RibbonButton();
            this.ribbonButton_ImportToDB = new System.Windows.Forms.RibbonButton();
            this.ribbonButton_ExportToFile = new System.Windows.Forms.RibbonButton();
            this.ribbonTab4 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel_Draw = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton_Pointer = new System.Windows.Forms.RibbonButton();
            this.ribbonButton_DrawPoint = new System.Windows.Forms.RibbonButton();
            this.ribbonButton_DrawLineString = new System.Windows.Forms.RibbonButton();
            this.ribbonButton_DrawDoubleLineString = new System.Windows.Forms.RibbonButton();
            this.ribbonButton_DrawPolygon = new System.Windows.Forms.RibbonButton();
            this.ribbonButton_DrawRectangle = new System.Windows.Forms.RibbonButton();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonTab2 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel5 = new System.Windows.Forms.RibbonPanel();
            this.ribbonSeparator3 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonSeparator4 = new System.Windows.Forms.RibbonSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusLabel_Zoom = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel_Scale = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel_ScreenPoint = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel_MapPoint = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel_Extent = new System.Windows.Forms.ToolStripStatusLabel();
            this.treeViewContent = new System.Windows.Forms.TreeView();
            this.contextMenu_Map = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeMap = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllMap = new System.Windows.Forms.ToolStripMenuItem();
            this.renameMap = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveMap = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsMap = new System.Windows.Forms.ToolStripMenuItem();
            this.newLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.addShapeFile = new System.Windows.Forms.ToolStripMenuItem();
            this.addPostGIS = new System.Windows.Forms.ToolStripMenuItem();
            this.addRasterFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.propetryMap = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu_Layer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.renameLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.saveLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.newField = new System.Windows.Forms.ToolStripMenuItem();
            this.viewFields = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.propetryLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu_MapView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.zoomIn = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOut = new System.Windows.Forms.ToolStripMenuItem();
            this.pan = new System.Windows.Forms.ToolStripMenuItem();
            this.fullExtent = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.firstExtent = new System.Windows.Forms.ToolStripMenuItem();
            this.previousExtent = new System.Windows.Forms.ToolStripMenuItem();
            this.nextExtent = new System.Windows.Forms.ToolStripMenuItem();
            this.lastExtent = new System.Windows.Forms.ToolStripMenuItem();
            this.ribbonOrbMenuItem1 = new System.Windows.Forms.RibbonOrbMenuItem();
            this.ribbonOrbMenuItem2 = new System.Windows.Forms.RibbonOrbMenuItem();
            this.ribbonOrbRecentItem1 = new System.Windows.Forms.RibbonOrbRecentItem();
            this.ribbonOrbRecentItem2 = new System.Windows.Forms.RibbonOrbRecentItem();
            this.ribbonButton13 = new System.Windows.Forms.RibbonButton();
            this.panel1.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.contextMenu_Map.SuspendLayout();
            this.contextMenu_Layer.SuspendLayout();
            this.contextMenu_MapView.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbon1
            // 
            this.ribbon1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 72);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbImage = null;
            // 
            // 
            // 
            this.ribbon1.QuickAcessToolbar.AltKey = null;
            this.ribbon1.QuickAcessToolbar.Image = null;
            this.ribbon1.QuickAcessToolbar.Tag = null;
            this.ribbon1.QuickAcessToolbar.Text = null;
            this.ribbon1.QuickAcessToolbar.ToolTip = null;
            this.ribbon1.QuickAcessToolbar.ToolTipImage = null;
            this.ribbon1.QuickAcessToolbar.ToolTipTitle = null;
            this.ribbon1.Size = new System.Drawing.Size(963, 138);
            this.ribbon1.TabIndex = 1;
            this.ribbon1.Tabs.Add(this.ribbonTab_Start);
            this.ribbon1.Tabs.Add(this.ribbonTab4);
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.TabSpacing = 6;
            this.ribbon1.Text = "ribbon1";
            // 
            // ribbonTab_Start
            // 
            this.ribbonTab_Start.Panels.Add(this.ribbonPanel1);
            this.ribbonTab_Start.Panels.Add(this.ribbonPanel2);
            this.ribbonTab_Start.Panels.Add(this.ribbonPanel3);
            this.ribbonTab_Start.Panels.Add(this.ribbonPanel4);
            this.ribbonTab_Start.Tag = null;
            this.ribbonTab_Start.Text = "Start";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.ribbonButton_NewMap);
            this.ribbonPanel1.Items.Add(this.ribbonButton_OpenMap);
            this.ribbonPanel1.Items.Add(this.ribbonButton_SaveMap);
            this.ribbonPanel1.Tag = null;
            this.ribbonPanel1.Text = "Map";
            // 
            // ribbonButton_NewMap
            // 
            this.ribbonButton_NewMap.AltKey = null;
            this.ribbonButton_NewMap.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.ribbonButton_NewMap.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonButton_NewMap.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_NewMap.Image")));
            this.ribbonButton_NewMap.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_NewMap.SmallImage")));
            this.ribbonButton_NewMap.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonButton_NewMap.Tag = null;
            this.ribbonButton_NewMap.Text = "New";
            this.ribbonButton_NewMap.ToolTip = null;
            this.ribbonButton_NewMap.ToolTipImage = null;
            this.ribbonButton_NewMap.ToolTipTitle = null;
            this.ribbonButton_NewMap.Click += new System.EventHandler(this.ribbonButton_NewMap_Click);
            // 
            // ribbonButton_OpenMap
            // 
            this.ribbonButton_OpenMap.AltKey = null;
            this.ribbonButton_OpenMap.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.ribbonButton_OpenMap.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonButton_OpenMap.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_OpenMap.Image")));
            this.ribbonButton_OpenMap.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_OpenMap.SmallImage")));
            this.ribbonButton_OpenMap.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonButton_OpenMap.Tag = null;
            this.ribbonButton_OpenMap.Text = "Open";
            this.ribbonButton_OpenMap.ToolTip = null;
            this.ribbonButton_OpenMap.ToolTipImage = null;
            this.ribbonButton_OpenMap.ToolTipTitle = null;
            this.ribbonButton_OpenMap.Click += new System.EventHandler(this.ribbonButton_OpenMap_Click);
            // 
            // ribbonButton_SaveMap
            // 
            this.ribbonButton_SaveMap.AltKey = null;
            this.ribbonButton_SaveMap.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.ribbonButton_SaveMap.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonButton_SaveMap.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_SaveMap.Image")));
            this.ribbonButton_SaveMap.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_SaveMap.SmallImage")));
            this.ribbonButton_SaveMap.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonButton_SaveMap.Tag = null;
            this.ribbonButton_SaveMap.Text = "Save";
            this.ribbonButton_SaveMap.ToolTip = null;
            this.ribbonButton_SaveMap.ToolTipImage = null;
            this.ribbonButton_SaveMap.ToolTipTitle = null;
            this.ribbonButton_SaveMap.Click += new System.EventHandler(this.ribbonButton_SaveMap_Click);
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.Items.Add(this.ribbonButton_ZoomIn);
            this.ribbonPanel2.Items.Add(this.ribbonButton_ZoomOut);
            this.ribbonPanel2.Items.Add(this.ribbonButton_Pan);
            this.ribbonPanel2.Items.Add(this.ribbonButton_FullExtent);
            this.ribbonPanel2.Items.Add(this.ribbonButton_FirstExtent);
            this.ribbonPanel2.Items.Add(this.ribbonButton_PreviousExtent);
            this.ribbonPanel2.Items.Add(this.ribbonButton_NextExtent);
            this.ribbonPanel2.Items.Add(this.ribbonButton_LastExtent);
            this.ribbonPanel2.Tag = null;
            this.ribbonPanel2.Text = "View";
            // 
            // ribbonButton_ZoomIn
            // 
            this.ribbonButton_ZoomIn.AltKey = null;
            this.ribbonButton_ZoomIn.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.ribbonButton_ZoomIn.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonButton_ZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_ZoomIn.Image")));
            this.ribbonButton_ZoomIn.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_ZoomIn.SmallImage")));
            this.ribbonButton_ZoomIn.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonButton_ZoomIn.Tag = null;
            this.ribbonButton_ZoomIn.Text = "ZoomIn";
            this.ribbonButton_ZoomIn.ToolTip = null;
            this.ribbonButton_ZoomIn.ToolTipImage = null;
            this.ribbonButton_ZoomIn.ToolTipTitle = null;
            this.ribbonButton_ZoomIn.Click += new System.EventHandler(this.zoomIn_Click);
            // 
            // ribbonButton_ZoomOut
            // 
            this.ribbonButton_ZoomOut.AltKey = null;
            this.ribbonButton_ZoomOut.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.ribbonButton_ZoomOut.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonButton_ZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_ZoomOut.Image")));
            this.ribbonButton_ZoomOut.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_ZoomOut.SmallImage")));
            this.ribbonButton_ZoomOut.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonButton_ZoomOut.Tag = null;
            this.ribbonButton_ZoomOut.Text = "ZoomOut";
            this.ribbonButton_ZoomOut.ToolTip = null;
            this.ribbonButton_ZoomOut.ToolTipImage = null;
            this.ribbonButton_ZoomOut.ToolTipTitle = null;
            this.ribbonButton_ZoomOut.Click += new System.EventHandler(this.zoomOut_Click);
            // 
            // ribbonButton_Pan
            // 
            this.ribbonButton_Pan.AltKey = null;
            this.ribbonButton_Pan.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.ribbonButton_Pan.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonButton_Pan.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_Pan.Image")));
            this.ribbonButton_Pan.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_Pan.SmallImage")));
            this.ribbonButton_Pan.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonButton_Pan.Tag = null;
            this.ribbonButton_Pan.Text = "Pan";
            this.ribbonButton_Pan.ToolTip = null;
            this.ribbonButton_Pan.ToolTipImage = null;
            this.ribbonButton_Pan.ToolTipTitle = null;
            this.ribbonButton_Pan.Click += new System.EventHandler(this.pan_Click);
            // 
            // ribbonButton_FullExtent
            // 
            this.ribbonButton_FullExtent.AltKey = null;
            this.ribbonButton_FullExtent.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.ribbonButton_FullExtent.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonButton_FullExtent.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_FullExtent.Image")));
            this.ribbonButton_FullExtent.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_FullExtent.SmallImage")));
            this.ribbonButton_FullExtent.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonButton_FullExtent.Tag = null;
            this.ribbonButton_FullExtent.Text = "Full";
            this.ribbonButton_FullExtent.ToolTip = null;
            this.ribbonButton_FullExtent.ToolTipImage = null;
            this.ribbonButton_FullExtent.ToolTipTitle = null;
            this.ribbonButton_FullExtent.Click += new System.EventHandler(this.fullExtent_Click);
            // 
            // ribbonButton_FirstExtent
            // 
            this.ribbonButton_FirstExtent.AltKey = null;
            this.ribbonButton_FirstExtent.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.ribbonButton_FirstExtent.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonButton_FirstExtent.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_FirstExtent.Image")));
            this.ribbonButton_FirstExtent.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_FirstExtent.SmallImage")));
            this.ribbonButton_FirstExtent.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonButton_FirstExtent.Tag = null;
            this.ribbonButton_FirstExtent.Text = "First";
            this.ribbonButton_FirstExtent.ToolTip = null;
            this.ribbonButton_FirstExtent.ToolTipImage = null;
            this.ribbonButton_FirstExtent.ToolTipTitle = null;
            this.ribbonButton_FirstExtent.Click += new System.EventHandler(this.firstExtent_Click);
            // 
            // ribbonButton_PreviousExtent
            // 
            this.ribbonButton_PreviousExtent.AltKey = null;
            this.ribbonButton_PreviousExtent.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.ribbonButton_PreviousExtent.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonButton_PreviousExtent.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_PreviousExtent.Image")));
            this.ribbonButton_PreviousExtent.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_PreviousExtent.SmallImage")));
            this.ribbonButton_PreviousExtent.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonButton_PreviousExtent.Tag = null;
            this.ribbonButton_PreviousExtent.Text = "Previous";
            this.ribbonButton_PreviousExtent.ToolTip = null;
            this.ribbonButton_PreviousExtent.ToolTipImage = null;
            this.ribbonButton_PreviousExtent.ToolTipTitle = null;
            this.ribbonButton_PreviousExtent.Click += new System.EventHandler(this.previousExtent_Click);
            // 
            // ribbonButton_NextExtent
            // 
            this.ribbonButton_NextExtent.AltKey = null;
            this.ribbonButton_NextExtent.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.ribbonButton_NextExtent.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonButton_NextExtent.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_NextExtent.Image")));
            this.ribbonButton_NextExtent.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_NextExtent.SmallImage")));
            this.ribbonButton_NextExtent.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonButton_NextExtent.Tag = null;
            this.ribbonButton_NextExtent.Text = "Next";
            this.ribbonButton_NextExtent.ToolTip = null;
            this.ribbonButton_NextExtent.ToolTipImage = null;
            this.ribbonButton_NextExtent.ToolTipTitle = null;
            this.ribbonButton_NextExtent.Click += new System.EventHandler(this.nextExtent_Click);
            // 
            // ribbonButton_LastExtent
            // 
            this.ribbonButton_LastExtent.AltKey = null;
            this.ribbonButton_LastExtent.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.ribbonButton_LastExtent.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonButton_LastExtent.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_LastExtent.Image")));
            this.ribbonButton_LastExtent.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_LastExtent.SmallImage")));
            this.ribbonButton_LastExtent.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonButton_LastExtent.Tag = null;
            this.ribbonButton_LastExtent.Text = "Last";
            this.ribbonButton_LastExtent.ToolTip = null;
            this.ribbonButton_LastExtent.ToolTipImage = null;
            this.ribbonButton_LastExtent.ToolTipTitle = null;
            this.ribbonButton_LastExtent.Click += new System.EventHandler(this.lastExtent_Click);
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.Items.Add(this.ribbonButton_AddShapeFileLayer);
            this.ribbonPanel3.Items.Add(this.ribbonButton_NewLayer);
            this.ribbonPanel3.Items.Add(this.ribbonButton_AddRasterFileLayer);
            this.ribbonPanel3.Items.Add(this.ribbonButton_AddPostGISLayer);
            this.ribbonPanel3.Tag = null;
            this.ribbonPanel3.Text = "Layer";
            // 
            // ribbonButton_AddShapeFileLayer
            // 
            this.ribbonButton_AddShapeFileLayer.AltKey = null;
            this.ribbonButton_AddShapeFileLayer.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.ribbonButton_AddShapeFileLayer.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonButton_AddShapeFileLayer.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_AddShapeFileLayer.Image")));
            this.ribbonButton_AddShapeFileLayer.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_AddShapeFileLayer.SmallImage")));
            this.ribbonButton_AddShapeFileLayer.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonButton_AddShapeFileLayer.Tag = null;
            this.ribbonButton_AddShapeFileLayer.Text = "ShapeFile";
            this.ribbonButton_AddShapeFileLayer.ToolTip = null;
            this.ribbonButton_AddShapeFileLayer.ToolTipImage = null;
            this.ribbonButton_AddShapeFileLayer.ToolTipTitle = null;
            this.ribbonButton_AddShapeFileLayer.Click += new System.EventHandler(this.ribbonButton_AddShapeFileLayer_Click);
            // 
            // ribbonButton_NewLayer
            // 
            this.ribbonButton_NewLayer.AltKey = null;
            this.ribbonButton_NewLayer.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.ribbonButton_NewLayer.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonButton_NewLayer.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_NewLayer.Image")));
            this.ribbonButton_NewLayer.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_NewLayer.SmallImage")));
            this.ribbonButton_NewLayer.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonButton_NewLayer.Tag = null;
            this.ribbonButton_NewLayer.Text = "NewLayer";
            this.ribbonButton_NewLayer.ToolTip = null;
            this.ribbonButton_NewLayer.ToolTipImage = null;
            this.ribbonButton_NewLayer.ToolTipTitle = null;
            this.ribbonButton_NewLayer.Click += new System.EventHandler(this.ribbonButton_NewLayer_Click);
            // 
            // ribbonButton_AddRasterFileLayer
            // 
            this.ribbonButton_AddRasterFileLayer.AltKey = null;
            this.ribbonButton_AddRasterFileLayer.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.ribbonButton_AddRasterFileLayer.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonButton_AddRasterFileLayer.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_AddRasterFileLayer.Image")));
            this.ribbonButton_AddRasterFileLayer.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_AddRasterFileLayer.SmallImage")));
            this.ribbonButton_AddRasterFileLayer.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonButton_AddRasterFileLayer.Tag = null;
            this.ribbonButton_AddRasterFileLayer.Text = "RasterFile";
            this.ribbonButton_AddRasterFileLayer.ToolTip = null;
            this.ribbonButton_AddRasterFileLayer.ToolTipImage = null;
            this.ribbonButton_AddRasterFileLayer.ToolTipTitle = null;
            this.ribbonButton_AddRasterFileLayer.Click += new System.EventHandler(this.ribbonButton_AddRasterFileLayer_Click);
            // 
            // ribbonButton_AddPostGISLayer
            // 
            this.ribbonButton_AddPostGISLayer.AltKey = null;
            this.ribbonButton_AddPostGISLayer.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.ribbonButton_AddPostGISLayer.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonButton_AddPostGISLayer.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_AddPostGISLayer.Image")));
            this.ribbonButton_AddPostGISLayer.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_AddPostGISLayer.SmallImage")));
            this.ribbonButton_AddPostGISLayer.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonButton_AddPostGISLayer.Tag = null;
            this.ribbonButton_AddPostGISLayer.Text = "PostGIS";
            this.ribbonButton_AddPostGISLayer.ToolTip = null;
            this.ribbonButton_AddPostGISLayer.ToolTipImage = null;
            this.ribbonButton_AddPostGISLayer.ToolTipTitle = null;
            this.ribbonButton_AddPostGISLayer.Click += new System.EventHandler(this.ribbonButton_AddPostGISLayer_Click);
            // 
            // ribbonPanel4
            // 
            this.ribbonPanel4.Items.Add(this.ribbonButton_ConnectDB);
            this.ribbonPanel4.Items.Add(this.ribbonButton_DisConnectDB);
            this.ribbonPanel4.Items.Add(this.ribbonButton_ImportToDB);
            this.ribbonPanel4.Items.Add(this.ribbonButton_ExportToFile);
            this.ribbonPanel4.Tag = null;
            this.ribbonPanel4.Text = "Tool";
            // 
            // ribbonButton_ConnectDB
            // 
            this.ribbonButton_ConnectDB.AltKey = null;
            this.ribbonButton_ConnectDB.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.ribbonButton_ConnectDB.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonButton_ConnectDB.DropDownItems.Add(this.ribbonButtonList1);
            this.ribbonButton_ConnectDB.DropDownItems.Add(this.ribbonButtonList2);
            this.ribbonButton_ConnectDB.DropDownItems.Add(this.ribbonButtonList3);
            this.ribbonButton_ConnectDB.DropDownItems.Add(this.ribbonSeparator1);
            this.ribbonButton_ConnectDB.DropDownItems.Add(this.ribbonSeparator2);
            this.ribbonButton_ConnectDB.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_ConnectDB.Image")));
            this.ribbonButton_ConnectDB.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_ConnectDB.SmallImage")));
            this.ribbonButton_ConnectDB.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonButton_ConnectDB.Tag = null;
            this.ribbonButton_ConnectDB.Text = "ConnectDB";
            this.ribbonButton_ConnectDB.ToolTip = null;
            this.ribbonButton_ConnectDB.ToolTipImage = null;
            this.ribbonButton_ConnectDB.ToolTipTitle = null;
            this.ribbonButton_ConnectDB.Click += new System.EventHandler(this.ribbonButton_ConnectDB_Click);
            // 
            // ribbonButtonList1
            // 
            this.ribbonButtonList1.AltKey = null;
            this.ribbonButtonList1.ButtonsSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.ribbonButtonList1.FlowToBottom = false;
            this.ribbonButtonList1.Image = null;
            this.ribbonButtonList1.ItemsSizeInDropwDownMode = new System.Drawing.Size(7, 5);
            this.ribbonButtonList1.Tag = null;
            this.ribbonButtonList1.Text = "ribbonButtonList1";
            this.ribbonButtonList1.ToolTip = null;
            this.ribbonButtonList1.ToolTipImage = null;
            this.ribbonButtonList1.ToolTipTitle = null;
            // 
            // ribbonButtonList2
            // 
            this.ribbonButtonList2.AltKey = null;
            this.ribbonButtonList2.ButtonsSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.ribbonButtonList2.FlowToBottom = false;
            this.ribbonButtonList2.Image = null;
            this.ribbonButtonList2.ItemsSizeInDropwDownMode = new System.Drawing.Size(7, 5);
            this.ribbonButtonList2.Tag = null;
            this.ribbonButtonList2.Text = "ribbonButtonList2";
            this.ribbonButtonList2.ToolTip = null;
            this.ribbonButtonList2.ToolTipImage = null;
            this.ribbonButtonList2.ToolTipTitle = null;
            // 
            // ribbonButtonList3
            // 
            this.ribbonButtonList3.AltKey = null;
            this.ribbonButtonList3.ButtonsSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.ribbonButtonList3.FlowToBottom = false;
            this.ribbonButtonList3.Image = null;
            this.ribbonButtonList3.ItemsSizeInDropwDownMode = new System.Drawing.Size(7, 5);
            this.ribbonButtonList3.Tag = null;
            this.ribbonButtonList3.Text = "ribbonButtonList3";
            this.ribbonButtonList3.ToolTip = null;
            this.ribbonButtonList3.ToolTipImage = null;
            this.ribbonButtonList3.ToolTipTitle = null;
            // 
            // ribbonSeparator1
            // 
            this.ribbonSeparator1.AltKey = null;
            this.ribbonSeparator1.Image = null;
            this.ribbonSeparator1.Tag = null;
            this.ribbonSeparator1.Text = null;
            this.ribbonSeparator1.ToolTip = null;
            this.ribbonSeparator1.ToolTipImage = null;
            this.ribbonSeparator1.ToolTipTitle = null;
            // 
            // ribbonSeparator2
            // 
            this.ribbonSeparator2.AltKey = null;
            this.ribbonSeparator2.Image = null;
            this.ribbonSeparator2.Tag = null;
            this.ribbonSeparator2.Text = null;
            this.ribbonSeparator2.ToolTip = null;
            this.ribbonSeparator2.ToolTipImage = null;
            this.ribbonSeparator2.ToolTipTitle = null;
            // 
            // ribbonButton_DisConnectDB
            // 
            this.ribbonButton_DisConnectDB.AltKey = null;
            this.ribbonButton_DisConnectDB.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.ribbonButton_DisConnectDB.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonButton_DisConnectDB.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_DisConnectDB.Image")));
            this.ribbonButton_DisConnectDB.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_DisConnectDB.SmallImage")));
            this.ribbonButton_DisConnectDB.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonButton_DisConnectDB.Tag = null;
            this.ribbonButton_DisConnectDB.Text = "DisConnectDB";
            this.ribbonButton_DisConnectDB.ToolTip = null;
            this.ribbonButton_DisConnectDB.ToolTipImage = null;
            this.ribbonButton_DisConnectDB.ToolTipTitle = null;
            this.ribbonButton_DisConnectDB.Click += new System.EventHandler(this.ribbonButton_DisConnectDB_Click);
            // 
            // ribbonButton_ImportToDB
            // 
            this.ribbonButton_ImportToDB.AltKey = null;
            this.ribbonButton_ImportToDB.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.ribbonButton_ImportToDB.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonButton_ImportToDB.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_ImportToDB.Image")));
            this.ribbonButton_ImportToDB.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_ImportToDB.SmallImage")));
            this.ribbonButton_ImportToDB.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonButton_ImportToDB.Tag = null;
            this.ribbonButton_ImportToDB.Text = "ImportToDB";
            this.ribbonButton_ImportToDB.ToolTip = null;
            this.ribbonButton_ImportToDB.ToolTipImage = null;
            this.ribbonButton_ImportToDB.ToolTipTitle = null;
            this.ribbonButton_ImportToDB.Click += new System.EventHandler(this.ribbonButton_ImportToDB_Click);
            // 
            // ribbonButton_ExportToFile
            // 
            this.ribbonButton_ExportToFile.AltKey = null;
            this.ribbonButton_ExportToFile.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.ribbonButton_ExportToFile.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonButton_ExportToFile.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_ExportToFile.Image")));
            this.ribbonButton_ExportToFile.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_ExportToFile.SmallImage")));
            this.ribbonButton_ExportToFile.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonButton_ExportToFile.Tag = null;
            this.ribbonButton_ExportToFile.Text = "ExportToFile";
            this.ribbonButton_ExportToFile.ToolTip = null;
            this.ribbonButton_ExportToFile.ToolTipImage = null;
            this.ribbonButton_ExportToFile.ToolTipTitle = null;
            this.ribbonButton_ExportToFile.Click += new System.EventHandler(this.ribbonButton_ExportToFile_Click);
            // 
            // ribbonTab4
            // 
            this.ribbonTab4.Panels.Add(this.ribbonPanel_Draw);
            this.ribbonTab4.Tag = null;
            this.ribbonTab4.Text = "Edit";
            // 
            // ribbonPanel_Draw
            // 
            this.ribbonPanel_Draw.Enabled = false;
            this.ribbonPanel_Draw.Items.Add(this.ribbonButton_Pointer);
            this.ribbonPanel_Draw.Items.Add(this.ribbonButton_DrawPoint);
            this.ribbonPanel_Draw.Items.Add(this.ribbonButton_DrawLineString);
            this.ribbonPanel_Draw.Items.Add(this.ribbonButton_DrawDoubleLineString);
            this.ribbonPanel_Draw.Items.Add(this.ribbonButton_DrawPolygon);
            this.ribbonPanel_Draw.Items.Add(this.ribbonButton_DrawRectangle);
            this.ribbonPanel_Draw.Tag = null;
            this.ribbonPanel_Draw.Text = "Draw";
            // 
            // ribbonButton_Pointer
            // 
            this.ribbonButton_Pointer.AltKey = null;
            this.ribbonButton_Pointer.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.ribbonButton_Pointer.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonButton_Pointer.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_Pointer.Image")));
            this.ribbonButton_Pointer.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_Pointer.SmallImage")));
            this.ribbonButton_Pointer.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonButton_Pointer.Tag = null;
            this.ribbonButton_Pointer.Text = "Pointer";
            this.ribbonButton_Pointer.ToolTip = null;
            this.ribbonButton_Pointer.ToolTipImage = null;
            this.ribbonButton_Pointer.ToolTipTitle = null;
            this.ribbonButton_Pointer.Click += new System.EventHandler(this.ribbonButton_Pointer_Click);
            // 
            // ribbonButton_DrawPoint
            // 
            this.ribbonButton_DrawPoint.AltKey = null;
            this.ribbonButton_DrawPoint.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.ribbonButton_DrawPoint.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonButton_DrawPoint.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_DrawPoint.Image")));
            this.ribbonButton_DrawPoint.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_DrawPoint.SmallImage")));
            this.ribbonButton_DrawPoint.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonButton_DrawPoint.Tag = null;
            this.ribbonButton_DrawPoint.Text = "Point";
            this.ribbonButton_DrawPoint.ToolTip = null;
            this.ribbonButton_DrawPoint.ToolTipImage = null;
            this.ribbonButton_DrawPoint.ToolTipTitle = null;
            this.ribbonButton_DrawPoint.Click += new System.EventHandler(this.ribbonButton_DrawPoint_Click);
            // 
            // ribbonButton_DrawLineString
            // 
            this.ribbonButton_DrawLineString.AltKey = null;
            this.ribbonButton_DrawLineString.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.ribbonButton_DrawLineString.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonButton_DrawLineString.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_DrawLineString.Image")));
            this.ribbonButton_DrawLineString.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_DrawLineString.SmallImage")));
            this.ribbonButton_DrawLineString.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonButton_DrawLineString.Tag = null;
            this.ribbonButton_DrawLineString.Text = "LineString";
            this.ribbonButton_DrawLineString.ToolTip = null;
            this.ribbonButton_DrawLineString.ToolTipImage = null;
            this.ribbonButton_DrawLineString.ToolTipTitle = null;
            this.ribbonButton_DrawLineString.Click += new System.EventHandler(this.ribbonButton_DrawLineString_Click);
            // 
            // ribbonButton_DrawDoubleLineString
            // 
            this.ribbonButton_DrawDoubleLineString.AltKey = null;
            this.ribbonButton_DrawDoubleLineString.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.ribbonButton_DrawDoubleLineString.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonButton_DrawDoubleLineString.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_DrawDoubleLineString.Image")));
            this.ribbonButton_DrawDoubleLineString.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_DrawDoubleLineString.SmallImage")));
            this.ribbonButton_DrawDoubleLineString.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonButton_DrawDoubleLineString.Tag = null;
            this.ribbonButton_DrawDoubleLineString.Text = "DoubleLineString";
            this.ribbonButton_DrawDoubleLineString.ToolTip = null;
            this.ribbonButton_DrawDoubleLineString.ToolTipImage = null;
            this.ribbonButton_DrawDoubleLineString.ToolTipTitle = null;
            this.ribbonButton_DrawDoubleLineString.Click += new System.EventHandler(this.ribbonButton_DrawDoubleLineString_Click);
            // 
            // ribbonButton_DrawPolygon
            // 
            this.ribbonButton_DrawPolygon.AltKey = null;
            this.ribbonButton_DrawPolygon.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.ribbonButton_DrawPolygon.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonButton_DrawPolygon.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_DrawPolygon.Image")));
            this.ribbonButton_DrawPolygon.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_DrawPolygon.SmallImage")));
            this.ribbonButton_DrawPolygon.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonButton_DrawPolygon.Tag = null;
            this.ribbonButton_DrawPolygon.Text = "Polygon";
            this.ribbonButton_DrawPolygon.ToolTip = null;
            this.ribbonButton_DrawPolygon.ToolTipImage = null;
            this.ribbonButton_DrawPolygon.ToolTipTitle = null;
            this.ribbonButton_DrawPolygon.Click += new System.EventHandler(this.ribbonButton_DrawPolygon_Click);
            // 
            // ribbonButton_DrawRectangle
            // 
            this.ribbonButton_DrawRectangle.AltKey = null;
            this.ribbonButton_DrawRectangle.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.ribbonButton_DrawRectangle.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonButton_DrawRectangle.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_DrawRectangle.Image")));
            this.ribbonButton_DrawRectangle.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_DrawRectangle.SmallImage")));
            this.ribbonButton_DrawRectangle.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonButton_DrawRectangle.Tag = null;
            this.ribbonButton_DrawRectangle.Text = "Rectangle";
            this.ribbonButton_DrawRectangle.ToolTip = null;
            this.ribbonButton_DrawRectangle.ToolTipImage = null;
            this.ribbonButton_DrawRectangle.ToolTipTitle = null;
            this.ribbonButton_DrawRectangle.Click += new System.EventHandler(this.ribbonButton_DrawRectangle_Click);
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Tag = null;
            this.ribbonTab1.Text = "Help";
            // 
            // ribbonTab2
            // 
            this.ribbonTab2.Tag = null;
            this.ribbonTab2.Text = null;
            // 
            // ribbonPanel5
            // 
            this.ribbonPanel5.Tag = null;
            this.ribbonPanel5.Text = null;
            // 
            // ribbonSeparator3
            // 
            this.ribbonSeparator3.AltKey = null;
            this.ribbonSeparator3.Image = null;
            this.ribbonSeparator3.Tag = null;
            this.ribbonSeparator3.Text = null;
            this.ribbonSeparator3.ToolTip = null;
            this.ribbonSeparator3.ToolTipImage = null;
            this.ribbonSeparator3.ToolTipTitle = null;
            // 
            // ribbonSeparator4
            // 
            this.ribbonSeparator4.AltKey = null;
            this.ribbonSeparator4.Image = null;
            this.ribbonSeparator4.Tag = null;
            this.ribbonSeparator4.Text = null;
            this.ribbonSeparator4.ToolTip = null;
            this.ribbonSeparator4.ToolTipImage = null;
            this.ribbonSeparator4.ToolTipTitle = null;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.WindowText;
            this.panel1.Controls.Add(this.statusBar);
            this.panel1.Location = new System.Drawing.Point(146, 143);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1160, 429);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            this.panel1.Resize += new System.EventHandler(this.panel1_Resize);
            // 
            // statusBar
            // 
            this.statusBar.BackColor = System.Drawing.SystemColors.Menu;
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel_Zoom,
            this.statusLabel_Scale,
            this.statusLabel_ScreenPoint,
            this.statusLabel_MapPoint,
            this.statusLabel_Extent});
            this.statusBar.Location = new System.Drawing.Point(0, 407);
            this.statusBar.Name = "statusBar";
            this.statusBar.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusBar.Size = new System.Drawing.Size(1160, 22);
            this.statusBar.TabIndex = 0;
            this.statusBar.Text = "statusStrip1";
            // 
            // statusLabel_Zoom
            // 
            this.statusLabel_Zoom.Name = "statusLabel_Zoom";
            this.statusLabel_Zoom.Size = new System.Drawing.Size(112, 17);
            this.statusLabel_Zoom.Text = "statusLabel_Zoom";
            // 
            // statusLabel_Scale
            // 
            this.statusLabel_Scale.Name = "statusLabel_Scale";
            this.statusLabel_Scale.Size = new System.Drawing.Size(108, 17);
            this.statusLabel_Scale.Text = "statusLabel_Scale";
            // 
            // statusLabel_ScreenPoint
            // 
            this.statusLabel_ScreenPoint.Name = "statusLabel_ScreenPoint";
            this.statusLabel_ScreenPoint.Size = new System.Drawing.Size(146, 17);
            this.statusLabel_ScreenPoint.Text = "statusLabel_ScreenPoint";
            // 
            // statusLabel_MapPoint
            // 
            this.statusLabel_MapPoint.Name = "statusLabel_MapPoint";
            this.statusLabel_MapPoint.Size = new System.Drawing.Size(134, 17);
            this.statusLabel_MapPoint.Text = "statusLabel_MapPoint";
            // 
            // statusLabel_Extent
            // 
            this.statusLabel_Extent.Name = "statusLabel_Extent";
            this.statusLabel_Extent.Size = new System.Drawing.Size(113, 17);
            this.statusLabel_Extent.Text = "statusLabel_Extent";
            // 
            // treeViewContent
            // 
            this.treeViewContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewContent.CheckBoxes = true;
            this.treeViewContent.Location = new System.Drawing.Point(12, 145);
            this.treeViewContent.Name = "treeViewContent";
            this.treeViewContent.Size = new System.Drawing.Size(121, 427);
            this.treeViewContent.TabIndex = 5;
            this.treeViewContent.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewContent_AfterLabelEdit);
            this.treeViewContent.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewContent_AfterCheck);
            this.treeViewContent.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewContent_NodeMouseClick);
            this.treeViewContent.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewContent_NodeMouseDoubleClick);
            this.treeViewContent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeViewContent_MouseDown);
            // 
            // contextMenu_Map
            // 
            this.contextMenu_Map.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeMap,
            this.removeAllMap,
            this.renameMap,
            this.toolStripSeparator2,
            this.saveMap,
            this.saveAsMap,
            this.newLayer,
            this.addShapeFile,
            this.addPostGIS,
            this.addRasterFile,
            this.toolStripSeparator3,
            this.propetryMap});
            this.contextMenu_Map.Name = "contextMenu_Map";
            this.contextMenu_Map.Size = new System.Drawing.Size(161, 236);
            // 
            // removeMap
            // 
            this.removeMap.Image = ((System.Drawing.Image)(resources.GetObject("removeMap.Image")));
            this.removeMap.Name = "removeMap";
            this.removeMap.Size = new System.Drawing.Size(160, 22);
            this.removeMap.Text = "Remove";
            this.removeMap.Click += new System.EventHandler(this.removeMap_Click);
            // 
            // removeAllMap
            // 
            this.removeAllMap.Name = "removeAllMap";
            this.removeAllMap.Size = new System.Drawing.Size(160, 22);
            this.removeAllMap.Text = "Remove All";
            this.removeAllMap.Click += new System.EventHandler(this.removeAllMap_Click);
            // 
            // renameMap
            // 
            this.renameMap.Image = ((System.Drawing.Image)(resources.GetObject("renameMap.Image")));
            this.renameMap.Name = "renameMap";
            this.renameMap.Size = new System.Drawing.Size(160, 22);
            this.renameMap.Text = "Rename";
            this.renameMap.Click += new System.EventHandler(this.renameMap_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(157, 6);
            // 
            // saveMap
            // 
            this.saveMap.Image = ((System.Drawing.Image)(resources.GetObject("saveMap.Image")));
            this.saveMap.Name = "saveMap";
            this.saveMap.Size = new System.Drawing.Size(160, 22);
            this.saveMap.Text = "Save";
            this.saveMap.Click += new System.EventHandler(this.saveMap_Click);
            // 
            // saveAsMap
            // 
            this.saveAsMap.Image = ((System.Drawing.Image)(resources.GetObject("saveAsMap.Image")));
            this.saveAsMap.Name = "saveAsMap";
            this.saveAsMap.Size = new System.Drawing.Size(160, 22);
            this.saveAsMap.Text = "Save As...";
            this.saveAsMap.Click += new System.EventHandler(this.saveAsMap_Click);
            // 
            // newLayer
            // 
            this.newLayer.Image = ((System.Drawing.Image)(resources.GetObject("newLayer.Image")));
            this.newLayer.Name = "newLayer";
            this.newLayer.Size = new System.Drawing.Size(160, 22);
            this.newLayer.Text = "New Layer...";
            this.newLayer.Click += new System.EventHandler(this.newLayer_Click);
            // 
            // addShapeFile
            // 
            this.addShapeFile.Image = ((System.Drawing.Image)(resources.GetObject("addShapeFile.Image")));
            this.addShapeFile.Name = "addShapeFile";
            this.addShapeFile.Size = new System.Drawing.Size(160, 22);
            this.addShapeFile.Text = "Add ShapeFile";
            this.addShapeFile.Click += new System.EventHandler(this.addShapeFile_Click);
            // 
            // addPostGIS
            // 
            this.addPostGIS.Image = ((System.Drawing.Image)(resources.GetObject("addPostGIS.Image")));
            this.addPostGIS.Name = "addPostGIS";
            this.addPostGIS.Size = new System.Drawing.Size(160, 22);
            this.addPostGIS.Text = "Add PostGIS";
            this.addPostGIS.Click += new System.EventHandler(this.addPostGIS_Click);
            // 
            // addRasterFile
            // 
            this.addRasterFile.Image = ((System.Drawing.Image)(resources.GetObject("addRasterFile.Image")));
            this.addRasterFile.Name = "addRasterFile";
            this.addRasterFile.Size = new System.Drawing.Size(160, 22);
            this.addRasterFile.Text = "Add RasterFile";
            this.addRasterFile.Click += new System.EventHandler(this.addRasterFile_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(157, 6);
            // 
            // propetryMap
            // 
            this.propetryMap.Name = "propetryMap";
            this.propetryMap.Size = new System.Drawing.Size(160, 22);
            this.propetryMap.Text = "Propetry";
            this.propetryMap.Click += new System.EventHandler(this.propetryMap_Click);
            // 
            // contextMenu_Layer
            // 
            this.contextMenu_Layer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeLayer,
            this.removeAllLayer,
            this.renameLayer,
            this.toolStripSeparator4,
            this.saveLayer,
            this.saveAsLayer,
            this.newField,
            this.viewFields,
            this.toggleLayer,
            this.zoomToLayer,
            this.propetryLayer});
            this.contextMenu_Layer.Name = "contextMenu_Layer";
            this.contextMenu_Layer.Size = new System.Drawing.Size(165, 230);
            // 
            // removeLayer
            // 
            this.removeLayer.Image = ((System.Drawing.Image)(resources.GetObject("removeLayer.Image")));
            this.removeLayer.Name = "removeLayer";
            this.removeLayer.Size = new System.Drawing.Size(164, 22);
            this.removeLayer.Text = "Remove";
            this.removeLayer.Click += new System.EventHandler(this.removeLayer_Click);
            // 
            // removeAllLayer
            // 
            this.removeAllLayer.Name = "removeAllLayer";
            this.removeAllLayer.Size = new System.Drawing.Size(164, 22);
            this.removeAllLayer.Text = "Remove All";
            this.removeAllLayer.Click += new System.EventHandler(this.removeAllLayer_Click);
            // 
            // renameLayer
            // 
            this.renameLayer.Image = ((System.Drawing.Image)(resources.GetObject("renameLayer.Image")));
            this.renameLayer.Name = "renameLayer";
            this.renameLayer.Size = new System.Drawing.Size(164, 22);
            this.renameLayer.Text = "Rename";
            this.renameLayer.Click += new System.EventHandler(this.renameLayer_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(161, 6);
            // 
            // saveLayer
            // 
            this.saveLayer.Image = ((System.Drawing.Image)(resources.GetObject("saveLayer.Image")));
            this.saveLayer.Name = "saveLayer";
            this.saveLayer.Size = new System.Drawing.Size(164, 22);
            this.saveLayer.Text = "Save";
            this.saveLayer.Click += new System.EventHandler(this.saveLayer_Click);
            // 
            // saveAsLayer
            // 
            this.saveAsLayer.Image = ((System.Drawing.Image)(resources.GetObject("saveAsLayer.Image")));
            this.saveAsLayer.Name = "saveAsLayer";
            this.saveAsLayer.Size = new System.Drawing.Size(164, 22);
            this.saveAsLayer.Text = "Save As...";
            this.saveAsLayer.Click += new System.EventHandler(this.saveAsLayer_Click);
            // 
            // newField
            // 
            this.newField.Image = ((System.Drawing.Image)(resources.GetObject("newField.Image")));
            this.newField.Name = "newField";
            this.newField.Size = new System.Drawing.Size(164, 22);
            this.newField.Text = "New Field...";
            this.newField.Click += new System.EventHandler(this.newField_Click);
            // 
            // viewFields
            // 
            this.viewFields.Name = "viewFields";
            this.viewFields.Size = new System.Drawing.Size(164, 22);
            this.viewFields.Text = "View Fields";
            this.viewFields.Click += new System.EventHandler(this.viewFields_Click);
            // 
            // toggleLayer
            // 
            this.toggleLayer.Name = "toggleLayer";
            this.toggleLayer.Size = new System.Drawing.Size(164, 22);
            this.toggleLayer.Text = "Toggle";
            this.toggleLayer.Click += new System.EventHandler(this.toggleLayer_Click);
            // 
            // zoomToLayer
            // 
            this.zoomToLayer.Image = ((System.Drawing.Image)(resources.GetObject("zoomToLayer.Image")));
            this.zoomToLayer.Name = "zoomToLayer";
            this.zoomToLayer.Size = new System.Drawing.Size(164, 22);
            this.zoomToLayer.Text = "Zoom To Layer";
            this.zoomToLayer.Click += new System.EventHandler(this.zoomToLayer_Click);
            // 
            // propetryLayer
            // 
            this.propetryLayer.Name = "propetryLayer";
            this.propetryLayer.Size = new System.Drawing.Size(164, 22);
            this.propetryLayer.Text = "Property";
            this.propetryLayer.Click += new System.EventHandler(this.propetryLayer_Click);
            // 
            // contextMenu_MapView
            // 
            this.contextMenu_MapView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomIn,
            this.zoomOut,
            this.pan,
            this.fullExtent,
            this.toolStripSeparator1,
            this.firstExtent,
            this.previousExtent,
            this.nextExtent,
            this.lastExtent});
            this.contextMenu_MapView.Name = "contextMenu_MapView";
            this.contextMenu_MapView.Size = new System.Drawing.Size(165, 186);
            // 
            // zoomIn
            // 
            this.zoomIn.Image = ((System.Drawing.Image)(resources.GetObject("zoomIn.Image")));
            this.zoomIn.Name = "zoomIn";
            this.zoomIn.Size = new System.Drawing.Size(164, 22);
            this.zoomIn.Text = "ZoomIn";
            this.zoomIn.Click += new System.EventHandler(this.zoomIn_Click);
            // 
            // zoomOut
            // 
            this.zoomOut.Image = global::MiniGIS.Properties.Resources.zoomout32;
            this.zoomOut.Name = "zoomOut";
            this.zoomOut.Size = new System.Drawing.Size(164, 22);
            this.zoomOut.Text = "ZoomOut";
            this.zoomOut.Click += new System.EventHandler(this.zoomOut_Click);
            // 
            // pan
            // 
            this.pan.Image = global::MiniGIS.Properties.Resources.pan32;
            this.pan.Name = "pan";
            this.pan.Size = new System.Drawing.Size(164, 22);
            this.pan.Text = "Pan";
            this.pan.Click += new System.EventHandler(this.pan_Click);
            // 
            // fullExtent
            // 
            this.fullExtent.Image = global::MiniGIS.Properties.Resources.FullExtent32;
            this.fullExtent.Name = "fullExtent";
            this.fullExtent.Size = new System.Drawing.Size(164, 22);
            this.fullExtent.Text = "Full Extent";
            this.fullExtent.Click += new System.EventHandler(this.fullExtent_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // firstExtent
            // 
            this.firstExtent.Image = ((System.Drawing.Image)(resources.GetObject("firstExtent.Image")));
            this.firstExtent.Name = "firstExtent";
            this.firstExtent.Size = new System.Drawing.Size(164, 22);
            this.firstExtent.Text = "First Extent";
            this.firstExtent.Click += new System.EventHandler(this.firstExtent_Click);
            // 
            // previousExtent
            // 
            this.previousExtent.Image = ((System.Drawing.Image)(resources.GetObject("previousExtent.Image")));
            this.previousExtent.Name = "previousExtent";
            this.previousExtent.Size = new System.Drawing.Size(164, 22);
            this.previousExtent.Text = "Pervious Extent";
            this.previousExtent.Click += new System.EventHandler(this.previousExtent_Click);
            // 
            // nextExtent
            // 
            this.nextExtent.Image = ((System.Drawing.Image)(resources.GetObject("nextExtent.Image")));
            this.nextExtent.Name = "nextExtent";
            this.nextExtent.Size = new System.Drawing.Size(164, 22);
            this.nextExtent.Text = "Next Extent";
            this.nextExtent.Click += new System.EventHandler(this.nextExtent_Click);
            // 
            // lastExtent
            // 
            this.lastExtent.Image = ((System.Drawing.Image)(resources.GetObject("lastExtent.Image")));
            this.lastExtent.Name = "lastExtent";
            this.lastExtent.Size = new System.Drawing.Size(164, 22);
            this.lastExtent.Text = "Last Extent";
            this.lastExtent.Click += new System.EventHandler(this.lastExtent_Click);
            // 
            // ribbonOrbMenuItem1
            // 
            this.ribbonOrbMenuItem1.AltKey = null;
            this.ribbonOrbMenuItem1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonOrbMenuItem1.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonOrbMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem1.Image")));
            this.ribbonOrbMenuItem1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem1.SmallImage")));
            this.ribbonOrbMenuItem1.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonOrbMenuItem1.Tag = null;
            this.ribbonOrbMenuItem1.Text = "ribbonOrbMenuItem1";
            this.ribbonOrbMenuItem1.ToolTip = null;
            this.ribbonOrbMenuItem1.ToolTipImage = null;
            this.ribbonOrbMenuItem1.ToolTipTitle = null;
            // 
            // ribbonOrbMenuItem2
            // 
            this.ribbonOrbMenuItem2.AltKey = null;
            this.ribbonOrbMenuItem2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonOrbMenuItem2.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonOrbMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem2.Image")));
            this.ribbonOrbMenuItem2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem2.SmallImage")));
            this.ribbonOrbMenuItem2.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonOrbMenuItem2.Tag = null;
            this.ribbonOrbMenuItem2.Text = "File";
            this.ribbonOrbMenuItem2.ToolTip = null;
            this.ribbonOrbMenuItem2.ToolTipImage = null;
            this.ribbonOrbMenuItem2.ToolTipTitle = null;
            // 
            // ribbonOrbRecentItem1
            // 
            this.ribbonOrbRecentItem1.AltKey = null;
            this.ribbonOrbRecentItem1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.ribbonOrbRecentItem1.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonOrbRecentItem1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbRecentItem1.Image")));
            this.ribbonOrbRecentItem1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbRecentItem1.SmallImage")));
            this.ribbonOrbRecentItem1.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonOrbRecentItem1.Tag = null;
            this.ribbonOrbRecentItem1.Text = "New";
            this.ribbonOrbRecentItem1.ToolTip = null;
            this.ribbonOrbRecentItem1.ToolTipImage = null;
            this.ribbonOrbRecentItem1.ToolTipTitle = null;
            // 
            // ribbonOrbRecentItem2
            // 
            this.ribbonOrbRecentItem2.AltKey = null;
            this.ribbonOrbRecentItem2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.ribbonOrbRecentItem2.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonOrbRecentItem2.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbRecentItem2.Image")));
            this.ribbonOrbRecentItem2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbRecentItem2.SmallImage")));
            this.ribbonOrbRecentItem2.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonOrbRecentItem2.Tag = null;
            this.ribbonOrbRecentItem2.Text = "Open";
            this.ribbonOrbRecentItem2.ToolTip = null;
            this.ribbonOrbRecentItem2.ToolTipImage = null;
            this.ribbonOrbRecentItem2.ToolTipTitle = null;
            // 
            // ribbonButton13
            // 
            this.ribbonButton13.AltKey = null;
            this.ribbonButton13.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Down;
            this.ribbonButton13.DropDownArrowSize = new System.Drawing.Size(5, 3);
            this.ribbonButton13.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton13.Image")));
            this.ribbonButton13.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton13.SmallImage")));
            this.ribbonButton13.Style = System.Windows.Forms.RibbonButtonStyle.Normal;
            this.ribbonButton13.Tag = null;
            this.ribbonButton13.Text = "Redo";
            this.ribbonButton13.ToolTip = null;
            this.ribbonButton13.ToolTipImage = null;
            this.ribbonButton13.ToolTipTitle = null;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 586);
            this.Controls.Add(this.treeViewContent);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ribbon1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "MiniGIS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.contextMenu_Map.ResumeLayout(false);
            this.contextMenu_Layer.ResumeLayout(false);
            this.contextMenu_MapView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab ribbonTab_Start;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton ribbonButton_NewMap;
        private System.Windows.Forms.RibbonButton ribbonButton_OpenMap;
        private System.Windows.Forms.RibbonButton ribbonButton_SaveMap;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonButton ribbonButton_ZoomIn;
        private System.Windows.Forms.RibbonButton ribbonButton_ZoomOut;
        private System.Windows.Forms.RibbonButton ribbonButton_Pan;
        private System.Windows.Forms.RibbonButton ribbonButton_FullExtent;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonButton ribbonButton_AddShapeFileLayer;
        private System.Windows.Forms.RibbonButton ribbonButton_NewLayer;
        private System.Windows.Forms.RibbonButton ribbonButton_AddRasterFileLayer;
        private System.Windows.Forms.RibbonPanel ribbonPanel4;
        private System.Windows.Forms.RibbonButton ribbonButton_ConnectDB;
        private System.Windows.Forms.RibbonButton ribbonButton_DisConnectDB;
        private System.Windows.Forms.RibbonButtonList ribbonButtonList1;
        private System.Windows.Forms.RibbonButtonList ribbonButtonList2;
        private System.Windows.Forms.RibbonButtonList ribbonButtonList3;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator1;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator2;
        private System.Windows.Forms.RibbonOrbMenuItem ribbonOrbMenuItem1;
        private System.Windows.Forms.RibbonTab ribbonTab2;
        private System.Windows.Forms.RibbonPanel ribbonPanel5;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator3;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator4;
        private System.Windows.Forms.RibbonTab ribbonTab4;
        private System.Windows.Forms.RibbonOrbMenuItem ribbonOrbMenuItem2;
        private System.Windows.Forms.RibbonOrbRecentItem ribbonOrbRecentItem1;
        private System.Windows.Forms.RibbonOrbRecentItem ribbonOrbRecentItem2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RibbonButton ribbonButton13;
        private System.Windows.Forms.TreeView treeViewContent;
        private System.Windows.Forms.RibbonButton ribbonButton_FirstExtent;
        private System.Windows.Forms.RibbonButton ribbonButton_PreviousExtent;
        private System.Windows.Forms.RibbonButton ribbonButton_NextExtent;
        private System.Windows.Forms.RibbonButton ribbonButton_LastExtent;
        private System.Windows.Forms.RibbonButton ribbonButton_AddPostGISLayer;
        private System.Windows.Forms.ContextMenuStrip contextMenu_Map;
        private System.Windows.Forms.ToolStripMenuItem saveMap;
        private System.Windows.Forms.ToolStripMenuItem removeMap;
        private System.Windows.Forms.ToolStripMenuItem propetryMap;
        private System.Windows.Forms.ContextMenuStrip contextMenu_Layer;
        private System.Windows.Forms.ToolStripMenuItem saveLayer;
        private System.Windows.Forms.ToolStripMenuItem toggleLayer;
        private System.Windows.Forms.ToolStripMenuItem propetryLayer;
        private System.Windows.Forms.ToolStripMenuItem newField;
        private System.Windows.Forms.ContextMenuStrip contextMenu_MapView;
        private System.Windows.Forms.ToolStripMenuItem zoomIn;
        private System.Windows.Forms.ToolStripMenuItem zoomOut;
        private System.Windows.Forms.ToolStripMenuItem pan;
        private System.Windows.Forms.ToolStripMenuItem fullExtent;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem firstExtent;
        private System.Windows.Forms.ToolStripMenuItem previousExtent;
        private System.Windows.Forms.ToolStripMenuItem nextExtent;
        private System.Windows.Forms.ToolStripMenuItem lastExtent;
        private System.Windows.Forms.ToolStripMenuItem removeLayer;
        private System.Windows.Forms.ToolStripMenuItem viewFields;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem newLayer;
        private System.Windows.Forms.ToolStripMenuItem addShapeFile;
        private System.Windows.Forms.ToolStripMenuItem addPostGIS;
        private System.Windows.Forms.ToolStripMenuItem addRasterFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem removeAllMap;
        private System.Windows.Forms.ToolStripMenuItem removeAllLayer;
        private System.Windows.Forms.RibbonButton ribbonButton_ImportToDB;
        private System.Windows.Forms.RibbonButton ribbonButton_ExportToFile;
        private System.Windows.Forms.RibbonPanel ribbonPanel_Draw;
        private System.Windows.Forms.RibbonButton ribbonButton_Pointer;
        private System.Windows.Forms.RibbonButton ribbonButton_DrawPoint;
        private System.Windows.Forms.RibbonButton ribbonButton_DrawLineString;
        private System.Windows.Forms.RibbonButton ribbonButton_DrawDoubleLineString;
        private System.Windows.Forms.RibbonButton ribbonButton_DrawPolygon;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.ToolStripMenuItem renameMap;
        private System.Windows.Forms.ToolStripMenuItem renameLayer;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_Zoom;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_ScreenPoint;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_Extent;
        private System.Windows.Forms.RibbonButton ribbonButton_DrawRectangle;
        private System.Windows.Forms.ToolStripMenuItem zoomToLayer;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_MapPoint;
        private System.Windows.Forms.ToolStripMenuItem saveAsMap;
        private System.Windows.Forms.ToolStripMenuItem saveAsLayer;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_Scale;
       
    }
}

