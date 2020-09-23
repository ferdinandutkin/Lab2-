using System;
using System.Text;
using System.Linq;


namespace Program
{
    
    public static class PM
    {
        public static object Pack(this object o) => o;
        public static T Unpack<T>(this object o) => (T)o;
       
    }
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {

                Console.WriteLine(@"Введите номер задания:
                                    1) Типы
                                    2) Строки
                                    3) Массивы
                                    4) Кортежи
                                    5) Работа с массивами
                                    6) Работа с checked/unchecked");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Task1();
                        break;

                    case 2:
                        Task2();
                        break;

                    case 3:
                        Task3();
                        break;

                    case 4:
                        Task4();
                        break;

                    case 5:
                        Task5();
                        break;
                    case 6:
                        Task6();
                        break;

                }
                Console.ReadKey();

                Console.Clear();

            }
           
        }
        static void Task1()
        { 

            sbyte sbyteVar = -101;
            byte byteVar = 205;
            short shortVar = -30000;
            ushort ushortVar = 60000;
            int intVar = -5;
            uint uintVar = 5u;
            long longVar = -50L;
            ulong ulongVar = 50ul;
            char charVar = 'A';
            float floatVar = 10.1f;
            double doubleVar = 100.1d;
            bool boolVar = true;

            decimal decimalVar = 104.33m;
            string stringVar = "Hello";
            dynamic dynamicVarFloat = 567F;
            dynamic dynamicVarString = "thisisme";
            object objectVarChar = 'B';

            bool boolVarConverted = Convert.ToBoolean(1);
            int intVarConverted = Convert.ToInt32("1783874");


            Array.ForEach(new[]
            {
                sbyteVar, byteVar, shortVar, ushortVar, intVar, uintVar, longVar, ulongVar, charVar, floatVar, doubleVar, boolVar, doubleVar,
                boolVar, decimalVar, stringVar,  dynamicVarFloat, objectVarChar
            }, Console.WriteLine);
          
            Console.WriteLine();

            //b - операции явного и неявного приведения типов

            charVar = (char)intVar;
            intVar = charVar;

            uintVar = (uint)shortVar;
            shortVar = sbyteVar;

            intVar = (int)floatVar;
            floatVar = intVar;


            uintVar = (uint)decimalVar;
            decimalVar = uintVar;


            doubleVar = floatVar;
            floatVar = (float)doubleVar;

            //c - упаковка и распаковка значимых типов
             
            int topack = 10;
            var packed = topack.Pack(); //Упаковка
            int unpacked = packed.Unpack<int>();

            //d - неявная типизация

            var variable = 99;
            var auto = "varauto";
            int sum = 101 + variable;


            //e - работа с Nullable переменной

            int? i = 7;
            Nullable<int> i1 = null;
            Console.WriteLine(i1.GetValueOrDefault());
            Console.WriteLine(null ?? i);

        }
        static void Task2()
        {

            Console.WriteLine($"литералы { (("литерал1" == "литерал2") ? "" : "не")} равны");
            Console.WriteLine();

            //b - строки на основе String и операции над ними

            string string1 = new string('e', 5);
            string string2 = new string(new[] { 'h', 'e', 'l', 'l', 'o', ' ', 'w', 'o', 'r', 'l', 'd' });
            string string3 = new string('!', 3);

            string string4 = string.Concat(string2, string3);
            string string5 = string.Copy(string1);
            string string6 = string2.Substring(0, 2);
            string[] words = string2.Split();
            string string7 = string1.Insert(2, string6);
            string string8 = string1.Replace(string6, "");

            Console.WriteLine($"Строки до сцепления: \n{string2}\n{string3}\nРезультирующая строка: {string4}");
            Console.WriteLine($"Копируемая строка: {string1}\nКопия строки: {string5}");
            Console.WriteLine($"Строка-оригинал: {string2}\nВыделенная подстрока: {string6}");
            Console.WriteLine($"Строка до разделения на слова: {string2}\nСлова в этой строке:");

            Array.ForEach(words, Console.WriteLine);
            
            Console.WriteLine($"Первоначальная строка: {string1}\nСтрока после вставки в первоначальную строку подстроки {string6}:\n" +
                $"{string7}");
            Console.WriteLine($"Строка с подстрокой: {string7}\nСтрока с удаленной подстрокой {string6}: {string8}");

            //c - пустые и null строки

            string nullString = null;
            string emptyString = string.Empty;

            Console.WriteLine($"Значение строки 1 равно {nullString}; значение строки 2 равно: {emptyString}.");
            Console.WriteLine(string.IsNullOrEmpty(nullString) ? "Строка 1 пустая или имеет значение null" : "Строка 1 не пустая и не имеет значение null");
            Console.WriteLine(string.IsNullOrEmpty(emptyString) ? "Строка 2 пустая или имеет значение null" : "Строка 2 не пустая и не имеет значение null");
            Console.WriteLine($"Длина строки 2 равна {emptyString.Length}");
            Console.WriteLine(emptyString == string.Empty ? "Строка 2 пустая" : "Строка 2 не пустая");

            //d - StringBuilder

            var stringBuilder = new StringBuilder("woah stringbuilder");
            Console.WriteLine($"Первоначальная строка: {stringBuilder}");
            Console.WriteLine($"Строка после удаления позиций: {stringBuilder.Remove(3, 3)}");
            stringBuilder.Append("!");
            stringBuilder.Insert(0, "?");
            Console.WriteLine($"Строка после вставки символов в начало и в конец: {stringBuilder}");
        }
        static void Task3()
        {
           
            var arr2D = new int[4, 5];
          
            for (int i = 0; i < arr2D.GetLength(0); i++)
            {
                for (int j = 0; j < arr2D.GetLength(1); j++)
                {
                    Console.Write(arr2D[i, j] = i * j);
                }
                Console.WriteLine();
            }

            string[] arrSring = { "zero", "one", "two", "three", "four"};

            Array.ForEach(arrSring, Console.WriteLine);
     

            Console.WriteLine("Длина массива {0}", arrSring.Length);
            Console.Write("Введите позицию и значение для изменения: " + Environment.NewLine);
 
            arrSring[Convert.ToInt32(Console.ReadLine())] = Console.ReadLine();

            Array.ForEach(arrSring, Console.WriteLine);
            Console.WriteLine();

             

            Array.ForEach(new[] {
                new[] { 1f, 2 },
                new[] { 1f, 2, 3 },
                new[] { 1f, 2, 3, 4 }
            }, subarr =>
            {
                Array.ForEach(subarr, s => Console.Write(s + " "));
                Console.WriteLine();
            });




            var duckTypedString = "hmmm";
            var duckTypedIntArr = new[] { 1, 8, 8 };
        }
        static void Task4()
        {
            ValueTuple< int, string, char, string, ulong> tuple1 = (10, "Привет", 't', "world", 12312313);
            Console.WriteLine(tuple1);
            Console.WriteLine(tuple1.Item1);
            Console.WriteLine(tuple1.Item3);
            Console.WriteLine(tuple1.Item4);

            var t = ("post office", 3.6);
            (string destination, double distance) = t;
            Console.WriteLine($"Distance to {destination} is {distance} kilometers.");

            Console.WriteLine((4, 5) == (4, 5));  
        
        }
        static void Task5()
        {
            (int Max, int Min, int Sum, char First) GetValues(int[] a, string s) => (a.Max(), a.Min(), a.Sum(), s.First());
           
            int[] a = { 3, 4, 1, 2, 5 };
            string s = "Hello";
            var (max, min, sum, first) = GetValues(a, s);
            var (_, _, _, first1) = GetValues(a, s);

            int another, way, of;
            char unpacking;

            (another, way, of, unpacking) = GetValues(a, s);



            Console.WriteLine($"Максимальный элемент: {another}");
            Console.WriteLine($"Минимальный элемент: {min}");
            Console.WriteLine($"Сумма элементов: {GetValues(a, s).Sum}"); //<- тоже типа распаковка
            Console.WriteLine($"Первый символ строки: {first1}");
        }
       
        static void Task6()
        {


            int checkedof() => checked(int.MaxValue);

            int uncheckedof () => unchecked(int.MaxValue + 1);

            Console.WriteLine($"{checkedof()} - checked (MaxValue + 1 не компилируется), {uncheckedof()} - unchecked");


           



        }
    }
}
