
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavelinThrower : MonoBehaviour
{
    public static JavelinThrower instance;
    public Rigidbody javelin;
    public Transform throwPoint;
    public Camera mainCamera, javelinCamera;
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
            javelin.rotation = throwPoint.transform.rotation;
        }



        if (PlayerController.instance.throwAfterAnimation)
        {

            
            javelinCamera.gameObject.SetActive(true);
            javelinCamera.enabled = true;

            mainCamera.gameObject.SetActive (false);
            mainCamera.enabled = false;


            PlayerController.instance.throwAfterAnimation = false;
            shouldRotate = false;
            javelin.isKinematic = false;





            javelin.velocity = throwPoint.transform.forward * force * Time.deltaTime;
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
        if (collision.collider.tag== "30METERS")
        {
            javelin.isKinematic = true;
            Debug.Log("30Meters");
        }

    }
   
    }






