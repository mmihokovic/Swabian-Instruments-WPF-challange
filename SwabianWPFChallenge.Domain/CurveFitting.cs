using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwabianWPFChallenge.Domain
{
    public class CurveFitting : IDataSource
    {
        private readonly IDataSource dataSource;
        private readonly FittingModelEnum fittingModel;
        private List<Point> fittedPoints;

        public CurveFitting(IDataSource dataSource, FittingModelEnum fittingModel)
        {
            this.dataSource = dataSource;
            this.fittingModel = fittingModel;
            SelectFittingModel();
        }

        private void SelectFittingModel()
        {
            switch (fittingModel)
            {
                case FittingModelEnum.Linear:
                    LinearFitting();
                    break;
                case FittingModelEnum.Exponential:
                    ExponentialFitting();
                    break;
                case FittingModelEnum.Power:
                    PowerFitting();
                    break;
            }
        }

        private void LinearFitting()
        {
            var points = dataSource.GetPoints;
            var xPoints = points.Select(p => p.X).ToList();
            var yPoints = points.Select(p => p.Y).ToList();
            var fitFunc = Fit.PolynomialFunc(xPoints.ToArray(), yPoints.ToArray(), 1);
            PopulateFittingPoints(fitFunc);
        }

        private void ExponentialFitting()
        {
            var points = dataSource.GetPoints;
            var xPoints = points.Select(p => p.X).ToList();
            var yPoints = points.Select(p => p.Y).ToList();
            var fitFunc = Fit.LinearCombinationFunc(xPoints.ToArray(), yPoints.ToArray(), x => 1.0,  x => Math.Exp(1.0 * x));
            PopulateFittingPoints(fitFunc);
        }

        private void PowerFitting()
        {
            var points = dataSource.GetPoints;
            var xPoints = points.Select(p => p.X).ToList();
            var yPoints = points.Select(p => p.Y).ToList();
            var fitFunc = Fit.LinearCombinationFunc(xPoints.ToArray(), yPoints.ToArray(), x => 1.0, x => Math.Exp(x));
            PopulateFittingPoints(fitFunc);
        }

        private void PopulateFittingPoints(Func<double, double> func)
        {
            var minX = dataSource.GetPoints.OrderBy(x => x.X).First().X;
            var maxX = dataSource.GetPoints.OrderByDescending(x => x.X).First().X;
            var delta = Math.Abs(maxX - minX) / 1000.0;
            fittedPoints = new List<Point>();
            for(var i = minX; i < maxX; i += delta)
            {
                var point = new Point(i, func.Invoke(i));
                fittedPoints.Add(point);
            }
        }


        public List<Point> GetPoints => fittedPoints;
    }
}
