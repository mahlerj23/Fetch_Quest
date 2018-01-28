using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {

    public int rows;
    public int cols;
    public GameObject squarePrefab;

    GameObject gridHolder;

    public float startX;
    public float startY;
    GameObject[,] gridArray;

	void Start () {
        squarePrefab = Resources.Load<GameObject>("Prefabs/Square");
        InitGridHolder();
        BuildGrid();
    }

    void InitGridHolder()
    {
        gridHolder = new GameObject();
        gridHolder.name = "GridHolder";
        gridHolder.transform.position = new Vector2(startX, startY);
    }

    void BuildGrid()
    {
        gridArray = new GameObject[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                GameObject square = Instantiate(squarePrefab, gridHolder.transform) as GameObject;
                Vector2 newPos = new Vector2(j, i);
                square.transform.localPosition = newPos;
                square.name = "Square_" + i + "_" + j;
                gridArray[i, j] = square;
            }
        }
    }

}
