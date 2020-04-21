using System;

namespace MediatorPattern
{
    public class Message2Handler : ContractHandler<Message2>
    {
        public override void HandleMessage(Message2 message)
        {
            Console.WriteLine($"Not so Secret message: {message.NotSoSecretMessage}");
        }
    }
}
