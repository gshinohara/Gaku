using System;
using Rhino;
using Rhino.Geometry;
using Rhino.DocObjects;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using GakuCommon.DocObjects;
using GakuCommon.Geometry;

namespace GrasshopperItems.Type
{
    public class GH_GakuClippingBox : GH_GakuGeometric<ClippingBoxEntity>
    {
        public GH_GakuClippingBox() { }
        public GH_GakuClippingBox(ClippingBoxEntity clippingBox)
        {
            Value = clippingBox;
        }
        public GH_GakuClippingBox(Guid id)
        {
            ReferenceID = id;
        }

        #region GH_Gooの継承
        public override BoundingBox Boundingbox => Value.Value.ToBrep().GetBoundingBox(true);
        public override string TypeName => "ClipBox";
        public override IGH_GeometricGoo DuplicateGeometry()
        {
            return new GH_GakuClippingBox(Value);
        }
        public override BoundingBox GetBoundingBox(Transform xform)
        {
            throw new NotImplementedException();
        }
        public override IGH_GeometricGoo Morph(SpaceMorph xmorph)
        {
            throw new NotImplementedException();
        }
        public override ClippingBoxEntity Value
        {
            get
            {
                if (IsReferencedGeometry)
                {
                    RhinoObject rhobj = RhinoDoc.ActiveDoc.Objects.FindId(ReferenceID);
                    return (rhobj as ClippingBoxObject).Entity;
                }
                else
                    return m_value;
            }
            set => m_value = value;
        }
        #endregion

        #region IGH_PreviewData
        public override void DrawViewportWires(GH_PreviewWireArgs args)
        {
            new GH_Box(Value.Value).DrawViewportWires(args);
        }
        public override void DrawViewportMeshes(GH_PreviewMeshArgs args)
        {
            new GH_Box(Value.Value).DrawViewportMeshes(args);
        }
        #endregion

        #region IGH_BakeAwareData
        public override bool BakeGeometry(RhinoDoc doc, ObjectAttributes att, out Guid obj_guid)
        {
            if (doc == null || att == null || !(Value is ClippingBoxEntity))
            {
                obj_guid = Guid.Empty;
                return false;
            }
            else
            {
                ClippingBoxObject clippingBox = ClippingBoxObject.CreateFromBox(doc,null,this.Value.Value);
                obj_guid = clippingBox.Id;
                return true;
            }
        }
        #endregion
    }
}