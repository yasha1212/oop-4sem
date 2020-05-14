using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThirdLaboratory
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        readonly string DATA_PLUGINS_PATH = Path.Combine(Directory.GetCurrentDirectory(), "DataPlugins");

        readonly string FUNCTIONAL_PLUGINS_PATH = Path.Combine(Directory.GetCurrentDirectory(), "FunctionalPlugins");

        readonly string SERIALIZE_PLUGINS_PATH = Path.Combine(Directory.GetCurrentDirectory(), "SerializePlugins");

        Action action;

        Dictionary<string, Func<Form>> dFormConstructors;

        Dictionary<Type, Func<string, Form>> dEditFormConstructors;

        List<IDataPlugin> dataPlugins;

        List<IFunctionalPlugin> functionalPlugins;

        List<ISerializePlugin> serializePlugins;

        IFunctionalPlugin currentFuncPlugin = null;

        ISerializePlugin currentSerializePlugin = null;

        public MainForm()
        {
            var pluginsLoader = new PluginsLoader<IDataPlugin>(DATA_PLUGINS_PATH);
            dataPlugins = pluginsLoader.Load();

            var functionalPluginsLoader = new PluginsLoader<IFunctionalPlugin>(FUNCTIONAL_PLUGINS_PATH);
            functionalPlugins = functionalPluginsLoader.Load();

            var serializePluginsLoader = new PluginsLoader<ISerializePlugin>(SERIALIZE_PLUGINS_PATH);
            serializePlugins = serializePluginsLoader.Load();

            InitializeComponent();
            InitializeFormData();

            var storage = new StorageService();
            action = UpdateList;
            storage.SetUpdateHandler(action);
        }

        private void UpdateList()
        {
            lbClothes.Items.Clear();
            foreach(Clothes item in StorageService.GetList())
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
            cbFuncPlugins.Items.Add("None");
            cbFuncPlugins.SelectedItem = "None";
            cbSerializePlugins.Items.Add("None");
            cbSerializePlugins.SelectedItem = "None";

            dFormConstructors = new Dictionary<string, Func<Form>>();
            dFormConstructors.Add("Dress", () => { return new DressForm(); });
            dFormConstructors.Add("Belt", () => { return new BeltForm(); });
            dFormConstructors.Add("Trousers", () => { return new TrousersForm(); });
            dFormConstructors.Add("Shirt", () => { return new ShirtForm(); });
            dFormConstructors.Add("Socks", () => { return new SocksForm(); });
            dFormConstructors.Add("Outwear", () => { return new OutwearForm(); });

            dEditFormConstructors = new Dictionary<Type, Func<string, Form>>();
            dEditFormConstructors.Add(typeof(Dress), (string name) => { return new DressForm(name); });
            dEditFormConstructors.Add(typeof(Belt), (string name) => { return new BeltForm(name); });
            dEditFormConstructors.Add(typeof(Trousers), (string name) => { return new TrousersForm(name); });
            dEditFormConstructors.Add(typeof(Shirt), (string name) => { return new ShirtForm(name); });
            dEditFormConstructors.Add(typeof(Socks), (string name) => { return new SocksForm(name); });
            dEditFormConstructors.Add(typeof(Outwear), (string name) => { return new OutwearForm(name); });

            foreach(var plugin in dataPlugins)
            {
                plugin.Activate(ref dFormConstructors, ref dEditFormConstructors, ref cbTypes);
            }
            foreach(var plugin in functionalPlugins)
            {
                cbFuncPlugins.Items.Add(plugin);
            }
            foreach(var plugin in serializePlugins)
            {
                cbSerializePlugins.Items.Add(plugin);
            }
        }

        private void bSerialize_Click(object sender, EventArgs e)
        {
            if (currentSerializePlugin != null)
            {
                saveFileDialog.ShowDialog();
                string path = saveFileDialog.FileName;
                if ("" != path)
                {
                    using (var file = new FileStream(path, FileMode.Create))
                    {
                        var byteArr = currentSerializePlugin.Serialize(StorageService.GetList());
                        if (currentFuncPlugin != null)
                        {
                            byteArr = currentFuncPlugin.ProcessOutput(byteArr, path);
                        }
                        file.Write(byteArr, 0, byteArr.Length);
                    }
                }
            }
        }

        private void bDeserialize_Click(object sender, EventArgs e)
        {
            if (currentSerializePlugin != null)
            {
                openFileDialog.ShowDialog();
                string path = openFileDialog.FileName;
                if ("" != path)
                {
                    using (var file = new FileStream(path, FileMode.Open))
                    {
                        var tempStream = new MemoryStream();
                        file.CopyTo(tempStream);
                        var byteArr = tempStream.ToArray();
                        if (currentFuncPlugin != null)
                        {
                            byteArr = currentFuncPlugin.ProcessInput(byteArr, path);
                        }
                        var objList = currentSerializePlugin.Deserialize(byteArr);
                        StorageService.ClearStorage();
                        foreach (var item in objList)
                        {
                            StorageService.AddItem(item);
                        }
                    }
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
                StorageService.DeleteItem(lbClothes.SelectedItem.ToString());
            }
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            if(lbClothes.SelectedIndex != -1)
            {
                string itemName = lbClothes.SelectedItem.ToString();
                var item = StorageService.GetItem(itemName);
                Func<string, Form> function = dEditFormConstructors[item.GetType()];
                Form form = function(itemName);
                form.ShowDialog();
            }
        }

        private void bChooseSerializer_Click(object sender, EventArgs e)
        {
            if (cbSerializePlugins.SelectedIndex != -1)
            {
                if (cbSerializePlugins.SelectedItem as string == "None")
                {
                    currentSerializePlugin = null;
                }
                else
                {
                    currentSerializePlugin = cbSerializePlugins.SelectedItem as ISerializePlugin;
                }
            }
        }

        private void bChooseFunc_Click(object sender, EventArgs e)
        {
            if (cbFuncPlugins.SelectedIndex != -1)
            {
                if (cbFuncPlugins.SelectedItem as string == "None")
                {
                    currentFuncPlugin = null;
                }
                else
                {
                    currentFuncPlugin = cbFuncPlugins.SelectedItem as IFunctionalPlugin;
                }
            }
        }
    }
}
