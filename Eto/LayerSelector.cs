using Rhino.DocObjects;
using Rhino.DocObjects.Tables;

namespace GrasshopperItems.Eto
{
    internal class LayerSelector : GeneralSelector<Layer>
    {
        public LayerSelector(LayerTable layers) : base(layers) { }
        protected override string GetTextString(Layer layer)
        {
            return layer.FullPath;
        }
    }
}
