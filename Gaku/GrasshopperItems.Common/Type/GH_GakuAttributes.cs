using System;
using Rhino;
using Rhino.DocObjects;
using Grasshopper.Kernel.Types;

namespace GrasshopperItems.Type
{
    public class GH_GakuAttributes : GH_Goo<ObjectAttributes>
    {
        public GH_GakuAttributes() { }
        public GH_GakuAttributes(ObjectAttributes att)
        {
            Value = att;
        }
        public GH_GakuAttributes(GH_GakuAttributes other)
        {
            if (other == null)
                throw new ArgumentNullException("other");
            else
                Value = other.Value;
        }
        #region GH_Gooの継承
        public override bool IsValid => throw new NotImplementedException();
        public override string TypeDescription => throw new NotImplementedException();
        public override string TypeName => "Attributes";
        public override IGH_Goo Duplicate()
        {
            return new GH_GakuAttributes(this);
        }
        public override string ToString()
        {
            if (Value == null)
                return $"Invalid {TypeName}";
            else
                return this.TypeName;
        }
        #endregion
    }
}
