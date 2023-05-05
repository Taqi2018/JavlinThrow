using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoulScript : MonoBehaviour
{
    public GameObject player;
    Vector3 playerStartPosition;
    // Start is called before the first frame update
    void Start()
    {
        playerStartPosition=player.transform.position;
    }


    private void OnCollisionEnter(Collision collision)
    {


        
       
        if (collision.collider.tag == "Javelin")
        {
            Debug.Log("collide"); 
           
            player.transform.position = playerStartPosition;
            
        } 
    }
}
