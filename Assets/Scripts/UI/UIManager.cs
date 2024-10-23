using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] private UIFrame[] frameArray;
    [SerializeField] private GameObject strikeImage;
    [SerializeField] private GameObject spareImage;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TextMeshProUGUI totalScoreText;

    private int currentFrameIndex;

    // Start is called before the first frame update
    void Start()
    {
        int frameNumber = 1;

        foreach (UIFrame frame in frameArray)
        {
            frame.SetFrameNumber(frameNumber);
            frameNumber++;
        }


    }
    public void displayGameOverScreen(int totalScore)
    {
        totalScoreText.text = "TOTAL SCORE: " + totalScore.ToString();
        gameOverScreen.SetActive(true);
    }

    public void updateFirstThrowOnFrame(int currentFrameIndex, int throwScore)
    {
        frameArray[currentFrameIndex - 1].SetFirstThrowScore(throwScore);
    }

    public void updateSecondThrowOnFrame(int currentFrameIndex, int throwScore)
    {
        frameArray[currentFrameIndex - 1].SetSecondThrowScore(throwScore);
    }

    public void updateTotalScoreOnFrame(int currentFrameIndex, int totalScore)
    {
        frameArray[currentFrameIndex - 1].SetTotalScore(totalScore);
    }

    public void displayStrike()
    {
        strikeImage.SetActive(true);
        Invoke("hideImages", 2);
    }

    public void displaySpare()
    {
        spareImage.SetActive(true);
        Invoke("hideImages", 2);
    }

    private void hideImages()
    {
        strikeImage.SetActive(false);
        spareImage.SetActive(false);   
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
