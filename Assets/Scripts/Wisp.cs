using UnityEngine;
using System.Collections;

public class Wisp : MonoBehaviour {

    Movement mov;
    Rigidbody2D rbD;
    PlayerController pc;
    AIController aic;

    bool enemyOrPlayerCheck;


    private void Awake()
    {
        mov = GetComponent<Movement>();
        rbD = GetComponent<Rigidbody2D>();

        try
        {
            
            pc = GetComponentInParent<PlayerController>();
            enemyOrPlayerCheck = pc.isEnemy;
        }
        catch
        {
            
            aic = GetComponentInParent<AIController>();
            enemyOrPlayerCheck = aic.isEnemy;
        }

        
        
    }
    
    void Start () {
        if (enemyOrPlayerCheck)
        {
            aic.RandomMovement(mov, rbD); 
        }
    }
	
	
	void Update () {
        if (!enemyOrPlayerCheck)
        {
            mov.Move(6, rbD);
        }else{
            aic.RandomMovement(mov,rbD);
        }        
	}  
}
