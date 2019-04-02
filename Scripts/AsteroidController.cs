//Author: Yasiru Karunawansa
//Purpose: control behaviour of an asteroid
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidController : MonoBehaviour {
    public float calculateX;
    public GameObject bullet;

    private GameObject spaceShip;
    private Vector3 bulletPos;
    private GameObject ship;
    private GameObject gui;
    private GUIManager guiScript;
    private bool colliding;
    private bool colliding2;

    public int shipHealth;
    public int playerScore;

    public AudioClip shipDestroy;
    public AudioClip asteroidExplosion;

    public GameObject[] bullets;
    public GameObject[] stage2Asteroids;
    // Use this for initialization
    void Start() {
        calculateX = Random.Range(-0.5f, 0.5f);//random x pos for asteroids


    }

    // Update is called once per frame
    void Update() {
        bullets = GameObject.FindGameObjectsWithTag("Bullet");

        ship = GameObject.Find("SpaceShipSmall");

        gui = GameObject.Find("SceneManager");

     

        CheckCollisionBullets(bullets);
        CheckCollisionShip();
    
        MoveAsteroid(calculateX);
        if (this.gameObject.transform.position.y < -6)//destroy if out of bounds
        {
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// vector based movement of asteroids
    /// </summary>
    void MoveAsteroid(float xCoord)
    {

        this.gameObject.transform.Translate(new Vector3(xCoord, -0.5f) * Time.deltaTime, Space.World);//move object
        this.gameObject.transform.Rotate(new Vector3(0, 0, 0.3f));

    }

    /// <summary>
    /// check for collision against bullets
    /// </summary>
    void CheckCollisionBullets(GameObject[] bulletArray){
        foreach (GameObject bullet in bullets)
        {
            if(bullet == null)
            {
                break;
            }
            else
            {
                bulletPos = bullet.transform.position;
                if (Vector3.Distance(bulletPos, this.gameObject.transform.position) < this.GetComponent<Renderer>().bounds.extents.magnitude)
                {
                    AudioSource.PlayClipAtPoint(asteroidExplosion, Camera.main.transform.position);
                    Destroy(bullet);
                    Destroy(this.gameObject);
                    gui.GetComponent<GUIManager>().updateScoreStage2();

                    if (this.gameObject.tag !="Stage2")//in not stage2 asteroid initiate 2 stage 2 asteroids
                    {
                        Instantiate(stage2Asteroids[Random.Range(0, 3)], this.transform.position, Quaternion.identity);
                        Instantiate(stage2Asteroids[Random.Range(0, 3)], this.transform.position, Quaternion.identity);
                        gui.GetComponent<GUIManager>().updateScoreStage1();
                    }
                  

                }
            }
        }
      
    }

    /// <summary>
    /// check collision against ship
    /// </summary>
    void CheckCollisionShip()
    {

        if (Vector3.Distance(ship.transform.position, this.gameObject.transform.position) < this.GetComponent<Renderer>().bounds.extents.magnitude && gui.GetComponent<GUIManager>().shipHealth == 3)
        {

            colliding = true;

            gui.GetComponent<GUIManager>().updateShipHealth1();//decrease ship life

            AudioSource.PlayClipAtPoint(asteroidExplosion, Camera.main.transform.position);


        }
        else if (Vector3.Distance(ship.transform.position, this.gameObject.transform.position) < this.GetComponent<Renderer>().bounds.extents.magnitude && gui.GetComponent<GUIManager>().shipHealth == 2 && colliding != true)
        {

            colliding2 = true;
            gui.GetComponent<GUIManager>().updateShipHealth2();
            AudioSource.PlayClipAtPoint(asteroidExplosion, Camera.main.transform.position);
     
      

        }
        else if (Vector3.Distance(ship.transform.position, this.gameObject.transform.position) < this.GetComponent<Renderer>().bounds.extents.magnitude && gui.GetComponent<GUIManager>().shipHealth == 1   &&   colliding2 != true)
        {
            AudioSource.PlayClipAtPoint(shipDestroy, Camera.main.transform.position);
            Destroy(ship);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);//Restart the game

        }


    }

}
