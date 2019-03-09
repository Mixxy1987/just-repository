using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace Common
{
    public class CustomObsCollection<T> : ObservableCollection<T>
    {
        ICollectionView _view;

        public CustomObsCollection()
        {
            _view = CollectionViewSource.GetDefaultView(this);
        }

        public void UpdateCollection()
        {
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(
                NotifyCollectionChangedAction.Reset));
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    AddPropertyChanged(e.NewItems);
                    break;

                case NotifyCollectionChangedAction.Remove:
                    RemovePropertyChanged(e.OldItems);
                    break;

                case NotifyCollectionChangedAction.Replace:
                case NotifyCollectionChangedAction.Reset:
                    RemovePropertyChanged(e.OldItems);
                    AddPropertyChanged(e.NewItems);
                    break;
            }

            base.OnCollectionChanged(e);
        }

        private void AddPropertyChanged(IEnumerable items)
        {
            if (items != null)
            {
                foreach (var obj in items.OfType<INotifyPropertyChanged>())
                {
                    obj.PropertyChanged += OnItemPropertyChanged;
                }
            }
        }

        private void RemovePropertyChanged(IEnumerable items)
        {
            if (items != null)
            {
                foreach (var obj in items.OfType<INotifyPropertyChanged>())
                {
                    obj.PropertyChanged -= OnItemPropertyChanged;
                }
            }
        }

        private void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            bool sortedPropertyChanged = false;
            foreach (SortDescription sortDescription in _view.SortDescriptions)
            {
                if (sortDescription.PropertyName == e.PropertyName)
                    sortedPropertyChanged = true;
            }

            if (sortedPropertyChanged)
            {
                NotifyCollectionChangedEventArgs arg = new NotifyCollectionChangedEventArgs(
                    NotifyCollectionChangedAction.Replace, sender, sender, this.Items.IndexOf((T) sender));

                OnCollectionChanged(arg);
            }
        }
    }
}
