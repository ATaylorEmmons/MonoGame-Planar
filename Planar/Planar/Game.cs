using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Planar.Modular;
using Planar.Render;
using Planar.Render.Fillshape;
using Planar.Render.FillShapeMaterial;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Planar
{

    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;

        PolygonFactory polygonFactory;
        RegularPolygonBuilder builder;


        Entity triangle;
        Entity diamond;

        const float vel = 2f;


        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

           

        }


        protected override void Initialize()
        {

            graphics.PreferredBackBufferWidth = 1080;
            graphics.PreferredBackBufferHeight = 720;

            graphics.ApplyChanges();

            builder = new RegularPolygonBuilder(3, 500.0f);

            polygonFactory = new PolygonFactory(builder);


            base.Initialize();
        }

   
        protected override void LoadContent()
        {
            triangle = new Entity();


            FillShapeMaterial triangleMaterial = new FillShapeMaterial();
            triangleMaterial.RenderShape = polygonFactory.Build();
            triangleMaterial.load(Content, GraphicsDevice);
            triangleMaterial.Color = Color.Bisque;

            triangle.Material = triangleMaterial;


            diamond = new Entity();

            builder.Edges = 4;
            

            //polygonFactory.Builder = builder;


            FillShapeMaterial diamondMaterial = new FillShapeMaterial();
            diamondMaterial.RenderShape = polygonFactory.Build();
            diamondMaterial.load(Content, GraphicsDevice);
            diamondMaterial.Color = Color.Wheat;

            diamond.Material = diamondMaterial;

            triangle.Name = "Triangle";
            diamond.AddChild(triangle);
        }

        protected override void UnloadContent()
        {
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


           
            diamond.update(gameTime.ElapsedGameTime.Milliseconds, Transform.OriginR2());
            

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            diamond.draw(GraphicsDevice);
            triangle.draw(GraphicsDevice);
           

            base.Draw(gameTime);
        }
    }
}
