using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planar.Render
{
    public interface IPolygon
    {
        int VertexCount
        {
            get;
        }

        VertexPosition[] Vertices
        {
            get;
        }

        int IndexCount
        {
            get;
        }

        short[] Indices
        {
            get;
        }

    }
}
