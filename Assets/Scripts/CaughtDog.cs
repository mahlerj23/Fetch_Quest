using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaughtDog : MonoBehaviour {

    public bool dogCaught = false;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Dog"))
        {
            Debug.Log("Catcher wins!");
            dogCaught = true;
        }
    }
}
