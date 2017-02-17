using UnityEngine;
using System.Collections;

public class Experience : MonoBehaviour
{
    private LevelManager LevelManager;

    private float pointsToNextLevel;

    private float experiencePoints;
    private int level;

    private void Start()
    {
        LevelManager = Managers.Instance.LevelManager;

        pointsToNextLevel = LevelManager.GetLevelRequirement(level);
    }

    public void GainExperince(float amount)
    {
        experiencePoints += amount;

        if (experiencePoints >= pointsToNextLevel)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        level++;

        pointsToNextLevel = LevelManager.GetLevelRequirement(level);
    }
}
