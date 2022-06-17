using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Ado.Net
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();

            Console.WriteLine("Insert into customer table");
            string result = program.InsertCustomerDB();
           // System.Data.DataTable

           Console.WriteLine(result);
           Console.ReadLine();

            //select query
            /*DataTable dt = new DataTable();
            dt = program.SelectCustomerDB();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++) 
            {
              Console.Write(dt.Rows[i][j] + "\t\t");
            }
              Console.WriteLine();
            }
 
             dt=program.SelectCustomerDBbyId(1);//select query by customer id 

                for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
            {
              Console.Write(dt.Rows[i][j] + "\t\t");
            }
              Console.WriteLine();
            }*/


            //update
           /* Console.WriteLine("update into customer table");
            program.UpdateCustomerDB();
            Console.WriteLine();*/

            //delete
            /*Console.WriteLine("delete into customer table");
            program.DeleteInCustomerDB("address");
            Console.WriteLine();*/

        }

        public static string sqlConnectionStr = @"Data Source=LAPTOP-3AOH9UNJ\SQLEXPRESS;Initial Catalog=CustomerDB;Integrated Security=True";

        public string InsertCustomerDB()
        {
            //Console.Write("Enter Customer Id: ");
            //int id = Convert.ToInt32((Console.ReadLine()));

                Console.Write("Enter Customer name: ");
                string name = (Console.ReadLine());

                Console.Write("Enter Customer Address: ");
                string address = (Console.ReadLine());

                Console.Write("Enter Customer phone number: ");
                int phoneNo = Convert.ToInt32((Console.ReadLine()));

                //insert into Customer_Table
                SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection stablishmentg
                SqlCommand cmd = new SqlCommand("insert into Customer_Table Values('" + name + "','" + address + "'," + phoneNo + ")", sqlConnection);
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                return "Customer Details Inserted!!";
        }
        public DataTable SelectCustomerDB()
        {
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);
            SqlCommand cmd = new SqlCommand("select* from Customer_Table", sqlConnection);
            sqlConnection.Open();//connection state
            SqlDataReader sqlDataReader = cmd.ExecuteReader();//execute select statement

            DataTable dataTable = new DataTable();
            dataTable.Load(sqlDataReader);

            sqlConnection.Close();
            return dataTable;
        }
        public DataTable SelectCustomerDBbyId(int id)
        {

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection establishment
            string db = sqlConnection.Database;
            SqlCommand cmd = new SqlCommand("select * from Customer_Table where id=" + id, sqlConnection);
            sqlConnection.Open();//connection state is open

            SqlDataReader dataReader = cmd.ExecuteReader();//execute select statment

            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);
            //DataTable, DataSet
            sqlConnection.Close(); //connection state is close
            return dataTable;
        }
        //update query
        //update a perticular row by CustomerAddress
        public string UpdateCustomerDB()
        {
            //Console.Write("Enter customer Id to update: ");
            //int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter customer name  to update: ");
            string name = Console.ReadLine();


            Console.Write("Enter address to update: ");
            string address = (Console.ReadLine());

            Console.Write("Enter phoneNo to update: ");
            int phoneNo = Convert.ToInt32(Console.ReadLine());


            //update customer data into sqlserver
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);
            SqlCommand cmd = new SqlCommand("update Customer_Table set address='" + address + "' , name ='" + name + "' , phoneNo='" + phoneNo + "' where address=" + address + "", sqlConnection);
            sqlConnection.Open();//connection state is open
            int result = cmd.ExecuteNonQuery();
            sqlConnection.Close(); //connection state is close
            if (result == 0)
            return "Not Updated";
            return "Updated";
        }

        // delete query
        public string DeleteInCustomerDB(string address)
        {
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStr);//connection establishment
            SqlCommand cmd = new SqlCommand("delete from Customer_Table where address=" + address, sqlConnection);
            sqlConnection.Open();//connection state is open
            int result = cmd.ExecuteNonQuery();//execute my sql commands and return no of rows affected
            sqlConnection.Close(); //connection state is close
            if (result == 0)
            return "Not Deleted";
            return "Deleted";
        }


    }
}
    

       

    




    
