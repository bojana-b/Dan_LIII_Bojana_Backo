using Dan_LIII_Bojana_Backo.Command;
using Dan_LIII_Bojana_Backo.Service;
using Dan_LIII_Bojana_Backo.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Dan_LIII_Bojana_Backo.ViewModel
{
    class ManagerWindowViewModel : ViewModelBase
    {
        ManagerWindow managerWindow;
        ServiceManager serviceManager;
        ServiceEmployee serviceEmployee;

        public ManagerWindowViewModel(ManagerWindow managerWindowOpen, vwManager managerLog)
        {
            managerWindow = managerWindowOpen;
            manager = managerLog;

            serviceEmployee = new ServiceEmployee();
            serviceManager = new ServiceManager();
            employeeList = serviceEmployee.GetAllEmployees(manager.Floor).ToList();
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
        private List<vwEmployee> employeeList;
        public List<vwEmployee> EmployeeList
        {
            get
            {
                return employeeList;
            }
            set
            {
                employeeList = value;
                OnPropertyChanged("EmployeeList");
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
        private ICommand salaryDef;
        public ICommand SalaryDef
        {
            get
            {
                if (salaryDef == null)
                {
                    salaryDef = new RelayCommand(param => salaryDefExecute(), param => CanSalaryDefExecute());
                }
                return salaryDef;
            }
        }

        private void salaryDefExecute()
        {
            try
            {
                if (Employee != null)
                {
                    Salary salaryDefined = new Salary(Employee);
                    salaryDefined.ShowDialog();
                    if((salaryDefined.DataContext as SalaryViewModel).IsUpdateEmployee == true)
                    {
                        EmployeeList = serviceEmployee.GetAllEmployees(manager.Floor).ToList();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanSalaryDefExecute()
        {
            if (Employee == null)
            {
                return false;
            }
            else if (employee.Responsability.Equals("Cleaning") || employee.Responsability.Equals("Cooking"))
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
                managerWindow.Close();
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
