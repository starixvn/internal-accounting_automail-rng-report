using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Testing_Sending_Email.Business;

namespace Testing_Sending_Email
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Sending email ...");

            bool status = TestEmail.SendMail();
            if (status)
            {
                Console.WriteLine("Sending email is successful");
            }
            else
            {
                Console.WriteLine("Sending email is unsuccessful");
            }

            Console.ReadLine();
        }
    }
}
