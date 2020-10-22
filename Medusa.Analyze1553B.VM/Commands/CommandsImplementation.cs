using DynamicData;
using Program.ByteSumCountingProgram.VM.ViewModels;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Viewer.VM;
using System.Linq;

namespace Program.ByteSumCountingProgram.VM
{
    public partial class Commands
    {
        private void OpenFolder()
        {
            string root = vmObject.SelectedViewModel.DialogService.ShowOpenFolderDialog();
            if (Directory.Exists(root))
            {
                vmObject.SelectedViewModel.Nodes.Clear();

                Node node = new();
                _ = CreateNestedFolderAsync(node, root);
                vmObject.SelectedViewModel.Nodes.Add(node);
            }
            else
            {
                dialogService.ShowMessage("Что-то пошло не так!");
            }
        }

        static string GetEndPartOfPath(string fullPath)
        {
            string[] words = fullPath.Split(new char[] { '\\' });
            return words[words.Length-1];
        }

        static void ProcessFile(ObservableCollection<FileInformation> fileInformation,string path)
        {
            long result = 0;
            foreach (var line in File.ReadLines(path))
            {
                byte[] str = Encoding.Default.GetBytes(line);
                foreach (var currentByte in str)
                {
                    result += currentByte;
                }
                result += line.Length;
            }
            fileInformation.Add(new(GetEndPartOfPath(path), result));
        }
        // определение асинхронного метода
        static async Task CreateNestedFolderAsync(Node node, string root)
        {
            node.Name = GetEndPartOfPath(root);

            node.Files = new();

            var files = System.IO.Directory.GetFiles(root + "\\");

            IEnumerable<string> paths = files;
            var processTasks = paths.Select(p => Task.Run(() => ProcessFile(node.Files,p)));
            _ =  Task.WhenAll(processTasks);

            var topDirectories = Directory.GetDirectories(root, "*", SearchOption.TopDirectoryOnly);
            if (topDirectories.Length > 0)
            {
                node.Nodes = new ObservableCollection<Node>();
                foreach (var dir in topDirectories)
                {
                    Node n = new();
                    _ = CreateNestedFolderAsync(n, dir);
                    node.Nodes.Add(n);
                    //TODO so easy way to async
                    await Task.Delay(1);
                    //TODO
                }
            }
        }

        private void DoNothing(object obj)
        {
            dialogService.ShowMessage(obj.ToString());
        }

    }
}
