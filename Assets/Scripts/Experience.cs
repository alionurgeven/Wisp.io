using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using DG.Tweening;

public class Experience : MonoBehaviour
{
    public int level;
    private int maxLevel;
    public float experiencePoints;
    public float perc;

    private event Action levelUp;

    public GameObject expBar;
    public Text levelText;

    [System.Serializable]
    public struct LevelAttributes
    {
        public int level;

        public float bodySize;
        public float minionSize;
        public float movementSpeed;
        public int nameFontSize;
        public float nameTextPosition;
        public float bodyColliderSize;
        public float minionsColliderSize;
        public float minionSpeed;
        public float minionRange;

        public float previousTotalXpRequired;
        public float totalXpRequired;
        
        public float healthPoint;
    }

    public LevelAttributes currentAttribute;

    void OnEnable()
    {
        ResetLevel();
    }

    private void Awake()
    {
        maxLevel = LevelManager.Instance.levelAttributes.Count;
    }

    void Update()
    {
        if (level < maxLevel)
        {
            if (currentAttribute.totalXpRequired <= experiencePoints)
            {
                level++;

                SetLevelAttributes(level);

                levelUp();

                if (expBar != null)
                {
                    if (level == maxLevel)
                    {
                        expBar.transform.DOScale(new Vector3(1, 1, 1), 0.7f);
                        levelText.text = "Level " + level + " (MAX)";
                    }
                    else
                    {
                        expBar.transform.DOScale(new Vector3(Mathf.Clamp((experiencePoints - currentAttribute.previousTotalXpRequired) / (currentAttribute.totalXpRequired - currentAttribute.previousTotalXpRequired), 0, 1), 1, 1), 0.7f);
                        levelText.text = "Level " + level;
                    }
                    
                }
            }
        }
    }

    public int GetLevel()
    {
        return currentAttribute.level;
    }

    public void GainExperience(float experience)
    {
        if (level < maxLevel)
        {
            experiencePoints += experience;
        }

        if (expBar != null)
        {
            if (level < maxLevel)
            {
                if (level != 1)
                {
                    perc = Mathf.Clamp((experiencePoints - LevelManager.Instance.levelAttributes[level - 2].totalXpRequired) / (currentAttribute.totalXpRequired - LevelManager.Instance.levelAttributes[level - 2].totalXpRequired), 0, 1);
                }
                else
                {
                    perc = experiencePoints / currentAttribute.totalXpRequired;
                }

                //expBar.transform.DOScale(new Vector3(Mathf.Clamp(perc, 0, 1), 1, 1), 0.7f);
                levelText.text = "Level " + level;
            }
            else
            {
                perc = 0.9f;
                levelText.text = "Level " + maxLevel + " (MAX)";
                //expBar.transform.DOScale(new Vector3(1, 1, 1), 0.7f);
            }
        }
    }

    public void LoseExperience(float experience)
    {
        if (expBar != null)
        {
            UpdateLostExperience(experience);
            //expBar.transform.DOScale(new Vector3(Mathf.Clamp(perc, 0, 1), 1, 1), 0.7f);
            levelText.text = "Level " + level;
        }
        else
        {
            UpdateLostExperience(experience);
        }
    }
    public void UpdateLostExperience(float experience)
    {
        experiencePoints -= experience;
        level = FindLevel(experiencePoints);
        SetLevelAttributes(level);
        perc = experiencePoints / currentAttribute.totalXpRequired;
    }

    public int FindLevel(float experiencePoints)
    {
        int levelCount = 1; 
        for (int i = 0; i < LevelManager.Instance.levelAttributes.Count; i++)
        {
            if (experiencePoints > LevelManager.Instance.levelAttributes[i].totalXpRequired)
            {
                levelCount++;
            }
        }
        return levelCount;
    }

    private void ResetExperience()
    {
        experiencePoints = 0;
    }

    private void ResetLevel()
    {
        level = 1;

        if (expBar != null)
        {
            levelText.text = "Level 1";
            //expBar.transform.DOScale(new Vector3(0, 1, 1), 0.7f);
        }
        
        ResetExperience();
        SetLevelAttributes(level);
    }

    public void SubscribeLevelUpEvent(Action function)
    {
        levelUp += function;
    }

    public void SetLevelAttributes(int level)
    {
        LevelManager.LevelAttributes currentLevelAttributes = LevelManager.Instance.levelAttributes[level - 1];

        this.level = level;
        currentAttribute.level = level;
        currentAttribute.bodySize = currentLevelAttributes.bodySize;
        currentAttribute.healthPoint = currentLevelAttributes.healthPoint;
        currentAttribute.minionSpeed = currentLevelAttributes.minionSpeed;
        currentAttribute.minionSize = currentLevelAttributes.minionSize;
        currentAttribute.nameTextPosition = currentLevelAttributes.nameTextPosition;
        currentAttribute.nameFontSize = currentLevelAttributes.nameFontSize;
        currentAttribute.movementSpeed = currentLevelAttributes.movementSpeed;
        currentAttribute.bodyColliderSize = currentLevelAttributes.bodyColliderSize;
        currentAttribute.minionRange = currentLevelAttributes.minionRange;

        if (level == 1)
        {
            currentAttribute.previousTotalXpRequired = 0;
        }
        else
        {
            currentAttribute.previousTotalXpRequired = currentAttribute.totalXpRequired;
        }
        currentAttribute.totalXpRequired = currentLevelAttributes.totalXpRequired;

        GainExperience(0);
    }
}