using UnityEngine;
using System.Collections;

public class Buff : Collectable {

    // TODO : Buff boostBar fulleme

    private void OnEnable()
    {
        GetComponent<SpriteRenderer>().color = Color.yellow;
        //GetComponent<SpriteRenderer>().color = Constants.colorList[Random.Range(0, Constants.colorList.Count)];
    }
}
