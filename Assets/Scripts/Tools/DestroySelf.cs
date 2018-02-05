using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour {

    [SerializeField]
    private float time = 1.5f;
	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, time);
	}
	
}
