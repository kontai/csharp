using System.Collections.Generic;
using System.ComponentModel;

namespace MySecondWPFProject
{
    public class Student : INotifyPropertyChanged
    {
        private string name;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            set
            {
                this.name = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
            get { return name; }
        }
    }
}