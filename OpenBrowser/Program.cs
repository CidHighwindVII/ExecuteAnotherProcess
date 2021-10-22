using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;

namespace OpenBrowser
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = string.Empty;
            Thread t = new Thread((ThreadStart)(() =>
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "Todos os ficheiros|*.*";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = openFileDialog.FileName;
                    }
                }
            }));

            // Run your code from a thread that joins the STA Thread
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();

            if (File.Exists("Teste.txt"))
            {
                File.Delete("Teste.txt");
            }

            File.AppendAllText("Teste.txt", $"Olha que bonito, escolheste um ficheiro em {filePath}");
        }
    }
}
