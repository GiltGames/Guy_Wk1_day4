using UnityEngine;
using UnityEngine.UIElements;
// This is the main script for the game

public class Launcher : MonoBehaviour
{
    public float Llim = -10;
    public float Win = 0;
    public float LScale = 100;
    public float angle = 0;
    public float scaleInc = 0.02f;
    public float angleInc = 0.2f;
    public float maxPower = 2;
    public float minPower = 0.5f;
    private float rotChk;
    private float scalChk;
    private Vector3 newscale;
    private Vector3 oldscale;
    private bool Fired = false;
    
    // rigidbody is a link to the shot
    Rigidbody2D rb;
    Vector3 force;
    Vector3 startPos;
    int pScore;

    //game objects are redundant - they linked to the graphic poower display now replaced by text

    public GameObject targetObjectPower;
    public GameObject targetObjectShot;
    public PowerGShow Pwr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
      
        // some redudant assignments - newscale is the only one needed now
        rb = targetObjectShot.GetComponent<Rigidbody2D>();
        startPos = transform.position;
        newscale = targetObjectPower.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

        // input on launcher


        //rotates launcher
        rotChk = Input.GetAxis("Horizontal");

        transform.Rotate(0,0,rotChk * -angleInc);

        //scales the power

        scalChk = Input.GetAxis("Vertical");
        
        oldscale = targetObjectPower.transform.localScale;
        
        //max and min power check
        
        if (scalChk > 0)
        {
            if (newscale.x < maxPower)
            {
                newscale = oldscale * (1 + (scalChk * scaleInc));
            }
        }
        else
        {
            if (newscale.x >minPower)
            {
                newscale = oldscale * (1 + (scalChk * scaleInc));
            }
        }
        
        // target object no longer displayed. PowerG is the displayed power

        if (targetObjectPower != null)
        {
           targetObjectPower.transform.localScale = newscale;
           Pwr.PowerG = Mathf.RoundToInt(newscale.x*100);
        }

        //fire key

        if (Input.GetKeyDown(KeyCode.Space))
            { if (Fired == false)
            {
               // Fired = true;

                //Debug.Log("FIRE");

                //Debug.Log(force); Debug.Log(newscale);
                
                //move shot to start
                targetObjectShot.transform.position = startPos;
                
                //apply force to shot
                rb.linearVelocity = Vector3.zero;

                force = LScale * newscale.x * GetComponent<Transform>().up;
                // Debug.Log(force); Debug.Log(newscale);
                rb.AddForce(force,ForceMode2D.Impulse);




            }



        }



        /*

        //check for end
        if(transform.position.y < Llim)
        {
            if (transform.position.x < Win)
            {
                pScore = pScore + 1;
                Debug.Log("Score");
            }
            else { Debug.Log("No Score"); }

                Debug.Log(pScore);


            rb.linearVelocity = Vector3.zero;
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = 0;
            transform.rotation = Quaternion.identity;
            Fired = false;
            transform.position = startPos;
        }

        */
    }
}
