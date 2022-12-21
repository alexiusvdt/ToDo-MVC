using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Category
  {
    public string Name { get; set; }
    public int CategoryId { get; set; }
    // collection navigation property: ref to related entity
    public List<Item> Items { get; set; }   
  }
}