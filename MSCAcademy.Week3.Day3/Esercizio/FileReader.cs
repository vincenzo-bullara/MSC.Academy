using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;

namespace Esercizio
{

    public class FileReader
    {   
        // dichiarazione EventHandlers
        public event EventHandler? OnBegin;
        public event EventHandler<MyEventArgs>? OnProgress;
        public event EventHandler<MyEventArgs>? OnEnd;
        public void ReadCsv()
        {
            var fullPath = Combine(
            GetFolderPath(SpecialFolder.MyDocuments),
            "MSC",
            "Week3",
            "Day3"
            );
            string csvFile = Combine(fullPath, "employees.csv");

            int rowCount = 0, difGender = 0;
            using (StreamReader sr = File.OpenText(csvFile))
            {
                //Event call
                if(OnBegin != null)
                    OnBegin(this, EventArgs.Empty);
                string line = string.Empty;
                sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    if (rowCount % 100 == 0)
                    {
                        //for (int i=0; i < rowCount / 100; i++)
                        //    Console.Write("\t");
                        Thread.Sleep(350);
                        if (OnProgress != null)
                            OnProgress(this, new MyEventArgs { rows=rowCount, dif=difGender});
                    }
                    rowCount++;
                    string[] split = line.Split(',');
                    if ((split[4]!="Male")&& (split[4]!="Female")){
                        difGender++;
                    }
                }
                sr.Close();
                Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                if (OnEnd != null)
                    OnEnd(this, new MyEventArgs { rows = rowCount, dif = difGender });
                Console.ResetColor();
            }
        }
    }
    // creazione custom EventArgs
    public class MyEventArgs : EventArgs
    {
        public int rows;
        public int dif;
    }
}
