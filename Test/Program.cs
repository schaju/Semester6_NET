using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using Model;

namespace Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var provider = new ConnectionProvider();
                var broker = new UserAccountBroker(provider);
                UserAccount account = broker.GetUser("florian", "pwd");

                if (account != null)
                {
                    Console.WriteLine(account.UserName);
                    Console.WriteLine(account.Password);
                }
                else
                {
                    Console.WriteLine("Falscher Username / Passwort");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.In.Read();
        }
    }
}