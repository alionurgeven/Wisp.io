using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    [System.Serializable]
    public class LevelAttributes
    {
        public float bodySize;
        public float minionSize;
        public float movementSpeed;
        public float nameTextPosition;
        public int nameFontSize;

        public float bodyColliderSize;

        public float totalXpRequired;

        public float minionSpeed;

        public float healthPoint;
        public float minionRange;

    }

    public List<LevelAttributes> levelAttributes;

    public static LevelManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        levelAttributes = new List<LevelAttributes>();

        for (int i = 0; i < 10; i++)
        {
            LevelAttributes newLevelAttributes = new LevelAttributes();
            newLevelAttributes.nameTextPosition = 1.6f + (0.4f * i);
            newLevelAttributes.nameFontSize = 32 + (2 * i);
            newLevelAttributes.bodySize = 1 + (4.0f / 10.0f * i);
            newLevelAttributes.minionSize = 1 + (4.0f / 10.0f * i);
            newLevelAttributes.bodyColliderSize = 1 + (4.0f / 10.0f * i);
            newLevelAttributes.movementSpeed = 6 - (3.0f / 10.0f * i);
            newLevelAttributes.healthPoint = 100 + (4900 * i);
            newLevelAttributes.minionSpeed = 50 + (5 * i);
            newLevelAttributes.minionRange = 1 + (0.4f * i);
            if (i == 0)
            {
                newLevelAttributes.totalXpRequired = 100;
            }
            else
            {
                newLevelAttributes.totalXpRequired = levelAttributes[i - 1].totalXpRequired + 100 + 50 * i;
            }

            levelAttributes.Add(newLevelAttributes);
        }
    }
}