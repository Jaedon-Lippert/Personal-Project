using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //REPLACE string WITH T
    class DynArray<T>
    {

        //Information Variables
        private int size;
        private int capacity;
        private T[] array;

        //Constructor
        public DynArray()
        {
            //set this to 0
            size = 0;
            capacity = 8;
            array = new T[capacity];
        }
        public DynArray(T[] list)
        {
            //set this to 0
            size = list.Length;
            capacity = 8;
            while (size > capacity)
            {
                capacity *= 2;
            }
            array = new T[capacity];
            for(int i = 0; i < size; i++)
            {
                array[i] = list[i];
            }
        }

        //Getters
        public int Size => size;
        public int Capacity => capacity;
        
        //Get From Position
        public T Index(int position)
        {
            try
            {
                if (position > size -1 || position < 0)
                {
                    throw new IndexOutOfRangeException();
                }
            }
            catch (IndexOutOfRangeException e)
            {
                
            }
            return array[position];
        }


        //Modify Substract
        //Pop Item at Position
        public T PopIndex(int position)
        {

            T popped = array[position];
            try
            {
                if (position > size - 1 || position < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                T[] tempArray = new T[capacity];

                if (true)
                {
                    int j = 0;
                    for (int i = 0; i < size; i++)
                    {
                        if (i != position)
                        {
                            tempArray[j] = array[i];
                            j++;
                        }
                    }
                }

                size--;
                array = new T[capacity];

                for (int i = 0; i < size; i++)
                {
                    array[i] = tempArray[i];
                }

                
            }
            catch (IndexOutOfRangeException e)
            {
                Console.Error.WriteLine(e);
            }
            return popped;
        }

        //Pop Back
        public T PopBack()
        {
            T popped = array[size - 1];
            try
            {
                if (size <= 0)
                {
                    throw new IndexOutOfRangeException();
                }
                T[] tempArray = new T[capacity];

                for (int i = 0; i < size-1; i++)
                {
                    tempArray[i] = array[i];
                }

                size--;
                array = new T[capacity];

                for (int i = 0; i < size; i++)
                {
                    array[i] = tempArray[i];
                }


            }
            catch (IndexOutOfRangeException e)
            {
                Console.Error.WriteLine(e);
            }
            return popped;
        }

        //Pop Front
        public T PopFront()
        {
            T popped = array[0];
            try
            {
                if (size <= 0)
                {
                    throw new IndexOutOfRangeException();
                }
                T[] tempArray = new T[capacity];

                for (int i = 1; i < size - 1; i++)
                {
                    tempArray[i-1] = array[i];
                }

                size--;
                array = new T[capacity];

                for (int i = 0; i < size; i++)
                {
                    array[i] = tempArray[i];
                }


            }
            catch (IndexOutOfRangeException e)
            {
                Console.Error.WriteLine(e);
            }
            return popped;
        }

        //Modify Add
        public T Insert(T value, int position)
        {
            try
            {
                if (position > size) throw new IndexOutOfRangeException();

                //Resize array
                size++;
                while (size > capacity)
                {
                    capacity *= 2;
                }

                T holder = value;
                T[] TempArray = new T[capacity];

                //New array
                for (int i = 0; i < size; i++)
                {
                    if (i >= position)
                    {
                        TempArray[i] = holder;
                        holder = array[i];
                    }
                    else
                    {
                        TempArray[i] = array[i];
                    }
                }

                array = new T[capacity];

                //Reassign
                for (int i = 0; i < size; i++)
                {
                    array[i] = TempArray[i];
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
            }
            return value;
        }
        //public T AddFront() { }
        //public T AddBack() { }

        //Modify Replace
        //public T ReplaceIndex() { }
        //public T ReplaceFront() { }
        //public T ReplaceBack() { }
        //public T ReplaceItem() { }
    }
}
