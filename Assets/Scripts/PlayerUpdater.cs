using UnityEngine;
using TMPro;

public class PlayerUpdater : MonoBehaviour {
    
    private event System.Action OnPlayerDeath;
    public static PlayerUpdater instance;
    [SerializeField] private TextMeshProUGUI scoreText;
    private void Awake() {
        instance = this;
    }

    public void listenEvent(System.Action action,bool listen){
        if(listen)
            OnPlayerDeath += action;
        else
            OnPlayerDeath -= action;
    }

    private int score = 0;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Points")){
            score++;
            scoreText.text = score.ToString();
            PointsSpawner.instance.AddToPool(other.gameObject);
        }else if (other.CompareTag("Enemy")){
            if(OnPlayerDeath != null){
                OnPlayerDeath();
            }
        }
    }

}