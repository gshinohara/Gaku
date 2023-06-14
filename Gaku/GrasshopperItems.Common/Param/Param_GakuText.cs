using System;
using System.Collections.Generic;
using Grasshopper.Kernel;
using GrasshopperItems.Type;

namespace GrasshopperItems.Param
{
    public class Param_GakuText : GH_GakuGeometryParam<GH_GakuText>
    {
        public Param_GakuText() : base(new GH_InstanceDescription("Text", "Text", "", Setting.Category, Setting.SubCat_Param)) { }
        public override Guid ComponentGuid => new Guid("17A5C0F6-8232-4182-952C-86622E1EDB5F");
        protected override GH_GetterResult Prompt_Singular(ref GH_GakuText value)
        {
            throw new NotImplementedException();
        }
        protected override GH_GetterResult Prompt_Plural(ref List<GH_GakuText> values)
        {
            throw new NotImplementedException();
        }
    }
}
