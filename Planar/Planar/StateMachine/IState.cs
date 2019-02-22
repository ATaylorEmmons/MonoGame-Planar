using Planar.Modular;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planar.StateMachine
{
    public interface IState
    {
        ///<summary>
        ///A method to be called as soon as this state is entered
        ///</summary>
        void Enter();

        /// <summary>
        /// A method called each frame from the containing machines update method.
        /// </summary>
        /// <param name="input"></param>
        void Update(InputState input, Entity entity);

        /// <summary>
        /// The method called just before the state changes from the current state. 
        /// Can return a state that should be entered immediatly.
        /// </summary>
        /// <returns></returns>
        IState Exit();
    }
}
