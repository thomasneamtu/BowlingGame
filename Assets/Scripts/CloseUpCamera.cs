using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    

public class CloseUpCamera : MonoBehaviour
{
    [SerializeField] private GameObject alternateCamera;
    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            alternateCamera.SetActive(true);
            Invoke("TurnOffCamera", 2.5f);
        }
    }

    private void TurnOffCamera()
    {
        alternateCamera.SetActive(false);
    }
}
