using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnFoods : MonoBehaviour
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
    private float randomR_2;
    private float randomTheta;

    private Vector3 GetSpawnPosition()
    {
        this.randomR_2 = Random.Range(0, this.spawnRadius * this.spawnRadius);
        this.randomTheta = Random.Range(0, 2 * Mathf.PI);
        this.randomX = Mathf.Sqrt(this.randomR_2) * Mathf.Cos(this.randomTheta);
        this.randomZ = Mathf.Sqrt(this.randomR_2) * Mathf.Sin(this.randomTheta);
        return new Vector3(this.randomX, this.foodHeight, this.randomZ);
    }

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


        for (int i = 0; i < this.FoodIniQuantity; i++)
        {

            Instantiate(this.FoodPrefab, this.GetSpawnPosition(), new Quaternion(0, 0, 0, 0));
        }
        this.FoodCounter = this.FoodIniQuantity;

        if (this.FoodSpawnFrecquency == 0)
        {
            return;
        }

        InvokeRepeating("SpawnFoodRepeat", 1 / this.FoodSpawnFrecquency, 1 / this.FoodSpawnFrecquency);

    }

    void SpawnFoodRepeat()
    {

        if (this.FoodCounter < this.FoodMax)
        {
            Instantiate(this.FoodPrefab, this.GetSpawnPosition(), new Quaternion(0, 0, 0, 0));
            this.FoodCounter += 1;
        }
    }
}