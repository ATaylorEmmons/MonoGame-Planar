using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Planar.Modular;

namespace Planar.Render
{
    class FillShapeMaterial : Material
    {
        Effect effect;
        Color color;

        public override void load()
        {
            
        }

        public override void draw(Entity owner)
        {
            effect.Parameters["WorldMatrix"].SetValue(owner.Matrix.FloatArray);

            effect.Parameters["Color"].SetValue(color.ToVector4());
        }

    }
}
