using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using inventory_all_the_things;
using inventory_all_the_things.Models;
using System.Collections.Generic;

namespace inventory_all_the_things.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ShopItemsController : ControllerBase
  {
    private DatabaseContext context;
    public ShopItemsController(DatabaseContext _context)
    {
      this.context = _context;
    }

    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<ShopItems>> GetAllItems()
    {
      var items = context.Item.OrderByDescending(item => item.SKU);
      return items.ToList();
    }

    [HttpPost]
    public ActionResult<ShopItems> CreateEntry([FromBody]ShopItems entry)
    {
      context.Item.Add(entry);
      context.SaveChanges();
      return entry;
    }

    [HttpGet("{id}")]
    public ActionResult getOneItem(int id)
    {
      var items = context.Item.FirstOrDefault(i = i.Id == id);
      if (items == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(items);
      }
    }
  }
}

