using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.HuntMonster
{
    public class Storage<T> where T : class
    {
        private List<T> Items = new List<T>();

        public int Count => Items.Count;
        public void Save(T item) 
        { 
            Items.Add(item);
            Debug.Log($"{item} 저장");

        }
        public T Get(int index) 
        { 
            if(index < 0 || index >= Items.Count)
            {
                return null;
            }
            return Items[index];
        }
        public T Get()
        {
            if (Items.Count == 0)
            {
                return null;
            }
            return Items[Items.Count - 1];
        }

    }
}
