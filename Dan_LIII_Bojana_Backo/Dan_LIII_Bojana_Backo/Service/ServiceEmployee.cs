﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dan_LIII_Bojana_Backo.Service
{
    class ServiceEmployee
    {
        // Method that add Manager to database
        public void AddEmployee(vwEmployee employee)
        {
            try
            {
                using (HotelDBEntities context = new HotelDBEntities())
                {
                    tblUser newUser = new tblUser();
                    tblEmployee newEmployee = new tblEmployee();
                    newUser.Name = employee.Name;
                    newUser.Surname = employee.Surname;
                    newUser.DateOfBirth = employee.DateOfBirth;
                    newUser.Email = employee.Email;
                    newUser.Username = employee.Username;
                    newUser.Password = SecurePasswordHasher.Hash(employee.Password);

                    context.tblUsers.Add(newUser);
                    context.SaveChanges();
                    employee.UserId = newUser.UserId;

                    newEmployee.UserId = employee.UserId;
                    newEmployee.Floor = employee.Floor;
                    newEmployee.Gender = employee.Gender;
                    newEmployee.Citizenship = employee.Citizenship;
                    newEmployee.Responsability = employee.Responsability;
                    newEmployee.Salary = employee.Salary;

                    context.tblEmployees.Add(newEmployee);
                    context.SaveChanges();
                    employee.EmployeeID = newEmployee.EmployeeID;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }
        // Method that reads all Employees from database
        public List<vwEmployee> GetAllEmployees(string managerFloor)
        {
            try
            {
                using (HotelDBEntities context = new HotelDBEntities())
                {
                    List<vwEmployee> list = new List<vwEmployee>();
                    list = (from x in context.vwEmployees where x.Floor == managerFloor select x).ToList();
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
        // Method that update Employee
        public vwEmployee EditEmployee(vwEmployee employee)
        {
            try
            {
                using (HotelDBEntities context = new HotelDBEntities())
                {
                    tblUser userToEdit = (from ss in context.tblUsers where ss.UserId == employee.UserId select ss).First();

                    userToEdit.Name = employee.Name;
                    userToEdit.Surname = employee.Surname;
                    userToEdit.DateOfBirth = employee.DateOfBirth;
                    userToEdit.Email = employee.Email;
                    userToEdit.Username = employee.Username;
                    userToEdit.Password = employee.Password;

                    userToEdit.UserId = employee.UserId;

                    tblUser userEdit = (from ss in context.tblUsers
                                        where ss.UserId == employee.UserId
                                        select ss).First();
                    context.SaveChanges();

                    tblEmployee employeeToEdit = (from ss in context.tblEmployees where ss.UserId == employee.UserId select ss).First();

                    employeeToEdit.Floor = employee.Floor;
                    employeeToEdit.Gender = employee.Gender;
                    employeeToEdit.Citizenship = employee.Citizenship;
                    employeeToEdit.Responsability = employee.Responsability;
                    employeeToEdit.Salary = employee.Salary;

                    employeeToEdit.EmployeeID = employee.EmployeeID;

                    tblEmployee employeeEdit = (from ss in context.tblEmployees
                                                where ss.EmployeeID == employee.EmployeeID
                                                select ss).First();
                    context.SaveChanges();
                    return employee;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
    }
}
