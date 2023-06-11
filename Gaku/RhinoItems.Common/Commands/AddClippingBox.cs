using System;
using Rhino;
using Rhino.Commands;
using Rhino.Geometry;
using Rhino.Input;
using GakuCommon.DocObjects;

namespace RhinoItems.Commands
{
    public class AddClippingBox : Command
    {
        public AddClippingBox()
        {
            Instance = this;
        }

        ///<summary>The only instance of the MyCommand command.</summary>
        public static AddClippingBox Instance { get; private set; }

        public override string EnglishName => "AddClippingBox";

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            Result result = RhinoGet.GetBox(out Box box);
            if (result == Result.Success)
                ClippingBoxObject.CreateFromBox(doc,null, box);
            return Result.Success;
        }
    }
}