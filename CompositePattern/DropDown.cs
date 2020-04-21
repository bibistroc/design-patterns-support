using System;
using System.Collections.Generic;

namespace CompositePattern
{
    public class DropDown : DropDownElement
    {
        private readonly List<DropDownElement> elements;

        public DropDown(string name)
            : base(name)
        {
            elements = new List<DropDownElement>();
        }

        public override void Add(DropDownElement element)
        {
            elements.Add(element);
        }

        public override void Remove(DropDownElement element)
        {
            elements.Remove(element);
        }

        public override void Display(int depth)
        {
            string start = new string(prefix, depth);
            Console.WriteLine($"{start}{name}");
            
            foreach (DropDownElement element in elements)
            {
                element.Display(depth+factor);
            }
        }
    }
}
