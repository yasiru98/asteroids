//Author: Yasiru Karunawansa
//Purpose: spawn bullets based on the ships position
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnBullets : MonoBehaviour {
    public GameObject bullet;
    private Vector3 direction;
    private Vector3 position;
    private Vehicle shipScript;

    public float fireRate = 0.5F;
    private float nextFire = 0.0F;

    public AudioClip shootSound;

    // Use this for initialization
    void Start () {

        GameObject ship = GameObject.Find("SpaceShipSmall");
        shipScript = ship.GetComponent<Vehicle>();


    }

    // Update is called once per frame
    void Update () {

        

        direction = shipScript.direction;//get direction of ship
        position = shipScript.vehiclePosition;
 
            if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)//Timing mechanism to prevent bullet spam
            {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, position, Quaternion.identity);

            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position);
        }
        
    }


}
