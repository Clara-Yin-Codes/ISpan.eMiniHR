using ISpan.eMiniHR.WinApp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISpan.eMiniHR.WinApp.Forms.Base
{
    public partial class UnderMaintenance : UserControl
    {
        public UnderMaintenance()
        {
            InitializeComponent();
        }

        private void UnderMaintenance_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Resources.UnderMaintenance;
        }
    }
}
