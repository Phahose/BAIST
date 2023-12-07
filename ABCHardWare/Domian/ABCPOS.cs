using System.Data;
using ABCHardWare.SalesManager;
using ABCHardWare.Domian;
namespace ABCHardWare.Domian
{
    public class ABCPOS
    {
        public int ProcessSale()
        {
            return 1;
        }

        public Item AddNewItem(Item item)
        {       
            Items items = new Items();
            items.AddItem(item);
            return item;
        }
    }
}
