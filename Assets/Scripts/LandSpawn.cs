using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class LandSpawn : MonoBehaviour {
    
    [SerializeField] private GameObject land;
    [SerializeField] private GameObject[] decorations;
    private Queue<GameObject> landQueue = new Queue<GameObject>();
    private Queue<GameObject> decorQueue = new Queue<GameObject>();
    public static LandSpawn instance;

    private void Awake() {
        instance = this;
        Spawn();
    }

    public void Spawn(){
        if(landQueue.Count == 0){
            GrowPoolland();
        }
        GameObject gameObject = landQueue.Dequeue();
        gameObject.transform.position = transform.position;
        gameObject.SetActive(true);
        

        for (int i = 0; i < Random.Range(1,3); i++) {
            if(decorQueue.Count == 0){
              GrowPoolDecor();
            }
            GameObject decorObject = decorQueue.Dequeue();
            decorObject.transform.SetParent(gameObject.transform);
            decorObject.transform.localPosition = new Vector2(Random.Range(-1,3),0);
            decorObject.SetActive(true);
        }
        
    }


    private void GrowPoolDecor(){
        for (int i = 0; i < 10; i++){
            int index = Random.Range(0,decorations.Length);
            GameObject gameObject = Instantiate(decorations[index]);
            AddToPoolDecor(gameObject);
        }
    }
    private void AddToPoolDecor(GameObject gameObject){
        gameObject.transform.SetParent(transform);
        gameObject.SetActive(false);
        decorQueue.Enqueue(gameObject);
    }
    
    private void GrowPoolland(){
        for (int i = 0; i < 2; i++) {
            GameObject gameObject = Instantiate(land);
            AddToPool(gameObject);
        }
    }
    public void AddToPool(GameObject gameObject){
         /* 
        for (int i = 0; i < gameObject.transform.childCount; i++) {
            AddToPoolDecor(gameObject.transform.GetChild(i).gameObject);
        }
        */
        foreach (Transform child in gameObject.transform){
            AddToPoolDecor(child.gameObject);
        }
        
        gameObject.transform.SetParent(transform);
        gameObject.SetActive(false);
        landQueue.Enqueue(gameObject);
    }


}