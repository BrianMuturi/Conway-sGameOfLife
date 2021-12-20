using System;

namespace Conway_sGameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Generation Pacifique = new Generation();
            
            Random Princesse = new Random();
            int x = Princesse.Next();
            int y = Princesse.Next();
            bool[,] mugisha = new bool[30, 30];
            Generation brian = new Generation(mugisha,x,y);

        }
    }
}
