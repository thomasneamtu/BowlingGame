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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) && !wasThrown)
        {
            wasThrown = true;
            aimingArrow.SetActive(false);
            myRigidbody.AddForce(aimingArrow.transform.forward * throwStrength, ForceMode.VelocityChange);
        }
    }
}