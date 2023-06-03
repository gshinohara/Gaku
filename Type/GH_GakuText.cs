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
            this.Value = textEntity;
        }
        public GH_GakuText(Guid id)
        {
            this.ReferenceID = id;
        }

        #region GH_Gooの継承
        public override BoundingBox Boundingbox => this.Value.GetBoundingBox(true);
        public override string TypeName => "Text";
        public override IGH_GeometricGoo DuplicateGeometry()
        {
            return new GH_GakuText(this.Value);
        }
        public override BoundingBox GetBoundingBox(Transform xform)
        {
            throw new System.NotImplementedException();
        }
        public override IGH_GeometricGoo Morph(SpaceMorph xmorph)
        {
            throw new System.NotImplementedException();
        }
        public override TextEntity Value
        {
            get
            {
                if (this.IsReferencedGeometry)
                {
                    RhinoObject rhobj = RhinoDoc.ActiveDoc.Objects.FindId(this.ReferenceID);
                    return (rhobj as TextObject).TextGeometry;
                }
                else
                    return this.m_value;
            }
            set => this.m_value = value;
        }
        #endregion

        #region IGH_PreviewData
        public override void DrawViewportWires(GH_PreviewWireArgs args)
        {
            args.Pipeline.Draw3dText(
                this.Value.PlainText,
                args.Color,
                this.Value.Plane,
                this.Value.TextHeight * this.Value.DimensionScale,
                this.Value.Font.FaceName,
                this.Value.Font.Bold,
                this.Value.Font.Italic,
                this.Value.TextHorizontalAlignment,
                this.Value.TextVerticalAlignment
                );
        }
        public override void DrawViewportMeshes(GH_PreviewMeshArgs args)
        {
        }
        #endregion

        #region IGH_BakeAwareData
        public override bool BakeGeometry(RhinoDoc doc, ObjectAttributes att, out Guid obj_guid)
        {
            if (doc == null || att == null || !(this.Value is GeometryBase))
            {
                obj_guid = Guid.Empty;
                return false;
            }
            else
            {
                obj_guid = doc.Objects.AddText(this.Value);
                return true;
            }
        }
        #endregion
    }
}