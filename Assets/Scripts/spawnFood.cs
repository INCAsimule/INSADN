using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    public GameObject FoodPrefab;
    public int FoodIniQuantity = 3;
    public int FoodMax = 10;
    public float FoodSpawnFrecquency = 0.5f;   //spawn par seconde
    private float foodHeight;
    private float spawnRadius;
    public int FoodCounter = 0;
    private float randomX;
    private float randomZ;
    public string FloorObject = "Tile";
    private DiskSize diskSize;
    private float randomR;
    private float randomTheta;

    // Start is called before the first frame update
    void Start()
    {

        this.foodHeight = this.FoodPrefab.transform.localScale.y / 2;

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

        Vector3 position;


        for (int i = 0; i < this.FoodIniQuantity; i++)
        {

            this.randomR = Random.Range(0, this.spawnRadius);
            this.randomTheta = Random.Range(0, 2 * Mathf.PI);
            this.randomX = this.randomR * Mathf.Cos(this.randomTheta);
            this.randomZ = this.randomR * Mathf.Sin(this.randomTheta);
            position = new Vector3(this.randomX, this.foodHeight, this.randomZ);
            Instantiate(this.FoodPrefab, position, new Quaternion(0, 0, 0, 0));
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
        Vector3 position;

        if (this.FoodCounter < this.FoodMax)
        {
            do
            {
                this.randomX = Random.Range(-this.spawnRadius, this.spawnRadius);
                this.randomZ = Random.Range(-this.spawnRadius, this.spawnRadius);
            } while (this.randomX * this.randomX + this.randomZ * this.randomZ > this.spawnRadius * this.spawnRadius);
            position = new Vector3(this.randomX, this.foodHeight, this.randomZ);
            Instantiate(this.FoodPrefab, position, new Quaternion(0, 0, 0, 0));
            this.FoodCounter += 1;
        }
    }
}
