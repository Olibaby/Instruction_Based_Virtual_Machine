using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SML_Extensions
{
    public partial class ImageDisplay : Form
    {
        public ImageDisplay()
        {
            InitializeComponent();
        }

        public Image image;

        private void ImageDisplay_Load(object sender, EventArgs e)
        {
            pictureBox1.Width = 300;
            pictureBox1.Height = 300;
            pictureBox1.Image = image;
        }
    }
}
