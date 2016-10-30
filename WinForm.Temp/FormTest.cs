using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RecognitionService.Classes;
using WinForm.Temp.Properties;

namespace WinForm.Temp
{
    public partial class FormTest : Form
    {
        private Bitmap _image;
        private Bitmap[] _etalon = new Bitmap[30];
        public FormTest()
        {
            InitializeComponent();
        }

        private void buttonLoadFile_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Title = Resources.OpenImage;
                dlg.Filter = Resources.TypesImages;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxNumber.Image = new Bitmap(dlg.FileName);
                    _image = new Bitmap(dlg.FileName);
                }
            }
        }

        public async void Recognition(Bitmap bmp, Bitmap[] etalonsBmp)
        {
            var service = new RService();
            var answer = await service.ProcessedImages(_image, _etalon);
            MessageBox.Show(answer.ToString());
        }

        private static double Coord(Bitmap first, Bitmap second)
        {
            double distance = 0;
            for (int i = 0; i < first.Width; ++i)
            {
                for (int j = 0; j < first.Height; ++j)
                {
                    distance += Math.Pow(first.GetPixel(i, j).R - second.GetPixel(i, j).R, 2);
                }
            }
            return Math.Pow(distance, 0.5);
        }

        private void buttonLoadEtalons_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Title = Resources.OpenImage;
                dlg.Filter = Resources.TypesImages;
                dlg.Multiselect = true;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var index = 0;
                    _etalon = new Bitmap[dlg.FileNames.Length];
                    foreach (var item in dlg.FileNames)
                    {
                        _etalon[index] = new Bitmap(item);
                        index++;
                    }
                    MessageBox.Show(index.ToString());
                }
            }
        }

        private void buttonRecognition_Click(object sender, EventArgs e)
        {
            Recognition(_image, _etalon);
        }
    }
}
