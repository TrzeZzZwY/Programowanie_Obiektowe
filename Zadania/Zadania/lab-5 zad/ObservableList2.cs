using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5_zad
{
    internal class ObservableList2<T> 
    {
        public delegate void Added(T value);
        public delegate void Updated(T value, int index);
        public delegate void Removed(int index);

        Added callback1;
        Updated callback2;
        Removed callback3;
        public ObservableList2(Added added, Updated updated, Removed removed)
        {
            callback1 = added;
            callback2 = updated;
            callback3 = removed;
        }
        protected List<T> lista = new List<T>();

        public T this[int i]
        {
            get => Get(i);
            set => Set(i,value);
        }
        public int Length => lista.Count;


        protected virtual void OnAdded(T value)
        {
            callback1(value);
        }
        protected virtual void OnUpdated(T value, int index)
        {
            callback2(value,index);
        }
        protected virtual void OnRemoved(int index)
        {
            callback3(index);
        }
        public void Add(T Value)
        {
            lista.Add(Value);

            this.OnAdded(Value);
        }

        public T Get(int i)
        {
            return lista[i];
        }
        public void Set(int index,T Value)
        {
            lista[index] = Value;
            this.OnUpdated(Value,index);
        }

        public void RemoveAt(int index)
        {
            T Value = lista[index];
            lista.RemoveAt(index);
            this.OnRemoved(index);
        }
       
    }
}
