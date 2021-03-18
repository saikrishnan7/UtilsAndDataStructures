namespace SolidPrinciplesExercise.LSP
{
    public class Rectangle : Shape
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public override double TotalArea()
        {
            return Height * Width;
        }
    }
}
