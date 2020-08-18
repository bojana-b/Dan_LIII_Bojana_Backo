using Dan_LIII_Bojana_Backo.Command;
using Dan_LIII_Bojana_Backo.Service;
using Dan_LIII_Bojana_Backo.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Dan_LIII_Bojana_Backo.ViewModel
{
    class LoginScreenViewModel : ViewModelBase
    {
        LoginScreen loginScreen;
        public static List<string> userPass;
        ServiceManager serviceManager;

        public LoginScreenViewModel(LoginScreen loginScreenOpen)
        {
            loginScreen = loginScreenOpen;
            userPass = new List<string>();
            ReadUsernameAndPasswordFromFile();
            serviceManager = new ServiceManager();
            manager = new vwManager();
            managerList = serviceManager.GetAllManagers().ToList();
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
        private List<vwManager> managerList;
        public List<vwManager> ManagerList
        {
            get
            {
                return managerList;
            }
            set
            {
                managerList = value;
                OnPropertyChanged("ManagerList");
            }
        }
        //private tblUser user;
        //public tblUser User
        //{
        //    get
        //    {
        //        return user;
        //    }
        //    set
        //    {
        //        user = value;
        //        OnPropertyChanged("User");
        //    }
        //}

        private string userName;
        public string UserName
        {

            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }
        #endregion

        #region Commands
        private ICommand submit;
        public ICommand Submit
        {
            get
            {
                if (submit == null)
                {
                    submit = new RelayCommand(SubmitCommandExecute,
                        param => CanSubmitCommandExecute());
                }
                return submit;
            }
        }

        private void SubmitCommandExecute(object obj)
        {
            try
            {
                string password = (obj as PasswordBox).Password;
                if (UserName.Equals(userPass.ElementAt(1)) && password.Equals(userPass.ElementAt(3)))
                {
                    OwnerWindow master = new OwnerWindow();
                    loginScreen.Close();
                    master.ShowDialog();
                }
                else if (serviceManager.IsUser(UserName))
                {
                    Manager = serviceManager.FindManager(UserName);
                    if (SecurePasswordHasher.Verify(password, Manager.Password))
                    {
                        ManagerWindow managerWindow = new ManagerWindow(Manager);
                        loginScreen.Close();
                        managerWindow.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Wrong usename or password!");
                    }
                }
                //else if (serviceAdmin.IsUser(UserName))
                //{
                //    Admin = serviceAdmin.FindAdmin(UserName);
                //    if (SecurePasswordHasher.Verify(password, Admin.UserPassword))
                //    {
                //        clinicList = serviceClinic.GetAllClinics().ToList();
                //        if (clinicList.Count == 0)
                //        {
                //            CreateClinic createClinic = new CreateClinic();
                //            loginScreen.Close();
                //            createClinic.ShowDialog();
                //        }
                //        else
                //        {
                //            AdminWindow adminWindow = new AdminWindow();
                //            loginScreen.Close();
                //            adminWindow.ShowDialog();
                //        }
                //    }
                //}
                else
                {
                    MessageBox.Show("Wrong usename or password!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanSubmitCommandExecute()
        {
            return true;
        }
        // Signup button
        private ICommand signUp;
        public ICommand SignUp
        {
            get
            {
                if (signUp == null)
                {
                    signUp = new RelayCommand(param => SignupExecute(), param => CanCreateSigunExecute());
                }
                return signUp;
            }
        }
        private void SignupExecute()
        {
            try
            {
                //Signup signup = new Signup();
                //loginScreen.Close();
                //signup.ShowDialog();
                MessageBox.Show("Patient registration not implemented yet!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanCreateSigunExecute()
        {
            return true;
        }
        #endregion

        // Function that read Owner username and password
        void ReadUsernameAndPasswordFromFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader(@"..\..\OwnerAccess.txt"))
                {
                    string line;
                    string[] arr;
                    while ((line = sr.ReadLine()) != null)
                    {
                        arr = line.Split();
                        for (int i = 0; i < arr.Length; i++)
                        {
                            userPass.Add(arr[i]);
                        }
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"The file was not found: '{e}'");
            }
            catch (IOException e)
            {
                Console.WriteLine($"The file could not be opened: '{e}'");
            }
        }
    }
}
