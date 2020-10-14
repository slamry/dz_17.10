using System;

namespace spiral
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Задайте размер матрицы n*n: ");
            int n;
            string input = Console.ReadLine();
            bool result = int.TryParse(input, out n); 
            while (result==false)
            {
                Console.Write("Введите ЧИСЛО: ");
                input = Console.ReadLine();
                result = int.TryParse(input, out n);
            }

            Console.WriteLine($"Матрица будет размером {n}*{n}");
            int[,] mass = new int[n, n];
            int elt = 1;//то что будем записывать в массив

            int rows = mass.GetUpperBound(0) + 1;//строки
            int columns = mass.Length / rows;

            Console.WriteLine("Вывод исходной матрицы:");
            for (int str = 0; str < rows; str++)//строки
            {
                for (int stl = 0; stl < columns; stl++)//кол-во эл-тов;стоблцы
                {
                    mass[str,stl] =elt;
                    Console.Write($"{mass[str,stl]} \t");
                    elt++;
                }
                Console.WriteLine();
            }

            //новая матрица. ввод элементов
            int[,] spir = new int[n, n];
            int buf_str = 0;//запомнить, на чем остановились в первой матице
            int buf_stl = 0;

            for (int i = 0, str = 0; i < 1; i++, str++)//запис. первую строку
            {
                for (int j = 0, stl = 0; j < columns; j++, stl++)
                {
                    spir[i, j] = mass[str,stl];
                }
            }

            for (int i = 1, stl = 0; i < n; i++, stl++)//запис бок столбец
            {
                int str = 1;
                int j = n - 1;
                spir[i, j] = mass[str,stl];
                buf_stl = stl;
                buf_str = str;
            }

            for (int stl = buf_stl+1, i = n-1, str= buf_str, j=n-2; stl<n;  )//ковыряемся со строками
            {
                spir[i, j] = mass[str, stl];
                if (stl==n-1)//когда подошел к краю..сомнительно!!
                {
                    buf_str=str+1;
                    buf_stl=0;
                    break;
                }
            }

            for (int i=n-1, j= n-3, str=buf_str, stl=buf_stl;j>=0 ;j--, stl++)//разбираемся с низом
            {
                spir[i, j] = mass[str, stl];
                buf_stl = stl;
                buf_str = str;
            }

            int j_stop = 0;//типа буф_стл, но для второй матрицы
            int i_stop = 0;
            for (int j =0, i=n-2, str = buf_str, stl = buf_stl; i>0; i--)//левый крайний столбец
            {
                stl++;
                if (stl == n)
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
            if (buf_stl == n-1)//если в конце строки
            {
                buf_str++;
                buf_stl = 0;
            }
            else if (buf_stl<n-1)//нам просто нужен сл элемент
            {
                buf_stl++;
            }



            while (buf_str<n && buf_stl < n)
            {
                for (int str = buf_str, stl = buf_stl, i = i_stop, j = j_stop + 1; spir[i, j] == 0; j++, stl++)//верх
                {
                    if (stl == n)
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

                if (buf_stl == n - 1)//если в конце строки
                {
                    buf_str++;
                    buf_stl = 0;
                }
                else if (buf_stl < n - 1)//нам просто нужен сл элемент
                {
                    buf_stl++;
                }

                for (int i = i_stop + 1, str = buf_str, stl = buf_stl, j = j_stop; spir[i, j] == 0; i++, stl++)//право
                {
                    if (stl == n)
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

                if (buf_stl == n - 1)//если в конце строки
                {
                    buf_str++;
                    buf_stl = 0;
                }
                else if (buf_stl < n - 1)//нам просто нужен сл элемент
                {
                    buf_stl++;
                }

                for (int i = i_stop, str = buf_str, stl = buf_stl, j = j_stop - 1; spir[i, j] == 0; j--, stl++)//низ
                {
                    if (stl == n)
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

                if (buf_stl == n - 1)//если в конце строки
                {
                    buf_str++;
                    buf_stl = 0;
                }
                else if (buf_stl < n - 1)//нам просто нужен сл элемент
                {
                    buf_stl++;
                }

                for (int i = i_stop - 1, str = buf_str, stl = buf_stl, j = j_stop; spir[i, j] == 0; i--, stl++)//лево
                {
                    if (stl == n)
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

                if (buf_stl == n - 1)//если в конце строки
                {
                    buf_str++;
                    buf_stl = 0;
                }
                else if (buf_stl < n - 1)//нам просто нужен сл элемент
                {
                    buf_stl++;
                }

            }

            Console.WriteLine("Закручивая в спираль:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{spir[i,j]} \t");
                }
                Console.WriteLine();
            }
        }
    }
}
