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
  public void Find_ReturnsCorrectItem_Item()
  {
    //Arrange
    string description01 = "Walk the dog";
    string description02 = "Wash the dishes";
    Item newItem1 = new Item(description01);
    Item newItem2 = new Item(description02);

    //Act
    Item result = Item.Find(2);

    //Assert
    Assert.AreEqual(newItem2, result);
  }