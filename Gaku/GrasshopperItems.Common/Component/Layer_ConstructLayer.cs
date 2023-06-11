using System;
using System.Drawing;
using Rhino.DocObjects;
using Grasshopper.Kernel;
using GrasshopperItems.Param;
using GrasshopperItems.Type;

namespace GrasshopperItems.Component
{
    public class Layer_ConstructLayer : GH_Component
    {
        public Layer_ConstructLayer()
          : base("Construct Layer", "ConL",
              "",
              Setting.Category, Setting.SubCat_Layer)
        {
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Name", "N", "", GH_ParamAccess.item);
            pManager.AddColourParameter("Color", "C", "", GH_ParamAccess.item);
        }
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new Param_GakuLayer(), "Layer", "L", "", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string name = default;
            Color color = default;
            DA.GetData("Name", ref name);
            DA.GetData("Color", ref color);

            GH_GakuLayer layer = new GH_GakuLayer();
            layer.Value = new Layer
            {
                Name = name,
                Color = color,
            };

            DA.SetData("Layer", layer);
        }
        protected override Bitmap Icon => null;
        public override Guid ComponentGuid => new Guid("7925E0C2-0CC4-4B55-BE8F-D2C7CF418CF5");
    }
}