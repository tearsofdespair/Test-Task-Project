using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPolller : MonoBehaviour
{

    public List<Pool> Pools;
    public Dictionary<string, Queue<GameObject>> PoolDictionary;
    // Start is called before the first frame update
    void Start()
    {
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();
    }

    
}
