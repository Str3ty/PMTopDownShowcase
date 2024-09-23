using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmemyAI : MonoBehaviour
{
    GameObject player;
    [SerializeField]
    float chasespeed = 5.0f;
    [SerializeField]
    float chaseTriggerDistance = 10f;
    [SerializeField]
    bool goHome = true;
    Vector3 homePosition;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        homePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //the chase direction is destination - enemy starting position
        Vector3 playerPosition = player.transform.position;
        Vector3 chaseDir = playerPosition - transform.position;
        Vector3 homeDir = homePosition - transform.position;
        if (chaseDir.magnitude < chaseTriggerDistance)
        {

            //move toward the player
            chaseDir.Normalize();
            GetComponent<Rigidbody2D>().velocity = chaseDir * chasespeed;
        }
        else if (goHome)
        {
            if (homeDir.magnitude < 0.1f)
            {
                transform.position = homePosition;
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            }
            else
            {

                homeDir.Normalize();
                GetComponent<Rigidbody2D>().velocity = homeDir * chasespeed;
            }
        
        }
        else
        {
            //if the player is NOT close, stop moving
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }
}
