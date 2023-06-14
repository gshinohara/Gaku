using System;
using System.Collections.Generic;
using Grasshopper.Kernel;
using GrasshopperItems.Type;

namespace GrasshopperItems.Param
{
    public class Param_GakuClippingBox : GH_GakuGeometryParam<GH_GakuClippingBox>
    {
        public Param_GakuClippingBox() : base(new GH_InstanceDescription("Clipping Box", "ClipBox", "", Setting.Category, Setting.SubCat_Param2)) { }
        public override Guid ComponentGuid => new Guid("5C69D813-86CB-472D-B2CF-66336E5FAFAA");
        protected override GH_GetterResult Prompt_Singular(ref GH_GakuClippingBox value)
        {
            throw new NotImplementedException();
        }
        protected override GH_GetterResult Prompt_Plural(ref List<GH_GakuClippingBox> values)
        {
            throw new NotImplementedException();
        }
    }
}
