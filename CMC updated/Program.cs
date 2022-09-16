using CMC_updated.CarDetails;
using CMC_updated.EmployeeDetails;
using CMC_updated.PartsDetails;
using System.Data;

namespace CMC_updated
{
    internal class Program
    {
        static void Main(string[] args)
        {   //Login Text
            Start:
                
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("===================================================================\n");
            Console.WriteLine("\tHi Welcome to BCMC(Bhavna Car Manufacturing Company");
            Console.WriteLine("\n===================================================================\n");

            //LoginPage
            Console.WriteLine("Press 1 For Login and Press 2 for Exit.");
            string A = Console.ReadLine();

            if (A=="1")
            {
                Start1:
                Console.ForegroundColor = ConsoleColor.White;
                string Username = @"admin@123";
                string Password = @"admin@123";
                Console.WriteLine("Please Enter Your Username :");
                string LoginUn = Console.ReadLine();
                Console.WriteLine("Please Enter Your Password :");
                string LoginPW = Console.ReadLine();


                if (Username == LoginUn && Password == LoginPW)
                {
                    //Normal Messages
                    
                    
                    Console.WriteLine("===================================================================\n");
                    Console.WriteLine("\tcongratulations you successfully login)");
                    Console.WriteLine("\n===================================================================\n");

                    //cass for entering in different differnet tables//
                    MainMenu:
                    Console.WriteLine("Press\n1 for Car Details\n2 for Employee Details\n3 for Parts details\n4 for Exit");
                    int B = int.Parse(Console.ReadLine());


                    switch (B)
                    {
                        case 1:
                            Console.WriteLine("\t\t\n\n<-----  SUCCESS  ----->\t\t Access granted to the car detailas Room\n\n");
                            Console.WriteLine("Press\n1 for entering the details\n2 for display the details\n3 for delete details\nanything for main menu\n");
                            int C=int.Parse(Console.ReadLine());
                            switch (C)
                            {
                                case 1://for adding car details
                                    one:
                                    CarDetailsM.CarDetailsAdd();
                                   
                                    
                                    break;
                                case 2://for display of car details
                                    CarDetailsM.CarDetailsDisplay();
                                    break;
                                case 3://for delete car details
                                    CarDetailsM.CarDetailsDelete();
                                    break;
                                default:
                                    Console.Clear();
                                    goto MainMenu;
                                    break;
                            }
                            break;
                        case 2:
                            Console.WriteLine("\t\t\n\n<-----  SUCCESS  ----->\t\t Access granted to the Employee detailas Room\n\n");
                            Console.WriteLine("Press\n1 for entering the details\n2 for display the details\n3 for delete details\n4 for main menu\n");
                            //Swirch case----->
                            string D = Console.ReadLine();
                            switch (D)
                            {
                                case "1"://for adding employee details
                                    EmpDetailsM.EmpDetailsAdd();
                                    break;
                                case "2":
                                    EmpDetailsM.EmpDetailsDisplay();
                                    break;
                                case "3":
                                    EmpDetailsM.EmployeDelete();
                                    break;
                                default:
                                    Console.Clear();
                                    goto MainMenu;
                                    break;
                            }
                            break;
                        case 3:
                            Console.WriteLine("\t\t\n\n<-----  SUCCESS  ----->\t\t Access granted to the car Room\n\n");
                            Console.WriteLine("Press\n1 for entering the details\n2 for display the details\n3 for delete details\n4 for main menu\n");
                            string E = Console.ReadLine();
                            switch (E)
                            {
                                case "1":
                                    PartsM.PartsAdd();
                                    Console.Clear();
                                    break;
                                case "2":
                                    PartsM.PartsDisplay();
                                    Console.Clear();
                                    break;
                                case "3":
                                    PartsM.PartsDelete();
                                    Console.Clear();
                                    break;
                                default:
                                    goto MainMenu;
                                    break;
                            }
                            break;
                        case 4:
                            break;

                        default:
                            Environment.Exit(0);
                            break;
                    }

                }

                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\t\t|||||  Username and Password are incorrect\n\t\tPlease Enter Something Valid |||||\n\n\n");
                    goto Start1;
                }
            }
            
            else if (A=="2")
            {
                Environment.Exit(0);

            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\t|||||  Please Enter Something Valid |||||\n\n\n");
                goto Start;
            }



        }
    }
}