using System;

namespace TCD.Mathematics
{
    /// <summary>
    /// Extension methods to the TCD.Mathematics.Point3D class
    /// </summary>
    public static class ExtensionMethods
    {
        //conversions/adjustments of Vector3D/Point3D
        /// <summary>
        /// This method is an alternative to (Point3D)vector
        /// </summary>
        /// <param name="v">the vector</param>
        /// <returns>(Point3D)vector</returns>
        public static Point3D AsPoint3D(this Vector3D v)
        {
            return (Point3D)v;
        }
        /// <summary>
        /// This method is an alternative to (Vector3D)vector
        /// </summary>
        /// <param name="v">the vector</param>
        /// <returns>(Vector3D)vector</returns>
        public static Vector3D AsVector3D(this Point3D p)
        {
            return (Vector3D)p;
        }
    }
}