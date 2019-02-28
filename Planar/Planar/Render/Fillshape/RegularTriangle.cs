using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Planar.Render.Fillshape
{
    public class RegularTriangle : IPolygon
    {
        const int size = 3;
        public int Size
        {
            get
            {
                return size;
            }
           
        }

        public VertexPosition[] Vertices
        {
            get
            {
                return this.vertices;
            }
        }

        VertexPosition[] vertices;

        public RegularTriangle(float radius)
        {
            Vector2 top = new Vector2( 0.0f, 1.0f );
            double rotation = (Math.PI) * (2.0 / 3.0);

          top = top * radius;

    
            
            Vector2 right = new Vector2(
             (float)(top.X * Math.Cos(rotation) + top.Y * Math.Sin(rotation)),
             (float)(-top.X * Math.Sin( rotation) + top.Y * Math.Cos(rotation))
            );

            Vector2 left = new Vector2(
                (float)(top.X * Math.Cos(2.0*rotation) + top.Y*Math.Sin(2.0*rotation)),
                (float)(-top.X * Math.Sin(2.0*rotation) + top.Y*Math.Cos(2.0*rotation))
            );
            
         

            this.vertices = new VertexPosition[3];
            vertices[0] = new VertexPosition(new Vector3(top.X, top.Y, 0.0f));
            vertices[1] = new VertexPosition(new Vector3(right.X, right.Y, 0.0f));
            vertices[2] = new VertexPosition(new Vector3(left.X, left.Y, 0.0f));


              /* 
               vertices[0] = new VertexPosition(new Vector3(-0.5, -0.5f, 0f));
               vertices[1] = new VertexPosition(new Vector3(0, 0.5f, 0f));
               vertices[2] = new VertexPosition(new Vector3(0.5f, -0.5f, 0f));
             */


        }


    }
}
