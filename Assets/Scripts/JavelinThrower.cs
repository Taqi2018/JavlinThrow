
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavelinThrower : MonoBehaviour
{
    public static JavelinThrower instance;
    public Rigidbody javelin;
    public Transform throwPoint;
    public Transform cam;
    public float force;
    bool shouldRotate;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        shouldRotate = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldRotate)
        {
            javelin.rotation = cam.rotation;
        }
       


        if (PlayerController.instance.throwAfterAnimation)
        {
            PlayerController.instance.throwAfterAnimation=false;
            shouldRotate = false;
            javelin.isKinematic = false;
            

      
     

            javelin.velocity = cam.forward * force*Time.deltaTime;
            transform.SetParent(null);



        }




    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            javelin.isKinematic = true;
            Debug.Log("Hit");
        }
    }






}
