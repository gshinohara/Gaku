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
    public class Param_GakuView : GH_GakuParam<GH_GakuView>
    {
        public Param_GakuView()
            : base(new GH_InstanceDescription("View", "View", "", Setting.Category, Setting.SubCat_Param)) { }
        public override Guid ComponentGuid => new Guid("1F7C0CEE-74F9-4EEB-84F0-BA725B7D9508");
        protected override GH_GetterResult Prompt_Singular(ref GH_GakuView value)
        {
            ViewSelector dialog = new ViewSelector(RhinoDoc.ActiveDoc.Views);
            dialog.SetDropDown();
            bool rc = dialog.ShowModal(RhinoEtoApp.MainWindow);
            if (rc)
            {
                value = new GH_GakuView(dialog.GetSelectedGuid());
                return GH_GetterResult.success;
            }
            else
            {
                value = new GH_GakuView();
                return GH_GetterResult.cancel;
            }
        }
        protected override GH_GetterResult Prompt_Plural(ref List<GH_GakuView> values)
        {
            throw new NotImplementedException();
        }
    }
}
