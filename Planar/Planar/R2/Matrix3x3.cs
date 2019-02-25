using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planar.R2
{
    public struct Matrix3x3
    {
        private float[] data;

        public Matrix3x3(float[] values) {
            data = values;
        }

        public float[] FloatArray
        {
            get
            {
                return this.data;
            }
        }

        public float this[uint i]
        {
            get
            {
                return this.data[i];
            }
            set
            {
                this.data[i] = value;
            }
        }

        static public Matrix3x3 Identity()
        {
            float[] data = { 1.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 0.0f, 1.0f  };
            Matrix3x3 ret = new Matrix3x3(data);

            return ret;
        }

        static public Matrix3x3 Scale(float x, float y)
        {
            float[] data = {
                            x, 0.0f, 0.0f,
                            0.0f, y, 0.0f, 
                            0.0f, 0.0f, 1.0f
                           };

            Matrix3x3 ret = new Matrix3x3(data);

            return ret;
        }

        static public Matrix3x3 Rotation(float theta)
        {
            float[] data = {
                            (float)Math.Cos(theta), -(float)Math.Sin(theta), 0.0f ,
                            (float)Math.Sin(theta), (float)Math.Cos(theta), 0.0f,
                            0.0f, 0.0f, 1.0f
                            };

            Matrix3x3 ret = new Matrix3x3(data);

            return ret;
        }

        static public Matrix3x3 Translation(float x, float y)
        {
            float[] data = {
                            1.0f, 0.0f, x,
                            0.0f, 1.0f, y,
                            0.0f, 0.0f, 1.0f
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
                    ret.data[3*i + j] = 0.0f;
                    for(uint k = 0; k < 3; k++)
                    {
                        ret.data[3*i + j] += a[3*i + k] * b[3*k + j];
                    }
                }
            }


            return ret;
        }

        static public Vector3 operator*(Matrix3x3 a, Vector3 vec)
        {
            return new Vector3(
                a[0] * vec.X + a[1] * vec.Y + a[2] * vec.Z,
                a[3] * vec.X + a[4] * vec.Y + a[5] * vec.Z,
                a[6] * vec.X + a[7] * vec.Y + a[8] * vec.Z
                );
        }

        static public Matrix3x3 TransformMatrix(float scaleX, float scaleY, float theta, float x, float y)
        {
            Matrix3x3 ret = new Matrix3x3(new float[]{0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f,  0.0f, 0.0f, 0.0f });

            ret[0] = scaleX * (float)Math.Cos(theta);
            ret[1] = scaleY * -(float)Math.Sin(theta);
            ret[2] = x;
            ret[3] = scaleX * (float)Math.Sin(theta);
            ret[4] = scaleY * (float)Math.Cos(theta);
            ret[5] = y;
            ret[6] = 0;
            ret[7] = 0;
            ret[8] = 1;

            return ret;
        }
    }
}
