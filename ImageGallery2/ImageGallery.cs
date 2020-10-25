using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C1.Win.C1Tile;

namespace ImageGallery2
{
    public partial class ImageGallery : Form
    {
        DataFetcher dataItem = new DataFetcher();
        List<ImageItem> list;
        int checkedItem = 0;
        
        public ImageGallery()
        {
            InitializeComponent();
        }

        private void ImageGallery_Load(object sender, EventArgs e)
        {
           
        }

        //panel of search text box
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle r = textbox1.Bounds;
            r.Inflate(3, 3);
            Pen p = new Pen(Color.LightGray);
            e.Graphics.DrawRectangle(p, r);
        }

        // search button
        private async void searchButton_Click(object sender, EventArgs e)
        { 
            statusStrip1.Visible = true;
            list = await 
                dataItem.GetImageData(textbox1.Text);
            AddTiles(list);
            statusStrip1.Visible = false;
        }
        private void AddTiles(List<ImageItem> imageList)
        {
            tiles.Groups[0].Tiles.Clear();
            foreach (var imageitem in imageList)
            {
                Tile tile = new Tile();
                tile.HorizontalSize = 2;
                tile.VerticalSize = 2;
                tiles.Groups[0].Tiles.Add(tile);
                Image img = Image.FromStream(new MemoryStream(imageitem.Base64));
                Template tl = new Template();
                ImageElement ie = new ImageElement();
                ie.ImageLayout = ForeImageLayout.Stretch;
                tl.Elements.Add(ie);
                tile.Template = tl;
                tile.Image = img;
            }
        }


        private void saveButton_Click(object sender, EventArgs e)
        {
            List<Image> picture = new List<Image>();
            foreach (Tile tile in tiles.Groups[0].Tiles)
            {
                if (tile.Checked)
                {
                    picture.Add(tile.Image);
                }
            }
            SaveFileDialog f = new SaveFileDialog();
            f.DefaultExt = "jpg";
            f.Filter = "Image files (*.jpg, *.png) | *.jpg; *.png";
            if (f.ShowDialog() == DialogResult.OK)
            {
                foreach (var img in picture)
                {
                    Image myImage = img;
                    myImage.Save(f.FileName);

                }

            }
        }

        //export pdf button
        private void exportButton_Click(object sender, EventArgs e)
        {
            List<Image> images = new List<Image>();
            foreach (Tile tile in tiles.Groups[0].Tiles)
            {
                if (tile.Checked)
                {
                    images.Add(tile.Image);
                }
            }
            ConvertToPdf(images);
            statusStrip1.Visible = true;
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = "pdf";
            saveFile.Filter = "PDF files (*.pdf)|*.pdf*";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                pdfDocument.Save(saveFile.FileName);
                statusStrip1.Visible = false;
            }
        }


        private void ConvertToPdf(List<Image> images)
        {
            RectangleF rect = pdfDocument.PageRectangle;
            bool firstPage = true;
            foreach (var selectedimg in images)
            {
                if (!firstPage)
                {
                    pdfDocument.NewPage();
                }
                firstPage = false;
                rect.Inflate(-72, -72);
                pdfDocument.DrawImage(selectedimg, rect);
            }
        }

        private void exportButton_Paint(object sender, PaintEventArgs e)
        {
            Rectangle r = new Rectangle(exportButton.Location.X, exportButton.Location.Y, exportButton.Width, exportButton.Height);
            r.X -= 29;
            r.Y -= 3;
            r.Width--;
            r.Height--;
            Pen p = new Pen(Color.LightGray);
            e.Graphics.DrawRectangle(p, r);
            e.Graphics.DrawLine(p, new Point(0, 43), new Point(this.Width, 43));
        }

        //tiles
        private void tiles_Paint(object sender,PaintEventArgs e)
        {
            Pen p = new Pen(Color.LightGray);
            e.Graphics.DrawLine(p, 0, 43, 800, 43);
        }

        private void tiles_TileChecked(object sender,C1.Win.C1Tile.TileEventArgs e)
        {
            checkedItem++;
            exportButton.Visible = true;
            saveButton.Visible = true;
        }

        private void tiles_TileUnchecked(object sender, C1.Win.C1Tile.TileEventArgs e)
        {
            checkedItem--;
            exportButton.Visible = checkedItem > 0;
            saveButton.Visible = checkedItem > 0;
        }
    }
}
