using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareDown : MonoBehaviour
{
    public bool canGoHere;
    public GameObject player;
    public Vector3 endPoint;

    const float TILE_SIZE = 1.6f;
    float tiles = 12f;
    bool hasEntered = false;
    bool hasExited = false;
    bool hasStayed = false;

    void LateUpdate()
    {
        hasEntered = false;
        hasExited = false;
        hasStayed = false;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!hasExited)
        {
            hasExited = true;
            if (other.gameObject.tag == "Dog" || other.gameObject.tag == "Catcher")
            {
                canGoHere = false;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (!hasStayed)
        {
            hasStayed = true;
            if(other.gameObject.tag == "Player")
            {
                canGoHere = true;
            }
            if (gameObject.tag == "House" || gameObject.tag == "Pool")
            {
                canGoHere = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasEntered)
        {
            hasEntered = true;
            if (other.gameObject.tag == "Player")
            {
                canGoHere = true;
            }
            if (gameObject.tag == "House" || gameObject.tag == "Pool")
            {
                canGoHere = false;
            }
        }
    }

    void OnMouseDown()
    {
        Debug.Log(gameObject.transform + " " + canGoHere);
        if (canGoHere)
        {
            for (int row = 0; row < tiles; row++)
            {
                for (int col = 0; col < tiles; col++)
                {
                    if (gameObject.name.Contains(row + "_" + col))
                    {
                        endPoint = new Vector3(row * TILE_SIZE, col * TILE_SIZE, 0);
                    }
                }
            }
            if (GameObject.Find("GameManager").GetComponent<TakeTurns>().isDogTurn)
            {
                GameObject.Find("Dog").GetComponent<PlayerMovement>().Move(gameObject);
            }
            else
            {
                GameObject.Find("Catcher").GetComponent<PlayerMovement>().Move(gameObject);
            }
        }
    }
}