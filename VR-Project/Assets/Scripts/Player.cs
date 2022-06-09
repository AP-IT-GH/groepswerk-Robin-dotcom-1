using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Rigidbody ball;
    private int hits;
    public Text playerScore;
    private int totalPlayerScore;

    private void Start()
    {
        playerScore.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        playerScore.text = "Score: " + hits.ToString();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("stick"))
        {
            if (hits <= 7)
            {
                hits += 1;
                totalPlayerScore += 1;
            }
        }
    }
}
