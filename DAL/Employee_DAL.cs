using BAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Employee_DAL
    {
        public bool Insert(BookBAL school)
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-5GL4B5D\\SQLEXPRESS1;Initial Catalog=Web;Integrated Security=True");

            SqlCommand cmdInsert = new SqlCommand("insert into book(book_id,book_name,book_author) values(@book_id,@book_name,@book_author)", cn);
            cmdInsert.Parameters.AddWithValue("@book_id", school.book_id);
            cmdInsert.Parameters.AddWithValue("@book_name", school.book_name);
            cmdInsert.Parameters.AddWithValue("@book_author", school.book_author);

            /*SqlCommand cmdInserts = new SqlCommand("insert into member(member_id,member_name) values(@member_id,@member_name)", cn);
            cmdInserts.Parameters.AddWithValue("@member_id", employee.memberid);
            cmdInserts.Parameters.AddWithValue("@member_name", employee.membername); */


            cn.Open();
            int i = cmdInsert.ExecuteNonQuery();

            bool status = false;

            if (i == 1)
            {
                status = true;
            }

            cn.Close();//finally
            cn.Dispose();//finally
            return status;



        }
        public bool Update(BookBAL school)
        {

            //SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthCnString"].ConnectionString);
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-5GL4B5D\\SQLEXPRESS1;Initial Catalog=Web;Integrated Security=True");

            SqlCommand cmdUpdate = new SqlCommand("[dbo].[Updatestudent]", cn);

            cmdUpdate.CommandType = System.Data.CommandType.StoredProcedure;
            cmdUpdate.Parameters.AddWithValue("@p_stuid", school.book_id);
            cmdUpdate.Parameters.AddWithValue("@p_stuname", school.book_name);
            cmdUpdate.Parameters.AddWithValue("@p_stuclass", school.book_author);
            cn.Open();
         int s = cmdUpdate.ExecuteNonQuery();
            bool statusd = false;
            if (s == 1)
            {
                statusd = true;
            }
            cn.Close();//finally
            cn.Dispose();//finally
            return statusd;

        }

        public BookBAL Find(int id)
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-5GL4B5D\\SQLEXPRESS1;Initial Catalog=Web;Integrated Security=True");

            //SqlCommand cmdSelect = new SqlCommand("[dbo].sp_Findstudent", cn);
            SqlCommand cmdSelect = new SqlCommand("[dbo].sp_Findstudent", cn);

            cmdSelect.CommandType = System.Data.CommandType.StoredProcedure;
            cmdSelect.Parameters.AddWithValue("@p_stuid", id);

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@p_name";
            p1.SqlDbType = System.Data.SqlDbType.NVarChar;
            p1.Size = 30;
            p1.Direction = System.Data.ParameterDirection.Output;
            cmdSelect.Parameters.Add(p1);


            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@p_stuclass";
            p2.SqlDbType = System.Data.SqlDbType.NVarChar;
            p2.Size = 20;
            p2.Direction = System.Data.ParameterDirection.Output;
            cmdSelect.Parameters.Add(p2);





            cn.Open();
            cmdSelect.ExecuteNonQuery();

            BookBAL found = new BookBAL();

            found.book_name = p1.Value.ToString();
            found.book_author = p2.Value.ToString();





            cn.Close();
            cn.Dispose();


            return found;



        }
        public List<BookBAL> List()
        {


            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-5GL4B5D\\SQLEXPRESS1;Initial Catalog=Web;Integrated Security=True");

            SqlCommand cmdlist = new SqlCommand("select book_id,book_name,book_author from book", cn);

            cn.Open();
            SqlDataReader dr = cmdlist.ExecuteReader();
            List<BookBAL> emplist = new List<BookBAL>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    BookBAL bal = new BookBAL();
                    bal.book_id= Convert.ToInt32(dr["book_id"]);
                    bal.book_name= dr["book_name"].ToString();
                    bal.book_author= dr["book_author"].ToString();


                    emplist.Add(bal);
                }
            }
            cn.Close();
            cn.Dispose();
            return emplist;

        }
        public bool Delete(int stuid)
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-5GL4B5D\\SQLEXPRESS1;Initial Catalog=Web;Integrated Security=True");

            SqlCommand cmdDelete = new SqlCommand("[dbo].sp_Deletestudent", cn);
            cmdDelete.CommandType = System.Data.CommandType.StoredProcedure;
            cmdDelete.Parameters.AddWithValue("@p_id", stuid);
            cn.Open();
            int i = cmdDelete.ExecuteNonQuery();
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            cn.Close();//finally
            cn.Dispose();//finally
            return status;

        }




    }
}
