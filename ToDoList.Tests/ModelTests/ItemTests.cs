using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Models;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Configuration;

namespace ToDoList.Tests
{

  [TestClass]
  //idisposable extends itemtest class and provides the interface for clearing between tests
  public class ItemTests : IDisposable
  {
    public IConfiguration Configuration { get; set; }

    public void Dispose()
    {
      Item.ClearAll();
    }

    public ItemTests()
    {
      IConfigurationBuilder builder = new ConfigurationBuilder()
          .AddJsonFile("appsettings.json");
      Configuration = builder.Build();
      DBConfiguration.ConnectionString = Configuration["ConnectionStrings:TestConnection"];
    }

    [TestMethod]
    public void ItemConstructor_CreatesInstanceOfItem_Item()
    {
      Item newItem = new Item("test");
      Assert.AreEqual(typeof(Item), newItem.GetType());
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      //Arrange
      string description = "Walk the dog.";
      Item newItem = new Item(description);

      //Act
      string result = newItem.Description;

      //Assert
      Assert.AreEqual(description, result);
    }
    [TestMethod]
    public void SetDescription_SetDescription_String()
    {
      //Arrange
      string description = "Walk the dog.";
      Item newItem = new Item(description);

      //Act
      string updatedDescription = "Do the dishes";
      newItem.Description = updatedDescription;
      string result = newItem.Description;

      //Assert
      Assert.AreEqual(updatedDescription, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyListFromDatabase_ItemList()
    {
      List<Item> newList = new List<Item> {};
      List<Item> result = Item.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsItems_ItemList()
    {
      //Arrange
      string description01 = "Walk the dog";
      string description02 = "Wash the dishes";
      Item newItem1 = new Item(description01);
      newItem1.Save();
      Item newItem2 = new Item(description02);
      newItem2.Save();
      List<Item> newList = new List<Item> { newItem1, newItem2 };

      //Act
      List<Item> result = Item.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
      public void GetId_ItemsInstantiateWithAnIdAndGetterReturns_Int()
      {
        //Arrange
        string description = "Walk the dog.";
        Item newItem = new Item(description);

        //Act
        int result = newItem.Id;

        //Assert
        Assert.AreEqual(1, result);
      }

      [TestMethod]
      public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Item()
      {
        Item firstItem = new Item("Mow the lawn");
        Item copyOfFirstItem = firstItem;
        copyOfFirstItem.Description = "Learn about C#";
        Assert.AreEqual(firstItem.Description, copyOfFirstItem.Description);
      }      

      [TestMethod]
      public void Save_SavesToDatabase_ItemList()
      {
        //Arrange
        Item testItem = new Item("Mow the lawn");

        //Act
        testItem.Save();
        List<Item> result = Item.GetAll();
        List<Item> testList = new List<Item>{testItem};

        //Assert
        CollectionAssert.AreEqual(testList, result);
      }      

      [TestMethod]
          public void Find_ReturnsCorrectItemFromDatabase_Item()
          {
            //Arrange
            Item newItem = new Item("Mow the lawn");
            newItem.Save();
            Item newItem2 = new Item("Wash dishes");
            newItem2.Save();

            //Act
            Item foundItem = Item.Find(newItem.Id);
            //Assert
            Assert.AreEqual(newItem, foundItem);
          }
    }
}

