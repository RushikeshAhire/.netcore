using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace database_final_.netcore
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Employees obj= new Employees { EmpNo = 11, Name="Rohan",Basic= 2345,DeptNo= 2 };
            //Connect();
            // Insert();
            // Update();
            // Delete();
            // Insert(obj);
            //  InsertParameterized(obj);
            GetSinglevalue();
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
            catch (Exception ex)
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
                cmdInsert.CommandText = "insert into Employees values(10,'Amol',1234,3)";

                cmdInsert.ExecuteNonQuery();
                Console.WriteLine("Succefully Added Data Into Database");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        static void Update()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Training;Integrated Security=True;";
            try
            {
                cn.Open();
                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = cn;
                cmdUpdate.CommandType = System.Data.CommandType.Text;
                cmdUpdate.CommandText = "Update Employees SET EmpNo=20 Where Name='Amol'";
                cmdUpdate.ExecuteNonQuery();
                Console.WriteLine("Succesfully Updated Your Data");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally { cn.Close(); }
        }

        static void Delete()
        {
            SqlConnection del = new SqlConnection();
            del.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Training;Integrated Security=True;";

            try
            {
                del.Open();
                SqlCommand cmdDelete = new SqlCommand();
                cmdDelete.Connection = del;
                cmdDelete.CommandType = System.Data.CommandType.Text;
                cmdDelete.CommandText = "delete from Employees where EmpNo=20";
                cmdDelete.ExecuteNonQuery();
                Console.WriteLine("Succefully Deleted Data From Table");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { del.Close(); }



        }

        static void Insert(Employees obj)
        {
            SqlConnection Insert= new SqlConnection();
            Insert.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Training;Integrated Security=True;";
            try
            {
                Insert.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = Insert;
                cmdInsert.CommandType= System.Data.CommandType.Text;
                cmdInsert.CommandText = $"insert into Employees values({obj.EmpNo},'{obj.Name}',{obj.Basic},{obj.DeptNo})";
                cmdInsert.ExecuteNonQuery();
                Console.WriteLine("Succefully Added Parameterized Data into table");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { Insert.Close(); }

        }

        static void InsertParameterized(Employees obj)
        {
            SqlConnection Insertparameter= new SqlConnection();
            Insertparameter.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Training;Integrated Security=True;";
            try
            {
                Insertparameter.Open();
                SqlCommand cmdInsertparameter = new SqlCommand();
                cmdInsertparameter.Connection = Insertparameter;
                cmdInsertparameter.CommandType= System.Data.CommandType.Text;
                cmdInsertparameter.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";

                cmdInsertparameter.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
                cmdInsertparameter.Parameters.AddWithValue("@Name", obj.Name);
                cmdInsertparameter.Parameters.AddWithValue("@Basic", obj.Basic);
                cmdInsertparameter.Parameters.AddWithValue("@DeptNo", obj.DeptNo);
                cmdInsertparameter.ExecuteNonQuery();
                Console.WriteLine("Succefully Added Parameterized @ Data in Table");
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
            finally { Insertparameter.Close(); }

        }

        static void GetSinglevalue()
        {
            SqlConnection Getsingle= new SqlConnection();
            Getsingle.ConnectionString =@"Data Source=(localdb)\ProjectModels;Initial Catalog=Training;Integrated Security=True;";
            try
            {
                Getsingle.Open();
                SqlCommand cmdGetsingle = new SqlCommand();
                cmdGetsingle.Connection = Getsingle;
                cmdGetsingle.CommandType= System.Data.CommandType.Text;
                cmdGetsingle.CommandText = "select count(*) from Employees";
                object retval= cmdGetsingle.ExecuteScalar();
                Console.WriteLine(retval);
                Console.WriteLine("succefully find GetSingle");

            }
            catch(Exception ex) { Console.WriteLine(ex.Message);}
            finally { Getsingle.Close(); }
        }







        public class Employees
        {
            public int EmpNo { get; set; }
            public string Name { get; set; }
            public decimal Basic { get; set; }
            public int DeptNo { get; set; }


        }

    }
}

