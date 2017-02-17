using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Natural"))
        {
            PoolManager.Instance.Despawn(other.gameObject);
            PoolManager.Instance.Spawn("NaturalPiecesPool", Constants.MIN_VECTOR, Constants.MAX_VECTOR, Quaternion.identity);
        }
        else if (other.CompareTag("Buff"))
        {
            // TODO : buff ne olacak?
        }
        else if (other.CompareTag("Debuff"))
        {
            // TODO : debuff ? 
        }
    }
}
