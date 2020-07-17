using UnityEngine;

public class OutsideBounds : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.CompareTag("Wall")) {
            SFXManager.Instance.PlaySoundEffect(0);
            transform.GetChild(0).gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
