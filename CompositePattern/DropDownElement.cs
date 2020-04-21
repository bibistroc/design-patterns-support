namespace CompositePattern
{
    public abstract class DropDownElement
    {
        protected string name;
        protected const int factor = 2;
        protected const char prefix = '-';

        protected DropDownElement(string name)
        {
            this.name = name;
        }

        public abstract void Add(DropDownElement element);
        public abstract void Remove(DropDownElement element);
        public abstract void Display(int depth);

        public void Display()
        {
            Display(1);
        }
    }
}
