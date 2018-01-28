using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeTurns : MonoBehaviour {
    
    float maxMoves;
    float currentMove;

    const float MAX_BONES = 4;
    float collectedBones = 0;

    bool dogCaught = false;
    public bool isDogTurn;

    void Start()
    {
        CoinFlip();
    }

    void CoinFlip()
    {
        int rand = Random.Range(0, 100);
        if(rand < 50)
        {
            PlayerIsDog();
        }
        else
        {
            PlayerIsCatcher();
        }
    }

    void PlayerIsDog()
    {
        isDogTurn = true;
        maxMoves = 3f;
        while(true)
        {
            if(collectedBones == MAX_BONES)
            {
                Debug.Log("Dog wins!");
                break;
            }
            else if (currentMove < maxMoves)
            {
                StartCoroutine(GameObject.Find("Dog").GetComponent<PlayerMovement>().WaitForKeyDown());
                currentMove++;
            }
            else if (currentMove == maxMoves)
            {
                isDogTurn = false;
                currentMove = 0;
                PlayerIsCatcher();
            }
        }
    }

    void PlayerIsCatcher()
    {
        isDogTurn = false;
        maxMoves = 2f;
        while (true)
        {
            if(dogCaught)
            {
                Destroy(GameObject.Find("Dog"));
            }
            if (currentMove < maxMoves)
            {
                StartCoroutine(GameObject.Find("Catcher").GetComponent<PlayerMovement>().WaitForKeyDown());
                currentMove++;
            }
            else if (currentMove == maxMoves)
            {
                isDogTurn = true;
                currentMove = 0;
                PlayerIsDog();
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Catcher wins!");
            dogCaught = true;
        }
    }
}
