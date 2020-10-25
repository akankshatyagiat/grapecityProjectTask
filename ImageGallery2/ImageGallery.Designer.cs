using C1.Framework;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace ImageGallery2
{
    partial class ImageGallery
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
            this.splitContainer1 = new SplitContainer();
            this.table = new TableLayoutPanel();
            this.panel1 = new Panel();
            this.panel2 = new Panel();
            this.textbox1 = new TextBox();
            this.searchButton = new C1.Win.C1Input.C1PictureBox();
            this.saveButton = new C1.Win.C1Input.C1PictureBox();
            this.exportButton = new C1.Win.C1Input.C1PictureBox();
            this.tiles = new C1.Win.C1Tile.C1TileControl();
            this.group1 = new C1.Win.C1Tile.Group();
            this.statusStrip1 = new StatusStrip();
            this.toolStripProgressBar1 = new ToolStripProgressBar();
            this.pdfDocument=new C1.C1Pdf.C1PdfDocument();

            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(2);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            splitContainer1.Size = new Size(762, 753);
            splitContainer1.SplitterDistance = 40;
            splitContainer1.TabIndex = 0;
            splitContainer1.Panel1.Controls.Add(table);
            splitContainer1.Panel2.Controls.Add(exportButton);
            splitContainer1.Panel2.Controls.Add(tiles);
            splitContainer1.Panel2.Controls.Add(statusStrip1);


            //table
            table.ColumnCount = 3;
            table.RowCount = 2;
            table.Dock = DockStyle.Fill;
            table.Location = new Point(0, 0);
            table.Size = new Size(800, 40);
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));  //column 1
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            table.Controls.Add(panel1, 1, 0);
            table.Controls.Add(panel2, 2, 0);
            //panel1 in table column 2
            panel1.Location = new Point(477, 0);
            panel1.Size = new Size(287, 40);
            panel1.Dock = DockStyle.Fill;
            panel1.Controls.Add(textbox1);
            panel1.Paint += new PaintEventHandler(this.panel1_Paint);

            //panel 2 in column 3
            panel2.Location = new Point(471, 12);
            panel2.Margin = new Padding(2,12,45,12);
            panel2.Size = new Size(250,30);
            panel2.TabIndex = 1;
            panel2.Controls.Add(searchButton);
            panel2.Controls.Add(saveButton);

            //textbox
            textbox1.BorderStyle = BorderStyle.None;
            textbox1.Name = "_searchBox";
            textbox1.Dock = DockStyle.Fill;
            textbox1.Location = new Point(16, 9);
            textbox1.Size = new Size(244, 50);
            textbox1.Text = "Search Image";
            textbox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;

            //search picture box button
            searchButton.Name = "_search";
            searchButton.Dock = DockStyle.Left;
            searchButton.Location = new Point(0, 0);
            //searchButton.Margin = new Padding(0);
            searchButton.Size = new Size(50,25);
            searchButton.SizeMode = PictureBoxSizeMode.Zoom;
            searchButton.Image = global::ImageGallery2.Properties.Resources.searchIcon;
            searchButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            searchButton.Click += new EventHandler(this.searchButton_Click);

            //exportbutton
            exportButton.Name = "_exportBtn";
            exportButton.Visible = false;
            exportButton.Location = new Point(29,3);
            exportButton.Size = new Size(256, 28);
            exportButton.SizeMode = PictureBoxSizeMode.Zoom;
            exportButton.Image = global::ImageGallery2.Properties.Resources.iconPDF;
            exportButton.TabIndex = 2;
            exportButton.Click+= new EventHandler(this.exportButton_Click);
            exportButton.Paint += new PaintEventHandler(this.exportButton_Paint);

            // save button
            saveButton.Name = "_saveBtn";
            saveButton.Visible = false;
            saveButton.Location = new Point(80,0);
            saveButton.Size = new Size(50,25);
            saveButton.Dock = DockStyle.Right;
            saveButton.SizeMode = PictureBoxSizeMode.Zoom;
            saveButton.Image = global::ImageGallery2.Properties.Resources.saveButton;
            saveButton.Click += new EventHandler(this.saveButton_Click);

            //tiles 
            //tiles.AllowRearranging = false;
            tiles.AllowChecking = true;
            tiles.Name = "_tilesControl";
            tiles.AutomaticLayout = true;
            tiles.MaximumRowsOrColumns = 0;
            tiles.CellHeight = 78;
            tiles.CellWidth = 78;
            tiles.CellSpacing =11;
            tiles.TabIndex = 2;
            tiles.Orientation =C1.Win.C1Tile.LayoutOrientation.Vertical;
            tiles.Dock = DockStyle.Fill;
            tiles.Size = new Size(764,718);
            tiles.IsAccessible = true;
            tiles.SurfacePadding = new Padding(12,4,12,4);
            tiles.SwipeDistance = 20;
            tiles.SwipeRearrangeDistance = 98;
            tiles.Paint += new PaintEventHandler(this.tiles_Paint);
            tiles.TileChecked += new EventHandler<C1.Win.C1Tile.TileEventArgs>(this.tiles_TileChecked);
            tiles.TileUnchecked += new EventHandler<C1.Win.C1Tile.TileEventArgs>(this.tiles_TileUnchecked);
            tiles.Groups.Add(this.group1);

            //
            group1.Name = "group1";
            //group1.TileControl.TileChecked+= new EventHandler<C1.Win.C1Tile.TileEventArgs>(this.tiles_TileChecked);
            //group1.TileControl.TileUnchecked+= new EventHandler<C1.Win.C1Tile.TileEventArgs>(this.tiles_TileUnchecked);

            //statusStrip
            statusStrip1.Items.AddRange(new ToolStripItem[] {
            toolStripProgressBar1});
            statusStrip1.Location = new Point(0, 687);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(762, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            statusStrip1.Visible = false;
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(200, 16);
            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;

            // ImageGallery
            // 
            this.ClientSize = new System.Drawing.Size(762, 753);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MaximumSize = new Size(810, 810);
            this.Name = "ImageGallery";
            this.ShowIcon = false;
            //this.StartPosition = FormStartPosition.CenterParent;

        }

        private SplitContainer splitContainer1;
        private TableLayoutPanel table;
        private Panel panel1;
        private Panel panel2;
        private TextBox textbox1;
        private C1.Win.C1Input.C1PictureBox searchButton;
        private C1.Win.C1Input.C1PictureBox saveButton;
        private C1.Win.C1Input.C1PictureBox exportButton;
        private C1.Win.C1Tile.C1TileControl tiles;
        private C1.Win.C1Tile.Group group1;
        private StatusStrip statusStrip1;
        private ToolStripProgressBar toolStripProgressBar1;
        private C1.C1Pdf.C1PdfDocument pdfDocument;
    }
}
#endregion