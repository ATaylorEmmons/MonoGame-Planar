using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planar.Render.Fillshape
{
    public class RegularPolygonBuilder : PolygonFactoryMethod
    {
        public string name;

        int edges;
        float radius;
        RegularPolygon polygon;

        bool created = false;

        public RegularPolygonBuilder(int edges, float radius)
        {
            this.edges = edges;
            this.radius = radius;
        }

        public int Edges {
            get
            {
                return this.edges;
            }
            set
            {
                this.created = false;
                this.edges = value;
            }
        }

        public float Radius
        {
            get
            {
                return this.radius;
            }
            set
            {
                this.created = false;
                this.radius = value;
            }
        }

        public IPolygon construct()
        {
            if(!created)
            {
                this.polygon = new RegularPolygon(this.edges, radius);
                created = true;
                return polygon;

            } else
            {
                return polygon;
            }
        }
    }
}
