using System.Collections.Generic;

namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Client> clientList = new List<Client>
            {
                new Client(),
                new MailClient()
            };

            foreach (Client client in clientList)
            {
                client.MakeCall();
            }
        }
    }
}
