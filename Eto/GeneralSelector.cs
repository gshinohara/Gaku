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
            this.Title = typeof(T).Name;
            this.Padding = 10;
            this.Resizable = true;
            this.Content = new DynamicLayout
            {
                Spacing = new Size(5, 5),
            };
            this.DefaultButton = new Button { Text = "OK" };
            this.DefaultButton.Click += this.OnOKClick;
            this.AbortButton = new Button { Text = "Cancel" };
            this.AbortButton.Click += this.OnCancelClick;

            this.Table = table;
        }
        protected virtual string GetTextString(T component)
        {
            return component.ToString();
        }
        private void SetLayout(Control control)
        {
            var buttonCells = new List<Button> { this.DefaultButton, this.AbortButton }.Select((Button b) => new TableCell(b, true));
            (this.Content as DynamicLayout).AddRow(control);
            (this.Content as DynamicLayout).AddRow(null);
            (this.Content as DynamicLayout).AddRow(new TableLayout(new TableRow(buttonCells)));
        }

        #region 外部アクセス
        public Guid GetSelectedGuid()
        {
            T selected = (this.DropDown.SelectedValue as ListItem).Tag as T;
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
            IEnumerator<T> enumerator = this.Table.GetEnumerator();
            while (enumerator.MoveNext())
            {
                ListItem item = new ListItem
                {
                    Text = this.GetTextString(enumerator.Current),
                    Tag = enumerator.Current,
                };
                this.DropDown.Items.Add(item);
            }

            this.SetLayout(this.DropDown);
        }
        #endregion

        #region Event
        private void OnOKClick(object sender, EventArgs e)
        {
            this.Close(true);
        }
        private void OnCancelClick(object sender, EventArgs e)
        {
            this.Close(false);
        }
        #endregion
    }
}