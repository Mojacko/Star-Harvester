using UnityEngine;

public class LandScript : MonoBehaviour {
    
    [SerializeField] private float speed = 1f;
    private void Update() {
        transform.position = new Vector2 (transform.position.x - speed * Time.deltaTime, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("lowerground")){
            LandSpawn.instance.Spawn();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("lowerground")){
            LandSpawn.instance.AddToPool(gameObject);
        }
    }
}