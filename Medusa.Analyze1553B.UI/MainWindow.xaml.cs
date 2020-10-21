using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

using Program.ByteSumCountingProgram.UIServices;
using Program.ByteSumCountingProgram.VM;
using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using SynchronizationContext = System.Threading.SynchronizationContext;

namespace Program.ByteSumCountingProgram.UI
{
    /// <summary> 
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow, ISynchronizationContextProvider, IDialogService
    {
        public SynchronizationContext SynchronizationContext { get; }

        public MainWindow()
        {
            InitializeComponent();
          
            SynchronizationContext = SynchronizationContext.Current;
        }

    }

}
