using System;
using System.Collections.Generic;
using System.Linq;

namespace Runder
{
    public class Program
    {
        public static List<Obstacle> obstacles = new List<Obstacle>();
        static void Main(string[] args)
        {

            obstacles.Clear(); //inutile mais pour s'assurer que la liste est bien vide
            obstacles.Add(new Obstacle(1,1));
            obstacles.Add(new Obstacle(0,2));
            obstacles.Add(new Obstacle(0,8)); //permet de gérer le cas 9:8:E => obstacle en 0:8
            obstacles.Add(new Obstacle(2,0));
            obstacles.Add(new Obstacle(8,0)); //permet de gérer le cas 8:9:N => obstacle en 8:0

            Rover Rover1 = new Rover();
            String instruction;
            //Lancement du programme
            do
            {
                Console.WriteLine("Instruction : (Q pour quitter)");
                instruction = Console.ReadLine();
                Console.WriteLine(Rover1.Move(instruction));
            } while (instruction != "Q");
            Console.WriteLine("Perte du signal vers Mars... Matt Damon ne peut compter que sur lui.");
        }
    }
}