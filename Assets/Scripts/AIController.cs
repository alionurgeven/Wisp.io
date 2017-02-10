using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class AIController : MonoBehaviour {
   
    public float movementSpeed;
    public GameObject body;
    public Experience experienceRef;
    public Rigidbody2D rb2D;

    [SerializeField]
    float horizontal;
    [SerializeField]
    float vertical;
    [SerializeField]
    Vector2 direction;
    [SerializeField]
    Vector2 velocity = Vector2.zero;
    [SerializeField]
    float lerpSensitiviy = 0;
    [SerializeField]
    int score;

    private void Awake()
    {
        movementSpeed = 1;
        experienceRef = GetComponentInParent<Experience>();
        experienceRef.SubscribeLevelUpEvent(LevelUpAction);
    }
    public void LevelUpAction()
    {
        GetComponentInChildren<MinionController>().rotationSpeed = experienceRef.currentAttribute.minionSpeed;
        movementSpeed = experienceRef.currentAttribute.movementSpeed;
        body.transform.GetChild(0).transform.DOScale(Vector3.one * experienceRef.currentAttribute.bodySize, 0.5f);
        //body.transform.GetChild(0).localScale = Vector3.one * experienceRef.currentAttribute.bodySize;
        for (int i = 0; i < body.transform.GetChild(1).childCount; i++)
        {
            body.transform.GetChild(1).GetChild(i).GetChild(0).transform.DOScale(Vector3.one * experienceRef.currentAttribute.minionSize, 0.5f);
            //body.transform.GetChild(1).GetChild(i).GetChild(0).localScale = Vector3.one * experienceRef.currentAttribute.minionSize;
        }
    }
    private void OnEnable()
    {
        score = 0;
    }
    private Vector2 Movement()
    {
        if (movementTimer >= 4)
        {
            movementTimer = 0;
            vertical = Random.Range(-GameManager.boundary, GameManager.boundary);
            horizontal = Random.Range(-GameManager.boundary, GameManager.boundary);
        }

        direction = Vector2.up * vertical + Vector2.right * horizontal;
        //velocity = movementSpeed * direction.normalized;
        velocity = Vector3.Lerp(velocity, movementSpeed * direction.normalized, Time.deltaTime * lerpSensitiviy);
        return velocity;
    }
    public int GetScore()
    {
        return score;
    }

    public void SetScore(int scoreToSet)
    {
        score = scoreToSet;
    }
    float movementTimer;
    void Update()
    {
        movementTimer += Time.deltaTime;
        
        rb2D.MovePosition(rb2D.position + Movement() * Time.fixedDeltaTime);
    }
    void FixedUpdate()
    {
        // rb2D.MovePosition(rb2D.position + Movement() * Time.fixedDeltaTime);
    }
}
