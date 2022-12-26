using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public float coolDown { set; get; } = 0f;
    float lastActiveTime = 0f;

    // Update is called once per frame
    public void UpdateSkill()
    {
        if (CheckConditions())
        {
            Activate();
            lastActiveTime = Time.time;
        }
    }
    private void Update()
    {
        if (CheckConditions())
        {
            Activate();
            lastActiveTime = Time.time;
        }
    }

    public bool CheckConditions()
    {
        // Declare local variables
        bool succeed = true;

        // Check if the delay to spawn an enemy is reached
        succeed &= CheckCoolDown();

        // Return true if everything passed
        return succeed;
    }

    public bool CheckCoolDown()
    {
        // Check if the delay to spawn an enemy is reached
        if (coolDown <= (Time.time - lastActiveTime))
            return true;

        return false;
    }

    new public virtual void Activate() { }
}
