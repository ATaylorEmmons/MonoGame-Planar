using Planar.R2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planar.Modular
{
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

        Dictionary<string, Entity> children;
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

        public new void update(float delta, Transform parentTransform)
        {
            base.update(delta, parentTransform);



            foreach(KeyValuePair<string, IComponent> component in this.components)
            {
                component.Value.update(delta);
            }

            foreach (KeyValuePair<string, Entity> child in this.children)
            {
                child.Value.update(delta, this);
            }
        }
    }
}
