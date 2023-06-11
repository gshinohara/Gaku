using System.Collections.Generic;
using Rhino.Geometry;
using Rhino.Display;

namespace GakuCommon.Geometry
{
    public class ClippingBoxEntity : Entity<Box>
    {
        internal ClippingBoxEntity(Box box) : base(box)
        {
            IsInside = true;
            Views = new List<RhinoView>();
        }
        public bool IsInside { get; set; }
        public IEnumerable<RhinoView> Views { get; }
    }
}
