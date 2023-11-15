using Microsoft.AspNetCore.Mvc;
using BAIST3150EmptyWebApi.Models;
using BAIST3150EmptyWebApi.TechnicalServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BAIST3150EmptyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        // GET: api/<ItemsController>
        [HttpGet]
        public List<Item> Get()
        {
            Items ItemManager = new Items();

            List<Item> ItemList = ItemManager.GetItems();
            return ItemList;
        }

        // GET api/<ItemsController>/5
        [HttpGet("{id}")]
        public Item Get(int ItemNumber)
        {

            Items ItemManger = new Items();
            Item Item = ItemManger.GetItem(ItemNumber);
            return Item;
        }

        // POST api/<ItemsController>
        [HttpPost]
        public void Post([FromBody] Item exampleItem)
        {
            Items ItemManager = new Items();
            ItemManager.AddItem(exampleItem);
        }

        // PUT api/<ItemsController>/5
        [HttpPut("{id}")]
        public void Put(int itemNumber, [FromBody] Item exampleItem)
        {
            Items ItemManager = new Items();
            ItemManager.UpdateItem(itemNumber,exampleItem);
        }

        // DELETE api/<ItemsController>/5
        [HttpDelete("{id}")]
        public void Delete(int itemNumber)
        {
            Items ItemManager = new Items();
            ItemManager.DeleteItem(itemNumber);
        }
    }
}
