using System;
using System.Collections.Generic;
using Grasshopper.Kernel;
using GrasshopperItems.Type;

namespace GrasshopperItems.Param
{
    public class Param_GakuClippingPlane: GH_GakuGeometryParam<GH_GakuClippingPlane>
    {
        public Param_GakuClippingPlane() : base(new GH_InstanceDescription("Clipping Plane", "ClipPln", "", Setting.Category, Setting.SubCat_Param)) { }
        public override Guid ComponentGuid => new Guid("59863529-F4F7-44A2-BC87-91065F48F32C");
        protected override GH_GetterResult Prompt_Singular(ref GH_GakuClippingPlane value)
        {
            throw new NotImplementedException();
        }
        protected override GH_GetterResult Prompt_Plural(ref List<GH_GakuClippingPlane> values)
        {
            throw new NotImplementedException();
        }
    }
}
