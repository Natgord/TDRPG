using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningRock : MonoBehaviour
{
    public Resource rocks;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rocks.amount <= 0)
        {
            Destroy(gameObject);
        }
    }
}
