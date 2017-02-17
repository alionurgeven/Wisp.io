using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Screen objects for navigating between them
    [Header("Screen Objects")]
    public GameObject mainScreen;
    public GameObject gameScreen;
    public GameObject deathScreen;

    // Popup objects
    [Header("Popup Objects")]
    public GameObject ratePopup;
    public GameObject tutorialPopup;

    // Screen references for navigation purposes
    private GameObject previousScreen;
    private GameObject currentScreen;
    private GameObject popupScreen;

    /// <summary>
    /// Open the desired screen with the given screen name.
    /// </summary>
    /// <param name="screen">New screen to change</param>
    public void OpenScreen(Screens screen)
    {
        // Get the new screen GameObject
        GameObject newScreen = GetScreenGameObject(screen);   

        if (newScreen)
        {
            // Change the screen
            ChangeScreen(newScreen);
        }
        else
        {
            Debug.LogError("Screen cannot found!");
        }
    }

    /// <summary>
    /// Return to the previous screen
    /// </summary>
    public void ReturnPreviousScreen()
    {
        // Temporary screen GameObject for changing variables
        GameObject temp = previousScreen;

        // Change the screen
        ChangeScreen(temp);
    }

    /// <summary>
    /// Transition of the screens between new screen and the current
    /// </summary>
    /// <param name="newScreen">New screen GameObject to change references</param>
    private void ChangeScreen(GameObject newScreen)
    {
        // Make current screen previous and disable it
        previousScreen = currentScreen;
        previousScreen.SetActive(false);

        // Make new screen current and enable it
        currentScreen = newScreen;
        currentScreen.SetActive(true);
    }

    /// <summary>
    /// Popup the desired popup screen to the game screen
    /// </summary>
    /// <param name="popup">Popup name to show</param>
    public void PopupScreen(Popups popup)
    {
        // Get the popup screen GameObject
        popupScreen = GetPopupGameObject(popup);

        if (popupScreen)
        {
            popupScreen.SetActive(true);
        }
        else
        {
            Debug.LogError("Popup cannot found!");
        }
    }

    /// <summary>
    /// Close the popup screen that is already opened
    /// </summary>
    public void ClosePopup()
    {
        popupScreen.SetActive(false);
        popupScreen = null;
    }

    /// <summary>
    /// Get the screen GameObject with the given screen parameter.
    /// </summary>
    /// <param name="screen">Screen name for the GameObject reference</param>
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

    /// <summary>
    /// Get the popup GameObject with the given popup parameter.
    /// </summary>
    /// <param name="popup">Popup name for the GameObject reference</param>
    /// <returns>
    /// Acquired GameObject reference or null if the popup name is wrong
    /// </returns>
    private GameObject GetPopupGameObject(Popups popup)
    {
        switch (popup)
        {
            case Popups.RatePopup:
                return ratePopup;
            case Popups.TutorialPopup:
                return tutorialPopup;
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

/// <summary>
/// Popup enums for easy and understandable representations 
/// of the popup names.
/// </summary>
public enum Popups
{
    RatePopup,
    TutorialPopup
}
