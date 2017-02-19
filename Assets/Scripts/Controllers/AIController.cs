using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AIController : MonoBehaviour
{
    [SerializeField]
    int score = 0;

    [SerializeField]
    float horizontal;
    [SerializeField]
    float vertical;

    [SerializeField]
    float movementTimer;

    [SerializeField]
    float movementDecisionTimer = 4;


    public bool isEnemy = true;

    private void Awake()
    {
        vertical = Random.Range(-Constants.BOUNDARY, Constants.BOUNDARY);
        horizontal = Random.Range(-Constants.BOUNDARY, Constants.BOUNDARY);
    }

    private void LateUpdate()
    {
        movementTimer += Time.deltaTime;
    }


    /// hayati 17.02.2017 20:39 
    public int GetScore() { return score; }
    public void SetScore(int foo) { score = foo; }
    /// 

    public void RandomMovement(Movement mov,Rigidbody2D rbD)
    {
        if (movementTimer >= movementDecisionTimer)
        {
            movementTimer = 0;
            vertical = Random.Range(-Constants.BOUNDARY + 10.0f, Constants.BOUNDARY - 10.0f);
            horizontal = Random.Range(-Constants.BOUNDARY + 10.0f, Constants.BOUNDARY - 10.0f);
        }

        mov.Move(vertical, horizontal, 5, rbD);
    }
}
