using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Screen objects for navigating between them
    [Header("Screen Objects")]
    public GameObject mainScreen;
    public GameObject gameScreen;
    public GameObject deathScreen;

    // Screen references for navigation purposes
    private GameObject previousScreen;
    private GameObject currentScreen;

    /// <summary>
    /// Change the current screen to the new screen founded by the 
    /// given parameter with disabling current screen and enabling
    /// the new one. Also change the previous and current screen
    /// references.
    /// </summary>
    /// <param name="screen">New screen to change</param>
    public void ChangeScreen(Screens screen)
    {
        // Get the new screen GameObject
        GameObject newScreen = GetScreenGameObject(screen);   

        if (newScreen)
        {
            // Make current screen previous and disable it
            previousScreen = currentScreen;
            currentScreen.SetActive(false);

            // Make new screen current and enable it
            currentScreen = newScreen;
            newScreen.SetActive(true);
        }
        else
        {
            Debug.LogError("Screen cannot found!");
        }
    }

    /// <summary>
    /// Get the screen GameObject with the given screen parameter.
    /// </summary>
    /// <param name="screen">Screen for the GameObject reference</param>
    /// <returns>
    /// Acquired GameObject reference or null if the screen name is wrong
    /// </returns>
    private GameObject GetScreenGameObject(Screens screen)
    {
        switch (screen)
        {
            case Screens.MainScreen:
                return mainScreen;
            case Screens.GameScreen:
                return gameScreen;
            case Screens.DeathScreen:
                return deathScreen;
            default:
                return null;
        }
    }
}

/// <summary>
/// Screen enums for easy and understandable representations
/// of the screen names.
/// </summary>
public enum Screens
{
    MainScreen,
    GameScreen,
    DeathScreen
};
