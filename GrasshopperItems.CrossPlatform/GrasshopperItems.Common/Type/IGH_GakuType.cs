using System;

namespace GrasshopperItems.Type
{
    public interface IGH_GakuType
    {
        Guid ReferenceID { get; set; }
        bool IsReferenced { get; }
    }
}
