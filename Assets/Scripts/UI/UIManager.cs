using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private UIFrame[] frameArray;
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
    public void updateFirstThrowOnFrame(int currentFrameIndex, int throwScore)
    {
        frameArray[currentFrameIndex - 1].SetFirstThrowScore(throwScore);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
