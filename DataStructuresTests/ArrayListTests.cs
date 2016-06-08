using DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTests
{
    [TestClass]
    public class ArrayListTests
    {
        private ArrayList<int> list;

        [TestInitialize]
        public void Startup()
        {
            list = new ArrayList<int>();
        }


        [TestMethod]
        public void CreateAList_AssertCountZero_AddOneItem_AssertCountOne()
        {
            Assert.AreEqual(0, list.Count);

            list.Add(1);
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public void CreateAList_Insert5Items_AssertCountFive()
        {
            for (int i = 0; i < 5; i++)
            {
                list.Add(i);
            }
            Assert.AreEqual(5, list.Count);
        }

        [TestMethod]
        public void CreateAList_Insert5Items_AssertListContains0_AssertListDoesNotContain10()
        {
            for (int i = 0; i < 5; i++)
            {
                list.Add(i);
            }

            Assert.IsTrue(list.Contains(0));
            Assert.IsFalse(list.Contains(10));
        }

        [TestMethod]
        public void CreateAList_Insert5Items_RemoveItem1_AssertListDoesNotContain1()
        {
            for (int i = 0; i < 5; i++)
            {
                list.Add(i);
            }

            list.Remove(1);
            Assert.IsFalse(list.Contains(1));
            Assert.AreEqual(4, list.Count);
        }

        [TestCleanup]
        public void Cleanup()
        {
            list = null;
        }
    }
}
