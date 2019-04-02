//Author: Yasiru Karunawansa
//Purpose: spawn asteroids in waves
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour {
    public GameObject[] asteroids;

    public Vector3 spawnValues;
    public int asteroidCount;

    public float startWait;
    public float spawnWait;
    public float waveWait;
    // Use this for initialization
    void Start () {
        StartCoroutine(Spawn());
    }
	
	// Update is called once per frame
	void Update () {
       



    }


    /// <summary>
    /// spawn asteroids in wawes using a yeild statements to wait before 1st wave is spawned and in between waves
    /// </summary>
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(startWait);
        while(true){
            for (int i = 0; i < asteroidCount; i++)
            {
                Vector3 spawnPos = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRot = Quaternion.identity;
                GameObject asteroid = Instantiate(asteroids[Random.Range(0, 3)], spawnPos, spawnRot);
             
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    
    }

  
}
