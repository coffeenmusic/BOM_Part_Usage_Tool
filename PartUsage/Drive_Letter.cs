using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PartUsage
{
    public partial class Drive_Letter : Form
    {
        public Drive_Letter()
        {
            InitializeComponent();
        }

        public string get_drive_letter()
        {
            return cbDriveLetter.Text;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
