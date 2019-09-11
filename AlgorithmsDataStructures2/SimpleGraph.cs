﻿using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class Vertex
    {
        public int Value;
        public Vertex(int val)
        {
            Value = val;
        }
    }

    public class SimpleGraph
    {
        public Vertex[] vertex;
        public int[,] m_adjacency;
        public int max_vertex;

        public SimpleGraph(int size)
        {
            max_vertex = size;
            m_adjacency = new int[size, size];
            vertex = new Vertex[size];
        }

        public void AddVertex(int value)
        {
            for (int i = 0; i < max_vertex; i++)
                if (vertex[i] == null)
                {
                    vertex[i] = new Vertex(value);
                    return;
                }

            // ваш код добавления новой вершины 
            // с значением value 
            // в свободную позицию массива vertex
        }

        // здесь и далее, параметры v -- индекс вершины
        // в списке  vertex
        public void RemoveVertex(int v)
        {
            if (vertex[v] != null)
            {
                for (int i = 0; i < max_vertex; i++)
                {
                    m_adjacency[v, i] = 0;
                    m_adjacency[i, v] = 0;
                }
                vertex[v] = null;
            }
            // ваш код удаления вершины со всеми её рёбрами
        }

        public bool IsEdge(int v1, int v2)
        {
            return m_adjacency[v1, v2] == 1 && m_adjacency[v2, v1] == 1;
            // true если есть ребро между вершинами v1 и v2
            //return false;
        }

        public void AddEdge(int v1, int v2)
        {
            if (vertex[v1] != null && vertex[v2] != null)
            {
                m_adjacency[v1, v2] = 1;
                m_adjacency[v2, v1] = 1;
            }
            // добавление ребра между вершинами v1 и v2
        }

        public void RemoveEdge(int v1, int v2)
        {
            if (vertex[v1] != null && vertex[v2] != null)
            {
                m_adjacency[v1, v2] = 0;
                m_adjacency[v2, v1] = 0;
            }
            // удаление ребра между вершинами v1 и v2
        }
    }
}