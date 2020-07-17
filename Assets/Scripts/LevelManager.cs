using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public static LevelManager Instance { get; protected set; }

    public int pointsNeeded;

    private int points;
    private int scenes;
    private WaitForSeconds seconds;

    private void Awake() {
        Instance = this;
        scenes = SceneManager.sceneCountInBuildSettings;
    }

    private void Start() {
        UIManager.Instance.SetPointsNeeded(pointsNeeded);
        seconds = new WaitForSeconds(1f);
    }

    public void SetPoints(int coincidences) {
        switch (coincidences) {
            case 0:
                SFXManager.Instance.PlaySoundEffect(6);
                break;
            case 1:
                points++;
                SFXManager.Instance.PlaySoundEffect(3);
                break;
            case 2:
                points += 3;
                SFXManager.Instance.PlaySoundEffect(4);
                break;
            default:
                points += 5;
                SFXManager.Instance.PlaySoundEffect(5);
                break;
        }
        UIManager.Instance.SetPointsScored(points);
    }

    public void EvaluateLevel() {
        if(pointsNeeded <= points) {    // You win!
            UIManager.Instance.ActivateWinPanel();
            SFXManager.Instance.PlaySoundEffect(0);
            StartCoroutine(NextLevel());

        } else if(pointsNeeded > points) {  // You lose!
            UIManager.Instance.ActivateLosePanel();
            SFXManager.Instance.PlaySoundEffect(1);
            StartCoroutine(BeginAgain());
        }
    }

    IEnumerator NextLevel() {
        yield return seconds;
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene + 1 < scenes) SceneManager.LoadScene(currentScene + 1);
        else SceneManager.LoadScene("Menu");
    }

    IEnumerator BeginAgain() {
        yield return seconds;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
