using System;

namespace AdapterPattern
{
    public class MailImplementation
    {
        public void SendMail()
        {
            Console.WriteLine("Making call from MailImplementation");
        }
    }
}