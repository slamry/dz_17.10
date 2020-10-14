using System;
using System.Collections.Generic;

namespace factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число: ");
            string input = Console.ReadLine();
            bool result = int.TryParse(input, out int numb);
            while (result == false)
            {
                Console.Write("Введите ЧИСЛО: ");
                input = Console.ReadLine();
                result = int.TryParse(input, out numb);
            }
            List<int> fact = new List<int>();

            fact.Add(1);
            int tseloe=0;

            for (int i = 2; i <= numb; i++)
            {
                for (int k = 0; k < fact.Count; k++)//умножение-перебор
                {
                    fact[k] = fact[k]*i + tseloe;
                    tseloe = 0;//обнуляем
                    if (fact[k]>=10)
                    {
                        tseloe = fact[k] / 10;
                        fact[k] %= 10;//на его месте оставляем остаток
                        if (tseloe>0 && k+1==fact.Count)//если нет места для целого. outofrange(((
                        {
                            fact.Add(0);
                        }
                    }                    
                }

                Console.WriteLine("Промежуточное число: ");
                for (int k = fact.Count-1; k>=0;k--)//вывод
                {
                    Console.Write(fact[k]);
                }
                Console.WriteLine("");
            }
        }
    }
}
