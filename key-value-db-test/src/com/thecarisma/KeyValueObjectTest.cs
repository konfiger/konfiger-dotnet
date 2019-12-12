using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.thecarisma
{
    class KeyValueObjectTest
    {
        public KeyValueObjectTest()
        {
            KeyValueObject kvo1 = new KeyValueObject("Greetings ", "Hello world from Adewale Azeez");
            Console.WriteLine(kvo1);
            Console.ReadKey();
        }

        public static void Main(string[] args)
        {
            new KeyValueObjectTest();
            new KeyValueDBTest();
        }

    }
}
