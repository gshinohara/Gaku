using Grasshopper;
using Grasshopper.Kernel;
using System;
using System.Drawing;

namespace GrasshopperItems
{
    public class GrasshopperItemsInfo : GH_AssemblyInfo
    {
        public override string Name => "Gaku";

        //Return a 24x24 pixel bitmap to represent this GHA library.
        public override Bitmap Icon => null;

        //Return a short string describing the purpose of this GHA library.
        public override string Description => "";

        public override Guid Id => new Guid("D2B9D644-DB4B-4BF8-894C-EDEE72961908");

        //Return a string identifying you or your company.
        public override string AuthorName => "SHINOHARA, Gaku";

        //Return a string representing your preferred contact details.
        public override string AuthorContact => "https://twitter.com/gakushinohara";
    }
}