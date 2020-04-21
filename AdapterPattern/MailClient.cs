namespace AdapterPattern
{
    public class MailClient : Client
    {
        private readonly MailImplementation mail;

        public MailClient()
        {
            mail = new MailImplementation();
        }

        public override void MakeCall()
        {
            mail.SendMail();
        }
    }
}
