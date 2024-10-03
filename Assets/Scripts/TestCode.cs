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
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movingDirection * Time.deltaTime);

        if (Input.GetMouseButton(0)) // 'true or false'
        {
           transform.Rotate(0, 0, 180 * Time.deltaTime);
        }

        if (Input.GetMouseButton(1)) // 'true or false'
        {
            transform.Rotate(0, 0, -180 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            movingDirection.x = 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movingDirection.x = -1;
        }

        transform.Translate(movingDirection * Time.deltaTime);
        movingDirection.x = 0;

        if (Time.realtimeSinceStartup > 5 && 3 > 0) // 'AND'
        {

        }

        if (Time.realtimeSinceStartup > 5 || 3 > 0) // || 'OR'
        {
            //transform.Rotate(0, 0, 180 * Time.deltaTime);
        }

        //UnityEngine.Debug.Log(transform.position);
    }
}
