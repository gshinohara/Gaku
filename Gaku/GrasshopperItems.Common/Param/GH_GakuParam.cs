using System;
using System.Collections.Generic;
using Rhino;
using Rhino.Geometry;
using Rhino.DocObjects;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;

namespace GrasshopperItems.Param
{
    public abstract class GH_GakuParam<T> : GH_PersistentParam<T>
        where T : class, IGH_Goo
    {
        protected GH_GakuParam(GH_InstanceDescription nTag) : base(nTag) { }
    }
}
