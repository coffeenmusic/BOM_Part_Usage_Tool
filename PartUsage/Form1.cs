using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;
using System.Linq;
using LinqToExcel;

namespace PartUsage
{
    public partial class Form1 : Form
    {
        SQLiteConnection c;
        string sql_db_filename = "partusage.sqlite";
        string base_dir = "";
        string correct_dir_delimeter = "Assembly";
        //List<string> headers = new List<string>(new string[] {"Item", "Qty", "Ref-Des", "Neoventus P/N", "Value", "Description", "Package", "Manufacturer 1", "Manufacturer 2", "Mfgr1 Part Number", "Mfgr2 Part Number"});
        List<string> hdr_qty = new List<string>(new string[] {"Quantity", "Qty"});
        List<string> hdr_item_num = new List<string>(new string[] { "Item", "#"});
        List<string> hdr_refdes = new List<string>(new string[] { "Ref-Des", "Refdes" });
        List<string> hdr_prt_num = new List<string>(new string[] { "Neoventus P/N", "Neoventus Part", "Part Number", "Part #", "Device"});
        List<string> hdr_value = new List<string>(new string[] { "Value"});
        List<string> hdr_description = new List<string>(new string[] { "Description", "Desc"});
        List<string> hdr_package = new List<string>(new string[] { "Package", "Pkg"});
        List<string> hdr_manufacturer = new List<string>(new string[] { "Manufacturer", "Manufacturer1", "Manufacturer 1", "Mfgr1"});
        List<string> hdr_mfr_num = new List<string>(new string[] { "Mfgr1 Part Number", "MFGR1_PART_NUMBER"});

        public Form1()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            pbMain.Visible = false;
            directoriesNotAddedToolStripMenuItem.Visible = false;

            if (!File.Exists(sql_db_filename))
            {
                Console.WriteLine("Creating Sqlite File");
                SQLiteConnection.CreateFile(sql_db_filename);
            }

            create_tables();

            List<string> dirs = sql_get_dirs_list(); // Get paths to BOM xlsx files
            if(dirs.Count > 0)
            {
                init_header_vars(); // Add lower and upper case values to header values in xlsx files
            }                      
        }

        // Header variables in xlsx files to look for. Add upper and lower case.
        private void init_header_vars()
        {
            hdr_item_num.AddRange(list_add_upper_lower(hdr_item_num));
            hdr_qty.AddRange(list_add_upper_lower(hdr_qty));
            hdr_refdes.AddRange(list_add_upper_lower(hdr_refdes));
            hdr_prt_num.AddRange(list_add_upper_lower(hdr_prt_num));
            hdr_value.AddRange(list_add_upper_lower(hdr_value));
            hdr_description.AddRange(list_add_upper_lower(hdr_description));
            hdr_package.AddRange(list_add_upper_lower(hdr_package));
            hdr_manufacturer.AddRange(list_add_upper_lower(hdr_manufacturer));
            hdr_mfr_num.AddRange(list_add_upper_lower(hdr_mfr_num));
        }

        private List<string> list_add_upper_lower(List<string> list)
        {
            List<string> new_items = new List<string>();
            foreach (var r in list)
            {
                string upper = r.ToString().ToUpper();
                string lower = r.ToString().ToLower();
                if(!list.Contains(upper)){
                    new_items.Add(upper);
                }
                if (!list.Contains(lower))
                {
                    new_items.Add(lower);
                } 
            }
            return new_items;
        }

        private void create_tables()
        {
            c = new SQLiteConnection("Data Source=" + sql_db_filename + ";Version=3;");
            c.Open();

            string sql = "CREATE TABLE paths (ID INTEGER PRIMARY KEY AUTOINCREMENT, PATH VARCHAR(500) UNIQUE)";
            SQLiteCommand cmd = new SQLiteCommand(sql, c);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {

            }

            sql = "CREATE TABLE part_usage (ID INTEGER PRIMARY KEY AUTOINCREMENT, PATH VARCHAR(500), PART_NUM VARCHAR(30), MFR_PART_NUM VARCHAR(100), UNIQUE(PATH, PART_NUM, MFR_PART_NUM))";
            cmd = new SQLiteCommand(sql, c);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {

            }
            

            c.Close();

            //sql = "CREATE TABLE parts (ID INTEGER PRIMARY KEY AUTOINCREMENT, CLIENT VARCHAR(50))";
        }

        private void sql_replace_drive_letter(string letter)
        {
            c.Open();
            letter += @":\";
            string sql = "UPDATE paths SET path=replace(path, (SELECT substr(path, 0, instr(path, '\\')) || '\\' AS drive_letter FROM paths), @letter) WHERE path LIKE (SELECT substr(path, 0, instr(path, '\\')) || '\\' AS drive_letter FROM paths)||'%';";
            SQLiteCommand cmd = new SQLiteCommand(sql, c);
            cmd.Parameters.AddWithValue("@letter", letter);
            cmd.ExecuteNonQuery();

            sql = "UPDATE part_usage SET path=replace(path, (SELECT substr(path, 0, instr(path, '\\')) || '\\' AS drive_letter FROM part_usage), @letter) WHERE path LIKE (SELECT substr(path, 0, instr(path, '\\')) || '\\' AS drive_letter FROM part_usage)||'%';";
            cmd = new SQLiteCommand(sql, c);
            cmd.Parameters.AddWithValue("@letter", letter);
            cmd.ExecuteNonQuery();
            c.Close();
        }

        private void sql_add_path(string path)
        {
            string sql = "INSERT OR REPLACE INTO paths (PATH) VALUES (@path);";
            SQLiteCommand cmd = new SQLiteCommand(sql, c);
            cmd.Parameters.AddWithValue("@path", path);
            cmd.ExecuteNonQuery();
        }

        private void sql_drop_table(string table)
        {
            c.Open();
            string sql = string.Format("DROP TABLE IF EXISTS {0}", table);
            SQLiteCommand cmd = new SQLiteCommand(sql, c);
            cmd.ExecuteNonQuery();
            c.Close();
        }

        private void sql_add_prt_dt(DataTable dt)
        {
            c.Open();
            string sql = "INSERT OR REPLACE INTO part_usage (PATH, PART_NUM, MFR_PART_NUM) VALUES (@path, @num, @mfr_num);";
            SQLiteCommand cmd;
            foreach (DataRow r in dt.Rows)
            {
                cmd = new SQLiteCommand(sql, c);
                cmd.Parameters.AddWithValue("@path", r["path"]);
                cmd.Parameters.AddWithValue("@num", r["prt_num"]);
                cmd.Parameters.AddWithValue("@mfr_num", r["mfr_prt_num"]);
                cmd.ExecuteNonQuery();
            }
            c.Close();
        }

        
        private List<string> sql_get_dirs_list()
        {
            List<string> dirs = new List<string>();
            c = new SQLiteConnection("Data Source=" + sql_db_filename + ";Version=3;");
            c.Open();

            string sql = "SELECT PATH FROM PATHS";
            SQLiteCommand command = new SQLiteCommand(sql, c);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                
                dirs.Add(reader["PATH"].ToString());
            }

            c.Close();

            return dirs;
        }

        private void update_directories(object sender)
        {
            c = new SQLiteConnection("Data Source=" + sql_db_filename + ";Version=3;");
            c.Open();

            TraverseTree(sender, base_dir);

            c.Close();
        }

        List<string> dirsNotAdded = new List<string>();
        private void update_parts(object sender)
        {
            var bw = sender as BackgroundWorker;
            progress_bar_cnt = 0;

            List<string> dirs = sql_get_dirs_list();

            c.Close();

            foreach(string dir in dirs)
            {
                if (dir.StartsWith("N:\\Clients\\GEIP\\Charlottesville\\Spruce_Display\\IDM\\Hardware"))
                {
                    Console.WriteLine("Found");
                }

                bool foundHeader = false;
                try
                {
                    foundHeader = getExcelColumnData(dir);
                }
                catch
                {
                    Console.WriteLine(dir + " Not Added");
                    dirsNotAdded.Add(dir);
                }

                if (!foundHeader)
                {
                    Console.WriteLine(dir + " Not Added");
                    dirsNotAdded.Add(dir);
                }
                else
                {
                    Console.WriteLine("Added Successfully: " + dir);
                }

                progress_bar_cnt++;

                // Update Progress bar
                bw.ReportProgress(progress_bar_cnt);
            }
        }

        int progress_bar_cnt;
        public void TraverseTree(object sender, string root)
        {
            var bw = sender as BackgroundWorker;
            bool first_subdir_set = true;
            Stack<string> first_subdirs = new Stack<string>(200);
            progress_bar_cnt = 0;


            // Data structure to hold names of subfolders to be
            // examined for files.
            Stack<string> dirs = new Stack<string>(200);

            if (!System.IO.Directory.Exists(root))
            {
                throw new ArgumentException();
            }
            dirs.Push(root);

            while (dirs.Count > 0)
            {
                string currentDir = dirs.Pop();
                string[] subDirs;
                try
                {
                    subDirs = System.IO.Directory.GetDirectories(currentDir);

                    // Progress Bar Logic
                    if (first_subdir_set)
                    {
                        foreach(string dir in subDirs)
                        {
                            first_subdirs.Push(dir);
                        }
                        first_subdir_set = false;
                    }
                    if(first_subdirs.Count > 0)
                    {
                        if (currentDir == first_subdirs.First())
                        {
                            first_subdirs.Pop();
                            progress_bar_cnt++;

                            // Update Progress bar
                            bw.ReportProgress(progress_bar_cnt);
                        }
                    }                    
                }
                // An UnauthorizedAccessException exception will be thrown if we do not have
                // discovery permission on a folder or file. It may or may not be acceptable 
                // to ignore the exception and continue enumerating the remaining files and 
                // folders. It is also possible (but unlikely) that a DirectoryNotFound exception 
                // will be raised. This will happen if currentDir has been deleted by
                // another application or thread after our call to Directory.Exists. The 
                // choice of which exceptions to catch depends entirely on the specific task 
                // you are intending to perform and also on how much you know with certainty 
                // about the systems on which this code will run.
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                catch (System.IO.DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                
                string currentFolder = currentDir.Substring(currentDir.LastIndexOf('\\') + 1);

                if (currentFolder == correct_dir_delimeter)
                {
                    add_files(currentDir);
                }

                // Push the subdirectories onto the stack for traversal.
                // This could also be done before handing the files.
                foreach (string str in subDirs)
                    dirs.Push(str);
            }
        }

        private void add_files(string dir)
        {
            string[] files = null;
            try
            {
                files = System.IO.Directory.GetFiles(dir);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            // Perform the required action on each file here.
            // Modify this block to perform your required task.
            foreach (string file in files)
            {
                try
                {
                    // Perform whatever action is required in your scenario.
                    System.IO.FileInfo fi = new System.IO.FileInfo(file);
                    if ((fi.Extension == ".xlsx" || fi.Extension == ".xls") && !fi.Name.StartsWith("~"))
                    {
                        Console.WriteLine(fi.Name);
                        sql_add_path(file);
                    }
                }
                catch (System.IO.FileNotFoundException e)
                {
                    // If file was deleted by a separate application
                    //  or thread since the call to TraverseTree()
                    // then just continue.
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
        }



        private bool getExcelColumnData(string pathToExcelFile)
        {
            var excelFile = new ExcelQueryFactory(pathToExcelFile);
            //var sheetname = excelFile.GetWorksheetNames().First();
            //var sheet = excelFile.WorksheetNoHeader(sheetname);
            var worksheets = excelFile.GetWorksheetNames();

            //var sheet = excelFile.WorksheetNoHeader();
            bool foundHeader = false, foundNeoNumHdr = false, foundMfrNumHdr = false;

            int idx_item_num = 0, idx_qty = 0, idx_refdes = 0, idx_prt_num = 0, 
                idx_value = 0, idx_desc = 0, idx_pkg = 0, idx_mfr = 0, idx_mfr_prt_num = 0;

            DataTable dt = new DataTable();
            dt.Clear();
            //dt.Columns.Add("item");
            //dt.Columns.Add("qty");
            //dt.Columns.Add("refdes");
            dt.Columns.Add("prt_num");
            //dt.Columns.Add("value");
            //dt.Columns.Add("desc");
            //dt.Columns.Add("pkg");
            //dt.Columns.Add("mfr");
            dt.Columns.Add("mfr_prt_num");
            dt.Columns.Add("path");

            foreach (var sheetname in worksheets)
            {
                var sheet = excelFile.WorksheetNoHeader(sheetname);

                if (foundHeader)
                {
                    break;
                }

                foreach (var r in sheet)
                {
                    DataRow row = dt.NewRow();

                    if (foundHeader)
                    {
                        //row["item"] = r[idx_item_num];
                        //row["qty"] = r[idx_qty];
                        //row["refdes"] = r[idx_refdes];
                        row["prt_num"] = r[idx_prt_num];
                        //row["value"] = r[idx_value];
                        //row["desc"] = r[idx_desc];
                        //row["pkg"] = r[idx_pkg];
                        //row["mfr"] = r[idx_mfr];
                        row["mfr_prt_num"] = r[idx_mfr_prt_num];
                        row["path"] = pathToExcelFile;

                        if (r[idx_prt_num].Value.ToString().Length >= 6)
                        {
                            dt.Rows.Add(row);
                        }
                    }
                    else
                    {
                        foreach (var c in r)
                        {
                            if (hdr_item_num.Contains(c.Value.ToString()))
                            {
                                idx_item_num = r.IndexOf(c);
                                //foundHeader = true;
                            }
                            else if (hdr_qty.Contains(c.Value.ToString()))
                            {
                                idx_qty = r.IndexOf(c);
                                //foundHeader = true;
                            }
                            else if (hdr_refdes.Contains(c.Value.ToString()))
                            {
                                idx_refdes = r.IndexOf(c);
                                //foundHeader = true;
                            }
                            else if (hdr_prt_num.Contains(c.Value.ToString()))
                            {
                                idx_prt_num = r.IndexOf(c);
                                //foundHeader = true;
                                foundNeoNumHdr = true;
                            }
                            else if (hdr_value.Contains(c.Value.ToString()))
                            {
                                idx_value = r.IndexOf(c);
                                //foundHeader = true;
                            }
                            else if (hdr_description.Contains(c.Value.ToString()))
                            {
                                idx_desc = r.IndexOf(c);
                                //foundHeader = true;
                            }
                            else if (hdr_package.Contains(c.Value.ToString()))
                            {
                                idx_pkg = r.IndexOf(c);
                                //foundHeader = true;
                            }
                            else if (hdr_manufacturer.Contains(c.Value.ToString()))
                            {
                                idx_mfr = r.IndexOf(c);
                                //foundHeader = true;
                            }
                            else if (hdr_mfr_num.Contains(c.Value.ToString()))
                            {
                                idx_mfr_prt_num = r.IndexOf(c);
                                //foundHeader = true;
                                foundMfrNumHdr = true;
                            }

                            if (foundNeoNumHdr && foundMfrNumHdr)
                            {
                                foundHeader = true;
                            }
                        }
                    }
                }
            }

            sql_add_prt_dt(dt);

            return foundHeader;
        }

        private BindingSource sql_get_part_usage(string search)
        {
            DataTable dt = new DataTable();
            string sql = string.Format("SELECT * FROM part_usage WHERE part_num LIKE '%{0}%' OR mfr_part_num LIKE '%{0}%'", search);
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, c);
            da.AcceptChangesDuringUpdate = true;
            da.AcceptChangesDuringFill = true;

            //fill the DataTable
            da.Fill(dt);

            //set the BindingSource DataSource
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            return bs;
        }

        private void txtSearchParts_TextChanged(object sender, EventArgs e)
        {
            dgvPartUsage.DataSource = sql_get_part_usage(txtSearchParts.Text);
            dgvPartUsage.Columns["ID"].Visible = false;
        }

        private void dgvPartUsage_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int r_idx = e.RowIndex;
            string path = dgvPartUsage.Rows[r_idx].Cells["Path"].Value.ToString();
            path = path.Substring(0, path.LastIndexOf('\\'));
            System.Diagnostics.Process.Start(path);
        }

        private void clearDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sql_drop_table("paths");
            sql_drop_table("part_usage");
            create_tables();
        }

        private void replaceDriveLetterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Drive_Letter l = new Drive_Letter();
            l.ShowDialog(); // waits for user input

            sql_replace_drive_letter(l.get_drive_letter());
        }

        private void bOMDirectoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> dirs = sql_get_dirs_list();
            BOM_Directories bdir = new BOM_Directories(dirs);
            bdir.Show();
        }

        private void addNewDirectoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    base_dir = fbd.SelectedPath.ToString();

                    DialogResult dialogResult = MessageBox.Show("It may take some time to search all directories and sub-directories. You can view all BOM directories already added at 'View -> BOM Directories'. Are you sure you would like to continue?", "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        pbMain.Visible = true;

                        // Initialize progress bar
                        pbMain.Maximum = System.IO.Directory.GetDirectories(base_dir).Count();
                        pbMain.Step = 1;
                        pbMain.Value = 0;

                        backgroundWorkerSearchDirectories.RunWorkerAsync();
                    }
                }
            }
        }

        private void addNewPartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("This will search all BOM *.xlsx files for parts and may take a while. Are you sure you would like to continue?", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                List<string> dirs = sql_get_dirs_list();

                // Verify paths
                if (dirs.Count > 0)
                {
                    string test_path = dirs[0].ToString();
                    test_path = test_path.Substring(0, test_path.LastIndexOf('\\'));

                    

                    if (Directory.Exists(test_path))
                    {
                        pbMain.Visible = true;

                        // Initialize progress bar
                        pbMain.Maximum = dirs.Count;
                        pbMain.Step = 1;
                        pbMain.Value = 0;

                        backgroundWorkerAddParts.RunWorkerAsync();
                    }
                    else
                    {
                        dialogResult = MessageBox.Show("Directory cannot be found, would you like to replace the drive letter?", "Warning", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            // Replace drive letter
                            Drive_Letter l = new Drive_Letter();
                            l.ShowDialog(); // waits for user input

                            sql_replace_drive_letter(l.get_drive_letter());
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Warning", "No directories currently found. Please run a directory search.");
                }
            }
        }

        private void backgroundWorkerSearchDirectories_DoWork(object sender, DoWorkEventArgs e)
        {
            update_directories(sender);
        }

        private void backgroundWorkerSearchDirectories_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbMain.Value = e.ProgressPercentage;
        }

        private void backgroundWorkerSearchDirectories_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbMain.Visible = false;
        }

        private void backgroundWorkerAddParts_DoWork(object sender, DoWorkEventArgs e)
        {
            update_parts(sender);
        }

        private void backgroundWorkerAddParts_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbMain.Value = e.ProgressPercentage;
        }

        private void backgroundWorkerAddParts_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbMain.Visible = false;
            if (dirsNotAdded != null)
            {
                if (dirsNotAdded.Count > 0)
                {
                    directoriesNotAddedToolStripMenuItem.Visible = true;

                    DirectoriesNotAdded na = new DirectoriesNotAdded(dirsNotAdded);
                    na.Show();
                }
            }
        }

        private void directoriesNotAddedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dirsNotAdded != null)
            {
                if(dirsNotAdded.Count > 0)
                {
                    DirectoriesNotAdded na = new DirectoriesNotAdded(dirsNotAdded);
                    na.Show();
                }
            }
            else
            {
                MessageBox.Show("This list is only available after adding parts. It will list any directories that had problems adding parts.");
            }            
        }
    }
}
