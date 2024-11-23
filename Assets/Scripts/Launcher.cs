using UnityEngine;
using UnityEngine.UIElements;
// This is the main script for the game

public class Launcher : MonoBehaviour
{
    //public float Llim = -10;
  //  public float Win = 0;

    //parameters for sensitivity of launcher controls
    public float LScale = 100;
    public float angle = 0;
    public float scaleInc = 0.01f;
    public float angleInc = 0.3f;
    
    //limits on launcher power
    public float maxPower = 2;
    public float minPower = 0.5f;

    //limits on angle of launcher
    public float maxangle = -0.6f;
    public float minangle = -0.1f;
    public float angle1;
    
    // for control of angle and power
    private float rotChk;
    private float scalChk;
    private Vector3 newscale;
    private Vector3 oldscale;
    // private bool Fired = false;
    public AudioSource gunSound;
    public AudioClip gunClip;

    // tracks shot and moves it back if it goes off the bottom
    public OutofBound OOB;
    
    // rigidbody is a link to the shot
    Rigidbody2D rb;
    Vector3 force;
    Vector3 startPos;
    int pScore;

    //game objects are redundant - they linked to the graphic poower display now replaced by text

    public GameObject targetObjectPower;
    public GameObject targetObjectShot;

    //link to power for display
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
        angle1 = transform.localRotation.z;
        // Debug.Log("Rotation - Key " + rotChk + "....Min:" + minangle + "....Max:" + maxangle + "... angle" + angle1);
       
        //checks for limits on lancher mve
        if (rotChk < 0)
        {

            if (angle1 < minangle)
            {

                transform.Rotate(0, 0, rotChk * -angleInc);

            }
        }
        if (rotChk > 0)
        { 
            if (angle1 > maxangle)
            {
                transform.Rotate(0, 0, rotChk * -angleInc);
            }

        }

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
        Debug.Log("Fired" + OOB.fired);
        //fire key

        if (Input.GetKeyDown(KeyCode.Space))
        // whether or not the shot is fired is by variable in OutofBound script  
        
        { if (OOB.fired == false)
            {
               OOB.fired = true;

                //Debug.Log("FIRE");

                //Debug.Log(force); Debug.Log(newscale);
                
                //move shot to start
                targetObjectShot.transform.position = startPos;
                
                //apply force to shot
                rb.linearVelocity = Vector3.zero;

                force = LScale * newscale.x * GetComponent<Transform>().up;
                // Debug.Log(force); Debug.Log(newscale);
                rb.AddForce(force,ForceMode2D.Impulse);

                AudioSource.PlayClipAtPoint(gunClip,startPos);


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
