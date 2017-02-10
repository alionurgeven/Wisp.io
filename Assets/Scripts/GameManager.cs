using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //Variables
    [SerializeField]
    static int MAX_NO_OF_NATURAL_PIECES = 250;
    [SerializeField]
    static int MAX_NO_OF_ENEMYWISPS = 25;
    [SerializeField]
    public static float boundary = 80.0f;
    public static Vector2 MAX_VECTOR = Vector2.one * boundary;
    public static Vector2 MIN_VECTOR = Vector2.one * -boundary;

    public Text ScoreText;
    public PlayerController pController;
    // Use this for initialization
    void Start () {
        for (int i = 0; i < MAX_NO_OF_NATURAL_PIECES; i++)
        {
            // TODO: overload function without rotation needed!
            PoolManager.Instance.Spawn("NaturalPieces", MIN_VECTOR, MAX_VECTOR, Quaternion.identity);
        }
        for (int i = 0; i < MAX_NO_OF_ENEMYWISPS; i++)
        {
            PoolManager.Instance.Spawn("EnemyWisps", MIN_VECTOR, MAX_VECTOR, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
        ScoreText.text = "Score: " + pController.GetScore();
	}
}
