using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Program.ByteSumCountingProgram.UI.Views;
using Program.ByteSumCountingProgram.UIServices;
using Program.ByteSumCountingProgram.VM;
using StructureMap.TypeRules;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


namespace Program.ByteSumCountingProgram.UI
{
    public partial class MainWindow : MetroWindow, ISynchronizationContextProvider, IDialogService
    {

        public string ShowOpenFolderDialog()
        {
            using (var fbd = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = fbd.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                    return fbd.SelectedPath;
                }
                else
                {
                    return "";
                }
            }
            
        }

        public MemoryStream ShowOpenFileDialog()
        {
            var openFileDlg = new Microsoft.Win32.OpenFileDialog
            {
                Filter = this.Filter
            };
            if (openFileDlg.ShowDialog() == true)
            {
                byte[] byteArray = Encoding.ASCII.GetBytes(openFileDlg.FileName);
                MemoryStream stream = new MemoryStream(byteArray);
                return stream;
            }
            else
            {
                return new MemoryStream();
            }
        }

        public MemoryStream ShowSaveFileDialog()
        {
            var saveFileDialog = new Microsoft.Win32.SaveFileDialog()
            {
                Filter = this.Filter
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                byte[] byteArray = Encoding.ASCII.GetBytes(openFileDlg.FileName);
                MemoryStream stream = new MemoryStream(byteArray);
                return stream;
            }
            else
            {
                return new MemoryStream();
            }
        }

        public void AddText(object arg, string text)
        {
            TextBlock textBlock = new TextBlock();
            if (arg != null)
            {
                if (Object.ReferenceEquals(arg.GetType(), textBlock.GetType()))
                {
                    textBlock = (TextBlock)arg;
                    textBlock.Text += text + "\n";
                }
            }

        }

        public void CreateCustomWindow()
        {
            MessageBox.Show("Здесь будет кастомное окно!");
        }

        public void ShowMessage(string message, string title = null)
        {
            MessageBox.Show(this, message, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void ScrollIntoView(object arg, int position)
        {
            ListView myListView = new ListView();
            if (Object.ReferenceEquals(arg.GetType(), myListView.GetType()))
            {
                myListView = (ListView)arg;
                myListView.SelectedItem = myListView.Items.GetItemAt(position);
                myListView.ScrollIntoView(myListView.SelectedItem);
                ListViewItem item = myListView.ItemContainerGenerator.ContainerFromItem(myListView.SelectedItem) as ListViewItem;
                item.Focus();
            }
            else
            {

            }

        }

        public void UpdateView(object arg)
        {
            ListView myListView = new ListView();
            if (Object.ReferenceEquals(arg.GetType(), myListView.GetType()))
            {
                myListView = (ListView)arg;
            }
        }

        public int CurrentPosition(object arg)
        {
            ListView myListView = (ListView)arg;
            if (Object.ReferenceEquals(arg.GetType(), myListView.GetType()))
            {
                int position = myListView.SelectedIndex;
                return position;
            }
            else
            {
                return 0;
            }

        }
    }
}
