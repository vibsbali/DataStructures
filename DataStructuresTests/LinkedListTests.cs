using ConcreteStructuresTwo;
using CoreNew;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTests
{
    [TestClass]
    public class LinkedListTests
    {
        private LinkedList<int> list;
            
        [TestInitialize]
        public void Startup()
        {
            list = new LinkedList<int>();   
        }


        [TestMethod]
        public void CreateAListWithOneNodeAssertHeadEqualTailAndCountIsOne()
        {
            list.AddToFront(new Node<int>(1));

            Assert.AreEqual(list.Head.Value, 1);
            Assert.AreEqual(list.Head.Value, list.Tail.Value);
            Assert.IsTrue(list.Count == 1);
        }
    }
}
