using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicLoad : MonoBehaviour {
    private static MusicLoad instance = null;
    private string currentScene;
    private AudioSource audioManager;
    public AudioClip[] ost;

    public static MusicLoad Instance {
        get { return instance; }
    }

    void Awake() {
        currentScene = SceneManager.GetActiveScene().name;
        if (instance == null) {
            DontDestroyOnLoad(gameObject);
            instance = this;

        } else Destroy(gameObject);
    }

    private void Start() {
        audioManager = this.GetComponent<AudioSource>();
        audioManager.clip = ost[0];
        audioManager.Play();
    }
}

