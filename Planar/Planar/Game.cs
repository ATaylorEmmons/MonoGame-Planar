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

            builder = new RegularPolygonBuilder(400, 500.0f);
            polygonFactory = new PolygonFactory(builder);


            base.Initialize();
        }

   
        protected override void LoadContent()
        {
            triangle = new Entity();

            FillShapeMaterial triangleMaterial = new FillShapeMaterial();
            triangleMaterial.RenderShape = polygonFactory.Build();
            triangleMaterial.load(Content, GraphicsDevice);
            triangleMaterial.Color = Color.Wheat;

            triangle.Material = triangleMaterial;


        }

        protected override void UnloadContent()
        {
        }

        float scale = .1f;

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            triangle.ScaleX -= scale;
            triangle.ScaleY -= scale;

            triangle.update(gameTime.ElapsedGameTime.Milliseconds, Transform.OriginR2());

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            triangle.draw(GraphicsDevice);
           

            base.Draw(gameTime);
        }
    }
}
