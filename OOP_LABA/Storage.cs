using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_LABA
{
    class Storage<T>
    {
        const int dop = 10; //дополнительная длина массива

        private T[] array;
        private int size;
        private int capacity;
        public Storage()
        {
            array = null;
        }
        public Storage(int _size)
        {
            //конструктор с заданной длиной массива
            array = new T[_size + dop];
            size = _size;
            capacity = _size + dop;
        }
        ~Storage() { }
        public void reserve(int _size)
        {
            //задать размер
            array = new T[_size + dop];
            size = 0;
            capacity = _size + dop;
        }
        public void push_back(T elem)
        {
            if (array == null)
            {
                array = new T[3];
                array[0] = elem;
                size = 1;
                capacity = 3;
            }
            else if (array != null)
            {
                if (size == capacity)
                {
                    T[] newarr = new T[size + dop];
                    for (int i = 0; i < size; i++)
                        newarr[i] = array[i];
                    newarr[size] = elem;
                    array = newarr;
                    capacity = size + dop;
                    size++;
                }
                else
                {
                    array[size] = elem;
                    size++;
                }
            }//вставка в конец
        }
        public void pop_back()
        { //удалить из конца  
            if (array != null && size > 0)
            {
                if (size < capacity / 3 && size > 20)
                {
                    size--;
                    T[] newarr = new T[size + dop];
                    for (int i = 0; i < size; i++)
                        newarr[i] = array[i];
                    array = newarr;
                    capacity = size + dop;
                }
                else size--;
            }
            else if (array == null || size <= 0)
                Console.WriteLine("Массив пустой");
        }//удалить последний элемент
        public void insert(T elem, int index)
        {
            if (array == null)
            {
                array = new T[3];
                array[0] = elem;
                size = 1;
                capacity = 3;
            }
            else if (size == 0)
            {
                array[0] = elem;
                size++;
            }
            else
            {
                if (index > size)
                    index = size;
                if (index < 0)
                {
                    index = 0;

                }
                if (size == capacity)
                {
                    size++;
                    T[] newarr = new T[size + dop];
                    for (int i = 0, k = 0; i < size; i++, k++)
                    {
                        if (i == index)
                        {
                            newarr[k] = elem;
                            k++;
                        }
                        else newarr[k] = array[i];
                    }
                    array = newarr;
                    capacity = size + dop;
                }
                else
                {
                    for (int i = size - 1; i >= index; i--)
                        array[i + 1] = array[i];
                    array[index] = elem;
                    size++;
                }
            }
        }
        //вставка по индексу
        public void push_front(T elem)
        {
            //insert(elem, 0);
            if (array == null)
            {
                array = new T[3];
                array[0] = elem;
                size = 1;
                capacity = 3;
            }
            else
            {
                if (size == capacity)
                {
                    size++;
                    T[] newarr = new T[size + dop];
                    newarr[0] = elem;
                    for (int i = 0; i < size - 1; i++)
                        newarr[i + 1] = array[i];
                    array = newarr;
                    capacity = size + dop;
                }
                else
                {
                    for (int i = size - 1; i >= 0; i--)
                        array[i + 1] = array[i];
                    size++;
                    array[0] = elem;
                }
            }
        }//вставка в начало
        public void pop_front()
        {   //удаляет первый элемент
            if (array != null && size > 0)
            {
                if (size < (capacity / 4) && size > 50)
                {
                    size--;
                    T[] newarr = new T[size + dop];
                    for (int i = 1; i < size + 1; i++)
                        newarr[i - 1] = array[i];
                    array = newarr;
                    capacity = size + dop;
                }
                else
                {
                    for (int i = 1; i < size; i++)
                        array[i - 1] = array[i];
                    size--;
                }
            }
            else Console.WriteLine("Массив пустой");
        }                       //удалить первый элемент
        public void pop(int index)
        { //удалить по индексу 
            if (array != null && size > 0)
            {
                if (size < (capacity / 4) && size > 50)
                {
                    size--;
                    T[] newarr = new T[size + dop];
                    for (int i = 0, k = 0; i < size + 1; i++)
                        if (i != index)
                        {
                            newarr[k] = array[i];
                            k++;
                        }
                    array = newarr;
                    capacity = size + dop;
                }
                else
                {
                    for (int i = index + 1; i < size; i++)
                        array[i - 1] = array[i];
                    size--;
                }
            }
            else Console.WriteLine("Массив пустой");
        }                    //удалить по индексу
        public T this[int i]
        {
            get
            {
                if (i < size && i >= 0 && array != null)
                    return array[i];
                else throw new IndexOutOfRangeException();
            }
            set
            {
                if (i < size && i >= 0 && array != null)
                    array[i] = value;
                else throw new IndexOutOfRangeException();
            }
        }
        public T getanddelete(int index)
        {
            if (array != null && size > 0)
            {
                if (size < (capacity / 4) && size > 50)
                {
                    size--;
                    T[] newarr = new T[size + dop];
                    for (int i = 0, k = 0; i < size + 1; i++)
                        if (i != index)
                        {
                            newarr[k] = array[i];
                            k++;
                        }
                    T r_elem = array[index];
                    array = newarr;
                    capacity = size + dop;
                    return r_elem;
                }
                else
                {
                    T r_elem = array[index];
                    for (int i = index + 1; i < size; i++)
                        array[i - 1] = array[i];
                    size--;
                    return r_elem;
                }
            }
            else throw new IndexOutOfRangeException();
        }
        public T get(int index)
        { //достать элемент 
            if (array != null && size > 0)
            {
                T r_elem = array[index];
                return r_elem;
            }
            else throw new Exception("Массив пустой");
        }                       //достать
        public void clear()
        { //очистка

            array = null;
            size = 0;
            capacity = 0;
        }                           //очистка
        public int Size()
        { //вернуть размер
            return size;
        }                             //вернуть размер
        public int Capacity()
        {  //вернуть размер расширенного массива
            return capacity;
        }                         //вернуть размер расширенного массива
        public bool empty()
        {  //проверить пустой ли 
            if (array == null || size == 0)
                return true;
            else return false;
        }                           //проверка, пустой ли массив
        public void resize(int n)
        { //изменить размер 
            if (array == null)
                reserve(n);
            else if (n > size && n <= capacity)
                size = n;
            else if (n > capacity)
            {
                T[] newarr = new T[n + dop];
                for (int i = 0; i < size; i++)
                    newarr[i] = array[i];

                array = newarr;
                size = n;
                capacity = size + dop;
            }
            else if (n < (capacity / 3) && n > 20)
            {
                size = n;
                T[] newarr = new T[size + dop];
                for (int i = 0; i < size; i++)
                    newarr[i] = array[i];

                array = newarr;
                capacity = size + dop;
            }
            else if (n < size)
                size = n;
        }                     //задать новый размер массива
        public int Find(T elem)
        { //найти по индексу
            if (array != null && size != 0)
                for (int i = 0; i < size; i++)
                {
                    if (array[i].Equals(elem))
                        return i;
                }
            return -1;
        }
    }
}
