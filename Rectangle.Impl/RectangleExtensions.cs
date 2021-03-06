
namespace Rectangle.Impl
{
    public static class RectangleExtensions
    {
        /// <summary>
        /// Checks if this <see cref="Rectangle"/> has this <see cref="Point"/>
        /// </summary>
        public static bool HasPoint(this Rectangle rectangle, Point point)
        {
            if (point.X < rectangle.X || point.Y < rectangle.Y)
                return false;
            if (point.X > rectangle.X + rectangle.Width || point.Y > rectangle.Y + rectangle.Height)
                return false;
            return true;
        }
    }
}