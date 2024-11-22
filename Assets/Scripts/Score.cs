using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{

    public int gameScore = 0;
  
    public TextMeshProUGUI scoreF;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreF.text = "Score: " + gameScore;
      Debug.Log(scoreF.text);
    }
}
