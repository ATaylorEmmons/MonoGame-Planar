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

        Matrix testScale = new Matrix(
            scaleX, 0.0f, 0.0f, 0.0f,
            0.0f, scaleY, 0.0f, 0.0f,
            0.0f, 0.0f, 1.0f, 0.0f,
            0.0f, 0.0f, 0.0f, 1.0f
            );

        Matrix testRotate = new Matrix(
            (float)Math.Cos(theta), -(float)Math.Sin(theta), 0.0f, 0.0f,
            (float)Math.Sin(theta), (float)Math.Cos(theta), 0.0f, 0.0f,
            0.0f, 0.0f, 1.0f, 0.0f,
            0.0f, 0.0f, 0.0f, 1.0f
            );
             

        Matrix testTranslate = new Matrix(
            1.0f, 0.0f, 0.0f, x,
            0.0f, 1.0f, 0.0f, y,
            0.0f, 0.0f, 1.0f, 0.0f,
            0.0f, 0.0f, 0.0f, 1.0f
            );


            Matrix test = testTranslate * testRotate * testScale;

            return test;
        }
    }
}
