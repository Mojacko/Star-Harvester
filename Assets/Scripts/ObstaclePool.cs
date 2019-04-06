using UnityEngine;
using System.Collections.Generic;
public class ObstaclePool : MonoBehaviour {
    
    [SerializeField] private GameObject[] Obstacles = new GameObject[3];
    private Queue<GameObject> ObstacleQueue = new Queue<GameObject>();
    public static ObstaclePool instance;
    private void Awake() {
        GrowPool();
        instance = this;
    }

    private void GrowPool(){
        for (int i = 0; i < 3; i++) {
            int index = Random.Range(0,Obstacles.Length);
            GameObject instance = Instantiate(Obstacles[index]);
            instance.transform.SetParent(transform);
            Addtopool(instance);
        }
    }

    public void Addtopool(GameObject obstacle){
        obstacle.SetActive(false);
        ObstacleQueue.Enqueue(obstacle);
    }

    public GameObject GetObstacle(){
        if(ObstacleQueue.Count == 0){
            GrowPool();
        }
        GameObject obstacle = ObstacleQueue.Dequeue();
        obstacle.SetActive(true);
        return obstacle;
    }
}