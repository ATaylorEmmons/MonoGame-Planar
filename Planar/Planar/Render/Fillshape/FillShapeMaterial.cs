using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Planar.Modular;

namespace Planar.Render.FillShapeMaterial
{
    class FillShapeMaterial : Material
    {
        Effect effect;
        VertexBuffer vertexBuffer;


        GraphicsDevice device;

        Color color;
        public Color Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }
        

        IPolygon shape;
        public IPolygon RenderShape
        {
            get
            {
                return this.shape;
            } set
            {
                this.shape = value;
            }
        }

        public override void load(ContentManager Content, GraphicsDevice device)
        {
            effect = Content.Load<Effect>("FillShape");
            this.device = device;

            vertexBuffer = new VertexBuffer(this.device, typeof(VertexPosition), this.shape.Size, BufferUsage.WriteOnly);

            vertexBuffer.SetData<VertexPosition>(shape.Vertices);

        }

        public override void draw(Entity owner)
        {

            effect.Parameters["resolution"].SetValue(new Vector2(1020.0f, 720.0f));
            effect.Parameters["ModelMatrix"].SetValue(owner.Matrix);
            //effect.Parameters["ViewMatrix"].SetValue(Matrix.Identity);
            effect.Parameters["color"].SetValue(color.ToVector4());
            effect.Techniques["FillShape"].Passes["Pass1"].Apply();

            device.SetVertexBuffer(vertexBuffer);
        
            device.DrawPrimitives(PrimitiveType.TriangleStrip, 0, shape.Size);
        }
    }
}
