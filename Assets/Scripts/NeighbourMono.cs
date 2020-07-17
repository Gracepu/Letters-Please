using UnityEngine;

public class NeighbourMono : MonoBehaviour {

    public Neighbour neighbour;
    public Sprite[] numbers;

    private SpriteRenderer numberSprite;

    private void Start() {
        numberSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        int points = CheckLikings(collision.transform.GetComponent<ContentLetter>());
        LevelManager.Instance.SetPoints(points);
        ShowNumbers(points);
        Destroy(collision.gameObject);
    }

    private int CheckLikings(ContentLetter letter) {
        int coincidences = 0;

        int[] letterTypes = letter.GetMessageTypes();
        for (int i = 0; i < letterTypes.Length; i++) {
            for (int j = 0; j < neighbour.liking.Length; j++) {
                if (letterTypes[i] == neighbour.liking[j].type) coincidences++;
            }
        }

        return coincidences;
    }

    private void ShowNumbers(int points) {
        switch (points) {
            case 0:
                break;
            case 1:
                numberSprite.sprite = numbers[0];
                numberSprite.gameObject.SetActive(true);
                break;
            case 2:
                numberSprite.sprite = numbers[1];
                numberSprite.gameObject.SetActive(true);
                break;
            default:
                numberSprite.sprite = numbers[2];
                numberSprite.gameObject.SetActive(true);
                break;
        }
        Invoke("DeactivateNumbers", 1f);
    }

    private void DeactivateNumbers() {
        numberSprite.gameObject.SetActive(false);
    }
}
