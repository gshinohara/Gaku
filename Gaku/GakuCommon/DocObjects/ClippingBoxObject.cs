using System;
using System.Drawing;
using System.Linq;
using Rhino;
using Rhino.ApplicationSettings;
using Rhino.DocObjects;
using Rhino.DocObjects.Custom;
using Rhino.Display;
using Rhino.Geometry;
using GakuCommon.Geometry;

namespace GakuCommon.DocObjects
{
    public class ClippingBoxObject : CustomBrepObject
    {
        public ClippingBoxObject() : base() { }
        public ClippingBoxObject(ClippingBoxEntity clippingBox) : base(clippingBox.Value.ToBrep())
        {
            Entity = clippingBox;
        }
        public ClippingBoxEntity Entity { get; }
        public static ClippingBoxObject CreateFromBox(RhinoDoc doc,ObjectAttributes att, Box box)
        {
            ClippingBoxEntity entity = new ClippingBoxEntity(box);
            entity.Views.Append(doc.Views.ActiveView);
            ClippingBoxObject @object = new ClippingBoxObject(entity);
            doc.Objects.AddRhinoObject(@object);
            @object.Attributes = att;
            return @object;
        }
        public override string ShortDescription(bool plural)
        {
            return plural ? "Clipping Boxes" : "Clipping Box";
        }
        protected override void OnDraw(DrawEventArgs e)
        {
            Action<BrepFace, Color> faceOperator = (BrepFace face, Color color) =>
            {
                Point3d centroid = AreaMassProperties.Compute(face).Centroid;
                face.ClosestPoint(centroid, out double u, out double v);
                Vector3d dir = face.NormalAt(u, v);
                if (Entity.IsInside)
                    dir.Reverse();
                e.Display.DrawArrow(new Line(centroid, dir), color);

                e.Display.AddClippingPlane(centroid, dir);
            };

            Color displayColor = IsSelected(false) == 0 ? Attributes.DrawColor(Document) : AppearanceSettings.SelectedObjectColor;

            e.Display.DrawBrepWires(Entity.Value.ToBrep(), displayColor, -1);
            foreach (BrepFace face in Entity.Value.ToBrep().Faces)
                faceOperator(face, displayColor);
        }
    }
}
