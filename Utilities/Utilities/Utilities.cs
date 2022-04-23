using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Utilities
{
    public class Util
    {
        public int ReadInt()
        {
            int x = 0;
            bool isOk;
            Console.Write("Inserire numero intero: ");
            isOk = int.TryParse(Console.ReadLine(), out x);
            while (!isOk)
            {
                isOk = int.TryParse(Console.ReadLine(), out x);
            }
            return x;
        }
        public double ReadDouble()
        {
            double x = 0;
            bool isOk;
            Console.Write("Inserire numero: ");
            isOk = double.TryParse(Console.ReadLine(), out x);
            while (!isOk)
            {
                isOk = double.TryParse(Console.ReadLine(), out x);
            }
            return x;
        }
        #region string readers
        public string PwReader()
        {
            string pw = null;
            int i = 0;
            int temp;
            Console.Write("Inserire password: ");
            while (i < 15)
            {
                char key = Console.ReadKey(true).KeyChar;
                switch (key)
                {
                    case '\r':
                        i = 16;
                        break;
                    case '\b':
                        if (i > 0)
                        {
                            i--;
                            pw = pw.Remove(pw.Length - 1);
                            Console.Write("\b \b");
                        }
                        break;
                    case ' ':
                        break;
                    default:
                        if ((char.IsDigit(key))&&i<14)
                        {
                            temp = key-'0';
                            pw += temp;
                            i++;
                            Console.Write("*");
                        }
                        else if (i < 14)
                        {
                            pw += key;
                            i++;
                            Console.Write("*");
                        }
                        break;
                }
            }
            Console.WriteLine();
            Console.WriteLine(pw);
            return pw;
        }
        
        public string UserReader()
        {
            string user = null;
            int i = 0;
            int temp;
            Console.Write("Inserire utente: ");
            while (i < 15)
            {
                char key = Console.ReadKey().KeyChar;
                switch (key)
                {
                    case '\r':
                        i = 16;
                        break;
                    case '\b':
                        if (i > 0)
                        {
                            i--;
                            user = user.Remove(user.Length - 1);
                            Console.Write("\b \b");
                        }
                        break;
                    case ' ':
                        break;
                    default:
                        if ((char.IsDigit(key)) && i < 14)
                        {
                            temp = key - '0';
                            user += temp;
                            i++;
                        }
                        else if (i < 14)
                        {
                            user += key;
                            i++;
                        }
                        break;
                }
            }
            return user;
        }
        #endregion
        public void ValueSelect(List<int> list)
        {
            int x = 0;
            foreach (int i in list)
            {
                x++;
                Console.WriteLine($"{x})\t{i}");
            }
            bool isOk;
            Console.Write("Inserire indice: ");
            isOk = int.TryParse(Console.ReadLine(), out int z);
            while (!isOk)
            {
                isOk = int.TryParse(Console.ReadLine(), out z);
            }

            //ConsoleKeyInfo keyInfo = Console.ReadKey();
            //if (keyInfo.Key == ConsoleKey.UpArrow)
            //{

            //}
            //else if (keyInfo.Key == ConsoleKey.DownArrow)
            //{

            //}
        }
        public void test(string qwerty)
        {
            TypeDescriptor.GetConverter(typeof(T)).ConvertToString(qwerty);
        }
    }
}
