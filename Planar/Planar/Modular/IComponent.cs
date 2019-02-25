using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planar.Modular
{
    /// <summary>
    /// Interface for Component types to be attached to an entity.
    /// </summary>
    public abstract class IComponent
    {
        /// <summary>
        /// Called Every Frame by the entity that this is attached to.
        /// </summary>
        /// <param name="owner"> The entity that this component is attached to.</param>
        /// <param name="delta"> In milliseconds the change in time from the last frame to this frame.</param>
        public abstract void update(Entity owner, float delta);
        
    }
}
