﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLR_Confidential
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintInterfaceMap();
            Console.ReadKey();
        }

        private static void PrintInterfaceMap()
        {
            var mapping = typeof(IllMadeJeans).GetInterfaceMap(typeof(IPantaloon));
            for (int i = 0; i < mapping.InterfaceMethods.Length; ++i)
            {
                Console.WriteLine(mapping.InterfaceMethods[i].Name);
                Console.WriteLine(mapping.TargetMethods[i].Name);
                Console.WriteLine(mapping.TargetMethods[i].Attributes);
            }
        }

        private static void PrintNonObjectTypes()
        {
            var methods = typeof(NonObjectTypes).GetMethods();
            foreach (var m in methods)
            {
                Console.WriteLine(m.Name);
                foreach (var p in m.GetParameters())
                {
                    Console.WriteLine(">> {0} : {1}", p.Name, p.ParameterType.Name);
                }
            }
        }
    }
}