using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private int throwCounter;
    [SerializeField] private Pin[] pins;

    // Start is called before the first frame update
    void Start()
    {
        StartThrow();

    }
    public void BallOnPit()
    {
        throwCounter++;

      
      
        Invoke("StartThrow", 3);
      

    }
    public void StartThrow()
    {
        CheckForFallenPins();

        if (throwCounter == 2)
        {
            RepositionPins();
            throwCounter = 0;
        }

        Instantiate(ballPrefab, transform.position, transform.rotation);
        
    }

    void RepositionPins()
    {

        foreach(Pin p in pins)
        {
            p.gameObject.SetActive(true);
            p.ResetPinToOrigin();
        }

    }

    void CheckForFallenPins()
    {
        int score = 0;

        foreach (Pin pin in pins)
        {
            if (pin.IsPinFallen())
            { 
                score++;
                pin.gameObject.SetActive(false);

            }
        }

        Debug.Log(score);
    }

}