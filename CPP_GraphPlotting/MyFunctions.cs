using System;
using System.Collections.Generic;
using System.Linq;

using OxyPlot;


namespace CPP_GraphPlotting
{
    static class MyFunctions
    {
        /// <summary>
        /// Returns new X-wise boundaries for a function based upon the values f(x) had given before. 
        /// It shall be used to prevent new function from scaling up the whole graph
        /// </summary>
        /// <param name="oldFunction">Old Function upon which new boundaries are created</param>
        /// <param name="newFunction">New function you want to input in the graph</param>
        /// <param name="lowerBoundary">Lower X boundary for an oldFunction</param>
        /// <param name="upperBoundary">Upper X boundary for an oldFunction</param>
        /// <returns>A tuple containing new boundaries</returns>
        public static (double lower, double upper) GetNewRangeBasedUponOldOne(BaseNode oldFunction, BaseNode newFunction, double lowerBoundary, double upperBoundary) {
            var newBoundaries = (lower: -1.0d, upper: -1.0d);

            // not really sure about the line below
            double[] valuesOfOldFunction = new double[(int)(Math.Abs(lowerBoundary) + Math.Abs(upperBoundary))]; // holds values of f(x), new boundaries are based upon this set of info

            // calculates the f(x) for given x
            double GetReturnValueForFunction(BaseNode function, double input) {
                return function.Calculate (input);
            }

            int counter_valueOfOldFunction = 0;
            for (double i = lowerBoundary; i < upperBoundary; i++) {
                valuesOfOldFunction[counter_valueOfOldFunction] = GetReturnValueForFunction (oldFunction, i);
                counter_valueOfOldFunction++;
            }

            var maxValueOfOldFunction = valuesOfOldFunction.Max ();
            var minValueOfOldFunction = valuesOfOldFunction.Min ();

            List<double> possibleBoundaries = new List<double> ();

            for (double i = lowerBoundary; i < upperBoundary; i += 0.3) {
                var val = GetReturnValueForFunction (newFunction, i);

                if (val >= minValueOfOldFunction && val <= maxValueOfOldFunction) {
                    possibleBoundaries.Add (i);
                }
            }

            newBoundaries = (lower: possibleBoundaries.Min (), upper: possibleBoundaries.Max ());

            return newBoundaries;
        }

        /// <summary>
        /// Returns new X-wise boundaries for a function f(x) based upon the points user selected as well as the lower and upper boundaries
        /// </summary>
        /// <param name="function">Function you're gonna draw</param>
        /// <param name="selectedPoints">Points selected by a user</param>
        /// <param name="lowerBoundary"></param>
        /// <param name="upperBoundary"></param>
        /// <returns>A tuple containing new boundaries</returns>
        public static (double lower, double upper) GetNewRangeBasedUponFixatedLimits(BaseNode function, DataPoint[] selectedPoints, double lowerBoundary, double upperBoundary) {
            var newBoundaries = (lower: -1.0d, upper: -1.0d);

            double[] xPoints = new double[selectedPoints.Length];
            double[] yPoints = new double[selectedPoints.Length];

            for (int i = 0; i < selectedPoints.Length; i++) {
                xPoints[i] = selectedPoints[i].X;
                yPoints[i] = selectedPoints[i].Y;
            }

            var maxValue = yPoints.Max ();
            var minValue = yPoints.Min ();

            List<double> possibleValues = new List<double> ();

            for (double i = lowerBoundary; i < upperBoundary; i += 0.3) {
                var val = function.Calculate (i);

                if (val <= maxValue && val >= minValue) {
                    possibleValues.Add (i);
                }
            }

            newBoundaries = (lower: possibleValues.Min (), upper: possibleValues.Max ());

            return newBoundaries;
        }
    }
}
