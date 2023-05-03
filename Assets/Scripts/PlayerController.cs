using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;
    public float speed;
    public Transform cam;
    public bool isWalking;
    public  bool isRunning;
    public float walkTime;
    public float throwTime;
    public bool isThrowing;

    public static PlayerController instance;
  
    private void Start()
    {
        instance = this;
      

    }

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            isThrowing = true;
            isWalking = false;
            isRunning = false;

            StartCoroutine(Throw());
           
    


        }

        if(!isThrowing)
        {

            
            float vertical = Input.GetAxisRaw("Vertical");
            // float horizantol = Input.GetAxisRaw("Horizontal");
            Vector3 inputDirection = new Vector3(0, 0, vertical).normalized;
            if (inputDirection.magnitude > 0.1)
            {

                isWalking = true;
                float faceAngle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                transform.rotation = Quaternion.Euler(0, faceAngle, 0);
                Vector3 dirWithCam = Quaternion.Euler(0, faceAngle, 0) * Vector3.forward;

                if (isWalking)
                {
                    characterController.Move(dirWithCam * speed*walkTime* Time.deltaTime);
                    walkTime += 1 * Time.deltaTime;
                    if (walkTime >= 2)
                    {
                        isWalking = false;
                        isRunning = true;
                    }

                }
                if (isRunning)
                {
                    characterController.Move(dirWithCam * speed * 1.5f * Time.deltaTime);
                }

            }

            if (inputDirection.magnitude < 0.1)
            {
                walkTime = 0.1f;
                isWalking=false;
                isRunning = false;
            }


        }
        IEnumerator Throw()
        {
            yield return new WaitForSeconds(throwTime);
            isThrowing = false;
            Debug.Log(isThrowing);

        }
    }

 
  
}
