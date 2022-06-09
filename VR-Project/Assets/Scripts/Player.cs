using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody ball;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("hole"))
        {
            Debug.Log("Hit the hole");
            ball.velocity = Vector3.zero;
        }
    }
}
