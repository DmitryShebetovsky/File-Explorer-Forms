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
using System.Diagnostics;

namespace FileExplorer
{
    public partial class Form1 : Form
    {
        private const int BYTE_IN_KILOBYTE = 1000;
        private const int COLUMN_WIDTH = 120;   
        private string topLevelName = "Этот компьютер";                                                              
        private string[] viewModes = { "Крупные значки", "Мелкие значки", "Список", "Таблица", "Плитка" };           
        private Dictionary<string, int> columnsFiles = new Dictionary<string, int>();                       
        private Dictionary<string, int> columnsDrives = new Dictionary<string, int>();                         
        private string[] columnsForFiles = { "Имя", "Размер", "Дата создания", "Дата изменения" };          
        private string[] columnsForDrives = { "Имя", "Тип", "Файловая система", "Общий размер", "Свободно" };        
        private List<FileSystemInfo> fileSystemItems = new List<FileSystemInfo>();                            
       // private IconCache iconCache = new IconCache();                                                                                                          

      public Form1()
        {
            InitializeComponent();
            Application.ThreadException += Application_ThreadException;
            foreach (string column in columnsForFiles)
            {
                columnsFiles.Add(column, COLUMN_WIDTH);
            }
            foreach (string column in columnsForDrives)
            {
                columnsDrives.Add(column, COLUMN_WIDTH);
            }
            foreach (string item in viewModes)
            {
                toolStripComboBox1.Items.Add(item);
            }
            toolStripComboBox1.SelectedIndex = 0;
            toolStripComboBox1.SelectedIndexChanged += toolStripComboBox1_SelectedIndexChanged;
            lv_files.MouseDoubleClick += lv_files_MouseDoubleClick;
            //lv_files.ColumnClick += lv_files_ColumnClick;
            lv_files.View = View.LargeIcon;
            tsl_path.Text = topLevelName;
            tv_files.BeforeExpand += tv_files_BeforeExpand;
            tv_files.AfterSelect += tv_files_AfterSelect;
            tv_files.AfterLabelEdit += tv_files_AfterLabelEdit;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowDrives();
        }
        
        void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (toolStripComboBox1.SelectedItem.ToString())
            {
                case "Крупные значки":
                    lv_files.View = View.LargeIcon;
                    break;
                case "Мелкие значки":
                    lv_files.View = View.SmallIcon;
                    break;
                case "Таблица":
                    lv_files.View = View.Details;
                    lv_files.FullRowSelect = true;
                    break;
                case "Список":
                    lv_files.View = View.List;
                    break;
                case "Плитка":
                    lv_files.View = View.Tile;
                    break;
                default:
                    MessageBox.Show("Неизвестный режим отображения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
        void lv_files_MouseDoubleClick(object sender, MouseEventArgs e)
        {


            ListViewItem selection = lv_files.GetItemAt(e.X, e.Y);

            object tag = selection.Tag;
            if (tag is FileInfo)
            {
                Process.Start(((FileInfo)tag).FullName);
                return;
            }

            string path = null;
            if (tag is DriveInfo)
            {
                path = ((DriveInfo)tag).RootDirectory.ToString();
            }
            else if (tag is DirectoryInfo)
            {
                path = ((DirectoryInfo)tag).FullName;
            }

            if (SetFileSystemItems(path))
            {
                ShowFileSystemItems();
                tsl_path.Text = path;

                ShowPathInTree(path);
            }
        }

        void tsb_upLevel_Click(object sender, EventArgs e)
        {

            string path = tsl_path.Text;

            if (path == topLevelName)
            {
                return;
            }

            DirectoryInfo currentDirectory = new DirectoryInfo(path);
            DirectoryInfo parentDirectory = currentDirectory.Parent;

            if (parentDirectory != null)
            {
                SetFileSystemItems(parentDirectory.FullName);
                ShowFileSystemItems();
                tsl_path.Text = parentDirectory.FullName;
                ShowPathInTree(tsl_path.Text);
            }
            else
            {
                ShowDrives();
            }
        }
        //void lv_files_ColumnClick(object sender, ColumnClickEventArgs e)
        //{

        //    if (tsl_path.Text == topLevelName)
        //    {
        //        return;
        //    }

        //    int currentColumn = e.Column;
        //    FileSystemComparer currentComparer = (FileSystemComparer)lv_files.ListViewItemSorter;
        //    if (currentComparer == null)
        //    {
        //        currentComparer = new FileSystemComparer();
        //    }
        //    if (currentColumn == currentComparer.columnIndex)
        //    {
        //        if (currentComparer.sortOrder == FileSystemComparer.SORTORDER.ASC)
        //        {
        //            currentComparer.sortOrder = FileSystemComparer.SORTORDER.DESC;
        //            lv_files.Columns[currentColumn].ImageIndex = 3;
        //        }
        //        else
        //        {
        //            currentComparer.sortOrder = FileSystemComparer.SORTORDER.ASC;
        //            lv_files.Columns[currentColumn].ImageIndex = 2;
        //        }
        //    }
        //    else
        //    {
        //        lv_files.Columns[currentComparer.columnIndex].ImageIndex = -1;
        //        lv_files.Columns[currentComparer.columnIndex].TextAlign = HorizontalAlignment.Center;
        //        lv_files.Columns[currentComparer.columnIndex].TextAlign = HorizontalAlignment.Left;

        //        currentComparer.columnIndex = currentColumn;
        //        currentComparer.sortOrder = FileSystemComparer.SORTORDER.ASC;
        //        lv_files.Columns[currentColumn].ImageIndex = 2;
        //    }
        //    lv_files.ListViewItemSorter = currentComparer;
        //    lv_files.Sort();
        //}
        void tv_files_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode currentNode = e.Node;
            
            currentNode.Nodes.Clear();

            string[] directories = Directory.GetDirectories(currentNode.FullPath);
            foreach (string directory in directories)
            {
                TreeNode t = new TreeNode(Path.GetFileName(directory), 0, 1);
                currentNode.Nodes.Add(t);

                try
                {
                    string[] a = Directory.GetDirectories(directory);
                    if (a.Length > 0)
                    {
                        t.Nodes.Add("?");
                    }
                }
                catch { }
            }
        }
        void tv_files_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            string currentPath = e.Node.FullPath;

            selectedNode.Expand();
            if (SetFileSystemItems(currentPath))
            {
                ShowFileSystemItems();
                tsl_path.Text = currentPath;
            }
            else
            {
                ShowPathInTree(tsl_path.Text);
            }
        }
        void tv_files_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            string currentPath = e.Node.FullPath;
            string newDirectoryName = e.Label;

            if (newDirectoryName == null || newDirectoryName.Trim().Length == 0)
            {
                e.CancelEdit = true;
                return;
            }

            string newFullName = Path.Combine(e.Node.Parent.FullPath, newDirectoryName);

            DirectoryInfo currentDirectory = new DirectoryInfo(currentPath);

            try
            {
                currentDirectory.MoveTo(newFullName);

                if (SetFileSystemItems(newFullName))
                {
                    ShowFileSystemItems();
                    tsl_path.Text = newFullName;
                }
            }
            catch
            {
                MessageBox.Show("Невозможно переименовать каталог", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.CancelEdit = true;
            }
        }

        public bool SetFileSystemItems(string path)
        {
  
            try
            {
                string[] access = Directory.GetDirectories(path);
            }
            catch 
            {
                MessageBox.Show("Невозможно прочитать каталог", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (fileSystemItems != null && fileSystemItems.Count != 0)
            {
                fileSystemItems.Clear();
            }
            string[] directories = Directory.GetDirectories(path);
            foreach (string directory in directories)
            {
                DirectoryInfo di = new DirectoryInfo(directory);
                fileSystemItems.Add(di);
            }
 
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                fileSystemItems.Add(fi);
            }

            return true;
        }

        private void ShowFileSystemItems()
        {
            lv_files.BeginUpdate();

            lv_files.Items.Clear();

            if (fileSystemItems == null || fileSystemItems.Count == 0)
            {
                return;
            }
            //SetColumsForFolders();                          

            //iconCache.ClearIconCashAndLists(il_DiscFoldersFilesIcons_Small, il_DiscFoldersFilesIcons_Large);

            ListViewItem lviFile = null;
            foreach (FileSystemInfo file in fileSystemItems)
            {
                    
                lviFile = new ListViewItem();
                lviFile.Tag = file;
                lviFile.Text = file.Name;
                
                if (file is DirectoryInfo)
                {
                    lviFile.ImageIndex = 1;
                    lviFile.SubItems.Add("Каталог");
                }

                else if (file is FileInfo)
                {
                    FileInfo currentFile = file as FileInfo;
                    if (currentFile == null) 
                    {
                        return;
                    }

                    string fileExtention = currentFile.Extension.ToLower();
                    //int iconIndex = iconCache.GetIconIndexByExtention(fileExtention);
                    
                    //if (iconIndex != -1)
                    //{
                    //    lviFile.ImageIndex = iconIndex;
                    //}

                    //else
                    //{
                    //    lviFile.ImageIndex = iconCache.AddIconForFile((FileInfo)file, il_DiscFoldersFilesIcons_Small, il_DiscFoldersFilesIcons_Large);
                    //}
                    //lviFile.SubItems.Add(((FileInfo)file).Length.ToString());
                }
                lviFile.SubItems.Add(file.CreationTime.ToString());
                lviFile.SubItems.Add(file.LastWriteTime.ToString());

                lv_files.Items.Add(lviFile);

                lv_files.EndUpdate();
            }
        }

        private void ShowDrives()
        {
            tsl_path.Text = topLevelName;

            if (lv_files != null && lv_files.Items.Count != 0)
            {
                lv_files.Items.Clear();
            }
            if (tv_files != null && tv_files.Nodes.Count != 0)
            {
                tv_files.Nodes.Clear();
            }

            DriveInfo[] discs = DriveInfo.GetDrives();

            if (discs.Length == 0)
            {
                MessageBox.Show("Диски не обнаружены", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            #region ListView

            //Настройка столбцов для дисков

            SetColumsForDrives();

            ListViewItem lviDisc;
            foreach (DriveInfo disc in discs)
            {
                if (disc.IsReady)
                {
                    string totalSize = String.Format("{0:F2} Гб", (double)disc.TotalSize / (BYTE_IN_KILOBYTE * BYTE_IN_KILOBYTE * BYTE_IN_KILOBYTE));             //в Гб
                    string freeSpace = String.Format("{0:F2} Гб", (double)disc.TotalFreeSpace / (BYTE_IN_KILOBYTE * BYTE_IN_KILOBYTE * BYTE_IN_KILOBYTE));        //в Гб

                    lviDisc = new ListViewItem(disc.Name, 0);
                    lviDisc.SubItems.Add(disc.DriveType.ToString());
                    lviDisc.SubItems.Add(disc.DriveFormat.ToString());
                    lviDisc.SubItems.Add(totalSize);
                    lviDisc.SubItems.Add(freeSpace);

                    lviDisc.Tag = disc;

                    lv_files.Items.Add(lviDisc);
                }
            }
            #endregion

            #region TreeView

            foreach (DriveInfo disc in discs)
            {
                if(disc.IsReady)
                {
                    //Добавить диск

                    TreeNode tnDisc = new TreeNode(disc.Name, 2, 2);
                    tv_files.Nodes.Add(tnDisc);
                
                    //Добавить "+", если есть содержимое

                    try
                    {
                        string[] directoriesInDisc = Directory.GetDirectories(disc.RootDirectory.ToString());
                        if (directoriesInDisc.Length > 0)
                        {
                            TreeNode tempNode = new TreeNode("?");
                            tnDisc.Nodes.Add(tempNode);
                        }
                    }
                    catch { }
                }
            }

            #endregion
        }

        private void ShowPathInTree(string path)
        {

            string[] directories = path.Split('\\');
            string root = Path.GetPathRoot(path);

            TreeNode currentNode = null;
            foreach (TreeNode treeNode in tv_files.Nodes)
            {
                if (treeNode.Text == root)
                {
                    treeNode.Expand();
                    currentNode = treeNode;
                    break;
                }
            }
            for (int i = 1; i < directories.Length; i++)
            {

                if (directories[i].Length == 0) 
                {
                    continue;
                }
                foreach (TreeNode treeNode in currentNode.Nodes)
                {
                    if (treeNode.Text == directories[i])
                    {
                        treeNode.Expand();
                        currentNode = treeNode;
                    }
                }
            }

            tv_files.SelectedNode = currentNode;
        }

        private bool MoveFileObject(FileSystemInfo fsObject, string newPath)
        {
            string message = "";
            try
            {
                if (fsObject is DirectoryInfo)
                {
                    message = "Не возможно переместить каталог";
                    ((DirectoryInfo)fsObject).MoveTo(newPath);
                }
                else
                {
                    message = "Не возможно переместить файл";
                    ((FileInfo)fsObject).MoveTo(newPath);
                }
                return true;
            }
            catch
            {
                MessageBox.Show(message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }
       

        private void SetColumsForDrives()
        {
            if (lv_files.Columns.Count != 0)
            {
                lv_files.Columns.Clear();
            }

            ColumnHeader column = null;
            foreach (KeyValuePair<string, int> item in columnsDrives)
            {
                column = new ColumnHeader();
                column.Text = item.Key;
                column.Width = item.Value;
                column.TextAlign = HorizontalAlignment.Left;
                lv_files.Columns.Add(column);
            }
        }

        //private void SetColumsForFolders()
        //{
        //    if (lv_files.Columns.Count != 0)
        //    {
        //        lv_files.Columns.Clear();
        //    }

        //    int sortedColumnIndex = 0;
        //    FileSystemComparer.SORTORDER sortOrder = FileSystemComparer.SORTORDER.ASC;

        //    FileSystemComparer currentComparer = (FileSystemComparer)lv_files.ListViewItemSorter;
        //    if (currentComparer != null)
        //    {
        //        sortedColumnIndex = currentComparer.columnIndex;
        //        sortOrder = currentComparer.sortOrder;
        //    }

        //    ColumnHeader column = null;
        //    int currentColumnIndex = 0;
        //    foreach (KeyValuePair<string, int> item in columnsFiles)
        //    {
        //        column = new ColumnHeader();
        //        column.Text = item.Key;
        //        column.Width = item.Value;
        //        if (sortedColumnIndex == currentColumnIndex)
        //        {
        //            if (sortOrder == FileSystemComparer.SORTORDER.ASC)
        //            {
        //                column.ImageIndex = 2;
        //            }
        //            else
        //            {
        //                column.ImageIndex = 3;
        //            }
        //        }

        //        lv_files.Columns.Add(column);
        //        currentColumnIndex++;
        //    }
        //}
    }
}