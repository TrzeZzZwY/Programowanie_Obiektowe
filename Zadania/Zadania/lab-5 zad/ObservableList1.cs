using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5_zad
{
    internal class ObservableList1<T>
    {
        protected List<T> lista = new List<T>();

        public T this[int i]
        {
            get {return Get(i); }
            set { Set(i, value); }
        }
        public int Length { get {return lista.Count; } }


        public event EventHandler<ChangedEventArgs<T>> Added;
        public event EventHandler<ChangedEventArgs<T>> Updated;
        public event EventHandler<ChangedEventArgs<T>> Removed;

        protected virtual void OnAdded(ChangedEventArgs<T> e)
        {
            this.Added?.Invoke(this, e);
        }
        protected virtual void OnUpdated(ChangedEventArgs<T> e)
        {
            this.Updated?.Invoke(this, e);
        }
        protected virtual void OnRemoved(ChangedEventArgs<T> e)
        {
            this.Removed?.Invoke(this, e);
        }
        public void Add(T Value)
        {
            lista.Add(Value);

            this.OnAdded(new ChangedEventArgs<T>(Value));
        }

        public T Get(int i)
        {
            return lista[i];
        }
        public void Set(int index,T Value)
        {
            lista[index] = Value;
            this.OnUpdated(new ChangedEventArgs<T>(Value));
        }

        public void RemoveAt(int index)
        {
            T Value = lista[index];
            lista.RemoveAt(index);
            this.OnRemoved(new ChangedEventArgs<T>(Value));
        }
       
    }
    public class ChangedEventArgs<T> : EventArgs
    {

        public T value;
        public ChangedEventArgs(T value)
        {
            this.value = value;
        }
    }
}
