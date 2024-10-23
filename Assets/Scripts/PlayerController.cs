using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private bool wasThrown;
    [SerializeField] private float throwStrength;
    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] private GameObject aimingArrow;
    [SerializeField] private AudioSource rollingSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    
    // Update is called once per frame
    void Update()
    {
        MoveBall();
        ThrowingBall();

    }



    void MoveBall()
    {
        if (!wasThrown)
        {
            transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime, 0, 0);
        }
        
    }

    void ThrowingBall()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !wasThrown)
        {
            wasThrown = true;
            aimingArrow.SetActive(false);
            myRigidbody.AddForce(aimingArrow.transform.forward * throwStrength, ForceMode.Impulse);
            rollingSource.Play();
            //play rolling sound

            Invoke("StopThrow", 10f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Respawn"))
        StopThrow();
    }
    void StopThrow()
    {
        FindObjectOfType<GameManager>().BallOnPit();
        Destroy(gameObject, 1f);
    }
}