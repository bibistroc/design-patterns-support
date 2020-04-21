using System;

namespace MediatorPattern
{
    public class Message1Handler : ContractHandler<Message1>
    {
        public override void HandleMessage(Message1 message)
        {
            Console.WriteLine($"Secret message: {message.SecretMessage}");
        }
    }
}
