using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public GameObject player;

    float speed = 0.75f;
    float startTime;
    float journeyLength;
    Transform startPoint;
    Vector3 endPoint;
    bool isMoving = false;

    void Start()
    {
        StartCoroutine(WaitForKeyDown());
    }

    void Update()
    {
        CheckMoving();
    }

    public IEnumerator WaitForKeyDown()
    {
        yield return new WaitWhile(() => !Input.GetKeyDown(KeyCode.Mouse0));
    }

    public void Move(GameObject obj)
    {
        startPoint = player.transform;
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
            player.transform.position = Vector3.Lerp(startPoint.position, endPoint, fractionDistance);
            if(fractionDistance >= 1f)
            {
                isMoving = false;
            }
        }
    }
}
