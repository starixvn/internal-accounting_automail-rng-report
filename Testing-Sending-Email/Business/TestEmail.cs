using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fanex.MailDeliver.Model;

namespace Testing_Sending_Email.Business
{
    public static class TestEmail
    {
        public static bool SendMail()
        {
            bool status = false;
            try
            {
                using (var client = new Fanex.MailDeliver.MailClient.API.MailDeliver())
                {
                    var mailItem = new MailRecord
                    {
                        MailTo = AppSettings.To,
                        Title = "Testing Send Email",
                        Subject = "Testing Send Email",
                        Body = "Testing Send Email - " + DateTime.Now.ToString()
                    };

                    client.SendMail(mailItem);
                    status = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }

            return status;
        }
    }
}
