using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
    public Vector3 playerPosition;
    public Vector3 startpos;
    public bool calculate;
    private Rigidbody rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        startpos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = speed * transform.forward;
    }
    
}
