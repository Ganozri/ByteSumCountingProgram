using System;
using System.Collections.ObjectModel;


namespace Program.ByteSumCountingProgram.VM
{
    public interface IVmObject
    {
        object VmObject { get; }

        public Commands Commands { get; }

        public IPageViewModel SelectedViewModel { get; set; }

        public ObservableCollection<Type> Types { get; set; }

    }
}
