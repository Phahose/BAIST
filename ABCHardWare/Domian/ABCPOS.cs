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
        public Item GetItem(string id)
        {      
            Items items = new Items();
            Item inventoryItem = items.FindItem(id);

            return inventoryItem;
        }
        public bool UpdateItem (Item item)
        {
            bool confirmation = false;
            Items items = new Items();
            items.UpdateItem(item);
            confirmation = true;
            return confirmation;
        }
        public bool DeleteItem(string itemId)
        {
            bool confirmation = false;
            Items items = new Items();
            items.DeleteItem(itemId);
            confirmation = true;
            return confirmation;
        }
        public bool AddCustomer(Customer customer)
        {
            bool confirmation = false;
            Customers customers = new Customers();
            customers.AddCustomer(customer);
            confirmation = true;
            return confirmation;
        }
        public bool UpdateCustomer(Customer customer)
        {
            bool confirmation = false;
            Customers customers = new Customers();
            customers.UpdateCustomer(customer);
            confirmation = true;
            return confirmation;
        }
        public Customer FindCustomer(string firstName, string lastName)
        {
            Customers customers = new Customers();
            Customer existingCustomer = customers.FindCustomer(firstName, lastName);
            return existingCustomer;
        }
        public bool DeleteCustomer(int customerID)
        {
            bool confirmation = false;
            Customers customers = new Customers();
            customers.DeleteCustomer(customerID);
            confirmation = true;
            return confirmation;
        }
    }
}
