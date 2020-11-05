using System;

namespace sspiral_nm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Задайте количество строк: ");
            int n;
            int m;
            string input = Console.ReadLine();//n
            Console.Write("Задайте количество столбцов: ");
            string input1 = Console.ReadLine();//m
            bool result = int.TryParse(input, out n);
            bool result1 = int.TryParse(input1, out m);
            while (result == false || result1==false)
            {
                Console.Write("Введите ЧИСЛО: ");
                input = Console.ReadLine();
                input1 = Console.ReadLine();
                result = int.TryParse(input, out n);
                result1 = int.TryParse(input1, out m);
            }

            Console.WriteLine($"Матрица будет размером {n}*{m}");
            int[,] mass = new int[n, m];
            int elt = 1;//то что будем записывать в массив

            int rows = mass.GetUpperBound(0) + 1;//строки
            int columns = mass.Length / rows;

            Console.WriteLine("Вывод исходной матрицы:");
            for (int str = 0; str < rows; str++)//строки
            {
                for (int stl = 0; stl < columns; stl++)//кол-во эл-тов;стоблцы
                {
                    mass[str, stl] = elt;
                    Console.Write($"{mass[str, stl]} \t");
                    elt++;
                }
                Console.WriteLine();
            }

            //новая матрица. ввод элементов
            int[,] spir = new int[n, m];
            int buf_str = 0;//запомнить, на чем остановились в первой матице
            int buf_stl = 0;

            for (int i = 0, str = 0; i < 1; i++, str++)//запис. первую строку
            {
                for (int j = 0, stl = 0; j < columns; j++, stl++)
                {
                    spir[i, j] = mass[str, stl];
                    buf_stl = stl;
                }
                buf_str = str;
            }

            if (buf_stl == m - 1)//если в конце строки
            {
                buf_str++;
                buf_stl = 0;
            }
            
            for (int i=1, j=m-1, str=buf_str, stl=buf_stl;i<n;i++,stl++)//запис бок столбец
            {
                if (stl == n)
                {
                    str++;
                    stl = 0;
                }
                spir[i, j] = mass[str, stl];
                buf_stl = stl;
                buf_str = str;
            }

            if (buf_stl == m - 1)//если в конце строки
            {
                buf_str++;
                buf_stl = 0;
            }
            else if (buf_stl < m - 1)//нам просто нужен сл элемент
            {
                buf_stl++;
            }

            for (int str = buf_str, stl = buf_stl, i=n-1, j = m-2; j>=0 ; j--,stl++)//низ
            {
                if (stl == m)
                {
                    str++;
                    stl = 0;
                }
                spir[i, j] = mass[str, stl];
                buf_stl = stl;
                buf_str = str;
            }

            int j_stop = 0;//типа буф_стл, но для второй матрицы
            int i_stop = 0;

            for (int j = 0, i = n - 2, str = buf_str, stl = buf_stl; i > 0; i--)//левый крайний столбец
            {
                stl++;
                if (stl == m)
                {
                    str++;
                    stl = 0;
                }
                spir[i, j] = mass[str, stl];
                buf_stl = stl;
                buf_str = str;
                i_stop = i;
                j_stop = j;
            }
            if (buf_stl == m - 1)//если в конце строки
            {
                buf_str++;
                buf_stl = 0;
            }
            else if (buf_stl < m - 1)//нам просто нужен сл элемент
            {
                buf_stl++;
            }

            while (buf_str < n && buf_stl < m)
            {
                for (int str = buf_str, stl = buf_stl, i = i_stop, j = j_stop + 1; spir[i, j] == 0; j++, stl++)//верх
                {
                    if (stl == m)
                    {
                        str++;
                        stl = 0;
                    }
                    spir[i, j] = mass[str, stl];
                    buf_stl = stl;
                    buf_str = str;
                    i_stop = i;
                    j_stop = j;
                }

                if (buf_stl == m - 1)//если в конце строки
                {
                    buf_str++;
                    buf_stl = 0;
                }
                else if (buf_stl < m - 1)//нам просто нужен сл элемент
                {
                    buf_stl++;
                }

                for (int i = i_stop + 1, str = buf_str, stl = buf_stl, j = j_stop; spir[i, j] == 0; i++, stl++)//право
                {
                    if (stl == m)
                    {
                        str++;
                        stl = 0;
                    }
                    spir[i, j] = mass[str, stl];
                    buf_stl = stl;
                    buf_str = str;
                    i_stop = i;
                    j_stop = j;
                }

                if (buf_stl == m - 1)//если в конце строки
                {
                    buf_str++;
                    buf_stl = 0;
                }
                else if (buf_stl < m - 1)//нам просто нужен сл элемент
                {
                    buf_stl++;
                }

                for (int i = i_stop, str = buf_str, stl = buf_stl, j = j_stop - 1; spir[i, j] == 0; j--, stl++)//низ
                {
                    if (stl == m)
                    {
                        str++;
                        stl = 0;
                    }
                    spir[i, j] = mass[str, stl];
                    buf_stl = stl;
                    buf_str = str;
                    i_stop = i;
                    j_stop = j;
                }

                if (buf_stl == m - 1)//если в конце строки
                {
                    buf_str++;
                    buf_stl = 0;
                }
                else if (buf_stl < m - 1)//нам просто нужен сл элемент
                {
                    buf_stl++;
                }

                for (int i = i_stop - 1, str = buf_str, stl = buf_stl, j = j_stop; spir[i, j] == 0; i--, stl++)//лево
                {
                    if (stl == m)
                    {
                        str++;
                        stl = 0;
                    }
                    spir[i, j] = mass[str, stl];
                    buf_stl = stl;
                    buf_str = str;
                    i_stop = i;
                    j_stop = j;
                }

                if (buf_stl == m - 1)//если в конце строки
                {
                    buf_str++;
                    buf_stl = 0;
                }
                else if (buf_stl < m - 1)//нам просто нужен сл элемент
                {
                    buf_stl++;
                }
            }

            Console.WriteLine("Закручивая в спираль:");
            for (int i = 0; i < rows; i++)//вывод-проверка
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{spir[i, j]} \t");
                }
                Console.WriteLine();
            }
        }
    }
}
