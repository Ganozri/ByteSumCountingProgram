
using System.Collections.ObjectModel;
using Program.ByteSumCountingProgram.UIServices;
using Program.ByteSumCountingProgram.VMServices;
using ReactiveUI.Fody.Helpers;
using DynamicData.Binding;
using Model;

namespace Program.ByteSumCountingProgram.VM.ViewModels
{
    public class FirstViewModel : CommonViewModelClass, IPageViewModel
    {
        [Reactive] public string Name { get;set;}
        [Reactive] public ObservableCollection<Node> Nodes { get;set; }
        [Reactive] public ObservableCollectionExtended<MainModel> MainModels { get;}
        
        private bool MoreThenFive(MainModel dataRecord)
        {
            return dataRecord.FirstNumber > 5;
        }
        private bool LessThenFive(MainModel dataRecord)
        {
            return dataRecord.FirstNumber < 5;
        }
        private void CreateNodes()
        {
            Nodes = new ObservableCollection<Node>();
        }
       

        public FirstViewModel(ISynchronizationContextProvider syncContext, IDialogService dialogService, IDataService dataService, Commands Commands)
        {
            DialogService = dialogService;
            //DialogService.Filter = "BMD files (*.bmd)|*.bmd";
            this.SyncContext = syncContext.SynchronizationContext;
            this.Commands = Commands;

            Name = "Первая бизнес-модель";

            MainModels = new ObservableCollectionExtended<MainModel>();
            CreateNodes();

           
        }
    }
}
