using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Workbench
{
    class Program
    {
        static void Main(string[] args)
        {
            Process process = new Process();
            // Configure the process using the StartInfo properties.
            process.StartInfo.FileName = "OpenBrowser.exe";
            process.Start();
            process.WaitForExit();

            if (File.Exists("Teste.txt"))
            {
                var text = File.ReadAllText("Teste.txt");
                Console.WriteLine(text);
            }
            else
            {
                Console.WriteLine("Nada encontrado");
            }

            Console.ReadLine();
        }
    }
}
