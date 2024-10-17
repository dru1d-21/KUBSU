﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp9.Program;

namespace ConsoleApp9
{
    internal class Program
    {
        public class MyArrayList<T>
        {
            private T[] elementData;
            private int size;
            public MyArrayList()
            {
                elementData = new T[0];
                size = 0;
            }
            public MyArrayList(T[] a)
            {
                size = a.Length;
                elementData = new T[size];
                Array.Copy(a, elementData, size);

            }
            public MyArrayList(int capasity)
            {
                elementData = new T[capasity];
                size = 0;

            }
            public void add(T e)
            {
                if (size >= elementData.Length)
                {
                    T[] NewElementData = new T[size + 1 + (size / 2)];
                    for (int i = 0; i < size; i++)
                    {
                        NewElementData[i] = elementData[i];
                    }
                    elementData = NewElementData;
                }
                elementData[size] = e;
                size++;
            }
            public void addAll(T[] a)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (size >= elementData.Length)
                    {
                        T[] NewElementData = new T[size + 1 + (size / 2)];
                        for (int j = 0; j < size; j++)
                        {
                            NewElementData[j] = elementData[j];
                        }
                        elementData = NewElementData;
                    }
                    size++;
                    elementData[size - 1] = a[i];
                }
            }
            public void clear()
            {
                elementData = new T[0];
                size = 0;
            }
            public bool contains(object o)
            {
                for (int i = 0; i < size; i++)
                {
                    if (elementData[i].Equals(o)) return true;
                }
                return false;
            }
            public bool containsAll(T[] a)
            {
                for (int i = 0; i < size; i++)
                {
                    if (contains(a[i]) == false) return false;
                }
                return true;
            }
            public bool isEmpty()
            {
                if (size == 0) return true;
                else return false;
            }
            public void remove(object o)
            {
                bool flag = false;
                for (int i = 0; i < size - 1; i++)
                {
                    if (elementData[i].Equals(o)) flag = true;
                    if (flag == true)
                    {
                        elementData[i] = elementData[i + 1];
                    }
                }
                if (flag == true) size--;
            }
            public void removeAll(T[] a)
            {
                for (int i = 0; i < size; i++) remove(a[i]);
            }
            public void retainAll(T[] a)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (!elementData[i].Equals(a[j]))
                        {
                            remove(elementData[i]);
                        }
                    }
                }
            }
            public int Size()
            {
                return size;
            }
            public T[] toArray()
            {
                T[] array = new T[size]; for (int i = 0; i < size; i++) array[i] = elementData[i];
                return array;
            }
            public void toArray(ref T[] a)
            {
                if (a == null)
                {
                    a = new T[size]; for (int i = 0; i < size; i++)
                    {
                        a[i] = elementData[i];
                    }
                }
                else
                {
                    int h = 0; for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            if (elementData[i].Equals(a[j]))
                            {
                                a[h] = elementData[i];
                                h++;
                            }
                        }
                    }
                }
            }

            public void add(int index, T e)
            {
                size++;
                for (int i = size - 2; i >= index; i--)
                {
                    elementData[i] = elementData[i + 1];
                }
                elementData[index] = e;
            }
            public void addAll(int index, T[] a)
            {
                for (int i = size - 1; i >= 0; i--)
                {
                    add(index, a[i]);
                }
            }
            public T get(int index)
            {
                return elementData[index];
            }
            public int indexOf(object o)
            {
                for (int i = 0; i < size; i++)
                {
                    if (elementData[i].Equals(o)) return i;
                }
                return -1;
            }
            public int lastIndexOf(object o)
            {
                for (int i = size - 1; i >= 0; i--)
                {
                    if (elementData[i].Equals(o)) return i;
                }
                return -1;
            }
            public T remove(int index)
            {
                T temp = get(index);
                remove(index);
                return temp;
            }
            public void set(int index, T e)
            {
                elementData[index] = e;
            }
            public T[] subList(int fromindex, int toindex)
            {
                T[] temp = new T[toindex - fromindex];
                for (int i = fromindex; i < toindex; i++)
                {
                    temp[i] = elementData[i];
                }
                return temp;
            }
            public String toString()
            {
                StringBuilder CreateString = new StringBuilder();
                for (int i = 0; i < size - 1; i++)
                {
                    CreateString.Append(elementData[i]).Append(",");
                }
                CreateString.Append(elementData[size - 1]);
                return CreateString.ToString();
            }
        }

        static void Main(string[] args)
        {
            MyArrayList<int> Array1 = new MyArrayList<int>();
            MyArrayList<int> Array2 = new MyArrayList<int>();
            int[] array3 = new int[5] { 1, 2, 3 , 4, 5};

            for (int i = 10; i > 1; i -= 2) Array2.add(i);

            Console.WriteLine("Метод add. Заполнили массив.");
            for (int i = 1; i < 10; i++) Array1.add(i);
            Console.WriteLine(Array1.toString());

            Console.WriteLine("Метод addAll. Один массив в другой.");
            Array2.addAll(array3);
            Console.WriteLine(Array2.toString());

            Console.WriteLine("Метод clear.");
            Array1.clear(); Array1.add(1);
            Console.WriteLine(Array1.toString()); Console.WriteLine("\"1\" добавил чтоб вывести хоть какой-то элемент.");

            Console.WriteLine("Метод contains. Проверяет на цифру 4");
            Console.WriteLine(Array2.toString());
            Console.WriteLine(Array2.contains(4));
            Console.WriteLine("Метод contains. Проверяет на число 10");
            Console.WriteLine(Array2.toString());
            Console.WriteLine(Array2.contains(10));

            Console.WriteLine("Метод containsAll. Проверяет на цифру массив 3");
            Console.WriteLine("Массив 2:");
            Console.WriteLine(Array2.toString());


        }
    }
}
