using Grasshopper.Kernel.Types;
using System;

namespace GrasshopperItems.Type
{
    public abstract class GH_GakuGenerative<T> : GH_Goo<T>, IGH_GakuType
    {
        public bool IsReferenced => ReferenceID != Guid.Empty;
        public override bool IsValid => throw new NotImplementedException();
        public virtual Guid ReferenceID { get; set; }
        public override string TypeDescription => throw new NotImplementedException();
        public override string ToString()
        {
            if (Value == null)
                return $"Invalid {TypeName}";
            else if (IsReferenced)
                return $"Referenced {TypeName}";
            else
                return TypeName;
        }
        #region casting
        public override bool CastFrom(object source)
        {
            if (source is GH_Guid)
            {
                GH_Guid guid = (GH_Guid)source;
                ReferenceID = guid.Value;
                return true;
            }
            else
                return false;
        }
        #endregion
    }
}
