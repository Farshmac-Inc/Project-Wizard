using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool 
{
    public Transform Container { get; private set; }

    public Queue<GameObject> Object;

    public Pool(Transform _container)
    {
        Container = _container;
        Object = new Queue<GameObject>();
    }
}
