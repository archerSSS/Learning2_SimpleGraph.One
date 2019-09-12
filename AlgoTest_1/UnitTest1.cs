using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsDataStructures2;

namespace AlgoTest_1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAdd_1()
        {
            SimpleGraph graph = new SimpleGraph(5);
            graph.AddVertex(22);
            graph.AddVertex(5);
            graph.AddVertex(7);
            graph.AddVertex(41);
            graph.AddVertex(92);
            
            Assert.IsTrue(graph.vertex[0].Value == 22);
            Assert.IsTrue(graph.vertex[1].Value == 5);
            Assert.IsTrue(graph.vertex[2].Value == 7);
            Assert.IsTrue(graph.vertex[3].Value == 41);
            Assert.IsTrue(graph.vertex[4].Value == 92);
            Assert.IsFalse(graph.vertex[0].Value == 91);
        }

        [TestMethod]
        public void TestAdd_Edge_1()
        {
            SimpleGraph graph = new SimpleGraph(5);
            graph.AddVertex(22);
            graph.AddVertex(5);
            graph.AddVertex(7);

            graph.AddEdge(0, 2);
            Assert.IsFalse(graph.IsEdge(1, 2));
            Assert.IsFalse(graph.IsEdge(0, 1));
            Assert.IsTrue(graph.IsEdge(0, 2));
        }

        [TestMethod]
        public void TestAdd_Edge_2()
        {
            SimpleGraph graph = new SimpleGraph(5);
            graph.AddVertex(22);
            graph.AddVertex(5);
            graph.AddVertex(7);
            graph.AddVertex(11);
            graph.AddVertex(52);
            graph.AddVertex(27);
            for (int i = 0; i < graph.max_vertex; i++)
                Assert.IsTrue(graph.vertex[i].Value != 27);


            graph.AddEdge(1, 4);
            graph.AddEdge(3, 4);
            graph.AddEdge(0, 1);
            Assert.IsFalse(graph.IsEdge(1, 2));
            Assert.IsFalse(graph.IsEdge(1, 3));
            Assert.IsFalse(graph.IsEdge(2, 0));
            Assert.IsFalse(graph.IsEdge(2, 1));
            Assert.IsFalse(graph.IsEdge(2, 3));
            Assert.IsFalse(graph.IsEdge(3, 0));
            Assert.IsFalse(graph.IsEdge(3, 1));
            Assert.IsFalse(graph.IsEdge(3, 2));
            Assert.IsFalse(graph.IsEdge(4, 0));
            Assert.IsFalse(graph.IsEdge(4, 2));

            Assert.IsTrue(graph.IsEdge(4, 1));
            Assert.IsTrue(graph.IsEdge(1, 4));
            Assert.IsTrue(graph.IsEdge(3, 4));
            Assert.IsTrue(graph.IsEdge(4, 3));
            Assert.IsTrue(graph.IsEdge(0, 1));
            Assert.IsTrue(graph.IsEdge(1, 0));
        }

        [TestMethod]
        public void TestAddRemove_Edge_1()
        {
            SimpleGraph graph = new SimpleGraph(5);
            graph.AddVertex(2);
            graph.AddVertex(5);

            graph.AddEdge(0, 1);
            Assert.IsFalse(graph.IsEdge(1, 2));
            Assert.IsFalse(graph.IsEdge(4, 2));
            Assert.IsTrue(graph.IsEdge(0, 1));
            Assert.IsTrue(graph.IsEdge(1, 0));

            graph.RemoveVertex(0);
            Assert.IsTrue(graph.vertex[0] == null);
            for (int i = 0; i < graph.vertex.Length; i++)
            {
                Assert.IsTrue(graph.m_adjacency[i, 0] == 0);
                Assert.IsTrue(graph.m_adjacency[0, i] == 0);
            }
        }

        [TestMethod]
        public void TestAddED_RemoveED_1()
        {
            SimpleGraph graph = new SimpleGraph(5);
            graph.AddVertex(2);
            graph.AddVertex(5);
            graph.AddVertex(41);
            graph.AddVertex(36);
            graph.AddVertex(62);

            graph.AddEdge(0, 1);
            Assert.IsFalse(graph.IsEdge(1, 2));
            Assert.IsFalse(graph.IsEdge(4, 2));
            Assert.IsTrue(graph.IsEdge(0, 1));
            Assert.IsTrue(graph.IsEdge(1, 0));

            graph.RemoveVertex(0);
            Assert.IsTrue(graph.vertex[0] == null);
            for (int i = 0; i < graph.vertex.Length; i++)
            {
                Assert.IsTrue(graph.m_adjacency[i, 0] == 0);
                Assert.IsTrue(graph.m_adjacency[0, i] == 0);
            }
        }

        [TestMethod]
        public void TestAddED_RemoveED_2()
        {
            SimpleGraph graph = new SimpleGraph(4);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);

            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(0, 3);
            graph.AddEdge(2, 3);
            Assert.IsFalse(graph.IsEdge(1, 3));
            Assert.IsFalse(graph.IsEdge(1, 2));
            Assert.IsTrue(graph.IsEdge(0, 1));
            Assert.IsTrue(graph.IsEdge(0, 2));
            Assert.IsTrue(graph.IsEdge(0, 3));
            Assert.IsTrue(graph.IsEdge(2, 3));

            graph.RemoveVertex(2);
            Assert.IsTrue(graph.vertex[2] == null);
            Assert.IsFalse(graph.IsEdge(0, 2));
            Assert.IsFalse(graph.IsEdge(2, 0));

            Assert.IsFalse(graph.IsEdge(2, 3));
            Assert.IsFalse(graph.IsEdge(3, 2));

            Assert.IsTrue(graph.vertex[0] != null);
            Assert.IsTrue(graph.vertex[1] != null);
            Assert.IsTrue(graph.vertex[2] == null);
            Assert.IsTrue(graph.vertex[3] != null);

            Assert.IsTrue(graph.m_adjacency[0, 0] == 0);
            Assert.IsTrue(graph.m_adjacency[0, 1] == 1);
            Assert.IsTrue(graph.m_adjacency[0, 2] == 0);
            Assert.IsTrue(graph.m_adjacency[0, 3] == 1);
            Assert.IsTrue(graph.m_adjacency[1, 0] == 1);
            Assert.IsTrue(graph.m_adjacency[1, 2] == 0);
            Assert.IsTrue(graph.m_adjacency[1, 3] == 0);
            Assert.IsTrue(graph.m_adjacency[2, 0] == 0);
            Assert.IsTrue(graph.m_adjacency[2, 1] == 0);
            Assert.IsTrue(graph.m_adjacency[2, 3] == 0);
            Assert.IsTrue(graph.m_adjacency[3, 0] == 1);
            Assert.IsTrue(graph.m_adjacency[3, 1] == 0);
            Assert.IsTrue(graph.m_adjacency[3, 2] == 0);
        }

        [TestMethod]
        public void TestAddED_RemoveED_3()
        {
            SimpleGraph graph = new SimpleGraph(4);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);

            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(0, 3);
            graph.AddEdge(2, 3);
            Assert.IsFalse(graph.IsEdge(1, 3));
            Assert.IsFalse(graph.IsEdge(1, 2));
            Assert.IsTrue(graph.IsEdge(0, 1));
            Assert.IsTrue(graph.IsEdge(0, 2));
            Assert.IsTrue(graph.IsEdge(0, 3));
            Assert.IsTrue(graph.IsEdge(2, 3));

            graph.RemoveVertex(2);
            Assert.IsTrue(graph.vertex[2] == null);
            Assert.IsFalse(graph.IsEdge(0, 2));
            Assert.IsFalse(graph.IsEdge(2, 0));

            Assert.IsFalse(graph.IsEdge(3, 2));
        }

        [TestMethod]
        public void TestAddED_RemoveED_4()
        {
            SimpleGraph graph = new SimpleGraph(7);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            graph.AddVertex(5);
            graph.AddVertex(6);
            graph.AddVertex(7);

            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(0, 3);
            graph.AddEdge(0, 4);
            graph.AddEdge(0, 5);
            graph.AddEdge(0, 6);
            graph.AddEdge(3, 5);
            Assert.IsTrue(graph.m_adjacency[0, 3] == 1);
            Assert.IsTrue(graph.m_adjacency[0, 5] == 1);
            Assert.IsTrue(graph.vertex[3] != null);
            Assert.IsTrue(graph.vertex[5] != null);

            graph.RemoveVertex(3);
            Assert.IsTrue(graph.m_adjacency[0, 3] == 0);
            Assert.IsTrue(graph.m_adjacency[0, 5] == 1);
            Assert.IsTrue(graph.vertex[3] == null);
            Assert.IsTrue(graph.vertex[5] != null);

            graph.RemoveEdge(0, 5);
            Assert.IsTrue(graph.m_adjacency[0, 5] == 0);
            Assert.IsTrue(graph.vertex[5] != null);

            graph.AddEdge(5, 0);
            Assert.IsTrue(graph.m_adjacency[0, 5] == 1);
            Assert.IsTrue(graph.vertex[5] != null);
        }

        [TestMethod]
        public void TestAddED_RemoveED_5()
        {
            SimpleGraph graph = new SimpleGraph(3);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);

            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            Assert.IsTrue(graph.m_adjacency[0, 1] == 1);
            Assert.IsTrue(graph.m_adjacency[0, 2] == 1);

            graph.RemoveEdge(0, 2);
            Assert.IsTrue(graph.m_adjacency[0, 1] == 1);
            Assert.IsTrue(graph.m_adjacency[0, 2] == 0);

            graph.AddEdge(2, 0);
            Assert.IsTrue(graph.m_adjacency[0, 1] == 1);
            Assert.IsTrue(graph.m_adjacency[0, 2] == 1);

            graph.RemoveEdge(2, 0);
            Assert.IsTrue(graph.m_adjacency[0, 1] == 1);
            Assert.IsTrue(graph.m_adjacency[2, 0] == 0);
        }
    }
}
