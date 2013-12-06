
namespace TCD.Mathematics
{
    /// <summary>
    /// A line in three-dimensional space
    /// </summary>
    public class Line3D
    {
        /// <summary>
        /// The 'base' Point3D of the Line3D
        /// </summary>
        public Point3D Base { get; set; }
        /// <summary>
        /// The Direction-Vector3D of the Line
        /// It will be normalized to have a Length of 1 !
        /// </summary>
        /// <exception cref="NullVectorException">Vector3D(0,0,0) is not allowed!</exception>
        private Vector3D _Direction;
        public Vector3D Direction 
        {
            get { return _Direction; }
            set { _Direction = value.Normalized(); }
        }

        /// <summary>
        /// Returns a Line3D, defined by Base and Direction
        /// </summary>
        /// <param name="basis">The base of the line</param>
        /// <param name="direction">The direction of the line</param>
        /// <exception cref="NullVectorException">Vector3D(0,0,0) is not allowed as the Direction!</exception>
        public Line3D(Point3D basis, Vector3D direction)
        {
            this.Base = basis;
            this.Direction = direction;
        }
        /// <summary>
        /// Returns a Line3D that goes through both Point3Ds
        /// </summary>
        /// <param name="basis">The first Point3D which will be used as the Base</param>
        /// <param name="point">The second Point3D</param>
        /// <exception cref="NullVectorException">If Point3Ds are identical, there's no Direction vector.</exception>
        public Line3D(Point3D basis, Point3D point)
        {
            this.Base = basis;
            this.Direction = point - basis;
        }

        /// <summary>
        /// Attempt to calculate the intersection of this Line3D with a Plane3D
        /// </summary>
        /// <param name="plane">The Plane3D to calculate with</param>
        /// <param name="forwardOnly">Shall intersections, that are 'behind' the lines Base (in terms of the lines Direction vector) be ignored?</param>
        /// <returns>The intersection Point3D</returns>
        /// <exception cref="IdenticalException">The line lies in the plane; they have an infinite number of intersections</exception>
        /// <exception cref="ParallelityException">The line is parallel, but not identical; they have no intersection</exception>
        /// <exception cref="ParameterViolationException">The intersection is 'behind' the lines Base - in correspondence with the 'forwardOnly' parameter</exception>
        public Point3D IntersectWithPlane3D(Plane3D plane, bool forwardOnly = false)
        {
            double dp = Vector3D.DotProduct(this.Direction, plane.Normal);
            if (dp == 0)//identical or parallel
            {
                if (this.Base.DistanceToPlane3D(plane) == 0)
                    throw new IdenticalException("Oups, the Line3D lies in the Plane3D!");
                else
                    throw new ParallelityException("Oups, the Line3D is parallel to the Plane3D!");
            }
            double dp1 = Vector3D.DotProduct(plane.Normal, plane.Base - this.Base);
            double dp2 = Vector3D.DotProduct(plane.Normal, this.Direction);
            //calculate intersection
            double s = dp1 / dp2;
            if (forwardOnly && s < 0)
                throw new ParameterViolationException("The Line3D points away from the Plane3D.");
            return (this.Base + s * this.Direction);//get the intersection
        }
       
        /// <summary>
        /// Returns a string that describes the current object. (b: Base, d: Direction)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("b: {0}, d: {1}", this.Base, this.Direction);
        }

        /// <summary>
        /// Calculate the two (one) points of the closest approach.
        /// </summary>
        /// <param name="l1">Line 1</param>
        /// <param name="l2">Line 2</param>
        /// <param name="failIfParallel">Shall the method fail if the lines are parallel? If not, the returned segment (the Point3D[]) will be located at the first lines Base</param>
        /// <returns>A Point3D[2] of the two nearest coordinates</returns>
        /// <exception cref="IdenticalException">The lines are identical, they have an infinite number of approach-segments</exception>
        /// <exception cref="ParallelityException">The two lines are parallel, they have an infinite number of approach-segments</exception>
        public static Point3D[] ApproachLines(Line3D l1, Line3D l2, bool failIfParallel = true)
        {
            Vector3D w0 = l1.Base - l2.Base;
            double a = Vector3D.DotProduct(l1.Direction, l1.Direction);
            double b = Vector3D.DotProduct(l1.Direction, l2.Direction);
            double c = Vector3D.DotProduct(l2.Direction, l2.Direction);
            double d = Vector3D.DotProduct(l1.Direction, w0);
            double e = Vector3D.DotProduct(l2.Direction, w0);
            if ((a * c - b * b) == 0)
            {
                if (failIfParallel)
                    throw new ParallelityException("The lines are parallel and do not have a single approach segment. Set failIfParallel=true to get a result anyways.");
                return new Point3D[2] { l1.Base, l2.Base + d / b * l2.Direction };//case: parallel
            }
            Point3D s1 = l1.Base + (b * e - c * d) / (a * c - b * b) * l1.Direction;
            Point3D s2 = l2.Base + (a * e - b * d) / (a * c - b * b) * l2.Direction;
            return new Point3D[2] { s1, s2 };
        }
    }
}
