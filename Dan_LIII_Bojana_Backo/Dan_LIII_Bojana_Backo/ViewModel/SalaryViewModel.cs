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

        public SalaryViewModel(Salary salaryOpen, vwEmployee employeeEdit)
        {
            salary = salaryOpen;
            employee = employeeEdit;
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
        private string salaryCreate;
        public string SalaryCreate
        {
            get
            {
                return salaryCreate;
            }
            set
            {
                salaryCreate = value;
                OnPropertyChanged("SalaryCreate");
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
            string sal = salaryCreate;
            double final = double.Parse(sal) * 0.75 * 1.12 * 0.15 * 5 * 0.75 * 5;
            return final;
        }
    }
}
