using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Calculator
{
    public class Queue
    {
        private string[] _array = new string[50];
        private int _first = 0;
        private int _last = 0;
        private int _count = 0;
        public void Enqueue(string element) 
        {
            if (_count == 50) throw new Exception("Черга переповнена");
            _array[_last] = element;
            _last = (_last + 1) % 50;
            _count++;
        }

        public string[] ToArray() 
        {
            string[] arr = new string[_count];
            for (int i = 0; i < _count; i++) arr[i] = _array[(i+_first)%50];
            return arr;
        }
        public string Dequeue()
        { 
            if(_count == 0) throw new Exception("Черга порожня");
            string element = _array[_first];
            _first = (_first + 1) % 50;
            _count--;
            return element;
        }
    }
}
