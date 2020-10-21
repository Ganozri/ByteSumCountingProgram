using DynamicData.Binding;
using Program.ByteSumCountingProgram.UIServices;
using Program.ByteSumCountingProgram.VMServices;
using Model;
using System.Collections.ObjectModel;

namespace Program.ByteSumCountingProgram.VM
{
    public interface IPageViewModel 
    {
        string Name { get;set;}

        ObservableCollection<Node> Nodes { get; set; }

        ObservableCollectionExtended<MainModel> MainModels { get;}

        IDialogService DialogService { get; set; }
        
    }
}

