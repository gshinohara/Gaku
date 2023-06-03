using Rhino;
using Rhino.Geometry;
using Rhino.DocObjects;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using System;


namespace GrasshopperItems.Type
{
    public abstract class GH_GakuGeometric<T> : GH_GeometricGoo<T>, IGH_GakuType, IGH_PreviewData, IGH_BakeAwareData
    {
        #region GH_GeometricGoo
        public bool IsReferenced => this.ReferenceID != Guid.Empty;
        public override bool IsReferencedGeometry => this.IsReferenced;
        public override Guid ReferenceID { get; set; }
        public abstract override T Value { get; set; }
        public override string TypeDescription => throw new NotImplementedException();
        public override string ToString()
        {
            if (this.Value == null)
                return $"Invalid {this.TypeName}";
            else if (this.IsReferenced)
                return $"Referenced {this.TypeName}";
            else
                return this.TypeName;
        }
        public override IGH_GeometricGoo Transform(Transform xform)
        {
            if (xform == null)
                return null;
            else
            {
                GH_GakuGeometric<T> duplicated = this.DuplicateGeometry() as GH_GakuGeometric<T>;
                (duplicated.Value as GeometryBase).Transform(xform);
                return duplicated;
            }
        }
        #endregion

        #region IGH_PreviewData
        public BoundingBox ClippingBox => this.Boundingbox;
        public abstract void DrawViewportWires(GH_PreviewWireArgs args);
        public abstract void DrawViewportMeshes(GH_PreviewMeshArgs args);
        #endregion

        #region IGH_BakeAwareData
        public virtual bool BakeGeometry(RhinoDoc doc, ObjectAttributes att, out Guid obj_guid)
        {
            if (doc == null || att == null || !(this.Value is GeometryBase))
            {
                obj_guid = Guid.Empty;
                return false;
            }
            else
            {
                obj_guid = doc.Objects.Add(this.Value as GeometryBase, att);
                return true;
            }
        }
        #endregion

        #region casting
        public override bool CastFrom(object source)
        {
            if (source is GH_Guid)
            {
                GH_Guid guid = (GH_Guid)source;
                this.ReferenceID = guid.Value;
                return true;
            }
            else
                return false;
        }
        #endregion
    }
}