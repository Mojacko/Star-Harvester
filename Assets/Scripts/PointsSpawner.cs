using UnityEngine;
using System.Collections.Generic;
public class PointsSpawner : MonoBehaviour {
    
    [SerializeField] private GameObject pointObj;
    [SerializeField] private float spawnY = 3f;
    [SerializeField] private float timeDelay = 2f;
    private float time = 0;
    private Queue<GameObject> pointPool = new Queue<GameObject>();
    public static PointsSpawner instance;
    private void Start() {
        instance = this;
    }
    private void Update() {
        if(time > timeDelay){
            Spawn();
            time = 0;
        }else{
            time += 1 * Time.deltaTime;
        }
    }
    private void GrowPool(){
        GameObject newObject = Instantiate(pointObj);
        AddToPool(newObject);
    }

    public void AddToPool(GameObject gameObject){
        gameObject.transform.SetParent(transform);
        gameObject.SetActive(false);
        pointPool.Enqueue(gameObject);
    }

    public void Spawn(){
        if(pointPool.Count == 0){
            GrowPool();
        }
        GameObject gameObject = pointPool.Dequeue();
        gameObject.transform.position = new Vector2(transform.position.x,Random.Range(-spawnY,spawnY));
        gameObject.SetActive(true);
    }

}