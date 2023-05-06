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

    private void OnTriggerEnter(Collider other)
    {
        if (!respwan)
        {




           
                Debug.Log("collide");



                player.transform.position = playerStartPosition;
                player.transform.rotation = playerStartRotation;
                respwan = true;
                TurnsLeft();







        
        }
    }

  /*  private void OnCollisionEnter(Collision collision)
    {

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
*/
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
