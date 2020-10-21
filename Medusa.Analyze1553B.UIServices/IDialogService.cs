using System.IO;

namespace Program.ByteSumCountingProgram.UIServices
{
    public interface IDialogService
    {
        void ShowMessage(string message, string title = null);

        string ShowOpenFolderDialog();
    }
}
