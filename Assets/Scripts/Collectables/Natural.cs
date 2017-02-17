using UnityEngine;
using System.Collections;

public class Natural : Collectable {

    private void OnEnable()
    {
        GetComponent<SpriteRenderer>().color = Constants.colorList[Random.Range(0, Constants.colorList.Count)];
    }
}
