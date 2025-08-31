using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    public class MainMenu
    {
        public static void Menu()
        {
            try
            {
                int choice = 0;
               
                    Console.WriteLine("Choose A Mode :");
                    Console.WriteLine("1. Doctor Mode.");
                    Console.WriteLine("2. Student Mode.");
                    Console.WriteLine("3. Exit.");

                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Doctor doctor = new Doctor();
                            doctor.DoctorMode();
                            break;

                    }
                
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
    }
}
