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
            this.Value = layer;
        }
        public GH_GakuView(GH_GakuView other)
        {
            if (other == null)
                throw new ArgumentNullException("other");
            else
                this.Value = other.Value;
        }
        public GH_GakuView(Guid guid)
        {
            this.ReferenceID = guid;
        }

        #region GH_Gooの継承
        public override string TypeName => "View";
        public override IGH_Goo Duplicate()
        {
            if (this.IsReferenced)
                return new GH_GakuView(ReferenceID);
            else
                return new GH_GakuView(this.Value);
        }
        public override RhinoView Value
        {
            get
            {
                if (this.IsReferenced)
                    return RhinoDoc.ActiveDoc.Views.Find(ReferenceID);
                else
                    return this.m_value;
            }
            set => this.m_value = value;
        }
        #endregion
    }
}
