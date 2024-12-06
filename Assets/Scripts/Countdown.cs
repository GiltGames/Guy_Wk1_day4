using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{

    public float TimeLeft = 60;
    public int TimeLeftSec;
    public string TimeDisplay;
    public TextMeshProUGUI TimeOutput;
    public bool GameEnd = false;
    
    public OutofBound OOB;
    public TextMeshProUGUI GameOver;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       GameEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Count down
        if (TimeLeft < 0)
        {
            GameEnd = true;

        }

      

        if (GameEnd == false)
        {
            // count down
            
            TimeLeft = TimeLeft - Time.deltaTime;
        }
        
        //Game ends
        else
        {



            TimeLeft = 0;
            OOB.fired = true;
            GameOver.text = "Game Over";

        }
        
        //Display Time

        TimeLeftSec = Mathf.FloorToInt(TimeLeft);
        TimeDisplay = "Time Left: " + TimeLeftSec;
        TimeOutput.text = TimeDisplay;
        
      

    }
}
