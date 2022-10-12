using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class BookBAL
    {
        private int _bookid;

        public int book_id
        {
            get { return _bookid; }
            set { _bookid = value; }
        }

        private string _bookname;

        public string book_name
        {
            //20
            get { return _bookname; }
            set
            {
                _bookname = value;

            }
        }



        private string _bookauthor;

        public string book_author
        {

            get { return _bookauthor; }
            set
            {
                
                    _bookauthor = value;
                

            }
        }
        





    }
}
