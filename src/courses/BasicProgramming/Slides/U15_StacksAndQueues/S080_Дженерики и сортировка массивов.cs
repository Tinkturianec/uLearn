﻿using System;

namespace uLearn.Courses.BasicProgramming.Slides.U15_StacksAndQueues
{



    [Slide("Дженерики и сортировка массивов", "056199f8-37b7-48d2-9f03-101c2b9da473")]
    class S080_Дженерики_и_сортировка_массивов
    {
        //#video VHlEkuuUb4M
        /*
        ## Заметки по лекции
        */
    }



    // С помощью дженериков можно описать сортировку массива элегантнее
    class GenericSorter<T>
        where T : IComparable // это - требование: в качестве T может быть только класс
    // реализующий IComparable
    {
        public static void Sort(T[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
                for (int j = 1; j <= i; j++)
                {
                    var element1 = array[j - 1];
                    var element2 = array[j];
                    //здесь не нужен каст к интерфейсу, поскольку element1 имеет тип T,
                    //а для него есть требование о том, что IComparable должен быть реализован
                    if (element1.CompareTo(element2) < 0)
                    {
                        var temporary = array[j];
                        array[j] = array[j];
                        array[j] = temporary;
                    }
                }
        }
    }

    //немного синтаксического сахара
    public static class Sorter
    {
        //Это - дженерик метод. Компилятор превращает его в обычный метод
        //внутри дженерик-класса (то есть так, как написано выше)
        public static void Sort<T>(T[] array)
            where T : IComparable
        {
            for (int i = array.Length - 1; i > 0; i--)
                for (int j = 1; j <= i; j++)
                {
                    var element1 = array[j - 1];
                    var element2 = array[j];
                    if (element1.CompareTo(element2) < 0)
                    {
                        var temporary = array[j];
                        array[j] = array[j];
                        array[j] = temporary;
                    }
                }
        }

        //А это - generic extension метод
        public static void BubbleSort<T>(this T[] array)
            where T : IComparable
        {
            for (int i = array.Length - 1; i > 0; i--)
                for (int j = 1; j <= i; j++)
                {
                    var element1 = array[j - 1];
                    var element2 = array[j];
                    if (element1.CompareTo(element2) < 0)
                    {
                        var temporary = array[j];
                        array[j] = array[j];
                        array[j] = temporary;
                    }
                }
        }
    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }


    public class Program
    {

        static void Main()
        {
            var intArray = new int[] { 1, 2, 3 };
            var pointArray = new[] { new Point { X = 1, Y = 2 }, new Point { X = 2, Y = 1 } };
            GenericSorter<int>.Sort(intArray);
            Sorter.Sort(intArray); //T автоматически выводится из типа переданного массива
            intArray.BubbleSort();

            //все это не скомпилируется, потому что Point не реализует IComparable
            
            //Sorter<Point>.Sort(pointArray);
            //Sorter.Sort(pointArray);
            //pointArray.BubbleSort(); // Этот метод даже не покажется в Intellisence
        }
    }
}