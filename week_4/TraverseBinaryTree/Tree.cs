using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TraverseBinaryTree
{
    public class Tree<T>
    {
        public Tree<T> Left { get; set; }
        public Tree<T> Right { get; set; }
        public T Data { get; set; }

       
    }
    
}
