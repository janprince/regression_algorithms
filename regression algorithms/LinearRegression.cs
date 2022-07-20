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
        X (2D array) is Data, m examples with n features
        y (1D array) is an array of m target values
        b (scalar) is the bias (model parameter)
        w (1D array) are the weights (n model parameters)

        m is the number of data examples
        n is the number of features

         */

        LinearRegression(double[][] X, double[] y, double b, double[] w)
        {
            this.X = X;
            this.y = y;

            // initializing the values of w based on the number of features.
            for(int i = 0; i < X[0].Length; i++)
            {
                this.w[i] = 0.3;
            }
        }

        double ModelPredict(double[] x)
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

        double ComputeCost()
        {
            /*
             * Returns:
             *  cost (scaler): cost;  i.e using the current values of the model parameters, w and b.
            */

            int m = X.Length;
            double cost = 0;

            // summing the squared error across data
            for (int i = 0; i < m; i++)
            {
                double f_wb_i = this.ModelPredict(X[i]);
                double error = Math.Pow((f_wb_i - y[i]), 2);
                cost += error;
            }

            // the mean of the total squared error 
            cost = cost / (2 * m);

            return cost;
        }


        Object[] ComputeGradient()
        {
        // computes the gradient for linear regression

        /* Returns:
            dj_dw(array): The gradient of the cost w.r.t.the parameters w.
            dj_db(scalar):       The gradient of the cost w.r.t.the parameter b.
        */

            int m = this.X.Length;                  // number of exmaples
            int n = this.X[0].Length;               // number of features

            double dj_db = 0;
            double[] dj_dw = { };

            // initializing values for dj_dw and dj_db
            for (int i = 0; i < n; i++) { dj_dw[i] = 0; }

            
            for(int i = 0; i < m; i++)
            {
                double err = this.ModelPredict(X[i]) - y[i];
                
                for (int j = 0; j < n; j++)
                {
                    dj_dw[j] = dj_dw[j] + (err * this.X[i][j]);
                }
                dj_db = dj_db + err;
                
            }

            for (int i=0; i < dj_dw.Length; i++)
            {
                dj_dw[i] = dj_dw[i] / m; 
            }

            dj_db = dj_db / m;

            // gradients dj_db and dj_dw
            Object[] gradients = { dj_db, dj_dw };


            return  gradients;
        }
    }
}
