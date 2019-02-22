using Planar.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Input;
namespace Planar.Modular
{
    /// <summary>
    /// A component to manage input.
    /// Uses PushDownStateMachine to manage states.
    /// </summary>
    

    class InputComponent : IComponent
    {
        PushDownStateMachine stateMachine;

        public InputComponent(IState state)
        {
            stateMachine = new PushDownStateMachine(state);
        }

        /// <summary>
        /// Captures the current state of the keyboard and mouse.
        /// Then submits them to the stateMachine's currently active state
        /// </summary>
        /// <param name="owner">The entity that owns the component</param>
        /// <param name="delta">The amount of time that passed from last frame to this one.</param>
        public override void update(Entity owner, float delta)
        {
            InputState inputState;
            inputState.keyboardState = Keyboard.GetState();
            inputState.mouseState = Mouse.GetState();
            stateMachine.Update(inputState, owner);
        }
    }
}
