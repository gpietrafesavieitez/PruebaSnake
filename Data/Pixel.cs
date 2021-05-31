namespace PruebaSnake.Data
{
    public class Pixel
    {
        public int PosX { get; set; }
        public int PosY { get; set; }

        public Pixel()
        {
        }

        public Pixel(int posX, int posY)
        {
            PosX = posX;
            PosY = posY;
        }

        public override string ToString()
        {
            return $"Pixel({PosX},{PosY})";
        }
    }
}
