using System;
using System.Collections.Generic;
using Rhino;
using Rhino.Geometry;
using Rhino.DocObjects;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;

namespace GrasshopperItems.Param
{
    public abstract class GH_GakuGeometryParam<T> : GH_PersistentGeometryParam<T>, IGH_PreviewObject, IGH_BakeAwareObject
        where T : class, IGH_GeometricGoo
    {
        protected GH_GakuGeometryParam(GH_InstanceDescription nTag) : base(nTag) { }

        #region IGH_PreviewObject
        public bool Hidden { get; set; }
        public bool IsPreviewCapable => true;
        public BoundingBox ClippingBox => Preview_ComputeClippingBox();
        public void DrawViewportMeshes(IGH_PreviewArgs args)
        {
            Preview_DrawMeshes(args);
        }
        public void DrawViewportWires(IGH_PreviewArgs args)
        {
            Preview_DrawWires(args);
        }
        #endregion

        #region IGH_BakeAwareObject
        public bool IsBakeCapable => true;
        public void BakeGeometry(RhinoDoc doc, ObjectAttributes att, List<Guid> obj_ids)
        {
            if (att == null)
                att = doc.CreateDefaultAttributes();
            foreach (IGH_BakeAwareData value in m_data)
            {
                value.BakeGeometry(doc, att, out Guid id);
                obj_ids.Add(id);
            }
        }
        public void BakeGeometry(RhinoDoc doc, List<Guid> obj_ids)
        {
            BakeGeometry(doc, null, obj_ids);
        }
        #endregion
    }
}