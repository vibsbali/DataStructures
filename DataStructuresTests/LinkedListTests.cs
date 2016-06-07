using ConcreteStructuresTwo;
using CoreNew;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTests
{
    [TestClass]
    public class LinkedListTests
    {
        private LinkedList<int> list;
        private Node<int> nodeOne;
        private Node<int> nodeTwo;
        private Node<int> nodeThree;
        private Node<int> nodeFour;

        [TestInitialize]
        public void Startup()
        {
            list = new LinkedList<int>();   
            nodeOne = new Node<int>(1);
            nodeTwo = new Node<int>(2);
            nodeThree = new Node<int>(3);
            nodeFour = new Node<int>(4);
        }


        [TestMethod]
        public void CreateAListWithOneNodeAssertHeadEqualTailAndCountIsOne()
        {
            list.AddToFront(nodeOne);

            Assert.AreEqual(list.Head.Value, 1);
            Assert.AreEqual(list.Head.Value, list.Tail.Value);
            Assert.IsTrue(list.Count == 1);
        }

        [TestMethod]
        public void CreateAListWithTwoNodeAssertHeadIsNotEqualTailAndCountIsTwo()
        {
            list.AddToFront(nodeOne);
            list.AddToFront(nodeTwo);

            Assert.AreEqual(list.Head.Value, 2);
            Assert.AreNotEqual(list.Head.Value, list.Tail.Value);
            Assert.IsTrue(list.Count == 2);
        }


        [TestMethod]
        public void CreateAListWithTwoNodeAndInsertNewNodeToHeadAssertHeadIsEqualToNewNode()
        {
            list.AddToFront(nodeOne);
            list.AddToFront(nodeTwo);

            Assert.AreEqual(list.Head.Value, 2);
            Assert.AreEqual(list.Head, nodeTwo);
            Assert.IsTrue(list.Count == 2);
        }


        [TestCleanup]
        public void Cleanup()
        {
            list = null;
            nodeOne = null;
            nodeTwo = null;
            nodeThree = null;
        }
    }
}
