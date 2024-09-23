using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    float bulletspeed = 10f;
    [SerializeField]
    float bulletLifetime = 2.0f;
    float timer = 0;
    [SerializeField]
    float shootDelay = 0.5f;
    GameObject player;
    [SerializeField]
    float shootDistance = 5;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //if player gets within certain distance
        Vector3 shootDir = player.transform.position - transform.position;
        if (shootDir.magnitude < shootDistance && timer > shootDelay)
        {
            //shoot towards the player
            //spawn the bullet
            GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
            //push the bullet towards the player
            shootDir.Normalize();
            bullet.GetComponent<Rigidbody2D>().velocity = shootDir * bulletspeed;
            //delay the next bullet
            timer = 0;
            Destroy(bullet, bulletLifetime);

        }
    }
}
