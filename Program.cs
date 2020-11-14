using System;

namespace write_type_method
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter something: ");
            object input = Console.ReadLine();
            WriteType(ref input);
        }

        static void WriteType(ref object input)
        {
            object converted_arg="";
            switch (input)/*try-catch & formatexeption??*/
            {
                default://по сути это и есть сбайт
                    try
                    {
                        sbyte arg = Convert.ToSByte(input);
                        converted_arg = arg;
                    }
                    catch (FormatException)
                    {
                        goto case "Byte";
                    }
                    catch (OverflowException)
                    {
                        goto case "Byte";
                    }
                    break;
                /*case ("SByte")://запихнуть две строки в метод
                    Console.Write($"{converted_arg} is ");
                    Console.WriteLine(converted_arg.GetType());
                    break;*/
                case ("Byte"):
                    try
                    {
                        byte arg = Convert.ToByte(input);
                        converted_arg = arg;
                    }
                    catch (FormatException)
                    {
                        goto case "Int16";
                    }
                    catch (OverflowException)
                    {
                        goto case "Int16";
                    }
                    break;
                case ("Int16"):
                    try
                    {
                        short arg = Convert.ToInt16(input);
                        converted_arg = arg;
                    }
                    catch (FormatException)
                    {
                        goto case "UInt16";
                    }
                    catch (OverflowException)
                    {
                        goto case "UInt16";
                    }
                    break;

                    case ("UInt16"):
                    try
                    {
                        ushort arg = Convert.ToUInt16(input);
                        converted_arg = arg;
                    }
                    catch (FormatException)
                    {
                        goto case "Int32";
                    }
                    catch (OverflowException)
                    {
                        goto case "Int32";
                    }
                    break;

                    case ("Int32"):
                    try
                    {
                        int arg = Convert.ToInt32(input);
                        converted_arg = arg;
                    }
                    catch (FormatException)
                    {
                        goto case "UInt32";
                    }
                    catch (OverflowException)
                    {
                        goto case "UInt32";
                    }
                    break;

                case ("UInt32"):
                    try
                    {
                        uint arg = Convert.ToUInt32(input);
                        converted_arg = arg;
                    }
                    catch (FormatException)
                    {
                        goto case "Int64";
                    }
                    catch (OverflowException)
                    {
                        goto case "Int64";
                    }
                    break;

                    case ("Int64"):
                    try
                    {
                        long arg = Convert.ToInt64(input);
                        converted_arg = arg;
                    }
                    catch (FormatException)
                    {
                        goto case "UInt64";
                    }
                    catch (OverflowException)
                    {
                        goto case "UInt64";
                    }
                    break;

                case ("UInt64"):
                    try
                    {
                        ulong arg = Convert.ToUInt64(input);
                        converted_arg = arg;
                    }
                    catch (FormatException)
                    {
                        goto case "Single";
                    }
                    catch (OverflowException)
                    {
                        goto case "Single";
                    }
                    break;

                    case ("Single"):
                    try
                    {
                        float arg = Convert.ToSingle(input);
                        converted_arg = arg;
                    }
                    catch (FormatException)
                    {
                        goto case "Double";
                    }
                    catch (OverflowException)
                    {
                        goto case "Double";
                    }
                    break;

                    case ("Double"):
                    try
                    {
                        double arg = Convert.ToDouble(input);
                        converted_arg = arg;
                    }
                    catch (FormatException)
                    {
                        goto case "Decimal";
                    }
                    catch (OverflowException)
                    {
                        goto case "Decimal";
                    }
                    break;

                case ("Decimal"):
                    try
                    {
                        decimal arg = Convert.ToDecimal(input);
                        converted_arg = arg;
                    }
                    catch (FormatException)
                    {
                        goto case "Char";
                    }
                    catch (OverflowException)
                    {
                        goto case "Char";
                    }
                    break;

                case ("Char"):
                    try
                    {
                        char arg = Convert.ToChar(input);
                        converted_arg = arg;
                    }
                    catch (FormatException)
                    {
                        goto case "Boolean";
                    }
                    catch (OverflowException)
                    {
                        goto case "Boolean";
                    }
                    break;

                case ("Boolean"):
                    try
                    {
                        bool arg = Convert.ToBoolean(input);
                        converted_arg = arg;
                    }
                    catch (FormatException)
                    {
                        goto case "String";
                    }
                    catch (OverflowException)
                    {
                        goto case "String";
                    }
                    break;

                case ("String"):
                    try
                    {
                        string arg = Convert.ToString(input);
                        converted_arg = arg;
                    }
                    finally
                    {

                    }
                    break;
            }
            Console.Write($"{converted_arg} is ");
            Console.WriteLine(converted_arg.GetType());
        }
    }    
}
