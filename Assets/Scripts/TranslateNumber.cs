using UnityEngine;

public class TranslateNumber : MonoBehaviour {

    private Vector3 origin;
    private float speed = .5f;

    private void Start() {
        origin = transform.position;
    }

    private void OnDisable() {
        StopAllCoroutines();
        transform.position = origin;
    }

    private void Update() {
        float translation = speed * Time.deltaTime;
        transform.Translate(Vector3.up * translation);
    }
}
