using Planar.R2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planar.Modular
{
    /// <summary>
    /// An Entity in an ECS that holds components to affect its behavior.
    /// </summary>
    /// <remarks>
    /// It seemd that every entity would have a transform. 
    /// Thus Planar.Modular.Transform is used as a base class
    /// rather than as a component(that every entity would have by default)
    /// </remarks>
    public class Entity : Transform
    {
        string name;
       
        public string Name
        {
            get
            {
                return this.name;
            } set
            {
                this.name = value;
            }
        }
        /// <summary>
        /// A dictionary of other entities.
        /// </summary>
        /// <remarks>
        /// The children's transform is updated by this entity's transform.
        /// </remarks>
        Dictionary<string, Entity> children;

        /// <summary>
        /// The components attached to this entity.
        /// </summary>
        Dictionary<string, IComponent> components;


        public Entity()
        {
            this.components = new Dictionary<string, IComponent>();
            this.children = new Dictionary<string, Entity>();
 
        }

        public void AttachComponent(string name, IComponent component)
        {
            this.components.Add(name, component);
        }

        public void AddChild(Entity entity)
        {
            this.children.Add(entity.Name, entity);
        }

        /// <summary>
        /// Method called each frame.
        /// </summary>
        /// <remarks>
        /// The components are updated first. They will likely affect the transform(the base class). 
        /// Next the base class's update is called.
        /// Finally the children's updates are called(in the same order as above).
        /// </remarks>
        /// <param name="delta">Change in time from the last frame to this one</param>
        /// <param name="parentTransform">The entity that owns this one. If this is a root entity pass in Transform::OriginR2()</param>
        public new void update(float delta, Transform parentTransform)
        {
            
            foreach(KeyValuePair<string, IComponent> component in this.components)
            {
                component.Value.update(this, delta);
            }

            base.update(delta, parentTransform);

            foreach (KeyValuePair<string, Entity> child in this.children)
            {
                child.Value.update(delta, this);
            }
        }
    }
}
