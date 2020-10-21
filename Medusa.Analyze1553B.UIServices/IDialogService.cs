using System.IO;

namespace Program.ByteSumCountingProgram.UIServices
{
    public interface IDialogService
    {
        void ShowMessage(string message, string title = null);
        MemoryStream ShowOpenFileDialog();
        MemoryStream ShowSaveFileDialog();

        string ShowOpenFolderDialog();
        string Filter { get; set; }
    }
}
