using System;

namespace TCD.Mathematics
{
    /// <summary>
    /// Represents a displacement in 3-D space.
    /// </summary>
    public class Vector3D
    {
        /// <summary>
        /// Initializes a new instance of a TCD.Mathematics.Vector3D structure.
        /// </summary>
        /// <param name="x">The new TCD.Mathematics.Vector3D structure's TCD.Mathematics.Vector3D.X value.</param>
        /// <param name="y">The new TCD.Mathematics.Vector3D structure's TCD.Mathematics.Vector3D.Y value.</param>
        /// <param name="z">The new TCD.Mathematics.Vector3D structure's TCD.Mathematics.Vector3D.Z value.</param>
        public Vector3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        /// <summary>
        /// IMPORTANT: Because "==" checks for object equality, you should use .Equals() to check if two vectors have the same length && orientation.
        /// </summary>
        /// <param name="v2"></param>
        /// <returns></returns>
        public bool Equals(Vector3D v2)
        {
            return (this.X == v2.X && this.Y == v2.Y && this.Z == v2.Z);
        }

        /// <summary>
        /// Negates a TCD.Mathematics.Vector3D structure.
        /// </summary>
        /// <param name="vector">The TCD.Mathematics.Vector3D structure to negate.</param>
        /// <returns>A TCD.Mathematics.Vector3D structure with TCD.Mathematics.Vector3D.X, TCD.Mathematics.Vector3D.Y, and TCD.Mathematics.Vector3D.Z values opposite of the TCD.Mathematics.Vector3D.X, TCD.Mathematics.Vector3D.Y, and TCD.Mathematics.Vector3D.Z values of vector.</returns>
        public static Vector3D operator -(Vector3D vector)
        {
            return new Vector3D(-vector.X, -vector.Y, -vector.Z);
        }
        /// <summary>
        /// Subtracts a TCD.Mathematics.Point3D structure from a TCD.Mathematics.Vector3D structure.
        /// </summary>
        /// <param name="vector">The TCD.Mathematics.Vector3D structure to be subtracted from.</param>
        /// <param name="point">The TCD.Mathematics.Point3D structure to subtract from vector.</param>
        /// <returns>The result of subtracting point from vector.</returns>
        public static Point3D operator -(Vector3D vector, Point3D point)
        {
            return new Point3D(vector.X - point.X, vector.Y - point.Y, vector.Z - point.Z);
        } 
        /// <summary>
        /// Subtracts a TCD.Mathematics.Vector3D structure from a TCD.Mathematics.Vector3D structure.
        /// </summary>
        /// <param name="vector1">The TCD.Mathematics.Vector3D structure to be subtracted from.</param>
        /// <param name="vector2">The TCD.Mathematics.Vector3D structure to subtract from vector1.</param>
        /// <returns>The result of subtracting vector2 from vector1.</returns>
        public static Vector3D operator -(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(vector1.X - vector2.X, vector1.Y - vector2.Y, vector1.Z - vector2.Z);
        }
        /// <summary>
        /// Multiplies the specified scalar by the specified TCD.Mathematics.Vector3D structure and returns the result as a TCD.Mathematics.Vector3D.
        /// </summary>
        /// <param name="scalar">The scalar to multiply.</param>
        /// <param name="vector">The TCD.Mathematics.Vector3D structure to multiply.</param>
        /// <returns>The result of multiplying scalar and vector.</returns>
        public static Vector3D operator *(double scalar, Vector3D vector)
        {
            return new Vector3D(vector.X * scalar, vector.Y * scalar, vector.Z * scalar);
        }
        /// <summary>
        /// Multiplies the specified TCD.Mathematics.Vector3D structure by the specified scalar and returns the result as a TCD.Mathematics.Vector3D.
        /// </summary>
        /// <param name="vector">The TCD.Mathematics.Vector3D structure to multiply.</param>
        /// <param name="scalar">The scalar to multiply.</param>
        /// <returns>The result of multiplying vector and scalar.</returns>
        public static Vector3D operator *(Vector3D vector, double scalar)
        {
            return new Vector3D(vector.X * scalar, vector.Y * scalar, vector.Z * scalar);
        }
        /// <summary>
        /// Divides the specified TCD.Mathematics.Vector3D structure by the specified scalar and returns the result as a TCD.Mathematics.Vector3D.
        /// </summary>
        /// <param name="vector">The TCD.Mathematics.Vector3D structure to be divided.</param>
        /// <param name="scalar">The scalar to divide vector by.</param>
        /// <returns>The result of dividing vector by scalar.</returns>
        public static Vector3D operator /(Vector3D vector, double scalar)
        {
            return new Vector3D(vector.X / scalar, vector.Y / scalar, vector.Z / scalar);
        }
        /// <summary>
        /// Translates the specified TCD.Mathematics.Point3D structure by the specified TCD.Mathematics.Vector3D structure and returns the result as a TCD.Mathematics.Point3D structure.
        /// </summary>
        /// <param name="vector">The TCD.Mathematics.Vector3D structure used to translate the specified TCD.Mathematics.Point3D structure.</param>
        /// <param name="point">The TCD.Mathematics.Point3D structure to be translated.</param>
        /// <returns>The result of translating point by vector.</returns>
        public static Point3D operator +(Vector3D vector, Point3D point)
        {
            return new Point3D(point.X + vector.X, point.Y + vector.Y, point.Z + vector.Z);
        }
        /// <summary>
        /// Adds two TCD.Mathematics.Vector3D structures and returns the result as a TCD.Mathematics.Vector3D structure.
        /// </summary>
        /// <param name="vector1">The first TCD.Mathematics.Vector3D structure to add.</param>
        /// <param name="vector2">The second TCD.Mathematics.Vector3D structure to add.</param>
        /// <returns>The sum of vector1 and vector2.</returns>
        public static Vector3D operator +(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(vector1.X + vector2.X, vector1.Y + vector2.Y, vector1.Z + vector2.Z);
        }
        
        /// <summary>
        /// Converts a TCD.Mathematics.Vector3D structure into a TCD.Mathematics.Point3D structure.
        /// </summary>
        /// <param name="vector">The vector to convert.</param>
        /// <returns>The result of converting vector.</returns>
        public static explicit operator Point3D(Vector3D vector)
        {
            return (Point3D)vector;
        }

        /// <summary>
        /// Gets the length of this TCD.Mathematics.Vector3D structure.
        /// </summary>
        public double Length
        {
            get { return Math.Sqrt(LengthSquared); }
        }
        /// <summary>
        /// Gets the square of the length of this TCD.Mathematics.Vector3D structure.
        /// </summary>
        public double LengthSquared
        {
            get { return X * X + Y * Y + Z * Z; }
        }
        /// <summary>
        /// Gets or sets the TCD.Mathematics.Vector3D.X component of this TCD.Mathematics.Vector3D structure.
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// Gets or sets the TCD.Mathematics.Vector3D.Y component of this TCD.Mathematics.Vector3D structure.
        /// </summary>
        public double Y { get; set; }
        /// <summary>
        /// Gets or sets the TCD.Mathematics.Vector3D.Z component of this TCD.Mathematics.Vector3D structure.
        /// </summary>
        public double Z { get; set; }

        /// <summary>
        /// Retrieves the angle required to rotate the first specified TCD.Mathematics.Vector3D structure into the second specified TCD.Mathematics.Vector3D structure.
        /// </summary>
        /// <param name="vector1">The first TCD.Mathematics.Vector3D structure to evaluate.</param>
        /// <param name="vector2">The second TCD.Mathematics.Vector3D structure to evaluate.</param>
        /// <returns>The angle in degrees needed to rotate vector1 into vector2.</returns>
        public static double AngleBetween(Vector3D vector1, Vector3D vector2)
        {
            Vector3D v1n = vector1.Normalized();
            Vector3D v2n = vector2.Normalized();
            return 180 * Math.Acos(Vector3D.DotProduct(v1n, v2n) / (Math.Sqrt(Vector3D.DotProduct(v1n, v1n)) * Math.Sqrt(Vector3D.DotProduct(v2n, v2n)))) / Math.PI;
        }  
        /// <summary>
        ///  Calculates the cross product of two TCD.Mathematics.Vector3D structures.
        /// </summary>
        /// <param name="vector1">The first TCD.Mathematics.Vector3D structure to evaluate.</param>
        /// <param name="vector2">The second TCD.Mathematics.Vector3D structure to evaluate.</param>
        /// <returns>The cross product of vector1 and vector2.</returns>
        public static Vector3D CrossProduct(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(
                (vector1.Y * vector2.Z - vector1.Z * vector2.Y),
                (vector1.Z * vector2.X - vector1.X * vector2.Z),
                (vector1.X * vector2.Y - vector1.Y * vector2.X)
                );
        }
        /// <summary>
        /// Calculates the dot product of two TCD.Mathematics.Vector3D structures.
        /// </summary>
        /// <param name="vector1">The first TCD.Mathematics.Vector3D structure to evaluate.</param>
        /// <param name="vector2">The second TCD.Mathematics.Vector3D structure to evaluate.</param>
        /// <returns>The dot product of vector1 and vector2.</returns>
        public static double DotProduct(Vector3D vector1, Vector3D vector2)
        {
            return (vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z);
        }
        
        
        /// <summary>
        /// Negates a TCD.Mathematics.Vector3D structure.
        /// </summary>
        public void Negate()
        {
            this.X = -this.X;
            this.Y = -this.Y;
            this.Z = -this.Z;
        }
        /// <summary>
        /// Normalizes the specified TCD.Mathematics.Vector3D structure.
        /// </summary>
        public void Normalize()
        {
            if (this.Length == 0)
                throw new NullVectorException("Didn't you pay attention in math? This is a null-Vector!");
            double l = this.Length;
            this.X = this.X / l;
            this.Y = this.Y / l;
            this.Z = this.Z / l;
        }
        /// <summary>
        /// Returns a normalized Vector3D for the current instance.
        /// </summary>
        /// <param name="v">The Vector3D to normalize</param>
        /// <returns>Vector3D</returns>
        /// <exception cref="NullVectorException">Vector Length is zero.</exception>
        public Vector3D Normalized()
        {
            if (this.Length == 0)
                throw new NullVectorException("Didn't you pay attention in math? This is a null-Vector!");
            return this / this.Length;
        }
        
        /// <summary>
        /// Creates a System.String representation of this TCD.Mathematics.Vector3D structure.
        /// </summary>
        /// <returns>A string containing the TCD.Mathematics.Vector3D.X, TCD.Mathematics.Vector3D.Y, and TCD.Mathematics.Vector3D.Z values of this TCD.Mathematics.Vector3D structure.</returns>
        public override string ToString()
        {
            return string.Format("{0};{1};{2}", this.X, this.Y, this.Z);
        }
    }
}
