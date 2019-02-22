using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
namespace Planar.StateMachine
{
    public struct InputState
    {
        public KeyboardState keyboardState;
        public MouseState mouseState;

        public InputState(KeyboardState keyboardState, MouseState mouseState)
        {
            this.keyboardState = keyboardState;
            this.mouseState = mouseState;
        }
    }
}
