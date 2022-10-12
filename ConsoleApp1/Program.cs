using BAL;
using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args) {
            Console.WriteLine("library Management System");
            Console.WriteLine("--------------------------------");
            Employee_Helper helper = new Employee_Helper();
            Console.WriteLine("Menu");
            Console.WriteLine("-----");
            Console.WriteLine("1. Add book details \n2.add member details\n 3.update member details\n 4.count employee\n 5.find employee\n 6.get all employee details\n 7.delete books\n");
            int userchoice = Convert.ToInt32(Console.ReadLine());
           BookBAL emp = new BookBAL();
            switch (userchoice)
            {
                case 1:

                    Console.WriteLine("Enter book id");
                    emp.book_id = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter bookname");
                    emp.book_name = Console.ReadLine().Trim();
                    Console.WriteLine("Enter book author");
                    emp.book_author = Console.ReadLine().Trim();


                    bool queryStatus = helper.AddEmployee(emp);
                    if (queryStatus)
                    {
                        Console.WriteLine("Employee added successfully.....");
                    }
                    else
                    {
                        Console.WriteLine("Some error occured...");
                    }
                    break;
                case 2:
                  /*  Console.WriteLine("Enter member id");
                    emp.member_id = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter member name");
                    emp.member_name = Console.ReadLine().Trim();



                    bool queryStatuss = helper.AddEmployees(emp);
                    if (queryStatuss)
                    {
                        Console.WriteLine("Employee added successfully.....");
                    }
                    else
                    {
                        Console.WriteLine("Some error occured...");
                    }
                    break;*/
                case 3:
                    Console.WriteLine("Enter member id ");
                    emp.member_id = Convert.ToInt32(Console.ReadLine());


                    Console.WriteLine("Enter member name");
                    emp.member_name = Console.ReadLine().Trim();


                    bool queryStatuse = helper.EditEmployee(emp);
                    if (queryStatuse)
                    {
                        Console.WriteLine("members details updated successfully.....");
                    }
                    else
                    {
                        Console.WriteLine("Some error occured...");
                    }


                    break;
                case 4:
                    int c = helper.Count();
                    Console.WriteLine("employee count succesfully" + " " + c);
                    break;
                case 5:
                    Console.WriteLine("Enter Employeeid ");
                    emp.book_id = Convert.ToInt32(Console.ReadLine());
                    BookBAL bal = new BookBAL();
                    bal = helper.searchEmployee(emp.book_id);
                    if (bal != null)
                    {
                        bal.book_id = emp.book_id;
                        Console.WriteLine("following were the details found in the db");
                        Console.WriteLine(bal.book_id);
                        Console.WriteLine(bal.book_name);
                        Console.WriteLine(bal.book_author);

                    }
                    else
                    {
                        Console.WriteLine("empid not found");
                    }
                    break;
                case 6:
                    List<BookBAL> list = new List<BookBAL>();
                    list = helper.dispEmployeeList();
                    foreach (var item in list)
                    {
                        Console.WriteLine(item.book_id);
                        Console.WriteLine(item.book_name);
                        Console.WriteLine(item.book_author);

                        Console.WriteLine();
                    }
                    break;
                case 7:
                    Console.WriteLine("Enter bookid ");
                    emp.book_id = Convert.ToInt32(Console.ReadLine());
                    queryStatus = helper.removebook(emp.book_id);
                    if (queryStatus)
                    {
                        Console.WriteLine("books  deleted successfully.....");
                    }
                    else
                    {
                        Console.WriteLine("Some error occured...");
                    }

                    break;
            }


        }



    }
    
}
