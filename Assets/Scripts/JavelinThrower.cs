using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavelinThrower : MonoBehaviour
{
    public Rigidbody javelin;
    public float force;
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            javelin.isKinematic = false;
            javelin.AddRelativeForce(new Vector3(0, force, 0));
            Debug.Log("Throw!!");
        }
    }
}
