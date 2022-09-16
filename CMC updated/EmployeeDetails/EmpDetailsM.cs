using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMC_updated.EmployeeDetails
{
    public class EmpDetailsM
    {
        //adding employee details
        public static void EmpDetailsAdd()
        {
            Console.WriteLine("Welcome to Bhavna CMC Employee section");
            one:
            EmpDetails emp = new EmpDetails();//class call object creation
                                              //taking inputs
            Console.WriteLine("Enter Employee name : ");
            emp.EmpName = Console.ReadLine();
            Console.WriteLine("Enter Employee Department : ");
            emp.EmpDepartment = Console.ReadLine();
            Console.WriteLine("Enter Working Hours :");
            emp.EmpWHours = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Gender : ");
            emp.EmpGender = Console.ReadLine();
            if (emp.EmpWHours > 9)
            {
                emp.EmpSalary = (9 + (emp.EmpWHours - 9) * 2);
                emp.EmpSalary *= 800;
            }
            else
            {
                emp.EmpSalary = emp.EmpWHours * 800;
            }

            SqlConnection con = new SqlConnection("server=BHAVNAWKS851;database=CMC;integrated security=true");//SQL Connection
            SqlCommand cmd = new SqlCommand("insert into Employee values('" + emp.EmpName + "','" + emp.EmpDepartment + "', " + emp.EmpWHours + ",'" + emp.EmpGender + "'," + emp.EmpSalary + ")", con);//sql insertion command
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("one Employee details added sucessfully");
            Console.WriteLine("Press 1  to add another Employee details in the list and press anykey to exit");
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
        public static void EmpDetailsDisplay()
        {
            two:
            Console.WriteLine("Enter the Employee ID to see the details");
            EmpDetails emp = new EmpDetails();
            emp.EmpId = int.Parse(Console.ReadLine());

            SqlConnection con = new SqlConnection("server=BHAVNAWKS851;database=CMC;integrated security=true");
            SqlDataAdapter da = new SqlDataAdapter("select * from Employee ", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Employee");
            int b = ds.Tables[0].Rows.Count;
            string c = ds.Tables[0].Rows[0][1].ToString();
            Console.WriteLine("Total Number of records" + b);
            for (int k = 0; k < b; k++)
            {
                if (emp.EmpId.ToString() == ds.Tables[0].Rows[k][0].ToString())
                {
                    Console.WriteLine("Name :" + ds.Tables[0].Rows[k][1].ToString());
                    Console.WriteLine("Department :{0}", ds.Tables[0].Rows[k][2].ToString());
                    Console.WriteLine("Working Hours  :{0}", ds.Tables[0].Rows[k][3].ToString());
                    Console.WriteLine("Gender :{0}", ds.Tables[0].Rows[k][4].ToString());
                    Console.WriteLine("Salary  :{0}", ds.Tables[0].Rows[k][5].ToString());
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
        public static void EmployeDelete()
        {
        three:
            EmpDetails cd = new EmpDetails();

            Console.WriteLine("Enter the Employee ID to delete the record: ");
            cd.EmpId = int.Parse(Console.ReadLine());
            SqlConnection con = new SqlConnection("server=BHAVNAWKS851;database=CMC;integrated security=true");
            SqlCommand cmd = new SqlCommand("delete from Employee where emp_id = '" + cd.EmpId + "'", con);
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
