using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planar.Modular
{
    public class MatrixTools
    {
        public static Matrix Identity()
        {
            return new Matrix(
                1.0f, 0.0f, 0.0f, 0.0f,
                0.0f, 1.0f, 0.0f, 0.0f,
                0.0f, 0.0f, 1.0f, 0.0f,
                0.0f, 0.0f, 0.0f, 1.0f
                );
        }

        static public Matrix TransformMatrix(float scaleX, float scaleY, float theta, float x, float y)
        {
            Matrix ret = new Matrix(
                scaleX * (float)Math.Cos(theta), scaleY * -(float)Math.Sin(theta), x, 0.0f,
                scaleX * (float)Math.Sin(theta), scaleY * (float)Math.Cos(theta), y, 0.0f,
                0.0f, 0.0f, 0.0f, 0.0f,
                0.0f, 0.0f, 0.0f, 0.0f 
                );

            return ret;
        }
    }
}
