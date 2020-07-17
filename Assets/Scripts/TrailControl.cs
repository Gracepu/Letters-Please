using UnityEngine;

public class TrailControl : MonoBehaviour {

    private TrailRenderer trail;
    private bool activate;
    private float time;

    private void Start() {
        trail = GetComponent<TrailRenderer>();
        trail.sortingLayerName = "Trail";
        trail.sortingOrder = 1;
    }

    void FixedUpdate() {

        if (time < 0.00001f) {
            time += Time.fixedDeltaTime;
        } else {
            ToggleTrail();
            activate = !activate;
            time = 0f;
        }
    }

    private void ToggleTrail() {
        trail.emitting = activate;
    }
}
