using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField] private Rigidbody myRigidbody;
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    public void ResetPinToOrigin()
    {
        myRigidbody.velocity = Vector3.zero;
        myRigidbody.angularVelocity = Vector3.zero;

        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPinFallen())
        {
            Debug.Log("Fell");
        }
    }


    public bool IsPinFallen()
    {
        if (transform.rotation.x > 0.1f || transform.rotation.x < -0.1f 
            || transform.rotation.z > 0.1f || transform.rotation.z < -0.1f)
        {
            return true;
        }
        else
        {
            return false;
        }   

    }

   
   
}
