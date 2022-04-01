using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_04
{
    class DynamicArray <T> :IEnumerable
    {
        private T?[] items = new T?[0];
        public DynamicArray()
        {

        }
        public T this[int i]
        {
            get
            {
                return this.items[i];
            }
            set
            {
                if(i > this.items.Length)
                {
                    T[] newItems = new T[i + 1];
                    Array.Copy(this.items, newItems, this.items.Length);
                    items = newItems;
                }
                items[i] = value;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new myEnumerator();
        }
    }
    class myEnumerator : IEnumerator
    {
        int index = -1;
        object[] items;
        public object Current => throw new NotImplementedException();

        public myEnumerator(object[] items)
        {
            this.items = items;
        }
        public bool MoveNext()
        {
            if(index < items.Length - 1)
            {
                index++;
            }
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
