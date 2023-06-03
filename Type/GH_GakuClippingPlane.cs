using System;
using Rhino;
using Rhino.Geometry;
using Rhino.DocObjects;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;

namespace GrasshopperItems.Type
{
    public class GH_GakuClippingPlane : GH_GakuGeometric<ClippingPlaneSurface>
    {
        public GH_GakuClippingPlane() { }
        public GH_GakuClippingPlane(ClippingPlaneSurface clippingPlaneSurface)
        {
            this.Value = clippingPlaneSurface;
        }
        public GH_GakuClippingPlane(Guid id)
        {
            this.ReferenceID = id;
        }

        #region GH_Gooの継承
        public override BoundingBox Boundingbox => this.Value.GetBoundingBox(true);
        public override string TypeName => "ClipPlane";
        public override IGH_GeometricGoo DuplicateGeometry()
        {
            return new GH_GakuClippingPlane(this.Value);
        }
        public override BoundingBox GetBoundingBox(Transform xform)
        {
            throw new System.NotImplementedException();
        }
        public override IGH_GeometricGoo Morph(SpaceMorph xmorph)
        {
            throw new System.NotImplementedException();
        }
        public override ClippingPlaneSurface Value
        {
            get
            {
                if (this.IsReferencedGeometry)
                {
                    RhinoObject rhobj = RhinoDoc.ActiveDoc.Objects.FindId(this.ReferenceID);
                    return (rhobj as ClippingPlaneObject).ClippingPlaneGeometry;
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
            PlaneSurface planeSrf = (this.Value as ClippingPlaneSurface) as PlaneSurface;
            GH_Surface gh_srf = new GH_Surface(planeSrf);
            GH_Rectangle gh_rect = new GH_Rectangle();
            gh_rect.CastFrom(gh_srf);

            gh_rect.DrawViewportWires(args);

            Line[] lines =
            {
                new Line(gh_rect.Value.PointAt(0.5,0),gh_rect.Value.PointAt(0.5,1)),
                new Line(gh_rect.Value.PointAt(0.5,0.5),gh_rect.Value.PointAt(0,0.5)),
                new Line(gh_rect.Value.PointAt(0.5, 0.5), gh_rect.Value.PointAt(0.5, 0.5) + gh_rect.Value.Plane.Normal * gh_rect.Value.Width / 2),
             };
            foreach (Line line in lines)
                new GH_Line(line).DrawViewportWires(args);
        }
        public override void DrawViewportMeshes(GH_PreviewMeshArgs args)
        {
            PlaneSurface planeSrf = (this.Value as ClippingPlaneSurface) as PlaneSurface;
            GH_Surface gh_srf = new GH_Surface(planeSrf);
            gh_srf.DrawViewportMeshes(args);
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
                obj_guid = doc.Objects.AddClippingPlane(this.Value.Plane, this.Value.Domain(0).Length, this.Value.Domain(1).Length, this.Value.ViewportIds(), att);
                return true;
            }
        }
        #endregion
    }
}