using Planar.Modular;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planar.StateMachine
{
    public class PushDownStateMachine
    {
       
        Stack<IState> stateStack;

        public PushDownStateMachine(IState startingState)
        {
            stateStack = new Stack<IState>();
            stateStack.Push(startingState);
        }

        /// <summary>
        /// Makes the supplied state the current state and puts it on top of the stack.
        /// </summary>
        /// <param name="state"></param>
        public void Enter(IState state)
        {
            stateStack.Push(state);
            stateStack.Peek().Enter();
        }

        /// <summary>
        /// Calls the current states update methods.
        /// </summary>
        /// <param name="input">The current state of keyboard or mouse.</param>
        /// <param name="entity">The entity that owns this state machine. </param>
        public void Update(InputState input, Entity entity)
        {
            stateStack.Peek().Update(input, entity);
        }

        /// <summary>
        /// Calls the current states Exit() method and then removes it from the stack.
        /// If Exit returned a state it enters it.
        /// </summary>
        public void Exit()
        {
            /*
             * Peek is used to avoid removing the state while we are in its Exit method.
             */

            IState next = stateStack.Peek().Exit();
            stateStack.Pop();

            if(next != null)
            {
                this.Enter(next);
            }
        }
    }
}
