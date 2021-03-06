using System;
using System.Collections.Generic;
using System.Linq;

namespace Rectangle.Impl
{
    public class RectangleNotFoundException : Exception { }
    public static class Service
    {
        /// <summary>
        /// Finds rectangle that includes all points from the list except one
        /// </summary>
        /// <param name="points">A points rectangle should include</param>
        /// <exception cref="ArgumentNullException">If <see cref="points"/> is <code>null</code> or some of it's elements are <code>null</code></exception>
        /// <exception cref="ArgumentException">If <see cref="points"/> has duplicates or it does not contain at least 2 points</exception>
        /// <exception cref="RectangleNotFoundException">If there is no <see cref="Rectangle"/> that includes all points except one </exception>
        /// <returns></returns>
        public static Rectangle FindRectangle(List<Point> points)
        {
            if (points is null)
                throw new ArgumentNullException(nameof(points));
            if (points.Count < 2)
                throw new ArgumentException("There must be at least 2 points", nameof(points));
            if (points.Any(t => t is null))
                throw new ArgumentNullException(nameof(points), "Some of points are null");
            if (points.Select(t => (t.X, t.Y)).Distinct().Count() != points.Count)
                throw new ArgumentException("Some of points have the same coordinates");
            var sortedByX = points.GroupBy(t => t.X).OrderBy(t => t.Key).Select(t => t.ToList()).ToList();
            var sortedByY = points.GroupBy(t => t.Y).OrderBy(t => t.Key).Select(t => t.ToList()).ToList();
            int x1 = sortedByX[0][0].X;
            int x2 = sortedByX[^1][0].X;
            int y1 = sortedByY[0][0].Y;
            int y2 = sortedByY[^1][0].Y;
            if (sortedByX[0].Count == 1)
                x1 = sortedByX[1][0].X;
            else if (sortedByX[^1].Count == 1)
                x2 = sortedByX[^2][0].X;
            else if (sortedByY[0].Count == 1)
                y1 = sortedByY[1][0].Y;
            else if (sortedByY[^1].Count == 1)
                y2 = sortedByY[^2][0].Y;
            else throw new RectangleNotFoundException();
            return new Rectangle
            {
                X = x1,
                Y = y1,
                Width = x2 - x1,
                Height = y2 - y1
            };
        }
    }
}