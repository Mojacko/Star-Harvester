using System.Collections;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour {
    [SerializeField] private float timeDelay = 3f;
    [SerializeField] private float lifeTime = 3f;
    [Header("Y axis spawn.")][SerializeField] private Vector2 minMax = new Vector2();
    
    private float time = 0f;

    private void Update() {
        if(time > timeDelay){
            Spawn(); 
            time = 0f;
        }else{
            time += 1 * Time.deltaTime;
        }
    }

    private void Spawn(){
        float randomY = Random.Range(minMax.x,minMax.y);
        GameObject obstacle = ObstaclePool.instance.GetObstacle();
        obstacle.transform.position = new Vector2(transform.position.x,randomY);
        StartCoroutine(Expire(obstacle));
    }

    IEnumerator Expire(GameObject gameObject){
        yield return new WaitForSeconds(lifeTime);
        ObstaclePool.instance.Addtopool(gameObject);
    }
    
    
}