using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnFood : MonoBehaviour
{
    public GameObject foodPrefab;
    public int foodIniQuantity;
    public int foodMax;
    public float foodSpawnFrecquency;   //spawn par seconde
    private Vector3 position;
    private float foodHeight = 1;
    public float spawnRadius;
    public int foodCounter = 0;
    private float randomX;
    private float randomZ;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < foodIniQuantity; i++)
        {
            do
            {
                randomX = Random.Range(-spawnRadius, spawnRadius);
                randomZ = Random.Range(-spawnRadius, spawnRadius);
            } while (randomX * randomX + randomZ * randomZ > spawnRadius * spawnRadius);
            position = new Vector3(randomX, foodHeight, randomZ);
            Instantiate(foodPrefab, position, new Quaternion(0, 0, 0, 0));
            foodCounter += 1;
        }
        InvokeRepeating("spawnFoodRepeat", 1 / foodSpawnFrecquency, 1 / foodSpawnFrecquency);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnFoodRepeat()
    {
        if (foodCounter < foodMax)
        {
            do
            {
                randomX = Random.Range(-spawnRadius, spawnRadius);
                randomZ = Random.Range(-spawnRadius, spawnRadius);
            } while (randomX * randomX + randomZ * randomZ > spawnRadius * spawnRadius);
            position = new Vector3(randomX, foodHeight, randomZ);
            Instantiate(foodPrefab, position, new Quaternion(0, 0, 0, 0));
            foodCounter += 1;
        }
    }
}
