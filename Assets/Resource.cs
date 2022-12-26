using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class Resource
{
    [SerializeField]
    public int amount;

    public int TakeResource(int takeAmount)
    {
        // Declare local varables
        int amountTaken = 0;

        // Check if the amount to take fit in left amount
        if (takeAmount <= amount)
        {
            // Take resource with request amount
            amount -= takeAmount;
            amountTaken = takeAmount;
        }
        else
        {
            // Take the rest of the resource
            amountTaken = amount;
            amount = 0;
        }

        // Return the amount taken
        return amountTaken;
    }
}
