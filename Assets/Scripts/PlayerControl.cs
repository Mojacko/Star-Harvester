using UnityEngine;

public class PlayerControl : MonoBehaviour {
    
    [SerializeField]private Rigidbody2D rb;
    [SerializeField]private float jumpForce = 3f;
    private bool isJumping = false;
    private bool canControl = true;
    private void Start() {
        PlayerUpdater.instance.listenEvent(OnGameOver,true);
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
            if(canControl)
                isJumping = true;
        }
    }

    private void FixedUpdate() {
        if(isJumping){
            rb.velocity = Vector2.up * jumpForce;
            isJumping = false;
        }
    }

    private void OnGameOver(){
         canControl = false;
         PlayerUpdater.instance.listenEvent(OnGameOver,false);
         GetComponent<Animator>().SetTrigger("gameOver");
         GetComponent<CapsuleCollider2D>().enabled = false;
         Destroy(rb);
    }
}