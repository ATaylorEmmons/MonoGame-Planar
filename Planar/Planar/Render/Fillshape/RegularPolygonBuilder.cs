using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planar.Render.Fillshape
{
    public class RegularPolygonBuilder : PolygonFactoryMethod
    {
        int edges;
        float radius;
        RegularPolygon polygon;

        bool created = false;

        public RegularPolygonBuilder(int edges, float radius)
        {
            this.edges = edges;
            this.radius = radius;
        }

        public IPolygon construct()
        {
            if(!created)
            {
                this.polygon = new RegularPolygon(this.edges, radius);

                return polygon;

            } else
            {
                return polygon;
            }
        }
    }
}
