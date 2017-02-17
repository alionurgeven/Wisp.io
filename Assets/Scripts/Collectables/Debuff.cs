using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuff : Collectable {
    // TODO : Debuff minion reverse rotation

    // TODO : Debuff player yavaslayabilir ?

    private void OnEnable()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        //GetComponent<SpriteRenderer>().color = Constants.colorList[Random.Range(0, Constants.colorList.Count)];
    }


}
