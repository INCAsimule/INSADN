using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    public GameObject FoodPrefab;
    public int FoodIniQuantity;
    public int FoodMax;
    public float FoodSpawnFrecquency;   //spawn par seconde
    private Vector3 position;
    private float foodHeight = 1;
    private float spawnRadius;
    public int FoodCounter = 0;
    private float randomX;
    private float randomZ;
    public string FloorObject = "Tile";

    // Start is called before the first frame update
    void Start()
    {
        spawnRadius = GameObject.Find(FloorObject).GetComponent<DiskSize>().Radius - 0.5f;
        for (int i = 0; i < FoodIniQuantity; i++)
        {
            do
            {
                randomX = Random.Range(-spawnRadius, spawnRadius);
                randomZ = Random.Range(-spawnRadius, spawnRadius);
            } while (randomX * randomX + randomZ * randomZ > spawnRadius * spawnRadius);
            position = new Vector3(randomX, foodHeight, randomZ);
            Instantiate(FoodPrefab, position, new Quaternion(0, 0, 0, 0));
            FoodCounter += 1;
        }
        InvokeRepeating("spawnFoodRepeat", 1 / FoodSpawnFrecquency, 1 / FoodSpawnFrecquency);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnFoodRepeat()
    {
        if (FoodCounter < FoodMax)
        {
            do
            {
                randomX = Random.Range(-spawnRadius, spawnRadius);
                randomZ = Random.Range(-spawnRadius, spawnRadius);
            } while (randomX * randomX + randomZ * randomZ > spawnRadius * spawnRadius);
            position = new Vector3(randomX, foodHeight, randomZ);
            Instantiate(FoodPrefab, position, new Quaternion(0, 0, 0, 0));
            FoodCounter += 1;
        }
    }
}
