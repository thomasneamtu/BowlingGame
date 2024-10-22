using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UIElements;

public class TestCode : MonoBehaviour
{

    public Vector3 movingDirection;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateNewPlatform", 5, 5); // Reapeating Spawn COULD CREATE PLATFORMS
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movingDirection * Time.deltaTime);

        
       
    }
    void CreateNewPlatform()
    {
        // CREATE NEW PLATFORM FOR NEW POSITION
             // LOOK INTO INSTANTIATE()

        Destroy(gameObject);
        Invoke("CreateNewPlatform", 4f);
    }
}
