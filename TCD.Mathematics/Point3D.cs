using System;

namespace TCD.Mathematics
{
    /// <summary>
    /// Represents an x-, y-, and z-coordinate point in 3-D space.
    /// </summary>
    public class Point3D
    {
        /// <summary>
        /// Initializes a new instance of the TCD.Mathematics.Point3D structure.
        /// </summary>
        /// <param name="x">The TCD.Mathematics.Point3D.X value of the new TCD.Mathematics.Point3D structure.</param>
        /// <param name="y">The TCD.Mathematics.Point3D.Y value of the new TCD.Mathematics.Point3D structure.</param>
        /// <param name="z">The TCD.Mathematics.Point3D.Z value of the new TCD.Mathematics.Point3D structure.</param>
        public Point3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        // Summary:
        //     Subtracts a TCD.Mathematics.Point3D structure from a TCD.Mathematics.Point3D
        //     structure and returns the result as a TCD.Mathematics.Vector3D
        //     structure.
        //
        // Parameters:
        //   point1:
        //     The TCD.Mathematics.Point3D structure on which to perform subtraction.
        //
        //   point2:
        //     The TCD.Mathematics.Point3D structure to subtract from point1.
        //
        // Returns:
        //     A TCD.Mathematics.Vector3D structure that represents the difference
        //     between point1 and point2.
        public static Vector3D operator -(Point3D point1, Point3D point2)
        {
            return new Vector3D(point1.X - point2.X, point1.Y - point2.Y, point1.Z - point2.Z);
        }
        /// <summary>
        /// Subtracts a TCD.Mathematics.Vector3D structure from a TCD.Mathematics.Point3D structure and returns the result as a TCD.Mathematics.Point3D structure.
        /// </summary>
        /// <param name="point">The TCD.Mathematics.Point3D structure from which to subtract vector.</param>
        /// <param name="vector">The TCD.Mathematics.Vector3D structure to subtract from point.</param>
        /// <returns>The changed TCD.Mathematics.Point3D structure, the result of subtracting vector from point.</returns>
        public static Point3D operator -(Point3D point, Vector3D vector)
        {
            return new Point3D(point.X - vector.X, point.Y - vector.Y, point.Z - vector.Z);
        }
        /// <summary>
        /// Adds a TCD.Mathematics.Point3D structure to a TCD.Mathematics.Vector3D and returns the result as a TCD.Mathematics.Point3D structure.
        /// </summary>
        /// <param name="point">The point to add.</param>
        /// <param name="vector">The vector to add.</param>
        /// <returns>A TCD.Mathematics.Point3D structure that is the sum of point and vector.</returns>
        public static Point3D operator +(Point3D point, Vector3D vector)
        {
            return new Point3D(point.X + vector.X, point.Y + vector.Y, point.Z + vector.Z);
        }
      
        /// <summary>
        /// Converts a TCD.Mathematics.Point3D structure into a TCD.Mathematics.Vector3D structure.
        /// </summary>
        /// <param name="point">The point to convert.</param>
        /// <returns>The result of converting point.</returns>
        public static explicit operator Vector3D(Point3D point)
        {
            return (Vector3D)point;
        }

        /// <summary>
        /// Gets or sets the x-coordinate of this TCD.Mathematics.Point3D structure.
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// Gets or sets the y-coordinate of this TCD.Mathematics.Point3D structure.
        /// </summary>
        public double Y { get; set; }
        /// <summary>
        /// Gets or sets the z-coordinate of this TCD.Mathematics.Point3D structure.
        /// </summary>
        public double Z { get; set; }

        /// <summary>
        /// Calculate the arithmetic center of a Point3D cloud
        /// </summary>
        /// <param name="points">One or more Point3Ds to calculate the center of</param>
        /// <returns>A Point3D that is in the geometrical center of all specified Point3Ds</returns>
        /// <exception cref="ArgumentNullException">Occurs when no Point3D is specified.</exception>
        public static Point3D CenterOfCluster(params Point3D[] points)
        {
            if (points.Length == 0)
                throw new ArgumentNullException("Pass me some Point3Ds; I can't work this way!!");
            double sx = 0;
            double sy = 0;
            double sz = 0;
            foreach (Point3D p in points)//sum up all points
            {
                sx += p.X;
                sy += p.Y;
                sz += p.Z;
            }
            return new Point3D(sx / points.Length, sy / points.Length, sz / points.Length);//calculate the center
        }
        
        /// <summary>
        /// Projects this Point3D on a Line3D.
        /// </summary>
        /// <param name="p">The Line3D to project on.</param>
        /// <returns>The 'shadow' of this Point3D</returns>
        public Point3D ProjectOnLine3D(Line3D line, bool forwardOnly = false)
        {
            Plane3D plane = new Plane3D(this, line.Direction);//a plane that is perpendicular to the line and where the poins lies in
            return line.IntersectWithPlane3D(plane);//calculate their intersection - this is where we project the point to
        }
        /// <summary>
        /// Projects this Point3D on a plane.
        /// </summary>
        /// <param name="p">The plane to project on.</param>
        /// <returns>The 'shadow' of this Point3D</returns>
        public Point3D ProjectOnPlane3D(Plane3D plane)
        {
            Line3D line = new Line3D(this, plane.Normal.Normalized());//the line through point and plane
            return line.IntersectWithPlane3D(plane);//calculate their intersection - this is where we project the point to
        }
        /// <summary>
        /// Calculates distance to a plane.
        /// </summary>
        /// <param name="p">The Plane3D to calculate with</param>
        public double DistanceToPlane3D(Plane3D plane)
        {
            return Vector3D.DotProduct(plane.Normal.Normalized(), this - plane.Base);
        }

        /// <summary>
        /// Creates a System.String representation of this TCD.Mathematics.Point3D structure.
        /// </summary>
        /// <returns>A System.String containing the TCD.Mathematics.Point3D.X, TCD.Mathematics.Point3D.Y, and TCD.Mathematics.Point3D.Z values of this TCD.Mathematics.Point3D structure.</returns>
        public override string ToString()
        {
            return string.Format("{0};{1};{2}", this.X, this.Y, this.Z);
        }
    }
}