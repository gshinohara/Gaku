using Rhino.Display;
using Rhino.DocObjects.Tables;

namespace GrasshopperItems.Eto
{
    internal class ViewSelector : GeneralSelector<RhinoView>
    {
        public ViewSelector(ViewTable views) : base(views) { }
        protected override string GetTextString(RhinoView view)
        {
            return view.ActiveViewport.Name;
        }
    }
}
