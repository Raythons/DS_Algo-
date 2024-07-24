using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Heap
{

    public class MinHeap
    {
        public int size = 0;
        private int[] array;
        private int capacity = 0;

        public MinHeap(int[] array)
        {
            this.array = array;
            size = array.Length;
        }

        public MinHeap(int capacityy)
        {
            array = new int[capacityy];
        }

        void HeapifyUp (int childPos)
        {
            int parentPos = Parent(childPos);
           
            if (childPos == 0  || array[parentPos] < array[childPos])
                return;
            (array[childPos], array[parentPos]) = (array[parentPos], array[childPos]);
            HeapifyUp(parentPos);


        }
        public void Push (int key)
        {
            //if (size + 1 >= capacity)
            //    throw new InvalidOperationException("Error");

            array[size++] = key;
            HeapifyUp(size - 1);
        }

        public int Top()
        {
            return array[0];
        }

        void HeapifyDown(int parentNodeIndex)
        {
            int childPos = Left(parentNodeIndex);
            int rightPos = Right(parentNodeIndex);

            if (childPos == -1)     
                return;
  
            if (rightPos != -1 && array[rightPos] < array[childPos]) 
                childPos = rightPos;

            if (array[parentNodeIndex] > array[childPos])
            {
                (array[childPos], array[parentNodeIndex]) = (array[parentNodeIndex], array[childPos]);
                HeapifyDown(childPos);
            }

        }

        public int Pop()
        {
            var returnval = array[0];
            array[0] = array[--size];
            HeapifyDown(0);
            return returnval;

        }

        private void InsertLessThan(int val, int parent_pose, List<int> lessThanVals)
        {


            if (array[parent_pose] < val) 
                lessThanVals.Add(array[parent_pose]);

            int leftChildPos = Left(parent_pose);
            int rightChildPos = Right(parent_pose);

            if (leftChildPos != -1)
                InsertLessThan(val, leftChildPos, lessThanVals);

            if (rightChildPos != -1)
                InsertLessThan(val, rightChildPos, lessThanVals);
            return;
        }

        public List<int> PrintLessThan (int val , int parent_pose)
        {
            List<int> lessThanVals = new();
            InsertLessThan( val, parent_pose, lessThanVals);
            return lessThanVals;    

        }

        int Left(int nodeIndex)
        {
            int p = 2 * nodeIndex + 1;
            if (p >= size)
                return -1;
            return p;
        }

        int Right(int nodeIndex)
        {
            int p = 2 * nodeIndex + 2;
            if (p >= size)
                return -1;
            return p;
        }

        int Parent(int nodeIndex)
        {
            return nodeIndex == 0 ? -1 : (nodeIndex - 1) / 2;
        }

    }
}