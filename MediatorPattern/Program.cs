namespace MediatorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();

            Message1 message1 = new Message1
            {
                SecretMessage = "my secret message"
            };

            mediator.Send(message1);

            Message2 message2 = new Message2
            {
                NotSoSecretMessage = "not so secret message"
            };

            mediator.Send(message2);
        }
    }
}
