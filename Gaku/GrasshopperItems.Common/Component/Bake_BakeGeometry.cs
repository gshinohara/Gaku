using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace GrasshopperItems.Component
{
    public class Bake_BakeGeometry : GH_Component
    {
        public Bake_BakeGeometry()
          : base("Bake Geometry", "Bake",
              "",
              Setting.Category, Setting.SubCat_Document)
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
        }
        protected override System.Drawing.Bitmap Icon => null;
        public override Guid ComponentGuid => new Guid("1E8A9125-6594-413D-9E1E-5DCB01ECC4D1");
    }
}