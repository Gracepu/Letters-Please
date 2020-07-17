using UnityEngine;

public class SFXManager : MonoBehaviour {

    public static SFXManager Instance { get; private set; }
    public AudioClip[] soundEffects;

    private AudioSource audioSource;

    private void Awake() {
        Instance = this;
    }

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySoundEffect(int index) {
        audioSource.PlayOneShot(soundEffects[index]);
    }
}
