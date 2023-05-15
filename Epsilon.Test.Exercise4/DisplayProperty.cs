using System.Collections.Generic;

namespace Epsilon.Test.Exercise4
{
    public class DisplayProperty
    {
        public void Display<T>(T obj) where T : IProperties
        {
            Console.WriteLine(obj.GetName());
        }
    }
}
