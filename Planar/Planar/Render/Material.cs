using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Planar.Modular;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planar.Render
{
    public abstract class Material
    {
        public abstract void load(ContentManager Content, GraphicsDevice device);
        public abstract void draw(Entity owner);
    }
}
