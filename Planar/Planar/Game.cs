using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Planar.Modular;
using Planar.Render;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Planar
{

    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;

        Entity triangle;
        
        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

           

        }


        protected override void Initialize()
        {
            base.Initialize();
        }

   
        protected override void LoadContent()
        {
            FillShapeMaterial mat = new FillShapeMaterial();
            Effect effect = Content.Load<Effect>("FillShape");
            mat.load(effect, GraphicsDevice);


            
            triangle = new Entity();

            triangle.Material = mat;

        }

        protected override void UnloadContent()
        {
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

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
