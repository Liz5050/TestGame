using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;

public class MyList<T> : List
{
    public void Push(T item)
    {
        this.Add(item);
    }
}
