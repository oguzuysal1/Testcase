using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private Queue<GameObject> inPoolObjects;
    public GameObject bullet;

    private int poolSize = 6;
    void Start()
    {
    
    }

   
    void Update()
    {
        
    }

    public GameObject getObjectFromPool(){
        GameObject obj = inPoolObjects.Dequeue();

        obj.SetActive(true);
        
        return obj;
    }
    public void Awake() {
        inPoolObjects = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(bullet);
            obj.SetActive(false);
            inPoolObjects.Enqueue(obj);
        }
    }

    public void ReturnToPool(GameObject obj) {
        obj.SetActive(false);
        inPoolObjects.Enqueue(obj);
    }

    
}
