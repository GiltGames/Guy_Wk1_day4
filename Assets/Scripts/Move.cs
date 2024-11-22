using UnityEngine;

public class Move : MonoBehaviour
{

    public float alienSp = 2;
    public float alienUL = 10;
    public float alienLL = -10;
    public Score Scr;
    Vector3 strtPosA;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        strtPosA = transform.position;
        Debug.Log("Start: "+strtPosA);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate (alienSp * Time.deltaTime,0,0); 

        if (transform.position.x > alienUL)
        {
            transform.position = new Vector3(alienLL, strtPosA.y, 0);

        }
        Debug.Log("Ongoing: " + strtPosA);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.position = new Vector3(alienLL, strtPosA.y, 0);
        Scr.gameScore += 1;
        Debug.Log("Change: " + strtPosA);
    }
}
