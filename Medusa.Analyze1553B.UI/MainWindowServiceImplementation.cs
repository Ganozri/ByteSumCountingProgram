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


        public void ShowMessage(string message, string title = null)
        {
            MessageBox.Show(this, message, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }
       
    }
}
