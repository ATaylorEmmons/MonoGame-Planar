using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planar.Render
{
    public class PolygonFactory
    {
        PolygonFactoryMethod method;

        public PolygonFactoryMethod Builder
        {
            set
            {
                this.method = value;
            }
        }

        public PolygonFactory(PolygonFactoryMethod builder)
        {
            this.method = builder;
        }



        public IPolygon Build()
        {
            return method.construct();
        }
    }
}
