using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Database1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Connect();
            Insert();
        }
       static void Connect()
            { 
            SqlConnection conn = new SqlConnection();
            //Data Source=(localdb)\ProjectModels;Initial Catalog=Training;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
            conn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Training;Integrated Security=True;";
            try
            {
                conn.Open();
                Console.WriteLine("success");
                Console.ReadLine();
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
      
            
            
        }
       
       static void Insert()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Training;Integrated Security=True;";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText="insert into Employees values(10,'Amol',1234,3)";

                cmdInsert.ExecuteNonQuery();
                Console.WriteLine("Succefully Added Data Into Database");

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

    }
}
