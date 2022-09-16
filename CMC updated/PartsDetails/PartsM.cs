using CMC_updated.EmployeeDetails;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMC_updated.PartsDetails
{
    public class PartsM
    {
        public static void PartsAdd()
        {
            Console.WriteLine("Welcome to Bhavna CMC Employee section");
            one:
            Parts me = new Parts();//class call object creation
                                   //taking inputs
            Console.WriteLine("Enter Part name : ");
            me.name = Console.ReadLine();
            Console.WriteLine("Enter Price : ");
            me.price = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Quantity: ");
            me.quantity = int.Parse(Console.ReadLine());

            SqlConnection con = new SqlConnection("server=BHAVNAWKS851;database=CMC;integrated security=true");//SQL Connection
            SqlCommand cmd = new SqlCommand("insert into parts values('" + me.name + "'," + me.price + "," + me.quantity + ")", con);//sql insertion command
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("one part added sucessfully");
            Console.WriteLine("Press 1  to add another part details in the list and press anykey to exit");
            int a = int.Parse(Console.ReadLine());
            string D = Console.ReadLine();
            if (D == "1")
            {
                Console.Clear();
                Console.WriteLine("Enter Another Details : ");
                goto one;
            }
            else
            {
                Environment.Exit(0);
            }
        }
        public static void PartsDisplay()
        {
        two:
            Console.WriteLine("Enter the part ID to see the details");
            Parts pa = new Parts();
            pa.id = int.Parse(Console.ReadLine());

            SqlConnection con = new SqlConnection("server=BHAVNAWKS851;database=CMC;integrated security=true");
            SqlDataAdapter da = new SqlDataAdapter("select * from parts ", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Employee");
            int b = ds.Tables[0].Rows.Count;
            string c = ds.Tables[0].Rows[0][1].ToString();
            Console.WriteLine("Total Number of records" + b);
            for (int k = 0; k < b; k++)
            {
                if (pa.id.ToString() == ds.Tables[0].Rows[k][0].ToString())
                {
                    Console.WriteLine("Name :" + ds.Tables[0].Rows[k][1].ToString());
                    Console.WriteLine("Price :{0}", ds.Tables[0].Rows[k][2].ToString());
                    Console.WriteLine("Quantity  :{0}", ds.Tables[0].Rows[k][3].ToString());
                }
            }
            //----------------------------------------------
            Console.WriteLine("press 1 to Display Another record  again and press any key to main menu.");
            string D = Console.ReadLine();
            if (D == "1")
            {
                Console.Clear();
                Console.WriteLine("Enter Another Details : ");
                goto two;
            }
            else
            {
                Environment.Exit(0);
            }
        }
        public static void PartsDelete()
        {
        three:
            Parts cd = new Parts();

            Console.WriteLine("Enter the Part ID to delete the record: ");
            cd.id = int.Parse(Console.ReadLine());
            SqlConnection con = new SqlConnection("server=BHAVNAWKS851;database=CMC;integrated security=true");
            SqlCommand cmd = new SqlCommand("delete from parts where p_id = '" + cd.id + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            Console.WriteLine("Record Inserted Sucessfully");
            //--------------------------------------------------------------------------------
            Console.WriteLine("press 1 to Delete Another record  again or press any key to main menu.");
            string D = Console.ReadLine();
            if (D == "1")
            {
                Console.Clear();
                Console.WriteLine("Enter Another Details : ");
                goto three;
            }
            else
            {
                Environment.Exit(0);

            }
        }
    }
}
