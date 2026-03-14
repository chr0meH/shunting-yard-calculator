using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorAlgorithm
{
    public class ArrayList<T>
    {
        private T[] _array = new T[10];
        private int _pointer = 0;
        
        public void Add(T element)
        {
            _array[_pointer] = element;
            _pointer += 1;

            if (_pointer == _array.Length)
            {
                var extendedArray = new T[_array.Length * 2];
                for (var i = 0; i < _array.Length; i++)
                {
                    extendedArray[i] = _array[i];
                }

                _array = extendedArray;
            }
        }

        public void Remove(T element)
        {
            for (var i = 0; i < _pointer; i++)
            {
                if (EqualityComparer<T>.Default.Equals(_array[i], element))
                {
                    for (var j = i; j < _pointer - 1; j++)
                    {
                        _array[j] = _array[j + 1];
                    }

                    _pointer -= 1;
                    return;
                }
            }
        }

        public T GetAt(int index)
        {
            return _array[index];
        }

        public int IndexOf(T element)
        {
            for (var i = 0; i < _pointer; i++)
            {
                if (EqualityComparer<T>.Default.Equals(_array[i], element))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Contains(T element)
        {
            return IndexOf(element) != -1;
        }

        public int Count()
        {
            return _pointer;
        }
    }
}

