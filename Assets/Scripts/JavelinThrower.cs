
using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JavelinThrower : MonoBehaviour
{
    public static JavelinThrower instance;
    public Rigidbody javelin;
    public Transform throwPoint;
    public Camera mainCamera, javelinCamera;
    public float force;
    bool shouldRotate;
    Transform startTransformJavelin;
    public GameObject parentPoint;
    public CinemachineFreeLook javelinFreelook;
    CinemachineBrain javelinBrain;
    int throws;
    public TextMeshProUGUI throwLeft;
    public TextMeshProUGUI howManyMeters;
    public TextMeshProUGUI gameOver;

    // Start is called before the first frame update
    void Start()
    {
        throws = 3;
        throwLeft.text = " Throws left = 3";
        instance = this;
        shouldRotate = true;
        startTransformJavelin=javelin.transform;
        javelinBrain=javelinCamera.GetComponent<CinemachineBrain>();


    }

    // Update is called once per fra
    void Update()
    {
        if (shouldRotate)
        {
            javelin.rotation = throwPoint.transform.rotation;
        }



        if (PlayerController.instance.throwAfterAnimation)
        {

            ThrowNow();
           
        }




    }

    private void ThrowNow()
    {
        throws--;
        throwLeft.text = "Throws left = "+Convert.ToString(throws);
        javelinCamera.gameObject.SetActive(true);
  
        javelinCamera.enabled = true;

        mainCamera.gameObject.SetActive(false);
        mainCamera.enabled = false;


        PlayerController.instance.throwAfterAnimation = false;
        shouldRotate = false;

        javelin.isKinematic = false;
        javelin.velocity = throwPoint.transform.forward * force * Time.deltaTime;

        SoundManager.instance.StartJavelinSound();
      
        transform.SetParent(null);

        StartCoroutine(RespawnJavelin());

    
    }

    IEnumerator RespawnJavelin()
    {
       yield return new WaitForSeconds(5.0f);
        howManyMeters.gameObject.SetActive(false);
        if (throws == 0)
        {
            gameOver.gameObject.SetActive(true);

            StartCoroutine(End());
        }


        javelin.isKinematic = true;
        javelin.transform.position = parentPoint.transform.position;
        javelin.transform.rotation = parentPoint.transform.rotation       ;

        transform.SetParent(parentPoint.transform);
      
        shouldRotate = true;


        mainCamera.gameObject.SetActive(true);
        mainCamera.enabled = true;


        javelinCamera.enabled = false;
        javelinCamera.gameObject.SetActive(false);

    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("Splash And Menu");
        
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
            howManyMeters.text = "Hit At 30 Meters";

            javelin.isKinematic = true;
          
            howManyMeters.gameObject.SetActive(true);
        }
        if (collision.collider.tag == "40METERS")
        {
            howManyMeters.text = "Hit At 40 Meters";
            javelin.isKinematic = true;
            howManyMeters.gameObject.SetActive(true);
        }
        if (collision.collider.tag == "50METERS")
        {

            howManyMeters.text = "Hit At 50 Meters";
            javelin.isKinematic = true;
            howManyMeters.gameObject.SetActive(true);
        }
        if (collision.collider.tag == "60METERS")
        {
            howManyMeters.text = "Hit At 60 Meters";
            javelin.isKinematic = true;
            howManyMeters.gameObject.SetActive(true);
        }
        if (collision.collider.tag == "70METERS")
        {
            howManyMeters.text = "Hit At 70 Meters";
            javelin.isKinematic = true;
            howManyMeters.gameObject.SetActive(true);
        }
        if (collision.collider.tag == "80METERS")
        {
            howManyMeters.text = "Hit At 80 Meters";
            javelin.isKinematic = true;
            howManyMeters.gameObject.SetActive(true);
        }

    }
   
    }






