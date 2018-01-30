﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : MonoBehaviour {
    
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "DogTrigger") 
		{
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
		}
	}
}
