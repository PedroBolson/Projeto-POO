﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FAKE_ENTERPRISE_LTDA
{
    public class Program
    {
        Menu menu;
        public Program()
        {
            menu = new Menu();
            menu.MenuOpcoes();
        }
        static void Main(string[] args)
        { 
            Program enterprise = new Program();
            Console.WriteLine("Digite qualquer tecla para sair!");
            Console.ReadKey();
        }
    }
}

