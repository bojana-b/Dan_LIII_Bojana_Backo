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
        ServiceManager serviceManager;
        List<string> floorManager;

        public AddEmployeeViewModel(AddEmployee addEmployeeOpen)
        {
            addEmployee = addEmployeeOpen;
            serviceEmployee = new ServiceEmployee();
            serviceManager = new ServiceManager();
            employee = new vwEmployee();
            floorManager = serviceManager.GetManagerFloor().ToList();
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
                bool existsFloor = false;
                string password = (obj as PasswordBox).Password;
                Employee.Password = password;
                for (int i = 0; i < floorManager.Count; i++)
                {
                    if (Employee.Floor == floorManager[i])
                    {
                        existsFloor = true;
                    }
                }
                if (existsFloor)
                {
                    LoginScreen login = new LoginScreen();
                    serviceEmployee.AddEmployee(Employee);
                    addEmployee.Close();
                    MessageBox.Show("Account created!");
                    login.ShowDialog();
                }
                else
                {
                    MessageBox.Show("There is no Manager for that floor. Can not hire an employee!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute(object obj)
        {
            if (String.IsNullOrEmpty(Employee.Name) || String.IsNullOrEmpty(Employee.Surname)
                || String.IsNullOrEmpty(Employee.Email) || String.IsNullOrEmpty(Employee.Gender)
                || String.IsNullOrEmpty(Employee.Floor) || String.IsNullOrEmpty(Employee.Citizenship)
                || String.IsNullOrEmpty(Employee.Responsability)
                || String.IsNullOrEmpty(Employee.Username) || String.IsNullOrEmpty((obj as PasswordBox).Password))
            {
                return false;
            }
            else
            {
                return true;
            }
            //return true;
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
