using Dan_LIII_Bojana_Backo.Command;
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
    class OwnerWindowViewModel : ViewModelBase
    {
        OwnerWindow ownerWindow;

        public OwnerWindowViewModel(OwnerWindow ownerWindowOpen)
        {
            ownerWindow = ownerWindowOpen;
        }

        // AddManager button
        private ICommand addManager;
        public ICommand AddManager
        {
            get
            {
                if (addManager == null)
                {
                    addManager = new RelayCommand(param => AddManagerExecute(), param => CanAddManagerExecute());
                }
                return addManager;
            }
        }
        private void AddManagerExecute()
        {
            try
            {
                AddManager addManager = new AddManager();
                ownerWindow.Close();
                addManager.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanAddManagerExecute()
        {
            return true;
        }
        // AddEmployee button
        private ICommand addEmployee;
        public ICommand AddEmployee
        {
            get
            {
                if (addEmployee == null)
                {
                    addEmployee = new RelayCommand(param => addEmployeeExecute(), param => CanAddEmployeeExecute());
                }
                return addEmployee;
            }
        }
        private void addEmployeeExecute()
        {
            try
            {
                AddEmployee addEmployee = new AddEmployee();
                ownerWindow.Close();
                addEmployee.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanAddEmployeeExecute()
        {
            return true;
        }
    }
}
