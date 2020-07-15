using DateTimeInput.Models;
using DateTimeInput.Utils;
using System;
using System.Windows.Input;

namespace DateTimeInput.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            ModelObject = new SampleModel
            {
                TheDateTime = DateTime.Now
            };
        }

        public SampleModel ModelObject { get; set; }

        public ICommand ExitCmd { get { return new RelayCommand(OnExitApp, () => true); } }


        private void OnExitApp()
        {
            System.Windows.Application.Current.MainWindow.Close();
        }
    }
}
