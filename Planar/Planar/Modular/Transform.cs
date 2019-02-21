using Planar.R2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planar.Modular
{
    public class Transform 
    {
        public Vector3 position;
        public float theta;
        public float scaleX;
        public float scaleY;

        Matrix3x3 matrix;


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

        public Transform()
        {
            position = new Vector3(0.0f, 0.0f, 0.0f);
            theta = 0.0f;
            scaleX = 1.0f;
            scaleY = 1.0f;
            matrix = Matrix3x3.Identity();
        }

        public void update(float delta, Transform parent)
        {
            this.matrix = parent.Matrix * Matrix3x3.TransformMatrix(this.scaleX, this.scaleY, this.theta, this.position.X, this.position.Y);
        }
    }
}
