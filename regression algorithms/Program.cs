namespace regression_algorithms
{
    class Program
    {
        public static void Main(String[] args)
        {
            double[] f = { 1.2 };
            double[] s = { 1, 2 };

            double result = VectorOperation.DotProduct(f, s);
        }
    }
}