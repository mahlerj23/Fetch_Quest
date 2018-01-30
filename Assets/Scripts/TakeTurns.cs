using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeTurns : MonoBehaviour {
    
    int maxMoves;

    const float TILE_SIZE = 1.6f;
    const float MAX_BONES = 4f;
    float collectedBones = 0f;
    
    public bool isDogTurn;
    bool ended;

    void Start()
    {
        CoinFlip();
        StartCoroutine(UpdateState());
    }

    void Update()
    {
        if (!ended)
        {
            CheckEndGame();
        }
    }

    void CoinFlip()
    {
        int rand = Random.Range(0, 100);
        if (rand < 50)
        {
            isDogTurn = true;
        }
        else
        {
            isDogTurn = false;
        }
    }

    IEnumerator UpdateState()
    {
        while (true)
        {
            if (isDogTurn)
            {
                yield return StartCoroutine(DogTurn());
            }
            else if (!isDogTurn)
            {
                yield return StartCoroutine(CatcherTurn());
            }
        }
    }

    IEnumerator DogTurn()
    {
        maxMoves = 3;
        Debug.Log(GameObject.Find("Dog") + " Start");
        for(int i = 0; i < maxMoves; i++)
        {
            Debug.Log("Move: " + (i + 1) + "/" + maxMoves);
            yield return StartCoroutine(WaitForMouseDown());
            yield return null;
        }
        Debug.Log("Waiting for player to hit space");
        yield return StartCoroutine(WaitForTurnEnd());
    }

    IEnumerator CatcherTurn()
    {
        maxMoves = 2;
        Debug.Log(GameObject.Find("Catcher") + " Start");
        for (int i = 0; i < maxMoves; i++)
        {
            Debug.Log("Move: " + (i + 1) + "/" + maxMoves);
            yield return StartCoroutine(WaitForMouseDown());
            yield return null;
        }
        Debug.Log("Waiting for player to hit space");
        yield return StartCoroutine(WaitForTurnEnd());
     }

    IEnumerator WaitForMouseDown()
    {
        while (!Input.GetKeyDown(KeyCode.Mouse0))
        {
            yield return null;
        }
    }

    IEnumerator WaitForTurnEnd()
    {
        while(!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
        ChangePlayerTurn();
    }

    void ChangePlayerTurn()
    {
        if(isDogTurn)
        {
            isDogTurn = false;
        }
        else if(!isDogTurn)
        {
            isDogTurn = true;
        }
    }

    void CheckEndGame()
    {
        float distanceApart = Vector3.Distance(GameObject.FindGameObjectWithTag("Dog").transform.position, GameObject.FindGameObjectWithTag("Catcher").transform.position);
        if (collectedBones == MAX_BONES)
        {
            ended = true;
            Debug.Log("Dog Wins");
            Application.Quit();
        }
        else if (Mathf.Abs(distanceApart) <= TILE_SIZE + .1f)
        {
            ended = true;
            Debug.Log("Catcher Wins");
            Application.Quit();
        }
    }
}
