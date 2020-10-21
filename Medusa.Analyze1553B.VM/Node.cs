using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using Viewer.VM;

namespace Program.ByteSumCountingProgram.VM
{
    public class Node
    {
        public string Name { get; set; }
        public ObservableCollection<FileInformation> Files { get;set;}
        public ObservableCollection<Node> Nodes { get; set; }

    }
}
