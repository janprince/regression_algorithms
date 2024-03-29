﻿using System;
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
        public double b = 0;
        public double[] w;

        /**
        X (2D array) is Data, m examples with n features
        y (1D array) is an array of m target values
        b (scalar) is the bias (model parameter)
        w (1D array) are the weights (n model parameters)

        m is the number of data examples
        n is the number of features

         */

        // constructor
        public LinearRegression(double[][] X, double[] y)
        {
            this.X = X;
            this.y = y;

            // initializing the values of w based on the number of features.
            double[] w = new double[X[0].Length];
            for (int i = 0; i < X[0].Length; i++)
            {
                w[i] = 0.3;
            }

            this.w = w;
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


        List<dynamic> ComputeGradient()
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
            List<dynamic> gradients = new List<dynamic>();
            gradients.Add(dj_db);
            gradients.Add(dj_dw);

            return gradients;
        }

        void GradientDescent(int num_iters, float alpha)
        {
            /* 
             * num_iters (int): is the number of iterations for which gradient descent will run
             * alpha (float): the learning rate
             * 
             */

            for (int i = 0; i < num_iters; i++)
            {

                // Calculate the gradient and update the parameters
                List<dynamic> gradients = this.ComputeGradient();

                double dj_db = gradients[0];
                double[] dj_dw = gradients[1];


                // Update parameters using w, b, alpha and gradients
                for (int j = 0; j < dj_dw.Length; j++)
                {
                    this.w[j] = this.w[j] - (alpha * dj_dw[j]);
                }

                this.b = this.b - (alpha * dj_db);

            }
        }
        void Fit(double[][] X, double[] y)
        {
            this.GradientDescent(1000, 0.00005f);

            Console.WriteLine("b: " + this.b);
        }
    }
}
