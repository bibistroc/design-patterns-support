using System;

namespace AdapterPattern
{
    public class Client
    {
        public virtual void MakeCall()
        {
            Console.WriteLine("Making call from Client");
        }
    }
}
