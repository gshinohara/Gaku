using System;
using Rhino;
using Rhino.Geometry;
using Rhino.DocObjects;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;

namespace GrasshopperItems.Type
{
    public class GH_GakuText : GH_GakuGeometric<TextEntity>
    {
        public GH_GakuText() { }
        public GH_GakuText(TextEntity textEntity)
        {
            Value = textEntity;
        }
        public GH_GakuText(Guid id)
        {
            ReferenceID = id;
        }

        #region GH_Gooの継承
        public override BoundingBox Boundingbox => Value.GetBoundingBox(true);
        public override string TypeName => "Text";
        public override IGH_GeometricGoo DuplicateGeometry()
        {
            return new GH_GakuText(Value);
        }
        public override BoundingBox GetBoundingBox(Transform xform)
        {
            throw new NotImplementedException();
        }
        public override IGH_GeometricGoo Morph(SpaceMorph xmorph)
        {
            throw new NotImplementedException();
        }
        public override TextEntity Value
        {
            get
            {
                if (IsReferencedGeometry)
                {
                    RhinoObject rhobj = RhinoDoc.ActiveDoc.Objects.FindId(ReferenceID);
                    return (rhobj as TextObject).TextGeometry;
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
            args.Pipeline.Draw3dText(
                Value.PlainText,
                args.Color,
                Value.Plane,
                Value.TextHeight * Value.DimensionScale,
                Value.Font.FaceName,
                Value.Font.Bold,
                Value.Font.Italic,
                Value.TextHorizontalAlignment,
                Value.TextVerticalAlignment
                );
        }
        public override void DrawViewportMeshes(GH_PreviewMeshArgs args)
        {
        }
        #endregion

        #region IGH_BakeAwareData
        public override bool BakeGeometry(RhinoDoc doc, ObjectAttributes att, out Guid obj_guid)
        {
            if (doc == null || att == null || !(Value is GeometryBase))
            {
                obj_guid = Guid.Empty;
                return false;
            }
            else
            {
                obj_guid = doc.Objects.AddText(Value);
                return true;
            }
        }
        #endregion
    }
}