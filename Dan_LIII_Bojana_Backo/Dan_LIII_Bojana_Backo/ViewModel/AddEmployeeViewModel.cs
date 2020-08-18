using Dan_LIII_Bojana_Backo.Command;
using Dan_LIII_Bojana_Backo.Service;
using Dan_LIII_Bojana_Backo.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Dan_LIII_Bojana_Backo.ViewModel
{
    class AddEmployeeViewModel : ViewModelBase
    {
        AddEmployee addEmployee;
        ServiceEmployee serviceEmployee;

        public AddEmployeeViewModel(AddEmployee addEmployeeOpen)
        {
            addEmployee = addEmployeeOpen;
            serviceEmployee = new ServiceEmployee();
            employee = new vwEmployee();
        }
        #region Properties
        private vwEmployee employee;
        public vwEmployee Employee
        {
            get
            {
                return employee;
            }
            set
            {
                employee = value;
                OnPropertyChanged("Employee");
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
                Employee.Password = password;
                Employee.Salary = 12300.ToString();
                LoginScreen login = new LoginScreen();
                serviceEmployee.AddEmployee(Employee);
                addEmployee.Close();
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
            //if (String.IsNullOrEmpty(Admin.FirstName) || String.IsNullOrEmpty(Admin.LastName)
            //    || String.IsNullOrEmpty(Admin.IdentificationCard) || String.IsNullOrEmpty(Admin.Gender)
            //    || String.IsNullOrEmpty(Admin.Citizenship)
            //    || String.IsNullOrEmpty(Admin.Username) || String.IsNullOrEmpty((obj as PasswordBox).Password))
            //{
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}
            return true;
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
                addEmployee.Close();
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
