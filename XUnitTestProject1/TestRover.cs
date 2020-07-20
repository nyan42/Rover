using System;
using System.Collections.Generic;
using Xunit;
namespace Runder.Test
{
    public class TestRover
    {
        private readonly Rover rover;
        public TestRover()
        {
            rover = new Rover();
        }

        [Fact]
        public void RoverReçoitUneCommandeVide()
        {
            var position = rover.Move(string.Empty);
            Assert.Equal("0:0:N", position);
        }
        [Fact]
        public void RoverReçoitPlusieursCommandes()
        {
            var position = rover.Move("FRF");
            Assert.Equal("1:1:E", position);
        }
        [Fact]
        public void RoverRencontreUnObstacle()
        {
            Program.obstacles.Add(new Obstacle(1, 1));
            var position = rover.Move("FRF");
            Assert.Equal("O:0:1:E", position);
            Program.obstacles.Clear();
        }
        [Fact]
        public void RoverDepasseLesLimitesDeLaGrille()
        {
            var position = rover.Move("RRF");
            Assert.Equal("0:9:S", position);
        }
        [Fact]
        public void OneMove()
        {
            var position = rover.Move("F");
            Assert.Equal("0:1:N", position);
        }
        [Fact]
        public void TwoMove()
        {
            var position = rover.Move("FF");
            Assert.Equal("0:2:N", position);
        }
        [Fact]
        public void ThreeMove()
        {
            var position = rover.Move("FFF");
            Assert.Equal("0:3:N", position);
        }
        [Fact]
        public void RotateL()
        {
            var position = rover.Move("L");
            Assert.Equal("0:0:W", position);
        }
        [Fact]
        public void Rotate2L()
        {
            var position = rover.Move("LL");
            Assert.Equal("0:0:S", position);
        }
        [Fact]
        public void Rotate3L()
        {
            var position = rover.Move("LLL");
            Assert.Equal("0:0:E", position);
        }
        [Fact]
        public void FullTurnL()
        {
            var position = rover.Move("LLLL");
            Assert.Equal("0:0:N", position);
        }
        [Fact]
        public void RotateR()
        {
            var position = rover.Move("R");
            Assert.Equal("0:0:E", position);
        }
        [Fact]
        public void RotateRR()
        {
            var position = rover.Move("RR");
            Assert.Equal("0:0:S", position);
        }
        [Fact]
        public void RotateRRR()
        {
            var position = rover.Move("RRR");
            Assert.Equal("0:0:W", position);
        }
        [Fact]
        public void FullTurnR()
        {
            var position = rover.Move("RRRR");
            Assert.Equal("0:0:N", position);
        }
        [Fact]
        public void TurnRandForward()
        {
            var position = rover.Move("RF");
            Assert.Equal("1:0:E", position);
        }
        [Fact]
        public void TurnLandForward()
        {
            var position = rover.Move("LF");
            Assert.Equal("9:0:W", position);
        }
        [Fact]
        public void ToupieTest()
        {
            var position = rover.Move("LLLLLRRRRR");
            Assert.Equal("0:0:N", position);
        }
        [Fact]
        public void SortieMapDroite()
        {
            var position = rover.Move("RFFFFFFFFFF");
            Assert.Equal("0:0:E", position);
        }
        [Fact]
        public void SortieMapHaut()
        {
            var position = rover.Move("FFFFFFFFFF");
            Assert.Equal("0:0:N", position);
        }
        [Fact]
        public void SortieMapGauche()
        {
            var position = rover.Move("LF");
            Assert.Equal("9:0:W", position);
        }

        //Test Obstacle
        [Fact]
        public void Obstacle02()
        {
            Program.obstacles.Add(new Obstacle(0, 2));
            var position = rover.Move("FF");
            Assert.Equal("O:0:1:N", position);
            Program.obstacles.Clear();
        }
        [Fact]
        public void Obstacle08()
        {
            Program.obstacles.Add(new Obstacle(0, 8));
            var position = rover.Move("RRFF");
            Assert.Equal("O:0:9:S", position);
            Program.obstacles.Clear();
        }
        [Fact]
        public void Obstacle20()
        {
            Program.obstacles.Add(new Obstacle(2, 0));
            var position = rover.Move("RFF");
            Assert.Equal("O:1:0:E", position);
            Program.obstacles.Clear();
        }
        [Fact]
        public void Obstacle80()
        {
            Program.obstacles.Add(new Obstacle(8, 0));
            var position = rover.Move("LFF");
            Assert.Equal("O:9:0:W", position);
            Program.obstacles.Clear();
        }
    }
}
