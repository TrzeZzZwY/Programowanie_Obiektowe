using System;
using System.Collections.Generic;
using System.Text;


namespace lab_02
{
    public class Student : Person , IEquatable<Student>
    {
        protected string group;
        protected List<Task> tasks;
        public string Group { get => group;}
        public Student(string name, int age, string group):base(name,age)
        {
            this.group = group;
        }

        public void AddTask(string taskName, TaskStatus taskStatus) => tasks.Add(new Task(taskName, taskStatus));
        public void RemoveTask(int index) => tasks.RemoveAt(index);
        public void UpdateTask(int index, TaskStatus taskStatus) => tasks[index] = new Task(tasks[index].Name, taskStatus);
        public string RenderTasks(string prefix = "\t")
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in tasks)
                sb.AppendLine($"{prefix}{item}");
            return sb.ToString();
        }
        public override string ToString() => $"Student: {name} ({age} y.o)\n";

        public bool Equals(Student other)
        {
            if (other == null) return false;
            if (other == this) return true;
            return Object.Equals(this.name, other.name) && Object.Equals(this.group, other.group);
        }
        private bool SequenceEqual<T>(List<T> a, List<T> b) => Array.Equals(a, b);
    }
}
