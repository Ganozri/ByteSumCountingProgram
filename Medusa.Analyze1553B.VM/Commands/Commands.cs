using System;
using System.Reactive.Concurrency;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using Program.ByteSumCountingProgram.UIServices;
using Program.ByteSumCountingProgram.VMServices;

namespace Program.ByteSumCountingProgram.VM
{
    public partial class Commands
    {
        public readonly IScheduler scheduler;
        public readonly IVmObject vmObject;
        public readonly IDialogService dialogService;
        public readonly IDataService dataService;

        public readonly ISynchronizationContextProvider syncContext;

        #region Commands

        public ICommand DoNothingCommand { get; }
        public ICommand OpenFolderCommand { get; }


        #endregion

        public Commands(ISynchronizationContextProvider syncContext, IVmObject vmObject, IDialogService dialogService, IDataService dataService)
        {
            this.vmObject       = vmObject;
            this.dialogService  = dialogService;
            this.dataService    = dataService;
            this.scheduler      = new SynchronizationContextScheduler(syncContext.SynchronizationContext);
            this.syncContext    = syncContext;

            DoNothingCommand = CreateCommand<object>(DoNothing);
            OpenFolderCommand = CreateCommand(OpenFolder);

        }

       

        ICommand CreateCommand(Func<Task> command) => ReactiveCommand.CreateFromTask(command, outputScheduler: scheduler);

        ICommand CreateCommand<T>(Func<T, Task> command) => ReactiveCommand.CreateFromTask(command, outputScheduler: scheduler);

        ICommand CreateCommand(Action command) => ReactiveCommand.Create(command, outputScheduler: scheduler);

        ICommand CreateCommand<T>(Action<T> command) => ReactiveCommand.Create(command, outputScheduler: scheduler);

    }
}
