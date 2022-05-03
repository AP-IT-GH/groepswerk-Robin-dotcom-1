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

    public Transform holePos;
    public override void Initialize()
    {
        startingPos = transform.localPosition;
        speed = 10f;
    }

    public override void OnEpisodeBegin()
    {
        transform.localPosition = startingPos;
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float move;
        move = actions.ContinuousActions[0];
        transform.Translate(move * Vector3.right * speed * Time.deltaTime);

       if (transform.localPosition.y < 0f)
       {
           SetReward(-1f);
           EndEpisode();
       }
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(holePos.localPosition);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("hole"))
        {
            SetReward(1f);
            EndEpisode();
        }
    }
}
