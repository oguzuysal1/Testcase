using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject SpawnPrefab;//-12,3.6 //-12,1.6 //11.3,-1.6 //11.3,3.8

    private Vector2 firstPosition = new Vector2(-12, 3.6f);
    private Vector2 secondPosition = new Vector2(-12, -1.6f);
    private Vector2 thirdPosition = new Vector2(11.3f, -1.6f);
    private Vector2 fourthPosition = new Vector2(11.3f, 3.8f);

    private float startDelay = 2;
    private float spawnRate = 4f;
    private int enemyCount;
    void Start()
    {
        
        
        InvokeRepeating("spawnEnemies", startDelay, spawnRate);

    }

    
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("enemy").Length;
    }

    public int generateRandomNumber()
    {
        int number = Random.Range(1, 5);
        return number;
    }

    private void spawnEnemies() {
        if (enemyCount <= 4)
        {
            switch (generateRandomNumber())
            {

                case 1: Instantiate(SpawnPrefab, firstPosition, SpawnPrefab.transform.rotation); break;

                case 2: Instantiate(SpawnPrefab, secondPosition, SpawnPrefab.transform.rotation); break;

                case 3: Instantiate(SpawnPrefab, thirdPosition, SpawnPrefab.transform.rotation); break;

                case 4: Instantiate(SpawnPrefab, fourthPosition, SpawnPrefab.transform.rotation); break;
            }
        }
    }
}
