using UnityEngine;

public class Managers : MonoBehaviour
{
    // Singleton instance of the Managers class
    public static Managers Instance;

    // All other managers to access
    private UIManager uiManager;
    private PoolManager poolManager;
    private GameManager gameManager;
    private LevelManager levelManager;
    private AbilityManager abilityManager;

    /// <summary>
    /// Create singleton Instance if there is not any instance before
    /// and get all the references to the other managers in Awake().
    /// </summary>
    private void Awake()
    {
        // Creating singleton instance of the Managers
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        // Get all the manager components
        uiManager = GetComponent<UIManager>();
        poolManager = GetComponent<PoolManager>();
        gameManager = GetComponent<GameManager>();
        levelManager = GetComponent<LevelManager>();
        abilityManager = GetComponent<AbilityManager>();
    }
}
