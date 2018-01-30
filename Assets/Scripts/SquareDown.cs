using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareDown : MonoBehaviour
{
    public Vector3 endPoint;

    bool canGoHereDog;
    bool canGoHereCatcher;

    const float TILE_SIZE = 1.6f;
    float tiles = 12f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.tag == "House" || gameObject.tag == "Pool")
        {
            canGoHereDog = false;
            canGoHereCatcher = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "DogMove")
        {
            //gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .4f);
            canGoHereDog = true;
        }
        if (other.gameObject.name == "CatcherMove")
        {
            //gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .4f);
            canGoHereCatcher = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "DogMove")
        {
            //gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            canGoHereDog = false;
        }
        if (other.gameObject.name == "CatcherMove")
        {
            //gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            canGoHereCatcher = false;
        }

    }

    void OnMouseDown()
    {
        StartCoroutine(WaitForOne());
        if (canGoHereDog && GameObject.Find("GridManager").GetComponent<TakeTurns>().isDogTurn)
        {
            FindEndPoint();
        }
        else if(canGoHereCatcher && !(GameObject.Find("GridManager").GetComponent<TakeTurns>().isDogTurn))
        {
            FindEndPoint();
        }
    }

    IEnumerator WaitForOne()
    {
        yield return new WaitForSeconds(1f);
    }

    void FindEndPoint()
    {
        Debug.Log(gameObject);
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
        GameObject.Find("GridManager").GetComponent<PlayerMovement>().GetStartPoint();
        GameObject.Find("GridManager").GetComponent<PlayerMovement>().Move(gameObject);
    }
}