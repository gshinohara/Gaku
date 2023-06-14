using System;
using Rhino;
using Rhino.DocObjects;
using Grasshopper.Kernel.Types;

namespace GrasshopperItems.Type
{
    public class GH_GakuLayer : GH_GakuGenerative<Layer>
    {
        public GH_GakuLayer() { }
        public GH_GakuLayer(Layer layer)
        {
            Value = layer;
        }
        public GH_GakuLayer(GH_GakuLayer other)
        {
            if (other == null)
                throw new ArgumentNullException("other");
            else
                Value = other.Value;
        }
        public GH_GakuLayer(Guid guid)
        {
            ReferenceID = guid;
        }
        #region GH_Gooの継承
        public override string TypeName => "Layer";
        public override IGH_Goo Duplicate()
        {
            if (IsReferenced)
                return new GH_GakuLayer(ReferenceID);
            else
                return new GH_GakuLayer(Value);
        }
        public override Layer Value
        {
            get
            {
                if (IsReferenced)
                    return RhinoDoc.ActiveDoc.Layers.FindId(ReferenceID);
                else
                    return m_value;
            }
            set => m_value = value;
        }
        #endregion
    }
}
