using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace TraverseBinaryTree
{
    public class Tester
    {
        public static void Main()
        {

           
            CustomClass number1 = new CustomClass
            {
                Number = 1,
                Name = "first"
            };
            CustomClass number2 = new CustomClass
            {
                Number = 2,
                Name = "second"
            }; 
            CustomClass number4 = new CustomClass
            {
                Number = 4,
                Name = "four"
            };

            Tree<CustomClass> tree = new Tree<CustomClass>();
            tree.Data = number1;

            Action<CustomClass> displayAction = Display;



            StartActionTree(tree, displayAction);

           

            
            void Display(CustomClass number)
            {
                Console.WriteLine("{0} - {1}", number.Name, number.Number);
            }



        }
        public static void StartActionTree<T>(Tree<T> tree, Action<T> action)
        {
            if (tree == null) return;
            Parallel.Invoke(
                () => StartActionTree(tree.Left, action),
                () => StartActionTree(tree.Right, action),
                () => action(tree.Data)
            );
        }
        
    }
}
