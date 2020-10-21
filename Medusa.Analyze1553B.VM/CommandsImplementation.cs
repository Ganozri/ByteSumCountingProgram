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

namespace Program.ByteSumCountingProgram.VM
{
    public partial class Commands
    {
       
        private void GetDataFromFile()
        {
            if (vmObject.SelectedViewModel != null)
            {
                using (StreamReader reader = new StreamReader(vmObject.SelectedViewModel.DialogService.ShowOpenFileDialog()))
                {
                    string path = reader.ReadToEnd();
                    if (File.Exists(path))
                    {
                        vmObject.SelectedViewModel.MainModels.Clear();

                        var rawData = dataService.GetData(path, vmObject.SelectedViewModel);

                        //vmObject.SelectedViewModel.MainModels.AddRange(rawData);
                        _ = FactorialAsync(vmObject,rawData);
                    }
                }
            }
            else
            {
                dialogService.ShowMessage("Не выбран тип продукта!");
            }
           
        }
        private void OpenFolder()
        {
            string root = vmObject.SelectedViewModel.DialogService.ShowOpenFolderDialog();
            if (Directory.Exists(root))
            {
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
        static async Task CreateNestedFolderAsync(Node node,string root)
        {
            node.Name = GetEndPartOfPath(root);

            node.Files = new();
            var files = System.IO.Directory.GetFiles(root + "\\");
            
            foreach (var item in files)
            {
                node.Files.Add(new(GetEndPartOfPath(item),1));
            }
            
            var topDirectories = Directory.GetDirectories(root, "*", SearchOption.TopDirectoryOnly);
            if (topDirectories.Length > 0)
            {
                node.Nodes = new ObservableCollection<Node>();
                foreach (var dir in topDirectories)
                {
                    Node n = new();
                    node.Nodes.Add(n);
                    _ = CreateNestedFolderAsync(n, dir);

                    //await Task.Delay(1);
                }
            }
        }

        //TODO
        // определение асинхронного метода
        static async Task FactorialAsync(IVmObject vmObject, MainModel[] rawData)
        {
            if (rawData.Length > 1000)
            {
                int offset = 20;
                int count = 15;
                for (int i = 0; i < count; i++)
                {
                    ArraySegment<MainModel> firstRecords = new ArraySegment<MainModel>(rawData, i * offset, offset);
                    vmObject.SelectedViewModel.MainModels.AddRange(firstRecords);
                    await Task.Delay(1);
                }
                ArraySegment<MainModel> lastRecords = new ArraySegment<MainModel>(rawData, offset*count, rawData.Length-offset*count);
                vmObject.SelectedViewModel.MainModels.AddRange(lastRecords);
            }
            else
            {
                vmObject.SelectedViewModel.MainModels.AddRange(rawData);
            }
        }
        //TODO
        
       
      
       
        private void DoNothing(object obj)
        {
            //dialogService.ShowMessage(obj.ToString());
            
        }
    }
}
