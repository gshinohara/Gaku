using System;
using System.Collections.Generic;
using Grasshopper.Kernel;
using GrasshopperItems.Type;

namespace GrasshopperItems.Param
{
    public class Param_GakuRhinoObject : GH_GakuGeometryParam<GH_GakuRhinoObject>
    {
        public Param_GakuRhinoObject() : base(new GH_InstanceDescription("Attributed Object", "AttObj", "", Setting.Category, Setting.SubCat_Param)) { }
        public override Guid ComponentGuid => new Guid("32B2E13B-41D1-4F19-BC54-7903313A7516");
        protected override GH_GetterResult Prompt_Singular(ref GH_GakuRhinoObject value)
        {
            throw new NotImplementedException();
        }
        protected override GH_GetterResult Prompt_Plural(ref List<GH_GakuRhinoObject> values)
        {
            throw new NotImplementedException();
        }
    }
}