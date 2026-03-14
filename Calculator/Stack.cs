using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorAlgorithm
{
    public class Stack
    {
        private string[] _array = new string[50];
        private int _pointer = 0;

        public string Peek() { return _pointer == 0 ? null : _array[_pointer-1]; }
        public void Push(string value) 
        {
            if (_pointer == _array.Length)
            {
                throw new Exception("Stack overflowed");
            }
            _array[_pointer] = value;
            _pointer++;
        }

        public string Pop()
        {
            if (_pointer == 0)
            {
                throw new Exception("Stack is empty");
            }
            _pointer--;
            var value = _array[_pointer];
            return value;
        }
    }
}
