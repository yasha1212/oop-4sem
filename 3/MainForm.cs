using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThirdLaboratory
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        Action action;
        Dictionary<string, Func<Form>> dFormConstructors;
        Dictionary<Type, Func<string, Form>> dEditFormConstructors;

        public MainForm()
        {
            InitializeComponent();
            InitializeFormData();
            var storage = new Storage();
            action = UpdateList;
            storage.SetUpdateHandler(action);
        }

        private void UpdateList()
        {
            lbClothes.Items.Clear();
            foreach(Clothes item in Storage.GetList())
            {
                lbClothes.Items.Add(item.Name);
            }
        }

        private void InitializeFormData()
        {
            cbTypes.Items.Add("Dress");
            cbTypes.Items.Add("Belt");
            cbTypes.Items.Add("Trousers");
            cbTypes.Items.Add("Shirt");
            cbTypes.Items.Add("Socks");
            cbTypes.Items.Add("Outwear");

            dFormConstructors = new Dictionary<string, Func<Form>>();
            dFormConstructors.Add("Dress", () => { return new DressForm(); });
            dFormConstructors.Add("Belt", () => { return new BeltForm(); });
            dFormConstructors.Add("Trousers", () => { return new TrousersForm(); });
            dFormConstructors.Add("Shirt", () => { return new ShirtForm(); });
            dFormConstructors.Add("Socks", () => { return new SocksForm(); });
            dFormConstructors.Add("Outwear", () => { return new OutwearForm(); });

            dEditFormConstructors = new Dictionary<Type, Func<string, Form>>();
            //dEditFormConstructors.Add(typeof(Dress), (string name) => { return new DressForm(name); });
            dEditFormConstructors.Add(typeof(Belt), (string name) => { return new BeltForm(name); });
            //dEditFormConstructors.Add(typeof(Trousers), (string name) => { return new TrousersForm(name); });
            //dEditFormConstructors.Add(typeof(Shirt), (string name) => { return new ShirtForm(name); });
            //dEditFormConstructors.Add(typeof(Socks), (string name) => { return new SocksForm(name); });
            //dEditFormConstructors.Add(typeof(Outwear), (string name) => { return new OutwearForm(name); });
        }

        private void bSerialize_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
            string path = saveFileDialog.FileName;
            if("" != path)
            {
                Serializer.Serialize(path, Storage.GetList());
            }
        }

        private void bDeserialize_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            string path = openFileDialog.FileName;
            if("" != path)
            {
                var decerializedList = Serializer.Deserialize(path);
                Storage.ClearStorage();
                foreach(Clothes item in decerializedList)
                {
                    Storage.AddItem(item);
                }
            }
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            if(cbTypes.SelectedIndex != -1)
            {
                string type = cbTypes.SelectedItem.ToString();
                Func<Form> function = dFormConstructors[type];
                Form form = function();
                form.ShowDialog();
            }
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if(lbClothes.SelectedIndex != -1)
            {
                Storage.DeleteItem(lbClothes.SelectedItem.ToString());
            }
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            if(lbClothes.SelectedIndex != -1)
            {
                string itemName = lbClothes.SelectedItem.ToString();
                var item = Storage.GetItem(itemName);
                Func<string, Form> function = dEditFormConstructors[item.GetType()];
                Form form = function(itemName);
                form.ShowDialog();
            }
        }
    }
}
