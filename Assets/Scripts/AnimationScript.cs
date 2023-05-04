using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class AnimationScript : MonoBehaviour
{
    public Animator Animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (PlayerController.instance.isWalking)
        {
            Debug.Log("Walk!!!");
            Animator.SetBool("isWalking", true);
        }
        if (!PlayerController.instance.isWalking)
        {
            Animator.SetBool("isWalking", false);
        }

        if (PlayerController.instance.isRunning)
        {
            Animator.SetBool("isRunning", true);
            Animator.SetBool("isWalking", false);
        }
        if (!PlayerController.instance.isRunning)
        {
            Animator.SetBool("isRunning", false);
          
        }
        if (PlayerController.instance.isThrowing)
        {
            Animator.SetBool("isThrowing", true);
            Animator.SetBool("isWalking", false);
            Animator.SetBool("isRunning", false);

        }
        if (!PlayerController.instance.isThrowing )
        {
            Animator.SetBool("isThrowing", false);
          
        }

    }
}