using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace GakuCommon.Geometry
{
    public abstract class Entity<T>
    {
        internal Entity(T obj)
        {
            this.Value = obj;
        }
        public T Value { get; set; }
    }
}
