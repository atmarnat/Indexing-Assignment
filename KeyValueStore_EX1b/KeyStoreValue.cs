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
                //Loops through the whole array
                //if the KeyValue.Key is equal to the desired index
                //then it will return the KeyValue.Value object that is paired with the Key
                for (int i = 0; i < ar.Length; i++)
                {
                    if (ar[i].Key == index)
                        return ar[i].Value;
                }
                //if the loop finishes, then a KeyValue string was not found equal to index
                //so it throws an exception
                throw new KeyNotFoundException(index);
            }
            set
            {
                //Loops through the whole array
                //if the KeyValue.Key is equal to the index
                //Then it will overwrite that spot in the array with a new KeyValue struct
                //it will then jump out of 'set', as the rest is not needed 
                for (int i = 0; i < ar.Length; i++)
                {
                    if (ar[i].Key == index)
                    {
                        ar[i] = new KeyValue(index, value);
                        return;
                    }
                }
                
                //if we make it here, then the index was not found in the array for any KeyValue.Key
                //There fore, the next step is to find an empty spot in the array to store a new KeyValue with the desired key, and the desired value
                //So, loop through the whole array
                
                //If the KeyValue.Key is equal to null (this happened for all of the slots in the array when it was initialized)
                //Then overwrite that index with a new KeyValue struct
                //increment the count, so that we can keep track of how many different KeyValue structs are stored in the array
                //then jump out of the set statement with the return.
                for (int i = 0; i < ar.Length; i++)
                {
                    if (ar[i].Key == null)
                    {
                        ar[i] = new KeyValue(index, value);
                        count++;
                        return;
                    }
                }
                //there is a bug in the code
                //if you store 10 different KeyValues into the array, then you cannot store any more, as the loop will never find a KeyValue.Key equal to null if 10 already were set
            }
        }
    }
}
