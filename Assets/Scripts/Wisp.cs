using UnityEngine;
using System.Collections;

public class Wisp : MonoBehaviour {

    Movement movementRef;
    Rigidbody2D rgb;
	// Use this for initialization
	void Start () {
        movementRef = GetComponent<Movement>();
        rgb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        movementRef.Move(6,rgb);
	}
}
