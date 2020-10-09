using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_DB
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory(@"DataBase");
            Functions Func = new Functions();
            Func.MainMenu();
        }
    }
}