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
    public float force;
    public Rigidbody javelin;

    public bool throwAfterAnimation;

    public bool isThrowing;


    public static PlayerController instance;
  
    private void Start()
    {
        instance = this;
       // StartCoroutine(PlayerState());


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


       
        if (!isThrowing)
        {


            float vertical = Input.GetAxisRaw("Vertical");
            //float horizantol = Input.GetAxisRaw("Horizontal");
            Vector3 inputDirection = new Vector3(0, 0, vertical).normalized;
            float faceAngle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            transform.rotation = Quaternion.Euler(0, faceAngle, 0);

            if (inputDirection.magnitude > 0.1)
            {

                isWalking = true;

                transform.rotation = Quaternion.Euler(0, faceAngle, 0);
                Vector3 dirWithCam = Quaternion.Euler(0, faceAngle, 0) * Vector3.forward;

                if (isWalking)
                {
                    characterController.Move(dirWithCam * speed * Time.deltaTime);
                    walkTime += 1 * Time.deltaTime;
                    if (walkTime >= 2)
                    {
                        isWalking = false;
                        isRunning = true;
                    }

                }
                if (isRunning)
                {
                    characterController.Move(dirWithCam * speed * 1.2f * Time.deltaTime);
                }

            }

            if (inputDirection.magnitude < 0.1)
            {
                walkTime = 0.1f;
                isWalking = false;
                isRunning = false;
            }


        }





    }
    public IEnumerator Throw()
    {



        yield return new WaitForSeconds(1.5f);
        throwAfterAnimation = true;
        yield return new WaitForSeconds(throwTime-1.5f);

        isThrowing = false;
       


    }

    public IEnumerator PlayerState()
    {
        yield return new WaitForSeconds(0.3f);
        if (!isThrowing)
        {


            float vertical = Input.GetAxisRaw("Vertical");
            //float horizantol = Input.GetAxisRaw("Horizontal");
            Vector3 inputDirection = new Vector3(0, 0, vertical).normalized;
            float faceAngle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            transform.rotation = Quaternion.Euler(0, faceAngle, 0);

            if (inputDirection.magnitude > 0.1)
            {

                isWalking = true;

                transform.rotation = Quaternion.Euler(0, faceAngle, 0);
                Vector3 dirWithCam = Quaternion.Euler(0, faceAngle, 0) * Vector3.forward;

                if (isWalking)
                {
                    characterController.Move(dirWithCam * speed * Time.deltaTime);
                    walkTime += 1 * Time.deltaTime;
                    if (walkTime >= 2)
                    {
                        isWalking = false;
                        isRunning = true;
                    }

                }
                if (isRunning)
                {
                    characterController.Move(dirWithCam * speed * 1.2f * Time.deltaTime);
                }

            }

            if (inputDirection.magnitude < 0.1)
            {
                walkTime = 0.1f;
                isWalking = false;
                isRunning = false;
            }


        }
        StartCoroutine(PlayerState());
    }




}
