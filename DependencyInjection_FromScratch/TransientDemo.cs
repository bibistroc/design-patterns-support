namespace DependencyInjection_FromScratch
{
    public class TransientDemo
    {
        private readonly ISingletonDemo singletonDemo;

        public TransientDemo(ISingletonDemo singletonDemo)
        {
            this.singletonDemo = singletonDemo;
        }
    }
}
