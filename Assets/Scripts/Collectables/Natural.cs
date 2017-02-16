using UnityEngine;
using System.Collections;

public class Natural : Collectable {

	// Use this for initialization
	void Start () {
        
    }
    private void OnEnable()
    {
        GetComponent<SpriteRenderer>().color = Constants.colorList[Random.Range(0, Constants.colorList.Count)];
    }
    // Update is called once per frame
    void Update () {
	
	}
}
