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
using System.Threading;
using TagLib;
using TagLib.Aiff;
using File = System.IO.File;

namespace MusicRenamer
{

    public partial class Form1 : Form
    {
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        string[] files;
        private string path;
        private String fullFilePath;
        private TagLib.File[] files2;
        private int oldIdx;

        public Form1()
        {
            InitializeComponent();
        }

        //click on select folder
        private void btnFolders_Click(object sender, EventArgs e)
        {
            fbd.Description = "Choose the folder which contains the music";
            fbd.ShowNewFolderButton = false;

            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = fbd.SelectedPath;

                setNotificationsText("Folder " + path + " was loaded");
                files = Directory.GetFiles(path, "*.mp3");

                files2 = getAllFiles(path);
                loadFiles(path);
            }
            else
            {
                setNotificationsText("Selected folder has not changed");
            }
        }

        //click on Title-button
        private void btntitle_Click(object sender, EventArgs e)
        {
            try
            {
                renameLikeTag(files2[listBoxFiles.SelectedIndex]);
                Console.WriteLine(path + ", " + this.path);
                loadFiles(this.path);
            }
            catch (IndexOutOfRangeException ioore)
            {
                setNotificationsText("There are no .mp3 files in the folder");
                Console.WriteLine(ioore);
            }
            catch (NullReferenceException nre)
            {
                setNotificationsText("Please select a folder first");
                Console.WriteLine(nre + "\n\ncatched!!!\n");
            }
        }

        private void btnDifferentName_Click(object sender, EventArgs e)
        {
            string newName = "new Name";
            if (path != null)
            {
                if (InputBox("New Name", "Please input new name:", ref newName) == DialogResult.OK)
                {
                    try
                    {
                        newName = removeSpecialCharacters(newName);
                        System.IO.File.Move(files2[listBoxFiles.SelectedIndex].Name, path + "\\" + newName + ".mp3");
                        loadFiles(this.path);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                    }
                }
            }
            else
            {
                setNotificationsText("Please select a Folder first!");
            }
        }

        //click on renameAll-button
        private void btnRenameAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBoxFiles.Items.Count; i++)
            {
                renameLikeTag(files2[i]);
            }
            loadFiles(path);
        }

        //no idea
        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            
        }

        //whenever selectedItem is changed-listener
        private void listBoxFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnTitle.Text = files2[listBoxFiles.SelectedIndex].Tag.Title;
                setNotificationsText("Ready to rename!");
            }
            catch (NullReferenceException nre)
            {
                setNotificationsText("Sorry this file has no header and cant be renamed automatically");
                btnTitle.Text = "ERROR";
                Console.WriteLine(nre + "\n\ncatched!!!\n");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        //-------------------- own methods --------------------
        private void setNotificationsText(String text)
        {
            notifications.Text = text;
        }

        private void loadFiles(string path)
        {
            if (path != null)
            {
                files2 = getAllFiles(path);
                if (files2.Length >= 1)
                {
                    oldIdx = listBoxFiles.SelectedIndex;
                    listBoxFiles.Items.Clear();

                    foreach (TagLib.File file in files2)
                    {
                        try
                        {
                            listBoxFiles.Items.Add(file.Name.Remove(0, path.Length + 1));
                        }
                        catch (NullReferenceException nre)
                        {
                            listBoxFiles.Items.Add("ERROR");
                            Console.WriteLine(nre + "\n\ncatched!!!\n");
                        }
                    }

                    try
                    {
                        if (oldIdx < 0)
                        {
                            oldIdx = 0;
                        }
                        listBoxFiles.SelectedIndex = oldIdx;
                    }
                    catch (System.ArgumentOutOfRangeException outRangeE)
                    {
                        oldIdx = 0;
                        listBoxFiles.SelectedIndex = oldIdx;
                        Console.WriteLine(outRangeE + " (catched)");
                    }
                }
            }
            else
            {
                setNotificationsText("Please select Folder first");
            }
        }

        private string removeSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if (c == '\\' || c == '/' || c == '*' || c == '?' || c == '"' || c == '<' || c == '>' || c == '|')
                {
                    sb.Append("_");
                }
                else
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }

        private TagLib.File[] getAllFiles(string path)
        {
            int index2 = 0;
            files = Directory.GetFiles(path, "*.mp3");
            TagLib.File[] tagLibFiles = new TagLib.File[files.Length]; 
            foreach (string file in files)
            {
                
                fullFilePath = path + "\\" + Path.GetFileName(file);
                Console.WriteLine(fullFilePath);
                try
                {
                    tagLibFiles[index2] = TagLib.File.Create(fullFilePath);
                }
                catch (TagLib.CorruptFileException cfe)
                {
                    setNotificationsText("Files were loaded but there are corrupt header");
                    Console.WriteLine(cfe + "\ncatched!!!");
                }
                index2++;
            }

            return tagLibFiles;
        }

        private void renameLikeTag(TagLib.File file)
        {
            try
            {
                string name = file.Tag.Title;
                name = removeSpecialCharacters(name);
                System.IO.File.Move(file.Name, path + "\\" + name + ".mp3");
            }
            catch (NullReferenceException nre)
            {
                setNotificationsText("Can't rename file without header, please put in a name manually");
                Console.WriteLine(nre + "\n\ncatched!!!\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }
    }
}
