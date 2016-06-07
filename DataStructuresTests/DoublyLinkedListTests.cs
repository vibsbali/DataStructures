using CoreNew;
using DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTests
{
    [TestClass]
    public class DoublyLinkedListTests
    {
        private DoublyLinkedList<int> list;
        private DoublyNode<int> nodeOne;
        private DoublyNode<int> nodeTwo;
        private DoublyNode<int> nodeThree;
        private DoublyNode<int> nodeFour;

        [TestInitialize]
        public void Startup()
        {
            list = new DoublyLinkedList<int>();
            nodeOne = new DoublyNode<int>(1);
            nodeTwo = new DoublyNode<int>(2);
            nodeThree = new DoublyNode<int>(3);
            nodeFour = new DoublyNode<int>(4);
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
            Assert.AreNotEqual(list.Head, list.Tail);
            Assert.IsTrue(list.Count == 2);

            Assert.AreEqual(list.Tail.Previous.Value, 2);
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

        [TestMethod]
        public void CreateAListWithTwoNodeAndInsertNewNodeToEndAssertTailIsEqualToNewNode()
        {
            list.AddToFront(nodeOne);
            list.AddToBack(nodeTwo);

            Assert.AreEqual(list.Head.Value, 1);
            Assert.AreEqual(list.Tail, nodeTwo);
            Assert.AreEqual(list.Tail.Value, 2);
            Assert.IsTrue(list.Count == 2);
        }


        [TestMethod]
        public void CreateAListWithTwoNodeAndRemoveANodeFromFrontAssertHeadEqualTail()
        {
            list.AddToFront(nodeOne);
            list.AddToBack(nodeTwo);

            Assert.AreEqual(list.Head.Value, 1);
            Assert.AreEqual(list.Tail, nodeTwo);
            Assert.AreEqual(list.Tail.Value, 2);
            Assert.IsTrue(list.Count == 2);

            list.RemoveFromFront();
            Assert.AreEqual(list.Head.Value, 2);
            Assert.AreEqual(list.Head, list.Tail);
            Assert.AreEqual(list.Tail.Value, 2);
            Assert.IsTrue(list.Count == 1);


            Assert.IsNull(list.Head.Previous);
        }

        [TestMethod]
        public void CreateAListWithFourNodeAndRemoveANodeFromFrontAssertHeadNotEqualTail()
        {
            list.AddToFront(nodeOne);
            list.AddToBack(nodeTwo);
            list.AddToBack(nodeThree);
            list.AddToBack(nodeFour);

            Assert.AreEqual(list.Head.Value, 1);
            Assert.AreEqual(list.Tail.Value, 4);
            Assert.IsTrue(list.Count == 4);

            list.RemoveFromFront();
            Assert.AreEqual(list.Head.Value, 2);
            Assert.AreNotEqual(list.Head, list.Tail);
            Assert.AreEqual(list.Tail.Value, 4);
            Assert.IsTrue(list.Count == 3);
        }

        [TestMethod]
        public void CreateAListWithTwoNodes_And_Remove_NodeFromBack_AssertHeadEqualTail()
        {
            list.AddToFront(nodeOne);
            list.AddToBack(nodeTwo);

            Assert.AreEqual(list.Head.Value, 1);
            Assert.AreEqual(list.Tail, nodeTwo);
            Assert.AreEqual(list.Tail.Value, 2);
            Assert.IsTrue(list.Count == 2);

            list.RemoveFromBack();
            Assert.AreEqual(list.Head.Value, 1);
            Assert.AreEqual(list.Head, list.Tail);
            Assert.AreEqual(list.Tail.Value, 1);
            Assert.IsTrue(list.Count == 1);

            Assert.IsNull(list.Head.Previous);
            Assert.IsNull(list.Tail.Next);
        }

        [TestMethod]
        public void CreateAListWithFourNodes_Remove_NodeFromBack_AssertHeadNotEqualTail()
        {
            list.AddToFront(nodeOne);
            list.AddToBack(nodeTwo);
            list.AddToBack(nodeThree);
            list.AddToBack(nodeFour);

            Assert.AreEqual(list.Head.Value, 1);
            Assert.AreEqual(list.Tail.Value, 4);
            Assert.IsTrue(list.Count == 4);

            list.RemoveFromBack();
            Assert.AreEqual(list.Head.Value, 1);
            Assert.AreNotEqual(list.Head, list.Tail);
            Assert.AreEqual(list.Tail.Value, 3);
            Assert.IsTrue(list.Count == 3);

            Assert.IsNull(list.Head.Previous);
            Assert.IsNull(list.Tail.Next);
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
