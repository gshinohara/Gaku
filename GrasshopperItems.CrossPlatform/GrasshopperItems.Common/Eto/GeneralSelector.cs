using System;
using System.Collections.Generic;
using System.Linq;
using Eto.Forms;
using Eto.Drawing;
using Rhino.Display;
using Rhino.DocObjects;
using Rhino.DocObjects.Tables;

namespace GrasshopperItems.Eto
{
    internal class GeneralSelector<T> : Dialog<bool>
        where T : class
    {
        private readonly DropDown DropDown = new DropDown();
        private IEnumerable<T> Table { get; }
        public GeneralSelector(IEnumerable<T> table)
        {
            Title = typeof(T).Name;
            Padding = 10;
            Resizable = true;
            Content = new DynamicLayout
            {
                Spacing = new Size(5, 5),
            };
            DefaultButton = new Button { Text = "OK" };
            DefaultButton.Click += OnOKClick;
            AbortButton = new Button { Text = "Cancel" };
            AbortButton.Click += OnCancelClick;

            Table = table;
        }
        protected virtual string GetTextString(T component)
        {
            return component.ToString();
        }
        private void SetLayout(Control control)
        {
            var buttonCells = new List<Button> { DefaultButton, AbortButton }.Select((b) => new TableCell(b, true));
            (Content as DynamicLayout).AddRow(control);
            (Content as DynamicLayout).AddRow(null);
            (Content as DynamicLayout).AddRow(new TableLayout(new TableRow(buttonCells)));
        }

        #region 外部アクセス
        public Guid GetSelectedGuid()
        {
            T selected = (DropDown.SelectedValue as ListItem).Tag as T;
            if (selected is ModelComponent)
            {
                ModelComponent modelComponent = selected as ModelComponent;
                return modelComponent.Id;
            }
            else if (selected is RhinoView)
            {
                RhinoView view = selected as RhinoView;
                return view.ActiveViewportID;
            }
            else
                return Guid.Empty;
        }
        public void SetDropDown()
        {
            IEnumerator<T> enumerator = Table.GetEnumerator();
            while (enumerator.MoveNext())
            {
                ListItem item = new ListItem
                {
                    Text = GetTextString(enumerator.Current),
                    Tag = enumerator.Current,
                };
                DropDown.Items.Add(item);
            }

            SetLayout(DropDown);
        }
        #endregion

        #region Event
        private void OnOKClick(object sender, EventArgs e)
        {
            Close(true);
        }
        private void OnCancelClick(object sender, EventArgs e)
        {
            Close(false);
        }
        #endregion
    }
}