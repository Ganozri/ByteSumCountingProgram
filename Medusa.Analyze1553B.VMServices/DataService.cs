using Program.ByteSumCountingProgram.UIServices;
using Model;
using System;
using System.IO;
using System.Linq;


namespace Program.ByteSumCountingProgram.VMServices
{
    public class DataService : IDataService
    {
        private readonly IDialogService dialogService;
        public DataService(IDialogService dialogService)
        {
            this.dialogService = dialogService; 
        }
    }
}
