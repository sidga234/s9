using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MyHomeLibary.Models
{
    public class LibraryDataAccessLayer
    {
        string connectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Library;Data Source=INDLAPTOP280\SQLEXPRESS";

        //To View all employees details
        public IEnumerable<Books> GetAllBooks()
        {
            try
            {
                List<Books> lstBooks = new List<Books>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetALLBookRecords", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Books books = new Books();
                        books.ID = Convert.ToInt32(rdr["ID"]);
                        books.BookName = Convert.ToString(rdr["BookName"]);
                        books.AuthorName = Convert.ToString(rdr["AuthorName"]);
                        books.Class = Convert.ToString(rdr["Class"]); 
                        books.Language= Convert.ToString(rdr["Language"]);
                        books.Price = Convert.ToDecimal(rdr["Price"]);
                        books.DateOfPurchase = Convert.ToString(rdr["DateOfPurchase"]);
                        books.Publisher = Convert.ToString(rdr["Publisher"]);
                        books.Type = Convert.ToString(rdr["Type"]);
                        lstBooks.Add(books);
                    }
                    con.Close();
                }
                return lstBooks;
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<Books> GetAllBooksByBookName(string _SearchByBookName)
        {
            try
            {
                List<Books> lstBooks = new List<Books>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetALLBookRecordsByBookName", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@_BookName", _SearchByBookName));
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Books books = new Books();
                        books.ID = Convert.ToInt32(rdr["ID"]);
                        books.BookName = Convert.ToString(rdr["BookName"]);
                        books.AuthorName = Convert.ToString(rdr["AuthorName"]);
                        books.Class = Convert.ToString(rdr["Class"]);
                        books.Language = Convert.ToString(rdr["Language"]);
                        books.Price = Convert.ToDecimal(rdr["Price"]);
                        books.DateOfPurchase = Convert.ToString(rdr["DateOfPurchase"]);
                        books.Publisher = Convert.ToString(rdr["Publisher"]);
                        books.Type = Convert.ToString(rdr["Type"]);
                        lstBooks.Add(books);
                    }
                    con.Close();
                }
                return lstBooks;
            }
            catch
            {
                throw;
            }
        }


        public IEnumerable<Types> GetAllTypes ()
        {
            try
            {
                List<Types> lstTypes = new List<Types>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetAllType", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Types types = new Types();
                        types.TypeId = Convert.ToInt32(rdr["TypeId"]);
                        types.Type = Convert.ToString(rdr["Type"]);

                        lstTypes.Add(types);
                    }
                    con.Close();
                }
                return lstTypes;
            }
            catch
            {
                throw;
            }
        }


        public IEnumerable<Classs> GetAllClasses()
        {
            try
            {
                List<Classs> lstClasses = new List<Classs>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetALLClasss", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Classs cls = new Classs();
                        cls.ClassId = Convert.ToInt32(rdr["ClassId"]);
                        cls.Class = Convert.ToString(rdr["Class"]);

                        lstClasses.Add(cls);
                    }
                    con.Close();
                }
                return lstClasses;
            }
            catch
            {
                throw;
            }
        }


        public IEnumerable<Languages> GetAllLanguages()
        {
            try
            {
                List<Languages> lstlanguage = new List<Languages>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetALLLanguage", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Languages lag = new Languages();
                        lag.LanguageId = Convert.ToInt32(rdr["LanguageId"]);
                        lag.Language = Convert.ToString(rdr["Language"]);

                        lstlanguage.Add(lag);
                    }
                    con.Close();
                }
                return lstlanguage;
            }
            catch
            {
                throw;
            }
        }

        public Books GetBookByID(int Bookid)
        {
            try
            {

                Books books = new Books();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetBookRecord", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", Bookid));
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                      
                        books.ID = Convert.ToInt32(rdr["ID"]);
                        books.BookName = Convert.ToString(rdr["BookName"]);
                        books.AuthorName = Convert.ToString(rdr["AuthorName"]);
                        books.Class = Convert.ToString(rdr["Class"]);
                        books.Language = Convert.ToString(rdr["Language"]);
                        books.DateOfPurchase = Convert.ToString(rdr["DateOfPurchase"]);
                        books.Publisher = Convert.ToString(rdr["Publisher"]);
                        books.Type = Convert.ToString(rdr["Type"]);
                        books.Price = Convert.ToDecimal(rdr["Price"]);
                    }
                    con.Close();
                }
                return books;
            }
            catch
            {
                throw;
            }
        }

        //To Add new books record 
        public int AddBooks(Books objbooks)


        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAddBooks", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BookName", objbooks.BookName);
                    cmd.Parameters.AddWithValue("@AuthorName", objbooks.AuthorName);
                    cmd.Parameters.AddWithValue("@Class",objbooks.Class);
                    cmd.Parameters.AddWithValue("@Language", objbooks.Language);
                    cmd.Parameters.AddWithValue("@DateOfPurchase", objbooks.DateOfPurchase);
                    cmd.Parameters.AddWithValue("@Publisher", objbooks.Publisher);
                    cmd.Parameters.AddWithValue("@Type", objbooks.Type);
                    cmd.Parameters.AddWithValue("@Price", objbooks.Price);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

     
        public int UpdateBooks(Books objbooks)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateBooks", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", objbooks.ID);
                    cmd.Parameters.AddWithValue("@BookName", objbooks.BookName);
                    cmd.Parameters.AddWithValue("@AuthorName", objbooks.AuthorName);
                    cmd.Parameters.AddWithValue("@Class", objbooks.Class);
                    cmd.Parameters.AddWithValue("@Language", objbooks.Language);
                    cmd.Parameters.AddWithValue("@DateOfPurchase", objbooks.DateOfPurchase);
                    cmd.Parameters.AddWithValue("@Publisher", objbooks.Publisher);
                    cmd.Parameters.AddWithValue("@Type", objbooks.Type);
                    cmd.Parameters.AddWithValue("@Price", objbooks.Price);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

          
        public int DeleteBooks(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteBooks", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

    }
}
