using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace KeyValueStore_EX1b
{
    public struct KeyValue
    {
        public KeyValue(string key, object value)
        {
            this.Key = key;
            this.Value = value;
        }
        public readonly string Key;
        public readonly object Value;
    }

    public class MyDictionary
    {
        int count = 0;
        KeyValue[] ar = new KeyValue[10];

        public object this[string index]
        {
            get
            {
                //searches for the key, then returns the value if found
                for (int i = 0; i < ar.Length; i++)
                {
                    if (ar[i].Key == index)
                        return ar[i].Value;
                }
                throw new KeyNotFoundException(index);
            }
            set
            {
                //checks for the key
                for (int i = 0; i < ar.Length; i++)
                {
                    if (ar[i].Key == index)
                    {
                        ar[i] = new KeyValue(index, value);
                        return;
                    }
                }
                //if the key is not found, checks for the first index
                for (int i = 0; i < ar.Length; i++)
                {
                    if (ar[i].Key == null)
                    {
                        ar[i] = new KeyValue(index, value);
                        count++;
                        return;
                    }
                }
            }
        }
    }
}
