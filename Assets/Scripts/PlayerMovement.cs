using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    float speed = 0.75f;
    float startTime;
    float journeyLength;
    Transform startPoint;
    Vector3 endPoint;
    bool isMoving = false;

    void Update()
    {
        CheckMoving();
    }

    public void GetStartPoint()
    {
        if (GameObject.Find("GridManager").GetComponent<TakeTurns>().isDogTurn)
        {
            startPoint = GameObject.FindGameObjectWithTag("Dog").transform;
        }
        else if(!(GameObject.Find("GridManager").GetComponent<TakeTurns>().isDogTurn))
        {
            startPoint = GameObject.FindGameObjectWithTag("Catcher").transform;
        }
    }

    public void Move(GameObject obj)
    {
        endPoint = obj.GetComponent<SquareDown>().endPoint;
        startTime = Time.time;
        journeyLength = Vector3.Distance(startPoint.position, endPoint);
        isMoving = true;
    }

    void CheckMoving()
    {
        if(isMoving)
        {
            float distanceCovered = (Time.time - startTime) * speed;
            float fractionDistance = distanceCovered / journeyLength;
            if(GameObject.Find("GridManager").GetComponent<TakeTurns>().isDogTurn)
            {
                GameObject.FindGameObjectWithTag("Dog").transform.position = Vector3.Lerp(startPoint.position, endPoint, fractionDistance);
            }
            else if(!(GameObject.Find("GridManager").GetComponent<TakeTurns>().isDogTurn))
            {
                GameObject.FindGameObjectWithTag("Catcher").transform.position = Vector3.Lerp(startPoint.position, endPoint, fractionDistance);
            }
            if (fractionDistance >= 1f)
            {
                isMoving = false;
            }
        }
    }
}
