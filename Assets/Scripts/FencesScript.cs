using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FencesScript : MonoBehaviour {

    public BoxCollider2D colliderNorth;
    public BoxCollider2D colliderSouth;
    public BoxCollider2D colliderWest;
    public BoxCollider2D colliderEast;

    void OnTriggerEnter2D(Collider2D other)
    {
    }
}
