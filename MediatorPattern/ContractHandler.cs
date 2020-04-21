namespace MediatorPattern
{
    public abstract class ContractHandler<TMessage>
        where TMessage : Message
    {
        public abstract void HandleMessage(TMessage message);
    }
}
