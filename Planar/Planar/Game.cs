using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Planar.Modular;


using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Planar
{

    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;

     
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
            
    
        }

        protected override void UnloadContent()
        {
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            


            base.Draw(gameTime);
        }
    }
}
