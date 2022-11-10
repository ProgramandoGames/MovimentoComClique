
using UnityEngine;

public class GroundMarker : MonoBehaviour {

    SpriteRenderer sprite;

    public float duration = 1f;

    float currentTime;

    private void Awake() {

        sprite = GetComponent<SpriteRenderer>();

    }

    void Start() {
        currentTime = Time.time;
        Destroy(gameObject, duration);
    }

    void Update() {

        var alpha = (Time.time - currentTime) / duration;

        sprite.color = Color.red - new Color(0, 0, 0, alpha);
    }

}
