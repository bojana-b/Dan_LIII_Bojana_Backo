using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        // Method that reads all Managers from database
        public List<vwManager> GetAllManagers()
        {
            try
            {
                using (HotelDBEntities context = new HotelDBEntities())
                {
                    List<vwManager> list = new List<vwManager>();
                    list = (from x in context.vwManagers select x).ToList();
                    //for (int i = 0; i < list.Count; i++)
                    //{
                    //    if (list[i].Stored == true)
                    //    {
                    //        Capacity += list[i].Quantity;
                    //    }
                    //}
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        // Method that delete Manager from database
        //public void DeleteManager(int productID)
        //{
        //    try
        //    {
        //        using (StockroomDBEntities context = new StockroomDBEntities())
        //        {

        //            tblProduct productToDelete = (from x in context.tblProducts where x.ProductID == productID select x).First();
        //            context.tblProducts.Remove(productToDelete);
        //            context.SaveChanges();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
        //    }
        //}

        // Method that update Manager
        //public vwManager EditManager(vwManager manager)
        //{
        //    try
        //    {
        //        using (HotelDBEntities context = new HotelDBEntities())
        //        {
        //            tblProduct productToEdit = (from x in context.tblProducts where x.ProductID == product.ProductID select x).First();

        //            productToEdit.ProductID = product.ProductID;
        //            productToEdit.ProductName = product.ProductName;
        //            productToEdit.ProductCode = product.ProductCode;
        //            productToEdit.Price = product.Price;
        //            productToEdit.Quantity = product.Quantity;
        //            productToEdit.Stored = product.Stored;

        //            context.SaveChanges();

        //            return product;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
        //        return null;
        //    }
        //}

        // Methot to check if Manager username exists in database
        public bool IsUser(string username)
        {
            try
            {
                using (HotelDBEntities context = new HotelDBEntities())
                {
                    vwManager admin = (from e in context.vwManagers where e.Username == username select e).First();

                    if (admin == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }

        public vwManager FindManager(string username)
        {
            try
            {
                using (HotelDBEntities context = new HotelDBEntities())
                {
                    vwManager admin = (from e in context.vwManagers where e.Username == username select e).First();
                    return admin;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
    }
}
