using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planar.R2
{
    public struct Vector2
    {
        private float[] data;

        public Vector2(float x, float y)
        {
            data = new float[2];
            data[0] = x;
            data[1] = y;
        }

        public float X
        {
            get
            {
                return data[0];
            }
            set
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


        public void add(Vector2 vec)
        {
            this.X += vec.X;
            this.Y += vec.Y;
        }

        public void scale(float a)
        {
            this.X *= a;
            this.Y *= a;
        }

        static public Vector2 operator *(float a, Vector2 vec)
        {
            return new Vector2(vec.X * a, vec.Y * a);
        }

        static public Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X + b.X, a.Y + b.Y);
        }

        public float dot(Vector2 vec)
        {
            return this.X * vec.X + this.Y * vec.Y;
        }

        public float magSquared()
        {
            return this.X * this.X + this.Y * this.Y;
        }

        static public Vector2 Lerp(Vector2 start, Vector2 end, float t)
        {
            return (1.0f - t) * start + t * end;
        }
    }
}
