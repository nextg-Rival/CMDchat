using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCP_Client
{
    class MainClass
    {
            static void Main(string[] args)
            {
            //login system V2
            string UNcompare;
            string Pcompare;
            string pathToTxt = @"...\TCP server\Login.txt";
            Console.WriteLine("Enter your username please!");
            string Username = Console.ReadLine();
            Console.WriteLine("Enter your password please!");
            string Password = Console.ReadLine();
            StreamWriter loginWINP = new StreamWriter(pathToTxt);
            loginWINP.WriteLine(Username);
            loginWINP.WriteLine(Password);
            loginWINP.Close();
            // !!!MASSIVE BUG - DOESN'T READ FROM CLIENT!!! ---------- IN THE CLIENT FILE THIS CODE IS PRETTY MUCH USELESS, RIGHT? WILL CHECK LATER ON!
            FileStream loginReader = new FileStream(@"...\TCP server\Login.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader loginRINP = new StreamReader(loginReader);
            UNcompare = loginRINP.ReadLine();
            Pcompare = loginRINP.ReadLine();
            loginRINP.Close();
            // check access privileges
            if (UNcompare != Username || Pcompare != Password)
            {
                Console.WriteLine("Error.");
                Console.ReadKey();
                Environment.Exit(0);
            }
            //end login system V2
            

            //login system beginning - V1
            //File.Create("C:\\Desktop\\C#\\Programs\\Projects\\TCP server\\Login.txt");
            //below - create login
            //FileStream loginWriter = new FileStream("C:\\Desktop\\C#\\Programs\\Projects\\TCP server\\Login.txt", FileMode.OpenOrCreate, FileAccess.Write);
            //StreamWriter loginWINP = new StreamWriter(loginWriter);
            //loginWINP.Write("Username: ");
            //loginWINP.Write(Console.ReadLine());
            //loginWINP.Close();
            //below - read client input - !!!BUG IS HERE - DOESN'T READ FROM CLIENT!!!
            //FileStream loginReader = new FileStream("C:\\Desktop\\C#\\Programs\\Projects\\TCP server\\Login.txt", FileMode.OpenOrCreate, FileAccess.Read);
            //StreamReader loginRINP = new StreamReader(loginReader);
            //textBox1.Text = loginRINP.ReadToEnd();
            //loginRINP.Close();
            //login system end - V1
            Console.WriteLine("Multi-Threaded TCP Server Demo");
                Console.WriteLine("Provide IP:");
                String ip = Console.ReadLine();

                Console.WriteLine("Provide Port:");
                int port = Int32.Parse(Console.ReadLine());

                ClientDemo client = new ClientDemo(ip, port);
            }
        }
    }
