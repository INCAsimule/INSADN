using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Agent : MonoBehaviour
{
    public float Speed = 5.0f;
    public float MaxEnergy = 100.0f;
    public float MaxHealth = 100.0f;
    public float VisionRadius = 30.0f;
    public int FertilityRate = 200;
    public string Name = "Unamed";

    private float Health;
    private float Energy;
    private Color Color;

    private TextMesh childTextMesh;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        this.Health = MaxHealth;
        this.Energy = MaxEnergy;
        this.Color = Color.blue;

        // Find the child TextMesh object
        childTextMesh = transform.Find("NameTag").GetComponent<TextMesh>();
        if (childTextMesh == null)
        {
            Debug.LogError("Child TextMesh object not found!");
        }

        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetDestinationToMousePosition();
        }
    }

    void SetDestinationToMousePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            agent.SetDestination(hit.point);
        }
    }
}
