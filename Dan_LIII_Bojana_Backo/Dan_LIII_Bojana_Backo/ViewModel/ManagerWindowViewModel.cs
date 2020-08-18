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

        public ManagerWindowViewModel(ManagerWindow managerWindowOpen)
        {
            managerWindow = managerWindowOpen;

            serviceEmployee = new ServiceEmployee();
            serviceManager = new ServiceManager();
            manager = new vwManager();
            employeeList = serviceEmployee.GetAllEmployees().ToList();
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
        #endregion

        #region Commands 
        //private ICommand remove;
        //public ICommand Remove
        //{
        //    get
        //    {
        //        if (remove == null)
        //        {
        //            remove = new RelayCommand(param => RemoveExecute(), param => CanRemoveExecute());
        //        }
        //        return remove;
        //    }
        //}

        //private void RemoveExecute()
        //{
        //    try
        //    {
        //        if (Product != null)
        //        {

        //            MessageBoxResult result = MessageBox.Show("Are you sure that you want to remove this product?",
        //               "My App",
        //                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
        //            int productID = product.ProductID;

        //            switch (result)
        //            {
        //                case MessageBoxResult.Yes:
        //                    string textForFile = String.Format("Deleted product {0} {1} {2}", product.ProductID,
        //                        product.ProductName, product.ProductCode);
        //                    eventObject.OnActionPerformed(textForFile);
        //                    service.DeleteProduct(productID);
        //                    ProductList = service.GetAllProducts().ToList();
        //                    break;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}
        //private bool CanRemoveExecute()
        //{
        //    if (Product == null)
        //    {
        //        return false;
        //    }
        //    else if (product.Stored == true)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        //private ICommand update;
        //public ICommand Update
        //{
        //    get
        //    {
        //        if (update == null)
        //        {
        //            update = new RelayCommand(param => UpdateExecute(), param => CanUpdateExecute());
        //        }
        //        return update;
        //    }
        //}

        //private void UpdateExecute()
        //{
        //    try
        //    {
        //        if (Update != null)
        //        {
        //            UpdateProduct updateProduct = new UpdateProduct(Product);
        //            updateProduct.ShowDialog();
        //            if ((updateProduct.DataContext as UpdateProductViewModel).IsUpdateProduct == true)
        //            {
        //                ProductList = service.GetAllProducts().ToList();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}
        //private bool CanUpdateExecute()
        //{
        //    if (Product == null)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}
        #endregion 
    }
}
