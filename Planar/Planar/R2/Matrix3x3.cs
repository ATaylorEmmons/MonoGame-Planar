using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planar.R2
{
    public struct Matrix3x3
    {
        private float[,] data;

        public Matrix3x3(float[,] values) {
            data = values;
        }

        public float this[uint i, uint j]
        {
            get
            {
                return this.data[i, j];
            }
            set
            {
                this.data[i, j] = value;
            }
        }

        static public Matrix3x3 Identity()
        {
            float[,] data = { { 1.0f, 0.0f, 0.0f }, { 0.0f, 1.0f, 0.0f }, { 0.0f, 0.0f, 1.0f } };
            Matrix3x3 ret = new Matrix3x3(data);

            return ret;
        }

        static public Matrix3x3 Scale(float x, float y)
        {
            float[,] data = {
                            { x, 0.0f, 0.0f },
                            { 0.0f, y, 0.0f },
                            { 0.0f, 0.0f, 1.0f }
                            };

            Matrix3x3 ret = new Matrix3x3(data);

            return ret;
        }

        static public Matrix3x3 Rotation(float theta)
        {
            float[,] data = {
                            { (float)Math.Cos(theta), -(float)Math.Sin(theta), 0.0f },
                            { (float)Math.Sin(theta), (float)Math.Cos(theta), 0.0f },
                            { 0.0f, 0.0f, 1.0f }
                            };

            Matrix3x3 ret = new Matrix3x3(data);

            return ret;
        }

        static public Matrix3x3 Translation(float x, float y)
        {
            float[,] data = {
                            { 1.0f, 0.0f, x },
                            { 0.0f, 1.0f, y },
                            { 0.0f, 0.0f, 1.0f }
                            };

            Matrix3x3 ret = new Matrix3x3(data);

            return ret;
        }
        
        static public Matrix3x3 operator*(Matrix3x3 a, Matrix3x3 b)
        {
            Matrix3x3 ret = Matrix3x3.Identity();

            for(uint i = 0; i < 3; i++)
            {
                for(uint j = 0; j < 3; j++)
                {
                    ret.data[i, j] = 0.0f;
                    for(uint k = 0; k < 3; k++)
                    {
                        ret.data[i, j] += a[i, k] * b[k, j];
                    }
                }
            }


            return ret;
        }

        static public Vector3 operator*(Matrix3x3 a, Vector3 vec)
        {
            return new Vector3(
                a[0, 0] * vec.X + a[0, 1] * vec.Y + a[0, 2] * vec.Z,
                a[1, 0] * vec.X + a[1, 1] * vec.Y + a[1, 2] * vec.Z,
                a[2, 0] * vec.X + a[2, 1] * vec.Y + a[2, 2] * vec.Z
                );
        }

        static public Matrix3x3 TransformMatrix(float scaleX, float scaleY, float theta, float x, float y)
        {
            Matrix3x3 ret = new Matrix3x3(new float[3, 3]{ { 0.0f, 0.0f, 0.0f}, { 0.0f, 0.0f, 0.0f }, { 0.0f, 0.0f, 0.0f } });

            ret[0, 0] = scaleX * (float)Math.Cos(theta);
            ret[0, 1] = scaleY * -(float)Math.Sin(theta);
            ret[0, 2] = x;
            ret[1, 0] = scaleX * (float)Math.Sin(theta);
            ret[1, 1] = scaleY * (float)Math.Cos(theta);
            ret[1, 2] = y;
            ret[2, 0] = 0;
            ret[2, 1] = 0;
            ret[2, 2] = 1;

            return ret;
        }
    }
}
