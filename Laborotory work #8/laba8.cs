using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class laba8
    {
        public class MyStack<T> : MyVector<T>
        {
            private MyVector<T> stack;
            private int top;
            public MyStack()
            {
                stack = new MyVector<T>();
                top = -1;
            }
            public void push(T item)
            {
                stack.add(item);
                top++;
            }
            public T pop()
            {
                if(top == -1) throw new Exception("empty");
                else
                {
                    T temp = stack.get(top);
                    stack.remove(top);
                    top--;
                    return temp;
                }
            }
            public T peek()
            {
                if (top == -1) throw new Exception("empty");
                else return stack.get(top);
            }
            public bool empty() => stack.isEmpty();
            public int search(T item)
            {
                if (stack.indexOf(item) == -1) return -1;
                return top - stack.indexOf(item);
            }
            public void printStack()
            {
                for(int i = 1; i < top; i++)
                {
                    Console.Write(stack.get(i));
                    Console.Write(", ");
                }
                Console.WriteLine(stack.get(top));
            }
        }
        static void Main(string[] args)
        {
            MyStack<int> stack = new MyStack<int>();
            for(int i = 0; i < 5; i++) stack.push(i);
            Console.WriteLine("Стек:");
            stack.printStack();
            Console.WriteLine("Поп:");
            Console.WriteLine(stack.pop());
            Console.WriteLine("Стек после поп:");
            stack.printStack();
            Console.WriteLine("Цифра 0 под номером:");
            Console.WriteLine(stack.search(0));
        }
    }
}
