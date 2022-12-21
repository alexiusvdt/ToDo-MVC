namespace ToDoList.Models
{
  public class Item
  {
    public int ItemId { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    // reference navigation property, holds a reference to a single related entity
    public Category Category { get; set;}
  }
}