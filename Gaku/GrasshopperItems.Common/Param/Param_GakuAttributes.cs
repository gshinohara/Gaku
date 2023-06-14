using System;
using System.Collections.Generic;
using Grasshopper.Kernel;
using GrasshopperItems.Type;

namespace GrasshopperItems.Param
{
    public class Param_GakuAttributes : GH_GakuParam<GH_GakuLayer>
    {
        public Param_GakuAttributes()
         : base(new GH_InstanceDescription("Attributes", "Att", "", Setting.Category, Setting.SubCat_Param)) { }
        public override Guid ComponentGuid => new Guid("07CBC81E-5ECE-4735-8216-2279A1947496");
        protected override GH_GetterResult Prompt_Singular(ref GH_GakuLayer value)
        {
            throw new NotImplementedException();
        }
        protected override GH_GetterResult Prompt_Plural(ref List<GH_GakuLayer> values)
        {
            throw new NotImplementedException();
        }
    }
}
