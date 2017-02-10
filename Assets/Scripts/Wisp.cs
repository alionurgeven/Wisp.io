using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wisp : MonoBehaviour {

    PlayerController pController;
    AIController aiController;
    public bool canBeDamaged;

    private void Awake()
    {
        canBeDamaged = true;
        pController = GetComponentInParent<PlayerController>();
        aiController = GetComponentInParent<AIController>();
    }
    private void OnEnable()
    {
        WispReset();
    }

    void WispReset()
    {
        if (pController !=null)
        {
            pController.SetScore(0);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Piece"))
        {
            Debug.Log("Girdi");
            if (pController != null)
            {
                pController.experienceRef.GainExperience(10);
                pController.SetScore(pController.GetScore() + 2);
            }
            PoolManager.Instance.Despawn(other.gameObject);
            PoolManager.Instance.Spawn("NaturalPieces", GameManager.MIN_VECTOR, GameManager.MAX_VECTOR, Quaternion.identity);
        }
    }

    public void LoseHealth(float lostHealth)
    {
        if(pController != null)
        {
            pController.experienceRef.currentAttribute.healthPoint -= lostHealth;

            if(pController.experienceRef.currentAttribute.healthPoint <= 0)
            {
                PoolManager.Instance.Despawn(transform.parent.gameObject);
            }
        }
        else
        {
            aiController.experienceRef.currentAttribute.healthPoint -= lostHealth;
            Debug.Log("Vurdu");
            if (aiController.experienceRef.currentAttribute.healthPoint <= 0)
            {
                PoolManager.Instance.Despawn(transform.parent.gameObject);
                PoolManager.Instance.Spawn("EnemyWisps", GameManager.MIN_VECTOR, GameManager.MIN_VECTOR, Quaternion.identity);
            }
        }
    }
}
