using Unity.VisualScripting;
using UnityEngine;

public class MoveChar : MonoBehaviour
{

    float charlr =0f;
    float charup =0f;
    Vector3 charup2;
    public float charinc = .05f;
    float charupinc = 5.0f;
    float charlrsp;
    float limSp = 5.0f;
    public float decay = 0.2f;
    Vector3 forcedirection = Vector3.up;
    float LRmove;

    Rigidbody2D rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        charlr = 0f;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //    charup = charupinc;
            //  Debug.Log("space press");
           // if (Collision.ReferenceEquals()
            {
                rb.AddForce(forcedirection * charupinc, ForceMode2D.Impulse);
            }
        }
        //        else {
        // if (charup >0)
        //   { charup = charup - decay; } }



        LRmove = Input.GetAxis("Horizontal");

        
        if (LRmove <0 ) 
        {
            if (charlrsp > -limSp)
            {
                charlrsp = charlrsp - charinc;
                Debug.Log("W press");
            }

      
        }

        if (LRmove > 0)
        {
            if (charlrsp < limSp)
            {
                charlrsp = charlrsp + charinc;
                Debug.Log("E press");
            }
            

          
        }
       



        transform.Translate(charlrsp *Time.deltaTime, charup *Time.deltaTime, 0);
        Debug.Log("LR"+charlrsp);
        Debug.Log("up"+charup);  
    }
}
