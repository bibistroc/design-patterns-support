using System;
using System.Linq;
using System.Reflection;

namespace MediatorPattern
{
    public class Mediator
    {
        public void Send<TMessage>(TMessage message)
            where TMessage : Message
        {
            Type contractHandlerType = typeof(ContractHandler<>);
            Type contractHandlerForMessageType = contractHandlerType.MakeGenericType(typeof(TMessage));
            MethodInfo handleMessageMethod = contractHandlerForMessageType.GetMethod("HandleMessage");

            Type messageHandler = Assembly.GetAssembly(typeof(Message))
                .GetTypes()
                .First(t => !t.IsAbstract && t.IsSubclassOf(contractHandlerForMessageType));


            object messageHandlerInstance = Activator.CreateInstance(messageHandler);
            handleMessageMethod.Invoke(messageHandlerInstance, new object[] { message });
        }
    }
}
