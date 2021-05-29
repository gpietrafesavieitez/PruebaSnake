using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaSnake.Data
{
    public class Pixel
    {
        public int posX { get; set; }
        public int posY { get; set; }

        public Pixel(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
        }

        public override string ToString()
        {
            return $"Pixel({posX},{posY})";

        }
    }
}
