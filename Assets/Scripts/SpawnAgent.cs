using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAgent : MonoBehaviour
{

    public int AgentIni = 5;
    private float spawnRadius = 10;
    private DiskSize diskSize;
    public string FloorObject = "Tile";
    public int AgentCounter = 0;
    public GameObject AgentPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnFoods spawnFoodScript = GameObject.Find("Spawn").GetComponent<SpawnFoods>();
        if (spawnFoodScript == null)
        {
            Debug.LogError("SpawnFoods script not found");
        }

        this.diskSize = GameObject.Find(this.FloorObject).GetComponent<DiskSize>();
        if (this.diskSize == null)
        {
            Debug.LogError("Wrong name for FloorObject");
            return;
        }
        this.spawnRadius = this.diskSize.Radius - 0.5f;

        for (int i = 0; i < this.AgentIni; i++)
        {
            Instantiate(this.AgentPrefab, spawnFoodScript.GetSpawnPosition(this.spawnRadius), new Quaternion(0, 0, 0, 0));
        }
        AgentCounter = AgentIni;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
