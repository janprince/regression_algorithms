using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace regression_algorithms
{

    internal class LinearRegression
    {
        private double[][] X;
        private double[] y;
        double b = 0;
        double[] w = {};

        /**
        X (2D array) is an array of features
        y (1D array) is an array of labels
        b (scalar) is the bias (model parameter)
        w (1D array) are the weights (model parameters)

         */

        LinearRegression(double[][] X, double[] y, double b, double[] w)
        {
            this.X = X;
            this.y = y;

            // initializing the values of w based on the length of X
            for(int i = 0; i < X[0].Length; i++)
            {
                this.w[i] = 0.3;
            }
        }

        double model_predict(double[] x)
        {
            /** 
               The linear model is represented by f(x) = w.x + b where w and x are vectors. 
              
                Single prediction for an observation in X    
            
                x (vector): sinlge observation from X 
            
                Returns:
                    p (scalar): prediction
             */

            double p = VectorOperation.DotProduct(this.w, x) + b;

            return p;

        }
    }
}
