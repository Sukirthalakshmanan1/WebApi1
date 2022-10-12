using BAL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public class Employee_Helper
    {
       Employee_DAL dal = null;
        public Employee_Helper()
        {
            dal = new Employee_DAL();
        }


        public bool AddE(BookBAL school)
        {
            return dal.Insert(school);

        }
      
        public bool Edit(BookBAL school)
        {
            return dal.Update(school);
        }
        
        public BookBAL search(int id)
        {
            return dal.Find(id);
        }
        public List<BookBAL> BList()
        {
            return dal.List();
        }
        public bool remove(int id)
        {
            return dal.Delete(id);
        }
    }
}
