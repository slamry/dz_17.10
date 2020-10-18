using System;
using System.Collections.Generic;

namespace calcul
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Учтите, что калькулятор для целых чисел.");
            Console.Write("Введите число: ");
            string input1 = Console.ReadLine();
            bool result1 = int.TryParse(input1, out int numb1);
            while (result1 == false)
            {
                Console.Write("Введите ЧИСЛО: ");
                input1 = Console.ReadLine();
                result1 = int.TryParse(input1, out numb1);
            }

            List<int> number1 = new List<int>();
            List<int> number2 = new List<int>();

            while (numb1 > 0)//запись в лист
            {
                number1.Add(numb1 % 10);
                numb1 /= 10;
            }

            string action="go";
            int tseloe = 0;
            while (action != "stop")
            {
                Console.WriteLine("Хотите остановиться? Введите \"stop\"");
                Console.Write("Выберите действие(+ - * /): ");
                action = Console.ReadLine();
                switch (action)
                {
                    case "+":

                        Console.Write("Введите второе число: ");
                        string input2 = Console.ReadLine();
                        bool result2 = int.TryParse(input2, out int numb2);
                        while (result2 == false)//никому не нужная проверка
                        {
                            Console.Write("Введите ЧИСЛО: ");
                            input2 = Console.ReadLine();
                            result2 = int.TryParse(input2, out numb2);
                        }
                         
                        if (number2.Count>0)//обнулить список. если i больше нуля, то удаляем, что есть
                        {
                            number2.Clear();
                        }

                        while (numb2 > 0)//запись в лист второго числа
                        {
                            number2.Add(numb2 % 10);
                            numb2 /= 10;
                        }

                        int nuli;//для нулей нужно
                        if (number1.Count<number2.Count)//чтобы не было любимого out_of_range
                        {
                            nuli = number2.Count - number1.Count;
                            for (int i =0; i < nuli; i++)
                            {
                                number1.Add(0);
                            }
                        }
                        else if (number1.Count > number2.Count)
                        {
                            nuli = number1.Count - number2.Count;
                            for (int i =0; i < nuli; i++)
                            {
                                number2.Add(0);
                            }                            
                        }

                        for (int i =0; i<number1.Count; i++)//само сложение
                        {
                            number1[i] = number1[i] + number2[i] + tseloe;
                            tseloe = number1[i]/10;
                            number1[i] %= 10;
                            if (number1.Count==number2.Count && i==number1.Count-1 && tseloe>0)//длины равны, счетчик в конце, нужно место для целого
                            {
                                number1.Add(tseloe);
                            }
                        }

                        //вывод
                        for(int i = number1.Count - 1; i >= 0; i--)
                        {
                            Console.Write(number1[i]);
                        }
                        Console.WriteLine("");

                        break;

                    /*case "-":

                        Console.Write("Введите второе число: ");
                        string input2 = Console.ReadLine();
                        bool result2 = int.TryParse(input2, out int numb2);
                        while (result2 == false)
                        {
                            Console.Write("Введите ЧИСЛО: ");
                            input2 = Console.ReadLine();
                            result2 = int.TryParse(input2, out numb2);
                        }
                         
                        if (number2.Count>0)
                        {
                            number2.Clear();
                        }

                        while (numb2 > 0)
                        {
                            number2.Add(numb2 % 10);
                            numb2 /= 10;
                        }

                        break;

                    case "*":

                        Console.Write("Введите второе число: ");
                        string input2 = Console.ReadLine();
                        bool result2 = int.TryParse(input2, out int numb2);
                        while (result2 == false)
                        {
                            Console.Write("Введите ЧИСЛО: ");
                            input2 = Console.ReadLine();
                            result2 = int.TryParse(input2, out numb2);
                        }
                         
                        if (number2.Count>0)
                        {
                            number2.Clear();
                        }

                        while (numb2 > 0)
                        {
                            number2.Add(numb2 % 10);
                            numb2 /= 10;
                        }

                        break;

                    case "/":

                        Console.Write("Введите второе число: ");
                        string input2 = Console.ReadLine();
                        bool result2 = int.TryParse(input2, out int numb2);
                        while (result2 == false)
                        {
                            Console.Write("Введите ЧИСЛО: ");
                            input2 = Console.ReadLine();
                            result2 = int.TryParse(input2, out numb2);
                        }
                         
                        if (number2.Count>0)
                        {
                            number2.Clear();
                        }

                        while (numb2 > 0)
                        {
                            number2.Add(numb2 % 10);
                            numb2 /= 10;
                        }

                        break;*/

                    case "stop":
                        break;

                    default:
                        Console.Write("Введено неверное действие. Введите снова.");
                        break;
                }
            }
        }
    }
}
