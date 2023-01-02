using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Item
  {
    public int ItemId { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    // reference navigation property, holds a reference to a single related entity
    public Category Category { get; set;}
    // collection navigation property holds a list of itemtag objects 
    public List<ItemTag> JoinEntities { get; }

  }
}