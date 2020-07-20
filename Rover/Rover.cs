using System;
using System.Linq;

namespace Runder
{
    public class Rover
    {
        private const char Left = 'L';
        private const char Right = 'R';
        private const char Forward = 'F';
        private const string Nord = "N";
        private const string Sud = "S";
        private const string West = "W";
        private const string Est = "E";
        private const int minimumValue = 0;
        private const int maxDeplacement = 9;
        private int axeX = 0;
        private int axeY = 0;
        private string orientation = Nord;
        private bool isBlocked = false;

        public string Move(string listeDirection)
        {
            char[] directionChar = listeDirection.ToCharArray();
            foreach (char lettre in directionChar)
            {
                UseDirection(lettre);
            }
            if (isBlocked == false)
            {
                return $"{axeX}:{axeY}:{orientation}";
            }
            else
            {
                return $"O:{axeX}:{axeY}:{orientation}";
            }
        }

        private void UseDirection(char direction)
        {
            switch (direction)
            {
                case Right:
                    isBlocked = false;
                    ToRight();
                    break;
                case Left:
                    isBlocked = false;
                    ToLeft();
                    break;
                case Forward:
                    ToForward();
                    break;
            }
        }

        private void ToForward()
        {

            switch (orientation)
            {

                case Nord:
                    axeY = DetectObstacleY(LimitMars(++axeY));
                    break;
                case Sud:
                    axeY = DetectObstacleY(LimitMars(--axeY));
                    break;
                case Est:
                    axeX = DetectObstacleX(LimitMars(++axeX));
                    break;
                case West:
                    axeX = DetectObstacleX(LimitMars(--axeX));
                    break;
            }
        }
        private int DetectObstacleY(int positionRover)
        {
            foreach (Obstacle caillou in Program.obstacles)
            {
                if (caillou.GetPosition().Item1 == positionRover)
                {

                    if (caillou.GetPosition().Item2 == axeX)
                    {
                        if (orientation == Nord)
                        {
                            Console.WriteLine("Un obstacle est présent en : " + $"{caillou.GetPosition().Item2}:{caillou.GetPosition().Item1}");
                            isBlocked = true;
                            if (positionRover == 0) { return 9;}
                            else {return --positionRover;}
                        }
                        else
                        {
                            Console.WriteLine("Un obstacle est présent en : " + $"{caillou.GetPosition().Item2}:{caillou.GetPosition().Item1}");
                            isBlocked = true;
                            if (positionRover == 11) { return 10;}
                            else {return ++positionRover;} 

                        }
                    }
                }
            }
            return positionRover;
        }
        private int DetectObstacleX(int positionRover)
        {
            foreach (Obstacle caillou in Program.obstacles)
            {
                if (caillou.GetPosition().Item2 == positionRover)
                {
                    if (caillou.GetPosition().Item1 == axeY)
                    {
                        if (orientation == Est)
                        {
                            Console.WriteLine("Un obstacle est présent en : " + $"{caillou.GetPosition().Item2}:{caillou.GetPosition().Item1}");
                            isBlocked = true;
                            if (positionRover == 0) { return 9;}
                            else {return --positionRover;}
                        }
                        else
                        {
                            Console.WriteLine("Un obstacle est présent en : " + $"{caillou.GetPosition().Item2}:{caillou.GetPosition().Item1}");
                            isBlocked = true;
                            if (positionRover == 11) { return 10;}
                            else {return ++positionRover;} 
                        }
                    }
                }
            }
            return positionRover;
        }

        private int LimitMars(int position)
        {
            if (position > maxDeplacement)
                return minimumValue;
            if (position < minimumValue)
                return maxDeplacement;
            return position;
        }

        private void ToLeft()
        {
            switch (orientation)
            {
                case Est:
                    orientation = Nord;
                    break;
                case West:
                    orientation = Sud;
                    break;
                case Sud:
                    orientation = Est;
                    break;
                case Nord:
                    orientation = West;
                    break;
            }
        }

        private void ToRight()
        {
            switch (orientation)
            {
                case Nord:
                    orientation = Est;
                    break;
                case Sud:
                    orientation = West;
                    break;
                case Est:
                    orientation = Sud;
                    break;
                case West:
                    orientation = Nord;
                    break;
            }
        }
    }
}