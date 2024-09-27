using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = GetComponent<Rigidbody2D>().velocity.x;
        float yInput = GetComponent<Rigidbody2D>().velocity.y;
        GetComponent<Animator>().SetFloat("x", xInput);
        GetComponent<Animator>().SetFloat("y", yInput);
    }
}
