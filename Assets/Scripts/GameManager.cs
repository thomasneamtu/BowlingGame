using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Pin[] pins;
    [SerializeField] private UIManager ui;
    [Header("Game Status")]
    [SerializeField] private int throwCounter;
    [SerializeField] private int maxAmountOfFrames;
    [SerializeField] private int currentFrame;
 
    [Header("Score Settings")]
    [SerializeField] private int totalScore;
    [SerializeField] private int firstThrowScore;
    [SerializeField] private int secondThrowScore;

    // Start is called before the first frame update
    void Start()
    {
        currentFrame = 1;
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

        if (throwCounter == 2 || firstThrowScore == 10) 
        {
           //Here is Strike or Spare moment

           StartNewFrame();
        }
        
        if (currentFrame > maxAmountOfFrames)
        {
            ui.displayGameOverScreen(totalScore);
            return;
        }
        
        
        Instantiate(ballPrefab, transform.position, transform.rotation);
        
    }
    void StartNewFrame()
    {
            totalScore += firstThrowScore + secondThrowScore;
            firstThrowScore = 0;
            secondThrowScore = 0;

            //Display Total Score
            ui.updateTotalScoreOnFrame(currentFrame, totalScore);

            throwCounter = 0;
            currentFrame++;
            RepositionPins();
            

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
            if (pin.IsPinFallen()&& pin.gameObject.activeInHierarchy)
            { 
                score++;
                pin.gameObject.SetActive(false);

            }
        }
        if(throwCounter == 1) //this is the moment where UI should be updated
        {
            firstThrowScore = score;
            ui.updateFirstThrowOnFrame(currentFrame, firstThrowScore);


            if (firstThrowScore == 10)
            {
                ui.displayStrike();
            }
        }  
        else if(throwCounter == 2)
        {
            secondThrowScore = score;
            ui.updateSecondThrowOnFrame(currentFrame, secondThrowScore);


            if (firstThrowScore + secondThrowScore == 10)
            {
                ui.displaySpare();
            }
        }
      
    }

}