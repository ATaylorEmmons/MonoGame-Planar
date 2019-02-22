using Planar.R2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planar.Modular
{
    /// <summary>
    /// The Linear Algebra that places objects appropriatly.
    /// </summary>
    public class Transform 
    {
        public Vector3 position;
        public float theta;
        public float scaleX;
        public float scaleY;


        /// <summary>
        /// Holds the current transform as a matrix.
        /// </summary>
        /// <remarks>
        /// May remove in the future as a builder function is used
        /// to return the transform matrix.
        /// </remarks>
        Matrix3x3 matrix;

        /// <summary>
        /// Returns the Identity Matrix.
        /// </summary>
   
        /// <returns>r</returns>
        static public Transform OriginR2()
        {
            return new Transform();
        }

        public Matrix3x3 Matrix
        {
            get
            {
                return matrix;
            }
        }
        
        public Vector2 Position
        {
            get
            {
                return new Vector2(position.X, position.Y);
            }
            set
            {
                position = new Vector3(value.X, value.Y, 1.0f);
            }
        }

        /// <summary>
        /// Gets or sets the number of radians from the X-Axis in a counter-clockwise motion.
        /// </summary>
        public float Angle
        {
            get
            {
                return this.theta;
            }
             set
            {
                this.theta = value;
            }
        }

        public float ScaleX
        {
            get
            {
                return this.scaleX;
            }
            set
            {
                this.scaleX = value;
            }
        }

        public float ScaleY
        {
            get
            {
                return this.scaleY;
            }
            set
            {
                this.scaleY = value;
            }
        }

        /// <summary>
        /// Creates a Transform object that is set to the Identity.
        /// </summary>
        public Transform()
        {
            position = new Vector3(0.0f, 0.0f, 0.0f);
            theta = 0.0f;
            scaleX = 1.0f;
            scaleY = 1.0f;
            matrix = Matrix3x3.Identity();
        }

        /// <summary>
        /// Creates and returns a transform matrix.
        /// </summary>
        /// <remarks>
        /// The transforms are performed in the order of: scale, rotation, translation
        /// </remarks>
        /// <param name="delta">Change in time from last frame to current</param>
        /// <param name="parent">What transform affects this one.</param>
        public void update(float delta, Transform parent)
        {
            this.matrix = parent.Matrix * Matrix3x3.TransformMatrix(this.scaleX, this.scaleY, this.theta, this.position.X, this.position.Y);
        }
    }
}
