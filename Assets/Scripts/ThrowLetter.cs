using UnityEngine;
using UnityEngine.UI;
public enum LetterState { Stop, Throwing, Reading };
public class ThrowLetter : MonoBehaviour {

    public float speed = .5f;
    public Image letterImage;
    public Transform letterPrefab;
    public Letters[] letters;
    public AudioClip throwLetterSound;
    
    private LetterState state;
    private int numberLettersThrown;
    private Transform currentLetter;
    private Animator animator;
    private AudioSource audioSource;
    private float time;

    private void Start() {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        state = LetterState.Reading;
        letterImage.sprite = letters[numberLettersThrown].letterImage;
        UIManager.Instance.SetLettersLeft(letters.Length);
        SFXManager.Instance.PlaySoundEffect(7);
    }

    public void ChangeStateAfterReading() {
        state = LetterState.Stop;
    }

    private void FixedUpdate() {
        if (state == LetterState.Stop) {
            if (Input.GetKeyDown(KeyCode.Mouse0)) {
                state = LetterState.Throwing;
                audioSource.PlayOneShot(throwLetterSound);

                // Get and translate mouse position
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 mouseDir = mousePos - transform.position;
                mouseDir = mouseDir.normalized;
                mouseDir.z = 0.0f;

                // Instantiate letter and put the correct info in it
                currentLetter = Instantiate(letterPrefab, transform.position, Quaternion.identity);
                currentLetter.GetComponent<ContentLetter>().letter = letters[numberLettersThrown];
                Rigidbody2D rb2d = currentLetter.GetComponent<Rigidbody2D>();

                // Add force and advance in letters' count
                animator.SetTrigger("throw");
                rb2d.AddForce(mouseDir * speed);
                numberLettersThrown++;
                UIManager.Instance.SetLettersLeft(letters.Length - numberLettersThrown);
            }

        } else if(state == LetterState.Throwing) {
            if (currentLetter == null && time > 1f) {
                time = 0;

                if (numberLettersThrown < letters.Length) {
                    state = LetterState.Reading;
                    letterImage.sprite = letters[numberLettersThrown].letterImage;
                    UIManager.Instance.ActivateLettersPanel();
                    SFXManager.Instance.PlaySoundEffect(7);

                } else LevelManager.Instance.EvaluateLevel();

            } else if (currentLetter == null) time += Time.fixedDeltaTime;
        }
    }
}
