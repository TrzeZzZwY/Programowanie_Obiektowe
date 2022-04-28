using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5_zad
{
    internal class ObservableList1v2<T>
    {
        protected List<T> lista = new List<T>();

        public T this[int i]
        {
            get => Get(i);
            set => Set(i, value);
        }
        public int Length => lista.Count;


        public event EventHandler<ChangedEventArgs2<T>> Added;
        public event EventHandler<ChangedEventArgs2<T>> Updated;
        public event EventHandler<ChangedEventArgs2<T>> Removed;

        protected virtual void OnAdded(ChangedEventArgs2<T> e) => this.Added?.Invoke(this, e);

        protected virtual void OnUpdated(ChangedEventArgs2<T> e) => this.Updated?.Invoke(this, e);

        protected virtual void OnRemoved(ChangedEventArgs2<T> e) => this.Removed?.Invoke(this, e);

        //Action<T> test = Value =>
        //{
        //    lista.Add(Value);

        //    OnAdded(new ChangedEventArgs2<T>(Value));
        //}

        private void Add(T Value)
        {
            lista.Add(Value);

            this.OnAdded(new ChangedEventArgs2<T>(Value));
        }

        public T Get(int i) => lista[i];

        public void Set(int index, T Value)
        {
            lista[index] = Value;
            this.OnUpdated(new ChangedEventArgs2<T>(Value));
        }

        public void RemoveAt(int index)
        {
            T Value = lista[index];
            lista.RemoveAt(index);
            this.OnRemoved(new ChangedEventArgs2<T>(Value));
        }

    }
    public class ChangedEventArgs2<T> : EventArgs
    {

        public T value;
        public ChangedEventArgs2(T value)
        {
            this.value = value;
        }
    }
}
