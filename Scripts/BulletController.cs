//Author: Yasiru Karunawansa
//Purpose: control bullet behaviour
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
 
    private Vector3 direction;
    private Vector3 position;
    private Vehicle shipScript;


	// Use this for initialization
	void Start () {

        GameObject ship = GameObject.Find("SpaceShipSmall");
        shipScript = ship.GetComponent<Vehicle>();
      

    } 
	
	// Update is called once per frame
	void Update () {
        direction = shipScript.direction;//ship direction
        position = shipScript.vehiclePosition;
     
        this.gameObject.transform.position += direction *Time.deltaTime* 50;
        Destroy(this.gameObject, 1);//destroy bullet after 1 second

        if (this.gameObject.transform.position.x > 14.9 || this.gameObject.transform.position.x < -14.9 || this.gameObject.transform.position.y>6.4 || this.gameObject.transform.position.y < -6.8)//destroy bullet if out of bounds
        {
            Destroy(this.gameObject);
        }

    }
   
}
