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
    public partial class DirectoriesNotAdded : Form
    {
        public DirectoriesNotAdded(List<string> dirs)
        {
            InitializeComponent();

            foreach(string dir in dirs)
            {
                lbNotAdded.Items.Add(dir);
            }
        }

        private void btnCloseDirNotAdded_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
