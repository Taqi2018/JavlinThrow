using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FoulScript : MonoBehaviour
{
    public GameObject player;
    Vector3 playerStartPosition;
    Quaternion playerStartRotation;
    

    int playerTurns;
    bool respwan;

    // Start is called before the first frame update
    void Start()
    {
        respwan= false;
        playerTurns = 3;


        playerStartPosition =player.transform.position;
        playerStartRotation = player.transform.rotation;
    }


    private void OnCollisionEnter(Collision collision)
    {
     
            if (collision.collider.name == "30Meters")
            {
                // javelin.isKinematic = true;
                Debug.Log("30Meters");
            }
        if (!respwan)
        {




            if (collision.collider.tag == "Javelin")
            {
                Debug.Log("collide");

       
                
                player.transform.position = playerStartPosition;
                player.transform.rotation = playerStartRotation;
                respwan = true;
               TurnsLeft();





               

            }
        }
    }

    void TurnsLeft()
    {
       // yield return new WaitForSeconds(0.2F);
        if (respwan)
        {

            playerTurns--;
            Debug.Log("Player turns left" + playerTurns);
            respwan = false;
        }
       
     
    }
}
