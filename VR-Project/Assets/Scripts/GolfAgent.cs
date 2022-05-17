using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class GolfAgent : Agent
{
    private Vector3 startingPos;
    private float speed;
    //private float rotationSpeed;
    private Rigidbody rb;
    private bool didHit;
    private int swings;

    public Transform holePos;
    public override void Initialize()
    {
        startingPos = transform.localPosition;
        speed = 60f;
        //rotationSpeed = 10f;
        rb = GetComponent<Rigidbody>();
        swings = 0;
        didHit = false;
    }

    public override void OnEpisodeBegin()
    {
        transform.localPosition = startingPos;
        rb.velocity = Vector3.zero;
        didHit = false;
        swings = 0;
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float move;
        //float rotate;
        move = actions.ContinuousActions[0];
        //rotate = actions.ContinuousActions[1];
        //transform.Translate(move * Vector3.right * speed * Time.deltaTime);
        rb.AddForce(transform.right * speed * move,ForceMode.Impulse);
        //transform.RotateAround(transform.position,transform.up,Time.deltaTime * rotationSpeed * rotate);

       if (transform.localPosition.y < 0f)
       {
           SetReward(-1f);
           EndEpisode();
       }

       if (swings >= 7)
       {
           SetReward(-1f);
           EndEpisode();
       }
    }

    private void Update()
    {
        if (didHit && !speed.Equals(0f))
        {
            swings += 1;
            speed = 0f;
            Debug.Log(swings);
        }

        if (rb.velocity == Vector3.zero)
        {
            didHit = false;
            speed = 60f;
        }
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(holePos.localPosition);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continiousActionsOut = actionsOut.ContinuousActions;
        continiousActionsOut[0] = Input.GetKey(KeyCode.Space) ? 1.0f : 0f;

        if (continiousActionsOut[0] == 1.0f)
        {
            didHit = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("hole"))
        {
            rb.velocity = Vector3.zero;
            SetReward(1f);
            EndEpisode();
        }
    }
}
