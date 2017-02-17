using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	void Start () {

        /// Hayati
        /// pieceler icin yazildi
        for (int i = 0; i < Constants.MAX_NO_OF_NATURAL_PIECES; i++)
        {
            PoolManager.Instance.Spawn("NaturalPiecePool", Constants.MIN_VECTOR, Constants.MAX_VECTOR, Quaternion.identity);
        }
        for (int i = 0; i < Constants.MAX_NO_OF_OTHER_PIECES; i++)
        {
            PoolManager.Instance.Spawn("BuffPiecePool", Constants.MIN_VECTOR, Constants.MAX_VECTOR, Quaternion.identity);
        }
        for (int i = 0; i < Constants.MAX_NO_OF_OTHER_PIECES; i++)
        {
            PoolManager.Instance.Spawn("DebuffPiecePool", Constants.MIN_VECTOR, Constants.MAX_VECTOR, Quaternion.identity);
        }

        /// end of hayati
        /// 

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
