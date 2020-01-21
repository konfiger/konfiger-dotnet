using System;

namespace io.github.thecarisma
{
    class KeyValueDBTest
    {
        public KeyValueDBTest()
        {
            KeyValueDB keyValueDB = new KeyValueDB("One=Adewale\nThrees=3333", true, '=', '\n', false);
            Console.WriteLine();
            foreach (KeyValueObject kvo in keyValueDB) {
                Console.WriteLine(kvo);
            }        
            Console.WriteLine(keyValueDB.Get("Greeting"));
            keyValueDB.Set("Greeting", "Hello from Adewale Azeez");
            keyValueDB.Add("One", "Added another one element");
            keyValueDB.Add("Null", "Remove this");
            Console.WriteLine(keyValueDB.GetLike("Three"));
        
            Console.WriteLine();
            foreach (KeyValueObject kvo in keyValueDB) {
                Console.WriteLine(kvo);
            }
            Console.WriteLine();
            Console.WriteLine("Removed: " + keyValueDB.Remove("Null"));
        
            Console.WriteLine(keyValueDB);
            Console.WriteLine();
            keyValueDB.Add("Two", "Added another two element");
            Console.WriteLine(keyValueDB);
            Console.WriteLine();
            keyValueDB.Add("Three", "Added another three element");
            Console.WriteLine(keyValueDB);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
