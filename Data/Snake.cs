using System.Collections.Generic;
using System.Linq;

namespace PruebaSnake.Data
{
    public class Snake
    {
        public const int
            LEFT = 0,
            UP = 1,
            RIGHT = 2,
            DOWN = 3;

        public List<Pixel> Body { get; set; }

        public Snake()
        {
            Body = new();
            Body.Add(new Pixel(0, 0));
        }

        public void Grow()
        {
            Body.Add( new Pixel( Body.Last().posX, Body.Last().posY ) );
        }

        public bool Check(Pixel pixel)
        {
            foreach (var p in this.Body)
            {
                if(p.posX == pixel.posX && p.posY == pixel.posY)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Collision()
        {
            for (int i = 0; i < Body.Count - 1; i++)
            {
                if (Body[0].posX == Body[i + 1].posX && Body[0].posY == Body[i + 1].posY)
                {
                    return true;
                }
            }
            return false;
        }

        public void Move(int dir)
        {
            int[] lastBodyX = new int[Body.Count];
            int[] lastBodyY = new int[Body.Count];
            for (int i = 0; i < Body.Count; i++)
            {
                lastBodyX[i] = Body[i].posX;
                lastBodyY[i] = Body[i].posY;
            }
            switch (dir)
            {
                case LEFT:
                    Body[0].posX--;
                    break;
                case UP:
                    Body[0].posY--;
                    break;
                case RIGHT:
                    Body[0].posX++;
                    break;
                case DOWN:
                    Body[0].posY++;
                    break;
            }
            for (int i = 0; i < Body.Count - 1; i++)
            {
                Body[i + 1].posX = lastBodyX[i];
                Body[i + 1].posY = lastBodyY[i];
            }
            
        }
    }

}
