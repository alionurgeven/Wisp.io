using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public int numberOfLevels;

    private float[] levelRequirements;

    private void Start()
    {
        InitializeLevelRequirements();
    }

    public float GetLevelRequirement(int level)
    {
        return levelRequirements[level];
    }

    private void InitializeLevelRequirements()
    {
        for (int i = 0; i < numberOfLevels; i++)
        {
            // TODO define a better function
            levelRequirements[i] = i * i * 100;
        }
    }
}
