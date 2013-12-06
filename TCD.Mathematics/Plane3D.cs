using System;

namespace TCD.Mathematics
{
    /// <summary>
    /// A plane in 3D-space
    /// </summary>
    public class Plane3D
    {
        /// <summary>
        /// The 'Base' of the Plane3D
        /// </summary>
        public Point3D Base { get; set; }
        /// <summary>
        /// The normal vector of this Plane3D
        /// </summary>
        /// <exception cref="NullVectorException">Vector3D(0,0,0) is not allowed!!</exception>
        private Vector3D _Normal;
        public Vector3D Normal
        {
            get { return _Normal; }
            set { _Normal = value.Normalized(); }
        }

        /// <summary>
        /// Define a Plane3D by a Base and a Normal
        /// </summary>
        /// <param name="b">The base of the plane</param>
        /// <param name="n">The normal vector, which is perpendicular to the plane.</param>
        /// <exception cref="NullVectorException">Vector3D(0,0,0) is not allowed as a Normal!</exception>
        public Plane3D(Point3D b, Vector3D n)
        {
            this.Base = b;
            this.Normal = n.Normalized();
        }
        /// <summary>
        /// Define a Plane3D by three Point3Ds
        /// </summary>
        /// <param name="p1">Point 1</param>
        /// <param name="p2">Point 2</param>
        /// <param name="p3">Point 3</param>
        /// <exception cref="NullVectorException">If two or more points are identical, no unique Normal can be calculated, resulting in this exception.</exception>
        public Plane3D(Point3D p1, Point3D p2, Point3D p3)
        {
            this.Base = p1;
            this.Normal = Vector3D.CrossProduct(p2 - p1, p3 - p1).Normalized();
        }
        /// <summary>
        /// Define a Plane3D by a Line3D and a Point3D
        /// </summary>
        /// <param name="l">The Line3D</param>
        /// <param name="p">The Point3D</param>
        /// <exception cref="NullVectorException">If the Point3D is on the Line3D, no Normal can be calculated, resulting in this exception.</exception>
        public Plane3D(Line3D l, Point3D p)
        {
            this.Base = l.Base;
            this.Normal = Vector3D.CrossProduct(l.Direction, p - l.Base).Normalized();
        }

        /// <summary>
        /// Get the line that is the intersection of two Planes
        /// </summary>
        /// <param name="p1">Plane 1</param>
        /// <param name="p2">Plane 2</param>
        /// <exception cref="ParallelityException">If the planes are parallel, there's no single line of intersection.</exception>
        /// <exception cref="IdenticalException">Occurs if the planes are identical.</exception>
        public static Line3D IntersectPlane3Ds(Plane3D p1, Plane3D p2)
        {
            Vector3D u = Vector3D.CrossProduct(p1.Normal, p2.Normal);//a vector perpendicular to both planes
            if (u.LengthSquared == 0)//if it's length is zero
            {
                if (Vector3D.DotProduct(p1.Base - p2.Base, p1.Normal) == 0)//if the vector between the bases is perpendicular to a normal
                    throw new IdenticalException("The Planes are identical!");
                else
                    throw new ParallelityException("The Planes are parallel!");//the vector between the bases is not parallel to the surface
            }
            //let's calculate the point
            double d = u.X;
            double x = 0;
            double y = 0;
            double z = 0;
            if (Math.Abs(u.Y) > d)//y=0
            {
                x = 0;
                y = (p1.Normal.X * p2.Normal.Z - p2.Normal.X * p1.Normal.Z) / (p2.Normal.Y * p1.Normal.Z - p1.Normal.Y * p2.Normal.Z);
                z = (p2.Normal.X * p1.Normal.Y - p1.Normal.X * p2.Normal.Y) / (p2.Normal.Y * p1.Normal.Z - p1.Normal.Y * p2.Normal.Z);
            }
            if (Math.Abs(u.Z) > d)//z=0
            {
                x = (p1.Normal.Y * p2.Normal.Z - p2.Normal.Y * p1.Normal.Z) / (p2.Normal.X * p1.Normal.Z - p1.Normal.X * p2.Normal.Z);
                y = 0;
                z = (p1.Normal.X * p2.Normal.Y - p2.Normal.X * p1.Normal.Y) / (p2.Normal.X * p1.Normal.Z - p1.Normal.X * p2.Normal.Z);
            }
            else//x=0
            {
                x = (p1.Normal.Y * p2.Normal.Z - p2.Normal.Y * p1.Normal.X) / (p1.Normal.X * p2.Normal.Y - p2.Normal.X * p1.Normal.Y);
                y = (p2.Normal.X * p1.Normal.Z - p1.Normal.X * p2.Normal.Z) / (p1.Normal.X * p2.Normal.Y - p2.Normal.X * p1.Normal.Y);
                z = 0;
            }
            return new Line3D(new Point3D(x, y, z), u);
        }

        /// <summary>
        /// Returns a string that describes the current object. (b: Base, n: Normal)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("b: {0}, n: {1}", this.Base, this.Normal);
        }
    }
}
