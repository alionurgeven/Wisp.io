using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;
using DG.Tweening;

public class PlayerController : MonoBehaviour {

    public float movementSpeed;
    public GameObject body;
    public Experience experienceRef;
    public Rigidbody2D rb2D;
    MinionController mc;

    float horizontal;
    float vertical;
    [SerializeField]
    float boostPoint;
    Vector2 direction;
    Vector2 velocity = Vector2.zero;
    [SerializeField]
    float lerpSensitiviy = 0;
    public static float maxBoostPoint = 10;
    int score;
    bool boosting;

    private void Awake()
    {
        movementSpeed = 6;
        experienceRef = GetComponentInParent<Experience>();
        experienceRef.SubscribeLevelUpEvent(LevelUpAction);
        mc = GetComponentInChildren<MinionController>();
    }
    public void LevelUpAction()
    {
        mc.rotationSpeed = experienceRef.currentAttribute.minionSpeed;
        mc.range = experienceRef.currentAttribute.minionRange;

        mc.DetermineFormation(true);

        movementSpeed = experienceRef.currentAttribute.movementSpeed;
        body.transform.GetChild(0).transform.DOScale(Vector3.one * experienceRef.currentAttribute.bodySize, 0.5f);
        //body.transform.GetChild(0).localScale = Vector3.one * experienceRef.currentAttribute.bodySize;
        for (int i = 0; i < body.transform.GetChild(1).childCount; i++)
        {
            body.transform.GetChild(1).GetChild(i).GetChild(0).transform.DOScale(Vector3.one * experienceRef.currentAttribute.minionSize, 0.5f);
            //body.transform.GetChild(1).GetChild(i).GetChild(0).localScale = Vector3.one * experienceRef.currentAttribute.minionSize;
        }


    }
    private Vector2 Movement()
    {
        vertical = CnInputManager.GetAxisRaw("Vertical");
        horizontal = CnInputManager.GetAxisRaw("Horizontal");
        direction = Vector2.up * vertical + Vector2.right * horizontal;
        //velocity = movementSpeed * direction.normalized;
        velocity = Vector3.Lerp(velocity, movementSpeed * direction.normalized, Time.deltaTime * lerpSensitiviy);
        return velocity;
    }
	void Update () {
        rb2D.MovePosition(rb2D.position + Movement() * Time.fixedDeltaTime);
        if (boostPoint <= maxBoostPoint && !boosting)
        {
            boostPoint += Time.deltaTime;
        }
        else if (boosting && boostPoint >= 0)
        {
            boostPoint -= Time.deltaTime * 4;
        }
        if (boostPoint > 2.0f && CnInputManager.GetButtonDown("Jump")){
            MinionSpeedBoost();
        }
        else if(CnInputManager.GetButtonUp("Jump"))
        {
            mc.rotationSpeed /= 2;
            boosting = false;
        }
    }
    void FixedUpdate()
    {
       // rb2D.MovePosition(rb2D.position + Movement() * Time.fixedDeltaTime);
    }
    void MinionSpeedBoost()
    {
        boosting = true;
        mc.rotationSpeed *= 2;
        
    }
    public int GetScore()
    {
        return score;
    }

    public void SetScore(int scoreToSet)
    {
        score = scoreToSet;
    }
}
