using SelfDevelopmentApplication.Commands;
using SelfDevelopmentApplication.Helpers;
using System.Windows.Input;

namespace SelfDevelopmentApplication.ViewModels
{
    class ViewModelBase : ObservableObject
    {
        public ICommand ConfirmationDialogYesCommand { get; set; }
        public ICommand ConfirmationDialogNoCommand { get; set; }
        public ICommand CloseMessageBoxCommand { get; set; }

        private bool showConfirmationDialog;
        public bool ShowConfirmationDialog
        {
            get => showConfirmationDialog;
            set
            {
                showConfirmationDialog = value;
                OnPropertyChanged();
            }
        }

        private bool showMessageBox;
        public bool ShowMessageBox
        {
            get => showMessageBox;
            set
            {
                showMessageBox = value;
                OnPropertyChanged();
            }
        }

        private object confirmationDialogData;
        public object ConfirmationDialogData
        {
            get => confirmationDialogData;
            set
            {
                confirmationDialogData = value;
                OnPropertyChanged();
            }
        }

        public ViewModelBase()
        {
            CloseMessageBoxCommand = new RelayCommand(o =>
            {
                ShowMessageBox = false;
            });
        }
    }
}