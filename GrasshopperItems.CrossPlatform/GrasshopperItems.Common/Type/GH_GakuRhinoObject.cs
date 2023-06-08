using System;
using System.Collections.Generic;
using Rhino.Geometry;
using Rhino.DocObjects;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using GrasshopperItems.Type;

namespace GrasshopperItems.Type
{
    public class GH_GakuRhinoObject : GH_GakuGeometric<RhinoObject>
    {
        public GH_GakuRhinoObject() { }
        public GH_GakuRhinoObject(RhinoObject robj)
        {
            Value = robj;
        }

        #region GH_Gooの継承
        public override BoundingBox Boundingbox => Value.Geometry.GetBoundingBox(true);
        public override string TypeName => "Geometric Object";
        public override IGH_GeometricGoo DuplicateGeometry()
        {
            return new GH_GakuRhinoObject(Value);
        }
        public override BoundingBox GetBoundingBox(Transform xform)
        {
            throw new NotImplementedException();
        }
        public override IGH_GeometricGoo Morph(SpaceMorph xmorph)
        {
            throw new NotImplementedException();
        }
        public override RhinoObject Value
        {
            get => m_value;
            set => m_value = value;
        }
        #endregion

        #region IGH_PreviewData
        public override void DrawViewportWires(GH_PreviewWireArgs args)
        {
        }
        public override void DrawViewportMeshes(GH_PreviewMeshArgs args)
        {
        }
        #endregion
    }
}
