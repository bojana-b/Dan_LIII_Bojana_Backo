using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dan_LIII_Bojana_Backo.Service
{
    class ServiceManager
    {
        // Method that add Manager to database
        public void AddManager(vwManager manager)
        {
            try
            {
                using (HotelDBEntities context = new HotelDBEntities())
                {
                    tblUser newUser = new tblUser();
                    tblManager newManager = new tblManager();
                    newUser.Name = manager.Name;
                    newUser.Surname = manager.Surname;
                    newUser.DateOfBirth = manager.DateOfBirth;
                    newUser.Email = manager.Email;
                    newUser.Username = manager.Username;
                    newUser.Password = SecurePasswordHasher.Hash(manager.Password);

                    context.tblUsers.Add(newUser);
                    context.SaveChanges();
                    manager.UserId = newUser.UserId;

                    newManager.UserId = manager.UserId;
                    newManager.Floor = manager.Floor;
                    newManager.Experience = manager.Experience;
                    newManager.Qualifications = manager.Qualifications;

                    context.tblManagers.Add(newManager);
                    context.SaveChanges();
                    manager.ManagerID = newManager.ManagerID;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }
    }
}
