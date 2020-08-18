using Dan_LIII_Bojana_Backo.Command;
using Dan_LIII_Bojana_Backo.Service;
using Dan_LIII_Bojana_Backo.View;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Dan_LIII_Bojana_Backo.ViewModel
{
    class AddManagerViewModel : ViewModelBase
    {
        AddManager addManager;
        ServiceManager serviceManager;

        public AddManagerViewModel(AddManager addManagerOpen)
        {
            addManager = addManagerOpen;
            serviceManager = new ServiceManager();
            manager = new vwManager();
        }

        #region Properties
        private vwManager manager;
        public vwManager Manager
        {
            get
            {
                return manager;
            }
            set
            {
                manager = value;
                OnPropertyChanged("Manager");
            }
        }
        private DateTime dateOfBirth = DateTime.Now;
        public DateTime DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }
            set
            {
                dateOfBirth = value;
                OnPropertyChanged("DateOfBirth");
            }
        }
        #endregion

        // Save Button
        #region Commans
        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(SaveExecute, CanSaveExecute);
                }
                return save;
            }
        }
        private void SaveExecute(object obj)
        {
            try
            {
                string password = (obj as PasswordBox).Password;
                Manager.Password = password;
                LoginScreen login = new LoginScreen();
                serviceManager.AddManager(Manager);
                addManager.Close();
                MessageBox.Show("Account created!");
                login.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute(object obj)
        {
            if (String.IsNullOrEmpty(Manager.Name) || String.IsNullOrEmpty(Manager.Surname)
                || String.IsNullOrEmpty(Manager.Email) || String.IsNullOrEmpty(Manager.Floor)
                || String.IsNullOrEmpty(Manager.Qualifications) || String.IsNullOrEmpty(Manager.Experience.ToString())
                || String.IsNullOrEmpty(Manager.Username) || String.IsNullOrEmpty((obj as PasswordBox).Password))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // Cancel Button
        private ICommand cancel;
        public ICommand Cancel
        {
            get
            {
                if (cancel == null)
                {
                    cancel = new RelayCommand(param => CancelExecute(), param => CanCancelExecute());
                }
                return cancel;
            }
        }
        private void CancelExecute()
        {
            try
            {
                LoginScreen login = new LoginScreen();
                addManager.Close();
                login.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanCancelExecute()
        {
            return true;
        }
        #endregion
    }
}
