namespace DependencyInjection_FromScratch
{
    public class SingletonDemoWithConstructor
    {
        private readonly ISingletonDemo singletonDemo;

        public SingletonDemoWithConstructor(ISingletonDemo singletonDemo)
        {
            this.singletonDemo = singletonDemo;
        }
    }
}
