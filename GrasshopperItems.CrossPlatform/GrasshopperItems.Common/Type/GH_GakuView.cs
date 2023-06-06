using System;
using Rhino;
using Rhino.Display;
using Grasshopper.Kernel.Types;

namespace GrasshopperItems.Type
{
    public class GH_GakuView : GH_GakuGenerative<RhinoView>
    {
        public GH_GakuView() { }
        public GH_GakuView(RhinoView layer)
        {
            Value = layer;
        }
        public GH_GakuView(GH_GakuView other)
        {
            if (other == null)
                throw new ArgumentNullException("other");
            else
                Value = other.Value;
        }
        public GH_GakuView(Guid guid)
        {
            ReferenceID = guid;
        }

        #region GH_Gooの継承
        public override string TypeName => "View";
        public override IGH_Goo Duplicate()
        {
            if (IsReferenced)
                return new GH_GakuView(ReferenceID);
            else
                return new GH_GakuView(Value);
        }
        public override RhinoView Value
        {
            get
            {
                if (IsReferenced)
                    return RhinoDoc.ActiveDoc.Views.Find(ReferenceID);
                else
                    return m_value;
            }
            set => m_value = value;
        }
        #endregion
    }
}
