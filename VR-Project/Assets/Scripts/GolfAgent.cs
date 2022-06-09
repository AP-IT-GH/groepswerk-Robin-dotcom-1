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
    private float rotationSpeed;
    public Rigidbody rb;
    private bool didHit;
    private int swings;

    public Transform holePos;
    public override void Initialize()
    {
        startingPos = transform.localPosition;
        speed = 40f;
        rotationSpeed = 20;
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
        float forward;
        float backward;
        float rotate;
        forward = actions.ContinuousActions[0];
        backward = actions.ContinuousActions[2];
        rotate = actions.ContinuousActions[1];
        rb.AddForce(transform.forward * speed * forward,ForceMode.Impulse);
        rb.AddForce(-transform.forward * speed * backward,ForceMode.Impulse);
        transform.Rotate(new Vector3(0,rotationSpeed,0) * rotate * Time.deltaTime);

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
        if (!rb.velocity.Equals(Vector3.zero))
        {
            didHit = true;
        }

        if (didHit && rb.velocity.Equals(new Vector3(0, 0, speed)))
        {
            swings += 1;
            speed = 0f;
        }

        speed = 20f;
        didHit = false;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(holePos.localPosition);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continiousActionsOut = actionsOut.ContinuousActions;
        continiousActionsOut[0] = Input.GetKey(KeyCode.Space) ? 1.0f : 0f;
        continiousActionsOut[1] = Input.GetKey(KeyCode.LeftShift) ? 1.0f : 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("hole"))
        {
            rb.velocity = Vector3.zero;
            SetReward(1f);
            EndEpisode();
        }

        if (other.CompareTag("obstacle"))
        {
            SetReward(-1f);
            EndEpisode();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("obstacle"))
        {
            SetReward(-1f);
            EndEpisode();
        }
    }
}
