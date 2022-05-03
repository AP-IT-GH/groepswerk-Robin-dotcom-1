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
        Vector3 move = Vector3.zero;
        move.x = actions.ContinuousActions[0];
        transform.Translate(move * speed * Time.deltaTime);

       if (transform.localPosition.y < 0f)
       {
           SetReward(-1f);
           EndEpisode();
       }
    }

    public override void CollectObservations(VectorSensor sensor)
    {
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
