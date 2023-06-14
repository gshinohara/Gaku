using System;
using System.Collections.Generic;
using Eto.Forms;
using Rhino;
using Rhino.UI;
using Grasshopper.Kernel;
using GrasshopperItems.Type;
using GrasshopperItems.Eto;

namespace GrasshopperItems.Param
{
    public class Param_GakuLayer : GH_GakuParam<GH_GakuLayer>
    {
        public Param_GakuLayer()
            : base(new GH_InstanceDescription("Layer", "Layer", "", Setting.Category, Setting.SubCat_Param)) { }
        public override Guid ComponentGuid => new Guid("28237E4B-382F-4EC9-A925-3A63E5C80E1A");
        protected override GH_GetterResult Prompt_Singular(ref GH_GakuLayer value)
        {
            LayerSelector dialog = new LayerSelector(RhinoDoc.ActiveDoc.Layers);
            dialog.SetDropDown();
            bool rc = dialog.ShowModal(RhinoEtoApp.MainWindow);
            if (rc)
            {
                value = new GH_GakuLayer(dialog.GetSelectedGuid());
                return GH_GetterResult.success;
            }
            else
            {
                value = new GH_GakuLayer();
                return GH_GetterResult.cancel;
            }
        }
        protected override GH_GetterResult Prompt_Plural(ref List<GH_GakuLayer> values)
        {
            throw new NotImplementedException();
        }
    }
}
