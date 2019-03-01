using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Planar.Modular;
using Planar.Render.Fillshape;

namespace Planar.Render.FillShapeMaterial
{
    class FillShapeMaterial : Material
    {
        Effect effect;
        VertexBuffer vertexBuffer;
        IndexBuffer indexBuffer;

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

            vertexBuffer = new VertexBuffer(this.device, typeof(VertexPosition), this.shape.VertexCount, BufferUsage.WriteOnly);
            vertexBuffer.SetData<VertexPosition>(shape.Vertices);

            indexBuffer = new IndexBuffer(this.device, typeof(short), this.shape.IndexCount, BufferUsage.WriteOnly);
            indexBuffer.SetData<short>(shape.Indices);
        }

        public override void draw(Entity owner)
        {

            effect.Parameters["resolution"].SetValue(new Vector2(1080.0f, 720.0f));
            effect.Parameters["ModelMatrix"].SetValue(owner.Matrix);
            //effect.Parameters["ViewMatrix"].SetValue(Matrix.Identity);
            effect.Parameters["color"].SetValue(color.ToVector4());
            effect.Techniques["FillShape"].Passes["Pass1"].Apply();

            device.Indices = this.indexBuffer;
            device.SetVertexBuffer(vertexBuffer);

            device.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, ((RegularPolygon)shape).Edges);
        }
    }
}
