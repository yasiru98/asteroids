//Author: Yasiru Karunawansa
//Purpose: controls game GUI
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager: MonoBehaviour {

    public  int shipHealth;
    public  int playerScore;
    
    // Use this for initialization
    void Start () {
        playerScore = 0;
        shipHealth = 3;
	}
	
	// Update is called once per frame
	void Update () {
      
    }
    void OnGUI()
    {
        GUI.skin.label.fontSize = 100;
        GUI.color = Color.magenta;
        GUI.skin.box.wordWrap = true;
        GUI.Box(new Rect(20, 20, 100, 20), "Score: " +
            playerScore);

        GUI.Box(new Rect(150, 20, 100, 20), "Lives: " +
         shipHealth);


    }
    /// <summary>
    /// score addition based on asteroid type
    /// </summary>
    public void updateScoreStage2()//score for stage 2 asteroids
    {
        playerScore = playerScore + 50;
    }
    public void updateScoreStage1()
    {
        playerScore = playerScore + 20;//scorefor stage 1 asteroids
    }

    /// <summary>
    /// ship life reduction
    /// </summary>
    public void updateShipHealth1()
    {
        shipHealth = 2;
    }
    public void updateShipHealth2()
    {
        shipHealth = 1;
    }
}
