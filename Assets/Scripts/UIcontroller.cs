using UnityEngine;
using UnityEngine.SceneManagement;
public class UIcontroller : MonoBehaviour {
    [SerializeField] private Animator[] gameOverScreens;

    private void Start() {
        PlayerUpdater.instance.listenEvent(OnGameOver,true);
    }

    private void OnGameOver(){
        PlayerUpdater.instance.listenEvent(OnGameOver,false);
        foreach (Animator animator in gameOverScreens) {
            animator.SetTrigger("gameOver");
        }
    }

    private void OnRestartGame(){
        SceneManager.LoadScene(0);
    }

}