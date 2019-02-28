using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planar.Render.Fillshape
{
    public class TriangleBuilder : PolygonFactoryMethod
    {
        float radius;
        public float Radius
        {
            get
            {
                return radius;
            }
            set
            {
                this.radius = value;
            }
        }

        public TriangleBuilder(float radius)
        {
            this.radius = radius;
        }
       
        public IPolygon construct()
        {
            return new RegularTriangle(radius);
        }
    }
}
