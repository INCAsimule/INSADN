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

    public float MaxSpeedMin = 4.0f;
    public float MaxSpeedMax = 4.0f;
    public float MaxEnergyMin = 100.0f;
    public float MaxEnergyMax = 100.0f;
    public float MaxHealthMin = 100.0f;
    public float MaxHealthMax = 100.0f;
    public float VisionRadiusMin = 30.0f;
    public float VisionRadiusMax = 30.0f;
    public int FertilityRateMin = 200;
    public int FertilityRateMax = 200;

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
            var newAgent = Instantiate(this.AgentPrefab, spawnFoodScript.GetSpawnPosition(this.spawnRadius), new Quaternion(0, 0, 0, 0));
            newAgent.GetComponent<Agent>().MaxEnergy =  Random.Range(this.MaxEnergyMin, this.MaxEnergyMax);
            newAgent.GetComponent<Agent>().Energy = newAgent.GetComponent<Agent>().MaxEnergy;
            newAgent.GetComponent<Agent>().MaxHealth = Random.Range(this.MaxHealthMin, this.MaxHealthMax);
            newAgent.GetComponent<Agent>().Health = newAgent.GetComponent<Agent>().MaxHealth;
            newAgent.GetComponent<Agent>().IsWantingReproduce = false;
            newAgent.GetComponent<Agent>().lastReproduceTime = 0;
            newAgent.GetComponent<Agent>().FertilityRate = Random.Range(this.FertilityRateMin, this.FertilityRateMax);
            newAgent.GetComponent<Agent>().MaxSpeed = Random.Range(this.MaxSpeedMin, this.MaxSpeedMax);
            newAgent.GetComponent<Agent>().Speed = newAgent.GetComponent<Agent>().MaxSpeed;
            newAgent.GetComponent<Agent>().VisionRadius = Random.Range(this.VisionRadiusMin, this.VisionRadiusMax);
            newAgent.GetComponent<Agent>().Color = Color.blue;
            newAgent.GetComponent<Agent>().Name = $"Agent {i}";
        }
        AgentCounter = AgentIni;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
