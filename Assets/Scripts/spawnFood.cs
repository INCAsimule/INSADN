using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    public GameObject FoodPrefab;
    public int FoodIniQuantity = 3;
    public int FoodMax = 10;
    public float FoodSpawnFrecquency = 0.5f;   //spawn par seconde
    private Vector3 position;
    private float foodHeight = 1;
    private float spawnRadius;
    public int FoodCounter = 0;
    private float randomX;
    private float randomZ;
    public string FloorObject = "Tile";
    private DiskSize diskSize;

    // Start is called before the first frame update
    void Start()
    {
        if (this.FoodPrefab == null)
        {
            Debug.LogError("No FoodPrefab set");
        }

        this.diskSize = GameObject.Find(this.FloorObject).GetComponent<DiskSize>();
        if (this.diskSize == null)
        {
            Debug.LogError("Wrong name for FloorObject");
            return;
        }
        this.spawnRadius = this.diskSize.Radius - 0.5f;

        for (int i = 0; i < this.FoodIniQuantity; i++)
        {
            do
            {
                this.randomX = Random.Range(-this.spawnRadius, this.spawnRadius);
                this.randomZ = Random.Range(-this.spawnRadius, this.spawnRadius);
            } while (this.randomX * this.randomX + this.randomZ * this.randomZ > this.spawnRadius * this.spawnRadius);
            position = new Vector3(this.randomX, this.foodHeight, this.randomZ);
            Instantiate(this.FoodPrefab, this.position, new Quaternion(0, 0, 0, 0));
        }
        this.FoodCounter = this.FoodIniQuantity;

        if (this.FoodSpawnFrecquency == 0)
        {
            return;
        }

        InvokeRepeating("SpawnFoodRepeat", 1 / this.FoodSpawnFrecquency, 1 / this.FoodSpawnFrecquency);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnFoodRepeat()
    {
        if (this.FoodCounter < this.FoodMax)
        {
            do
            {
                this.randomX = Random.Range(-this.spawnRadius, this.spawnRadius);
                this.randomZ = Random.Range(-this.spawnRadius, this.spawnRadius);
            } while (this.randomX * this.randomX + this.randomZ * this.randomZ > this.spawnRadius * this.spawnRadius);
            this.position = new Vector3(this.randomX, this.foodHeight, this.randomZ);
            Instantiate(this.FoodPrefab, this.position, new Quaternion(0, 0, 0, 0));
            this.FoodCounter += 1;
        }
    }
}
