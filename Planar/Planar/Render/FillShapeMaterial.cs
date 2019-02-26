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

        VertexBuffer buffer;


        struct VertexPosition2D
        {
            public VertexPosition2D(Vector2 vec)
            {

            }
        };

        public override void load(Effect effect)
        {
            this.effect = effect;

            VertexPosition[] vertices = new VertexPosition[3];
            vertices[0] = new VertexPosition(new Vector3(0, 1, 0));
            vertices[1] = new VertexPosition(new Vector3(+0.5f, 0, 0));
            vertices[2] = new VertexPosition(new Vector3(-0.5f, 0, 0));

            color = Color.Black;
            
        }

        public void load(Effect effect, GraphicsDevice device)
        {
            this.effect = effect;

            VertexPosition[] vertices = new VertexPosition[3];
            vertices[0] = new VertexPosition(new Vector3(0, 1, 0));
            vertices[1] = new VertexPosition(new Vector3(+0.5f, 0, 0));
            vertices[2] = new VertexPosition(new Vector3(-0.5f, 0, 0));

            buffer = new VertexBuffer(device, typeof(VertexPosition), 3, BufferUsage.WriteOnly);
            buffer.SetData<VertexPosition>(vertices);

          

        }

        public override void draw(Entity owner, GraphicsDevice device)
        {

           

            effect.Parameters["ModelMatrix"].SetValue(owner.Matrix);
            effect.Parameters["ViewMatrix"].SetValue(owner.Matrix);

            effect.Parameters["color"].SetValue(color.ToVector4());

            effect.Techniques["FillShape"].Passes["Pass1"].Apply();

            device.SetVertexBuffer(buffer);
            device.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 3);
        }

        public void draw(Entity owner)
        {
         

            effect.Parameters["ModelMatrix"].SetValue(owner.Matrix);
            effect.Parameters["ViewMatrix"].SetValue(owner.Matrix);

            effect.Parameters["color"].SetValue(color.ToVector4());

            effect.Techniques["FillShape"].Passes["Pass1"].Apply();
        }
    }
}
