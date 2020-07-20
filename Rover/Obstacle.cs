using System.Linq;

namespace Runder
{
    public class Obstacle
    {
        // Constructor that takes one argument:
        public Obstacle(int X, int Y)
        {
            Abscisse = X;
            Ordonnee = Y;
        }

        // Auto-implemented readonly property:
        public int Abscisse { get; }
        public int Ordonnee { get; }
        public  (int,int) GetPosition(){
            return (Ordonnee,Abscisse);
        }
    }
}