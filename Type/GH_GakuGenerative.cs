using Grasshopper.Kernel.Types;
using System;

namespace GrasshopperItems.Type
{
    public abstract class GH_GakuGenerative<T> : GH_Goo<T>, IGH_GakuType
    {
        public bool IsReferenced => this.ReferenceID != Guid.Empty;
        public override bool IsValid => throw new NotImplementedException();
        public virtual Guid ReferenceID { get; set; }
        public override string TypeDescription => throw new NotImplementedException();
        public override IGH_Goo Duplicate()
        {
            throw new System.NotImplementedException();
        }
        public override string ToString()
        {
            if (this.Value == null)
                return $"Invalid {this.TypeName}";
            else if (this.IsReferenced)
                return $"Referenced {this.TypeName}";
            else
                return this.TypeName;
        }
    }
}
