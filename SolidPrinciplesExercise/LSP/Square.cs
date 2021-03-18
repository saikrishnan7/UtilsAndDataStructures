namespace SolidPrinciplesExercise.LSP
{
    public class Square : Shape
    {
        public int SideLength { get; set; }

        public override double TotalArea()
        {
            return SideLength * SideLength;
        }
    }
}
