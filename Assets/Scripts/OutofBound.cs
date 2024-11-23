using UnityEditor.Rendering;
using UnityEngine;

public class OutofBound : MonoBehaviour
{

    public Vector3 StartPos;
    public float Lbound = -4.5f;
    public bool fired = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartPos = transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.y < Lbound)
        {
            transform.position = StartPos;
            fired = false;
        }


    }
}
