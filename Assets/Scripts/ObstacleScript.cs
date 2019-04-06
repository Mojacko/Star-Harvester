using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float rotationSpeed = 1f;
    private Transform pos;

    private void Start() {
        pos = transform;
    }

    private void Update() {
        pos.position = new Vector2(pos.position.x + moveSpeed * Time.deltaTime ,pos.position.y);
        transform.Rotate(0,0,rotationSpeed * Time.deltaTime);
    }
    
}
