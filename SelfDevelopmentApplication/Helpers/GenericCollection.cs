using System;

namespace SelfDevelopmentApplication.Helpers
{
    class GenericCollection<T> : ObservableObject
    {
        private T[] _array;

        public T this[int i]
        {
            get => _array[i];
            set
            {
                _array[i] = value;
                _ParentClassAction?.Invoke();
                OnPropertyChanged();
            }
        }

        private readonly Action _ParentClassAction;

        public GenericCollection(T[] array, Action ParentClassAction = null)
        {
            _array = array;
            _ParentClassAction = ParentClassAction;
        }
    }
}
