using Dan_LIII_Bojana_Backo.Command;
using Dan_LIII_Bojana_Backo.Service;
using Dan_LIII_Bojana_Backo.View;
using System;
using System.Windows;
using System.Windows.Input;

namespace Dan_LIII_Bojana_Backo.ViewModel
{
    class SalaryViewModel : ViewModelBase
    {
        Salary salary;
        ServiceEmployee serviceEmployee;

        public SalaryViewModel(Salary salaryOpen, vwEmployee employeeEdit, vwManager managerLog)
        {
            salary = salaryOpen;
            employee = employeeEdit;
            manager = managerLog;
            serviceEmployee = new ServiceEmployee();
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
        private int number;
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
                OnPropertyChanged("Number");
            }
        }

        private bool isUpdateEmployee;
        public bool IsUpdateEmployee
        {
            get
            {
                return isUpdateEmployee;
            }
            set
            {
                isUpdateEmployee = value;
            }
        }
        #endregion 

        #region Commands
        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return save;
            }
        }

        private void SaveExecute()
        {
            try
            {
                if (Number <= 1 || Number > 1000)
                {
                    MessageBox.Show("X must be in range of (1, 1000).");
                    return;
                }
                employee.Salary = salaryCalculation().ToString();
                serviceEmployee.EditEmployee(Employee);
                isUpdateEmployee = true;
                salary.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanSaveExecute()
        {
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
                salary.Close();
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

        public double salaryCalculation()
        {
            int sal = Number;
            if (Employee.Gender.Equals("M"))
            {
                double final = sal * 0.75 * ((double)Manager.Experience) * 1.12 * 0.15 * 5;
                return final;
            }
            else
            {
                double final = sal * 0.75 * ((double)Manager.Experience) * 1.15 * 0.15 * 5;
                return final;
            }            
        }
    }
}
