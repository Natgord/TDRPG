using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class CuttingWood : MonoBehaviour
{
    public Resource logs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (logs.amount <= 0)
        {
            Destroy(gameObject);
        }
    }
}
