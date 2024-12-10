using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject winMenu;
    public GameObject restartScreen;

    void Start()
    {
        HideAllMenus();
    }

    public void ShowWinMenu()
    {
        SetActiveScreen(winMenu);
    }

    public void ShowRestartScreen()
    {
        SetActiveScreen(restartScreen);
    }

    private void HideAllMenus()
    {
        winMenu.SetActive(false);
        restartScreen.SetActive(false);
    }

    private void SetActiveScreen(GameObject screen)
    {
        screen.SetActive(true);
    }

    /*
    private void SetActiveScreen(CanvasGroup activeScreen)
    {
        // Hide all screens
        winMenu.alpha = 0;
        winMenu.interactable = false;
        winMenu.blocksRaycasts = false;

        restartScreen.alpha = 0;
        restartScreen.interactable = false;
        restartScreen.blocksRaycasts = false;

        // Show the active screen
        activeScreen.alpha = 1;
        activeScreen.interactable = true;
        activeScreen.blocksRaycasts = true;

        // Stop the game
        Time.timeScale = 0;
    }

    public void HideAllMenus()
    {
        winMenu.SetActive(false);
        winMenu.alpha = 0;
        winMenu.interactable = false;
        winMenu.blocksRaycasts = false;

        restartScreen.alpha = 0;
        restartScreen.interactable = false;
        restartScreen.blocksRaycasts = false;

        // Resume the game
        Time.timeScale = 1;
    }
    */
}