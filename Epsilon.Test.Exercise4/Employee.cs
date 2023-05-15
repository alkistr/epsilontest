using Epsilon.Test.Exercise4;

namespace Epsilon.Test.Exercise4
{
    public class Employee : IProperties
    {
        public string Name { get; set; }
        public string GetName()
        {
            return Name;
        }
    }
}
