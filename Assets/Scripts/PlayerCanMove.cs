using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCanMove : MonoBehaviour {

    public bool canGoHereDog;
    public bool canGoHereCatcher;

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
        if (gameObject.name == "Dog" && GameObject.Find("GridManager").GetComponent<TakeTurns>().isDogTurn)
        {
            other.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .4f);
            canGoHereDog = true;
        }
        if (gameObject.name == "Catcher" && !(GameObject.Find("GridManager").GetComponent<TakeTurns>().isDogTurn))
        {
            other.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .4f);
            canGoHereCatcher = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (gameObject.name == "Dog" && GameObject.Find("GridManager").GetComponent<TakeTurns>().isDogTurn)
        {
            other.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            canGoHereDog = false;
        }
        if (gameObject.name == "Catcher" && !(GameObject.Find("GridManager").GetComponent<TakeTurns>().isDogTurn))
        {
            other.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            canGoHereCatcher = false;
        }

    }

}
