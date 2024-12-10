using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HUDController : MonoBehaviour
{
    public TMP_Text playerHealthText;
    public TMP_Text hackedBoxesText;
    public TMP_Text codesText;

    private int playerHealth = 10;
    private int hackedBoxes = 0;
    private int codes = 0;

    void Start()
    {
        UpdateHUD();
    }

    public void UpdateHUD()
    {
        playerHealthText.text = "Health: " + playerHealth + "/10";
        hackedBoxesText.text = "Hacked Boxes: " + hackedBoxes + "/4";
        codesText.text = "Codes: " + codes + "/4";
    }

    public void UpdatePlayerHealth(int health)
    {
        playerHealth = health;
        UpdateHUD();
    }

    public void IncrementHackedBoxes()
    {
        if (hackedBoxes < 4)
        {
            hackedBoxes++;
            UpdateHUD();
        }
    }

    public void IncrementCodes()
    {
        if (codes < 4)
        {
            codes++;
            UpdateHUD();
        }
    }
}