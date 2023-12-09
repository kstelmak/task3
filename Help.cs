using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace task3
{
    public class Help
    {
        List<string> row;
        ConsoleTables.ConsoleTable table;
        public Help(string[] args)
        {
            row = args.ToList();
            row.Insert(0, "V PC/User >");
            table = new ConsoleTables.ConsoleTable(row.ToArray());
            SetValues(args);
            FillTable(args);
            table.Write(Format.Alternative);
        }
        void SetValues(string[] args)
        {
            row[1] = "Draw";
            for (int i = 2; i <= args.Count(); i++)
            {
                if (i <= ((args.Count() - 1) / 2) + 1)
                {
                    row[i] = "Win";
                }
                else
                {
                    row[i] = "Lose";
                }
            }
        }
        void FillTable(string[] args)
        {
            for (int i = 0; i < args.Count(); i++)
            {
                row[0] = args[i];
                table.AddRow(row.ToArray());
                string temp = row[row.Count() - 1];
                row.RemoveAt(row.Count() - 1);
                row.Insert(1, temp);
            }
        }
    }
}
