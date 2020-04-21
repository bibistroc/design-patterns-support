using System;

namespace CompositePattern
{
    public class Element : DropDownElement
    {
        public Element(string name)
            : base(name)
        {
        }

        public override void Add(DropDownElement element)
        {
            Console.WriteLine($"[{name}] Cannot add elements to an element");
        }

        public override void Remove(DropDownElement element)
        {
            Console.WriteLine($"[{name}] Cannot remove elements from an element");
        }

        public override void Display(int depth)
        {
            string start = new string(prefix, depth);
            Console.WriteLine($"{start}{name}");
        }
    }
}
