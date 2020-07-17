using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {
    
    public static UIManager Instance { get; protected set; }

    public TextMeshProUGUI lettersLeft;
    public TextMeshProUGUI pointsScored;
    public TextMeshProUGUI pointsNeeded;
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject lettersPanel;

    private void Awake() {
        Instance = this;
    }

    public void SetLettersLeft(int number) {
        lettersLeft.text = number.ToString();
    }

    public void SetPointsScored(int number) {
        pointsScored.text = number.ToString();
    }

    public void SetPointsNeeded(int number) {
        pointsNeeded.text = "/ " + number;
    }

    public void ActivateLettersPanel() {
        lettersPanel.SetActive(true);
    }

    public void ActivateWinPanel() {
        winPanel.SetActive(true);
    }

    public void ActivateLosePanel() {
        losePanel.SetActive(true);
    }
}
