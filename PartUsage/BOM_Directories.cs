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
    public partial class BOM_Directories : Form
    {
        List<string> dirs;

        public BOM_Directories(List<string> dirs)
        {
            InitializeComponent();

            this.dirs = dirs;
            list_directories(dirs);
        }

        private void list_directories(List<string> dirs)
        {
            string matching_sequence = get_common_chars_string(dirs);
            string remove_common_chars = "";
            foreach (string dir in dirs)
            {
                if (chkShowFullPath.Checked)
                {
                    lbDirectories.Items.Add(dir);
                }
                else
                {                    
                    remove_common_chars = dir.Remove(dir.IndexOf(matching_sequence), matching_sequence.Length);
                    lbDirectories.Items.Add(remove_common_chars);
                }                
            }
        }

        private string get_common_chars_string(List<string> dirs)
        {
            bool all_chars_same = true;
            int idx = 0;
            string matching_sequence = "";
            while (all_chars_same)
            {
                string idx_char = "", prev_char = "";
                foreach (string dir in dirs)
                {
                    idx_char = dir[idx].ToString();
                    if (string.IsNullOrEmpty(prev_char))
                    {
                        prev_char = idx_char;
                    }
                    if (idx_char != prev_char)
                    {
                        all_chars_same = false;
                        break;
                    }
                    prev_char = idx_char;
                }
                if (all_chars_same)
                {
                    matching_sequence += idx_char;
                    idx++;
                }
            }
            return matching_sequence;
        }

        private void btnCloseBOMDir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkShowFullPath_CheckedChanged(object sender, EventArgs e)
        {
            lbDirectories.Items.Clear();
            list_directories(dirs);
        }
    }
}
