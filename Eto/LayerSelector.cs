using System;
using Eto.Forms;
using Eto.Drawing;
using Rhino.DocObjects;
using Rhino.DocObjects.Tables;

namespace GrasshopperItems.Eto
{
    internal class LayerSelector : Dialog<bool>
    {
        private readonly DropDown DropDown = new DropDown();
        private LayerTable Layers { get; }
        public LayerSelector(LayerTable layers)
        {
            this.Title = "Layer";
            this.Padding = 10;
            this.Resizable = true;
            this.Content = new DynamicLayout
            {
                Spacing = new Size(5,5),
            };
            this.DefaultButton = new Button { Text = "OK" };
            this.DefaultButton.Click += this.OnOKClick;
            this.AbortButton = new Button { Text = "Cancel" };
            this.AbortButton.Click += this.OnCancelClick;

            this.Layers = layers;

            foreach (Layer layer in layers)
                this.DropDown.Items.Add((ListItem)layer.FullPath);
        }
        public Guid GetLayerGuid()
        {
            int index = this.Layers.FindByFullPath(this.DropDown.SelectedKey,-1);
            if (index == -1)
                return Guid.Empty;
            else
                return this.Layers.FindIndex(index).Id;
        }
        public void AddDropDown()
        {
            (this.Content as DynamicLayout).AddRow(this.DropDown);
            (this.Content as DynamicLayout).AddRow(null);
            (this.Content as DynamicLayout).AddRow(this.DefaultButton, this.AbortButton);
        }
        private void OnOKClick(object sender, EventArgs e)
        {
            this.Close(true);
        }
        private void OnCancelClick(object sender, EventArgs e)
        {
            this.Close(false);
        }
    }
}
