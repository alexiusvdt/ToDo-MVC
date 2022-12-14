using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;

namespace ToDoList.Controllers
{
  public class ItemsController : Controller
  {
    [HttpGet("/categories/{categoryId}/items/new")]
    public ActionResult New(int categoryId)
    {
      Category category = Category.Find(categoryId);
      return View(category);
    }    
  
  
    [HttpGet("/categories/{categoryId}/items/{itemId}")]
    public ActionResult Show(int categoryId, int itemId)
    {
      Item item = Item.Find(itemId);
      Category category = Category.Find(categoryId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("item", item);
      model.Add("category", category);
      return View(model);
    }
  }

    // removed as Items all belong to Category objects now
    // impossible to just create an item
    // [HttpGet("/items")]
    // public ActionResult Index()
    // {
    //   List<Item> allItems = Item.GetAll();
    //   return View(allItems);
    // }
    // [HttpPost("/items/delete")]
    // public ActionResult DeleteAll()
    // {
    //   Item.ClearAll();
    //   return View();
    // }
    // [HttpGet("/items/new")]
    // public ActionResult New()
    // {
    //   return View();
    // }    

  //this is the old, original Show() method before 
  // we housed Items in Categories
  //  [HttpGet("/items/{id}")]
  //   public ActionResult Show(int id)
  //   {
  //     Item foundItem = Item.Find(id);
  //     return View(foundItem);
  //   }    

}