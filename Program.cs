using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Conway_sGameOfLife
{
    class Program
    {

        
        static void Main(string[] args)
        {
            Console.Write("Enter initial count:");
            int initialAliveCellsCount = int.Parse(Console.ReadLine());
            bool[,]grid = new bool[30, 30];

            
            Generation Gena = new Generation(grid, initialAliveCellsCount);
            Generation hash = new Generation(Gena, "*");
            hash.NewGeneration(grid);
            new Generation(hash, "*");
            

        }





        /*Gena.DisplayGrid(grid, 0);*/

        //Reading from text
        /*string filepath = @"E:\Poland\GOF.txt";
        List<string> lines = File.ReadAllLines(filepath).ToList();
        Foreach(string line in lines)
        {
            Console.WriteLine(line);
        }
        */
        //lines.Add($"{grid}");

       

        
    }

}
