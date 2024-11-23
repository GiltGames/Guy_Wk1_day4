using Unity.Hierarchy;
using UnityEngine;

public class ExplodeScript : MonoBehaviour
{
    public float ExpMinSiz = 0.1f;
    public float ExpMaxSiz =0.4f;
    public float ExpThresh =-12;
    public float ExpRotRate = 0.5f;
    Vector3 ExpCurSiz;
    public float ExpRate = 0.01f;
    Vector3 ExpStartPos;
    Vector3 ExpStartSiz;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ExpStartPos = transform.position;
        ExpStartSiz = transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        // Explosion only expands if it is on screen
        
        if (transform.position.x < ExpThresh)

        {

            transform.localScale = new Vector3(ExpMinSiz, ExpMinSiz, ExpMinSiz);
            transform.rotation = Quaternion.identity;

        }
        else
        {

            // if explosion not yet max size, expand it and rottat it
            ExpCurSiz = transform.localScale;
            if(ExpCurSiz.x < ExpMaxSiz)

            {
                ExpCurSiz = ExpCurSiz +new Vector3(ExpRate,ExpRate,ExpRate)* Time.deltaTime;
                transform.localScale = ExpCurSiz;
                transform.Rotate(0, 0, ExpRotRate);
            }

            // if explosion is max size, move it off screen to reset it
            else
            {
              transform.position = ExpStartPos;
            transform.localScale = ExpStartSiz;
            }
        }
            
            ;



    }
}
