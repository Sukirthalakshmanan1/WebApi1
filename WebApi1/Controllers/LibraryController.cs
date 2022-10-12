using BAL;
using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi1.Models;

namespace WebApi1.Controllers
{
    public class LibraryController : ApiController
    {
        Employee_Helper obj = null;
        public LibraryController()
        {
            obj = new Employee_Helper();
        }

       // [Route("GetAllEmps")]
        public List<Book> GetBookList()
        {
          

            List<BookBAL> empbal = new List<BookBAL>();
            empbal = obj.BList();
            List<Book> emps = new List<Book>();
            foreach (var item in empbal)
            {
                //Employees emp = new Employees();
                emps.Add(new Book { book_id = item.book_id, book_name = item.book_name, book_author = item.book_author });
            }
            return emps;

        }

     [Route("~/FindEmp")]
        public Book GetBookDetails()
        {
            return new Book
            {


                book_id = 15,
                book_name = "Davolio",

                book_author = "jack",

            };
        }
        // GET api/<controller>/5
       // [Route("~/FindEmp/{id}")]
        //  [Route("FindEmp/{id:int:min(1)}")]
       [Route("FindEmp/{id:int?}")]
        public Book GetBookByID(int id = 1)
        {
            BookBAL empbal = new BookBAL();
            empbal = obj.search(id);
            Book emp = new Book();
            emp.book_id = empbal.book_id;
            emp.book_name = empbal.book_name;
            emp.book_author = empbal.book_author;

            return emp;
            //return "value";
        }

        // POST api/<controller>
        public HttpResponseMessage PostProduct([FromBody] Book empdata)
        {
            BookBAL empbal = new BookBAL();
            empbal.book_id = empdata.book_id;
            empbal.book_name = empdata.book_name;
            empbal.book_author = empdata.book_author;


            bool ans = obj.AddE(empbal);
            if (ans)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }

        }

        // PUT api/<controller>/5
        public HttpResponseMessage PutProduct([FromBody] Book empdata)
        {

            BookBAL empbal = new BookBAL();
            empbal.book_id = empdata.book_id;
            empbal.book_name = empdata.book_name;
            empbal.book_author = empdata.book_author;



            bool ans = obj.Edit(empbal);
            if (ans)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage DeleteProduct(int id)
        {
            bool ans = obj.remove(id);
            if (ans)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }

        }

    }
}