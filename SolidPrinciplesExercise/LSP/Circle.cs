namespace SolidPrinciplesExercise.LSP
{
    public class Circle : Shape
    {
        public int Radius { get; set; }

        public override double TotalArea()
        {
            return 3.14 * Radius * Radius;
        }
    }
}
