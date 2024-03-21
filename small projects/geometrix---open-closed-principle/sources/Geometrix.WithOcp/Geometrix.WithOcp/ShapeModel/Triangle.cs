using System;

namespace RemoteLearning.Geometrix.WithOcp.ShapeModel
{
    internal class Triangle : IShape
    {
        public double FirstSide { get; set; }

        public double SecondSide { get; set; }

        public double ThirdSide { get; set; }

        public double CalculateArea()
        {
            double semiperimeter = 0.5 * (FirstSide + SecondSide + ThirdSide);
            return Math.Sqrt(semiperimeter 
                            * (semiperimeter - FirstSide) 
                            * (semiperimeter - SecondSide) 
                            * (semiperimeter - ThirdSide));
        }
    }
}
