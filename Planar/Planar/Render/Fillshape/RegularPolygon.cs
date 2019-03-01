using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Planar.Render.Fillshape
{
    public struct RegularPolygon : IPolygon
    {
        int edges;
        int vertexLength;
        int indexLength;

        VertexPosition[] vertices;
        short[] indices;

        public int Edges
        {
            get
            {
                return edges;
            }
        }

        public VertexPosition[] Vertices
        {
            get
            {
                return this.vertices;
            }
        }
        public short[] Indices
        {
            get
            {
                return this.indices;
            }
        }

        public int VertexCount
        {
            get
            {
                return this.vertexLength;
            }
        }

        public int IndexCount
        {
            get
            {
                return this.indexLength;
            }
        }

        public RegularPolygon(int edges, float radius)
        {
            this.edges = edges;
            vertexLength = edges + 1;
            indexLength = edges * 3;

            vertices = new VertexPosition[vertexLength];
            indices = new short[indexLength];

            Vector2 top = new Vector2(0.0f, 1.0f);
            double rotation = 2.0 * (Math.PI) / edges;

            top = top * radius;

            for (int i = 0; i < vertexLength; i++)
            {
                vertices[i] = new VertexPosition(new Vector3(
                    (float)(top.X * Math.Cos(i*rotation) + top.Y * Math.Sin(i*rotation)),
                    (float)(-top.X * Math.Sin(i*rotation) + top.Y * Math.Cos(i*rotation)),
                    0.0f
                    ));
            }


            short countA = 1;
            short countB = 2;
            for (int i = 0; i < indexLength; i++)
            {
                if (i == indexLength - 1)
                {
                    indices[i] = 2;
                    break;
                }
                    if(i % 3 == 0)
                    {
                        indices[i] = 1;
                    }
                    else if (i % 3 == 1)
                    {
                        countA++;
                        indices[i] = countA;
                    }
                    else
                    {
                        countB++;
                        indices[i] = countB;
                    }
               
            }
        }
    }
}
