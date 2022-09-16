using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMC_updated.CarDetails
{
    public class CarDetailsM
    {
        public static void CarDetailsAdd()
        {
            one:
            CarDetails cp = new CarDetails();
            Console.WriteLine("Enter Car Name");
            cp.Name = Console.ReadLine();
            Console.WriteLine(" Enter chesis Number e");
            cp.CN = Console.ReadLine();
            Console.WriteLine("Enter Car part Price");
            cp.partsPrice = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter MenPower Cost");
            cp.MenPowerCost = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Selling price");
            cp.SellingPrice = int.Parse(Console.ReadLine());

            cp.TotalCost = cp.partsPrice + cp.MenPowerCost;

            if (cp.SellingPrice > cp.TotalCost)
            {
                cp.Profit = cp.SellingPrice - cp.TotalCost;
                Console.WriteLine("Profit Generated : " + cp.Profit);
            }
            else
            {
                Console.WriteLine("No Profit Generated");
            }

            SqlConnection con = new SqlConnection("server=BHAVNAWKS851;database=CMC;integrated security=true");
            SqlCommand cmd = new SqlCommand("insert into car_details values ('" + cp.Name + "','" + cp.CN + "'," + cp.partsPrice + "," + cp.MenPowerCost + "," + cp.SellingPrice + "," + cp.TotalCost + "," + cp.Profit + ")", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            Console.WriteLine("Record Inserted Sucessfully");
            //-----------------------------------------------------------

            Console.WriteLine("press 1 to entering the details again and press any key to main menu.");
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

        public static void CarDetailsDisplay()
        {
            //details of car//
            two:
            CarDetails cd = new CarDetails();

            Console.WriteLine("Enter the car ID to be search : ");
            cd.ID = int.Parse(Console.ReadLine());
            SqlConnection con1 = new SqlConnection("server=BHAVNAWKS851;database=CMC;integrated security=true");
            SqlDataAdapter da = new SqlDataAdapter("select * from car_details ", con1);
            DataSet ds1 = new DataSet();
            da.Fill(ds1, "car_details");
            int b = ds1.Tables[0].Rows.Count;
            string c = ds1.Tables[0].Rows[0][1].ToString();
            Console.WriteLine("Total Number of records" + b);
            for (int k = 0; k < b; k++)
            {
                if (cd.ID.ToString() == ds1.Tables[0].Rows[k][0].ToString())
                {
                    Console.WriteLine("Name :" + ds1.Tables[0].Rows[k][1].ToString());
                    Console.WriteLine("Chesis Number :{0}", ds1.Tables[0].Rows[k][2].ToString());
                    Console.WriteLine("Car total parts price  :{0}", ds1.Tables[0].Rows[k][3].ToString());
                    Console.WriteLine("MenPower :{0}", ds1.Tables[0].Rows[k][4].ToString());
                    Console.WriteLine("Selling Price of car  :{0}", ds1.Tables[0].Rows[k][5].ToString());
                    Console.WriteLine("Total manufacturing cost :{0}", ds1.Tables[0].Rows[k][6].ToString());
                    Console.WriteLine("Net Profit :{0}", ds1.Tables[0].Rows[k][7].ToString());
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
        public static void CarDetailsDelete()
        {
            three:
            CarDetails cd = new CarDetails();

            Console.WriteLine("Enter the car ID to delete the record: ");
            cd.ID = int.Parse(Console.ReadLine());
            SqlConnection con = new SqlConnection("server=BHAVNAWKS851;database=CMC;integrated security=true");    
            SqlCommand cmd = new SqlCommand("delete from car_details where car_id = '"+cd.ID+"'" , con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            Console.WriteLine("Record Inserted Sucessfully");
            //--------------------------------------------------------------------------------
            Console.WriteLine("press 1 to Display Another record  again and press any key to main menu.");
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
