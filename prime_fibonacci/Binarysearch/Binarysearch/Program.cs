using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binarysearch
{
    class Node
    {
        public int item;
        public Node leftc;
        public Node rightc;
        public void display()
        {
            Console.Write("[");
            Console.Write(item);
            Console.Write("]");
        }
    }
    class Tree
    {
        public int count = 0;
        public static int[] a = new int[100];
        public Node root;
        public static int i = 0;
        public Tree()
        {
            root = null;
        }
        public Node ReturnRoot()
        {
            return root;
        }
        public void Insert(int id)
        {
            Node newNode = new Node();
            newNode.item = id;
            if (root == null)
                root = newNode;
            else
            {
                Node current = root;
                Node parent;
                while (true)
                {
                    parent = current;
                    if (id < current.item)
                    {
                        current = current.leftc;
                        if (current == null)
                        {
                            parent.leftc = newNode;
                            return;
                        }
                    }
                    else
                    {
                        current = current.rightc;
                        if (current == null)
                        {
                            parent.rightc = newNode;
                            return;
                        }
                    }
                }
            }
        }
        public void ascendingorder(Node Root)
        {
            if (Root != null)
            {
                ascendingorder(Root.leftc);
                Console.Write(Root.item + " ");
                ascendingorder(Root.rightc);
            }
        }
        public void descendingorder(Node Root)
        {
            if (Root != null)
            {
                descendingorder(Root.rightc);
                Console.Write(Root.item + " ");
                descendingorder(Root.leftc);
            }
        }
        public void Search(Node Root, int Element)
        {
            if (Root != null)
            {
                Search(Root.leftc, Element);
                if (Root.item == Element)
                {
                    Console.Write("Found");
                    count++;
                    return;
                }
                Search(Root.rightc, Element);
            }
        }

    }
    class Program
    {
        static void Main()
        {
            Console.Write("Enter number of Elements to read:  ");
            var size = Int32.Parse(Console.ReadLine());
            Tree theTree = new Tree();
            for (var i = 0; i < size; i++)
            {
                var Element = Int32.Parse(Console.ReadLine());
                theTree.Insert(Element);
            }
            Console.Write("Enter Element to search: ");
            var SearchElement = Int32.Parse(Console.ReadLine());
            Console.Write("The searched element is: ");
            theTree.Search(theTree.ReturnRoot(), SearchElement);
            if (theTree.count == 0)
            {
                Console.Write("Not Found");
            }
            Console.WriteLine(" ");
            Console.WriteLine("ascending order: ");
            theTree.ascendingorder(theTree.ReturnRoot());
            Console.WriteLine(" ");
            Console.WriteLine("descending order");
            theTree.descendingorder(theTree.ReturnRoot());
            Console.ReadKey();
        }
    }
}
