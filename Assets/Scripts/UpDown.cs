using UnityEngine;

public class UpDown : MonoBehaviour
{


    // delcare


    public float llim = -5.0f;
    public float ulim = -1.0f;
    public float inc = 1.0f;

    /// </summary>
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < llim || transform.position.y > ulim)
        { inc = -1 * inc; }

        transform.Translate(0, inc * Time.deltaTime,0);

    }
}
