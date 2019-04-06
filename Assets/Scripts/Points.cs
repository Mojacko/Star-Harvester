using UnityEngine;

public class Points : MonoBehaviour {
    
    [SerializeField] private float speed = 3f;


    private void Update() {
        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y);
        if(transform.position.x <= -4f){
            PointsSpawner.instance.AddToPool(gameObject);
        }

    }
}