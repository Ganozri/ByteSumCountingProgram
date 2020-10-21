using Model;
using ReactiveUI.Fody.Helpers;
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
        [Reactive] public string Name { get; set; }
        [Reactive] public ObservableCollection<FileInformation> Files { get;set;}
        [Reactive] public ObservableCollection<Node> Nodes { get; set; }
        public Node()
        {

        }
        public Node(string name)
        {
            Name = name;
        }

    }
}
