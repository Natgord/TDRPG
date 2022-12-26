using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public GameObject[] buildings;
    public int selectedBuild = 0;

    Animator characterAnimator;
    public Resource rocks;
    public Resource logs;
    public float miningDelay = 0f;
    float lastMining = 0f;

    // Start is called before the first frame update
    void Start()
    {
        characterAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Instantiate(buildings[selectedBuild], transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        switch(other.name)
        {
            case "MiningRock":
                if (characterAnimator.GetBool("isMining"))
                {
                    if(miningDelay < Time.time - lastMining)
                    {
                        rocks.amount += other.gameObject.GetComponent<MiningRock>().rocks.TakeResource(2);
                        lastMining = Time.time;
                    }

                }
                break;

            case "CuttingWood":
                if (characterAnimator.GetBool("isMining"))
                {
                    if (miningDelay < Time.time - lastMining)
                    {
                        logs.amount += other.gameObject.GetComponent<CuttingWood>().logs.TakeResource(2);
                        lastMining = Time.time;
                    }

                }
                break;

            default:
                break;
        }
    }

}
