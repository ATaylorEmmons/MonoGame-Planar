using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planar.Render
{
    public interface PolygonFactoryMethod
    {
        IPolygon construct();
    }
}
