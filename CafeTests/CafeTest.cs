using System;
using System.Collections.Generic;
using CafeLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CafeTests
{
    [TestClass]
    public class CafeRepoTests
    {
        [TestMethod]
        public void AddContentToDirectory_ShouldGetCorrectBool()
        {
            Menu content = new Menu();
            MenuRepository repo = new MenuRepository();
            bool addResult = repo.AddContentToDirectory(content);
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetDirectory_ShouldReturnCorrectList()
        {
            Menu testContent = new Menu();
            MenuRepository repo = new MenuRepository();
            repo.AddContentToDirectory(testContent);
            List<Menu> testList = repo.GetContent();
            bool directoryHasContent = testList.Contains(testContent);
            Assert.IsTrue(directoryHasContent);
        }
        private MenuRepository _repo;
        private Menu _menu;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuRepository();
            _menu = new Menu(1, "CheeseBurger", "Meat patty in a bun with cheese.", ingredientListTest, true, true, 6.50m);
            _repo.AddContentToDirectory(_menu);
        }
        private readonly List<string> ingredientListTest = new List<string>()
        {
            "Meat Patty", "Bun", "Cheese"
        };
        [TestMethod]
        public void GetByMealNumber_ShouldReturnCorrectTitle()
        {
            Menu searchResult = _repo.GetContentByMenuNumber(1);
            Assert.AreEqual(_menu, searchResult);
        }
        [TestMethod]
        public void DeleteMenuItem_ShouldReturnTrue()
        {
            Menu toBeDeleted = _repo.GetContentByMenuNumber(1);
            bool removeResult = _repo.DeleteExistingContent(toBeDeleted);
            Assert.IsTrue(removeResult);
        }
    }
}