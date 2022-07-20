namespace regression_algorithms
{
    class Program
    {
        public static void Main(String[] args)
        {
            double[][] X_train = new double[3][];
            X_train[0] = new double[] { 2104, 5, 1, 45 };
            X_train[1] = new double[] { 1416, 3, 2, 40 };
            X_train[2] = new double[] { 852, 2, 1, 35 };
            
            double[] y_train = { 460, 232, 178 };

            LinearRegression model = new(X_train, y_train);


            // test initialize values of b and w
            Console.WriteLine(model.b);

            for (int i = 0; i < model.w.Length; i++)
            {
                Console.WriteLine(model.w[i]);
            }
        }
    }
}