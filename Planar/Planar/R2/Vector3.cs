using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planar.R2
{
    public struct Vector3
    {
        private float[] data;

        public Vector3(float x, float y, float z)
        {
            data = new float[3];
            data[0] = x;
            data[1] = y;
            data[2] = z;
        }

        public float X
        {
            get
            {
                return data[0];
            } set
            {
                data[0] = value;
            }
        }

        public float Y
        {
            get
            {
                return data[1];
            }
            set
            {
                data[1] = value;
            }
        }

        public float Z
        {
            get
            {
                return data[2];
            }
            set
            {
                data[2] = value;
            }
        }

        public void add(Vector3 vec)
        {
            this.X += vec.X;
            this.Y += vec.Y;
            this.Z += vec.Z;
        }

        public void scale(float a)
        {
            this.X *= a;
            this.Y *= a;
            this.Z *= a;
        }

        static public Vector3 operator*(float a, Vector3 vec)
        {
            return new Vector3(vec.X * a, vec.Y * a, vec.Z * a);
        }

        static public Vector3 operator+(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public float dot(Vector3 vec)
        {
            return this.X * vec.X + this.Y * vec.Y + this.Z + vec.Z;
        }

        public float magSquared()
        {
            return this.X * this.X + this.Y * this.Y + this.Z * this.Z;
        }

        static public Vector3 Lerp(Vector3 start, Vector3 end, float t)
        {
            return (1.0f - t) * start + t * end;
        }
    }
}
