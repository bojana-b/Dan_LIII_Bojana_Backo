using Dan_LIII_Bojana_Backo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Dan_LIII_Bojana_Backo.View
{
    /// <summary>
    /// Interaction logic for Salary.xaml
    /// </summary>
    public partial class Salary : Window
    {
        public Salary(vwEmployee employeEdit, vwManager managerLog)
        {
            InitializeComponent();
            this.DataContext = new SalaryViewModel(this, employeEdit, managerLog);
        }
    }
}
