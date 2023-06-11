using System;
using System.Drawing;
using Grasshopper.Kernel;
using GrasshopperItems.Param;
using GrasshopperItems.Type;

namespace GrasshopperItems.Component
{
    public class Layer_DeconstructLayer : GH_Component
    {
        public Layer_DeconstructLayer()
          : base("Deconstruct Layer", "DeconL",
              "",
              Setting.Category, Setting.SubCat_Layer)
        {
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddParameter(new Param_GakuLayer(), "Layer", "L", "", GH_ParamAccess.item);
        }
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Name", "N", "", GH_ParamAccess.item);
            pManager.AddColourParameter("Color", "C", "", GH_ParamAccess.item);
        }
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            GH_GakuLayer layer = default;
            DA.GetData("Layer", ref layer);

            string name = layer.Value.Name;
            Color color = layer.Value.Color;

            DA.SetData("Name", name);
            DA.SetData("Color", color);
        }
        protected override Bitmap Icon => null;
        public override Guid ComponentGuid => new Guid("AB5FCC70-FD2A-4623-BCBE-6948E3AEF11F");
    }
}