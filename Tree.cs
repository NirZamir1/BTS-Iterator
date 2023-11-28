using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class Tree<T> : IEnumerable<Tree<T>> where T : IComparable<T>
    {
        Stack<Tree<T>> stack = new Stack<Tree<T>>();
        public Tree<T> LeftNode;
        public Tree<T> RightNode;
        private T Value;
        public Tree(T Value)
        {
            this.Value = Value;
        }
        public T GetValue()
        {
            return Value;
        }
        public Tree<T> Add(T Value)
        {
            if (this.Value.CompareTo(Value) > 0)
            {
                if (LeftNode == null)
                {
                    LeftNode = new Tree<T>(Value);
                }
                else
                {
                    LeftNode.Add(Value);
                }
            }
            else
            {
                if (RightNode == null)
                {
                    RightNode = new Tree<T>(Value);
                }
                else
                {
                    RightNode.Add(Value);
                }
            }
            return this;
        }
    


        public void printInAscending()
        {
            if (LeftNode != null)
            {
                LeftNode.printInAscending();
            }
            Console.WriteLine(Value);
            if (RightNode != null)
            {
                RightNode.printInAscending();
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Tree<T>> GetEnumerator()
        {
            return new TreeEnumarator<T>(this);

        }
    }
    public class TreeEnumarator<T> : IEnumerator<Tree<T>> where T : IComparable<T>
    {
        private Tree<T> res;
        private Tree<T> root;
        Stack<Tree<T>> stack;
        public TreeEnumarator(Tree<T> root)
        {
            this.root = root;
            stack = new Stack<Tree<T>>();
            downLeft(root);
        }
        public Tree<T> Current => res;

        object IEnumerator.Current => res;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if(stack.Count == 0)
                return false;
            res = stack.Pop();
            if(res.RightNode != null)
            {
                downLeft(res.RightNode);
            }
            return true;
        }
        public void downLeft(Tree<T> node)
        {
            if (node == null)
                return;
            stack.Push(node);
            downLeft(node.LeftNode);
        }
        public void Reset()
        {
            stack.Clear();
            downLeft(root);
        }
    }
}
