using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
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
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; //0.166666666 = 60fps
        //IF you click
        if (Input.GetButton("Fire1") && timer > shootDelay)
        {
            timer = 0; //reset the timer
            //shoot towards the mouse cursor 
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;
            Vector3 mouseDir = mousePos - transform.position;
            //normalize the vector so we don't have wonky speeds
            mouseDir.Normalize();
            //spawn in the bullet
            GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
            //push the bullet towards the mouse
            bullet.GetComponent<Rigidbody2D>().velocity = mouseDir * bulletspeed;
            Destroy(bullet, bulletLifetime);
        }
    }
}
