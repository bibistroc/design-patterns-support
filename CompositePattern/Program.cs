namespace CompositePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            DropDownElement root = new DropDown("root");

            DropDownElement firstDropdown = new DropDown("firstDropdown");
            firstDropdown.Add(new Element("first"));
            firstDropdown.Add(new Element("second"));
            firstDropdown.Add(new Element("third"));

            root.Add(firstDropdown);

            DropDownElement secondDropdown = new DropDown("secondDropdown");
            secondDropdown.Add(new Element("first 2"));
            secondDropdown.Add(new Element("second 2"));

            root.Add(secondDropdown);

            DropDownElement thirdDropdown = new DropDown("thirdDropdown");
            DropDownElement element = new Element("first 3");
            element.Add(new Element("first 3.1"));
            thirdDropdown.Add(element);

            root.Add(thirdDropdown);

            root.Display();
        }
    }
}
