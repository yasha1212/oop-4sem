using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdLaboratory
{
    public class StorageService
    {
        private static Dictionary<string, Clothes> clothes;
        private static event Action UpdateUI;

        public StorageService()
        {
            clothes = new Dictionary<string, Clothes>();
        }

        public static Clothes GetItem(string name)
        {
            return clothes[name];
        }

        public void SetUpdateHandler(Action updateHandler)
        {
            UpdateUI += updateHandler;
        }

        public static void AddItem(Clothes item)
        {
            if(clothes.ContainsKey(item.Name))
            {
                clothes.Remove(item.Name);
                clothes.Add(item.Name, item);
            }
            else
            {
                clothes.Add(item.Name, item);
            }
            UpdateUI?.Invoke();
        }

        public static void DeleteItem(string name)
        {
            clothes.Remove(name);
            UpdateUI?.Invoke();
        }

        public static List<Clothes> GetList()
        {
            var clothesList = new List<Clothes>();
            foreach(Clothes item in clothes.Values)
            {
                clothesList.Add(item);
            }
            return clothesList;
        }

        public static void ClearStorage()
        {
            clothes.Clear();
        }
    }
}
