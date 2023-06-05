using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public partial class Agent : MonoBehaviour
{
    public float MaxSpeed = 4.0f;
    public float MaxEnergy = 100.0f;
    public float MaxHealth = 100.0f;
    public float VisionRadius = 30.0f;
    public string Name = "Unamed";
    public Vector3 NextDestination = new Vector3(0.0f, 0.0f);

    private float Health;
    private float Energy;
    private float Speed;
    private Color Color;

    private TextMesh childTextMesh;
    private NavMeshAgent agent;
    private AgentMaker agentMaker;

    public Agent()
    {

    }

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
            childTextMesh.text = this.Name;
            Debug.LogError("Child TextMesh object not found!");
        }

        this.agent = GetComponent<NavMeshAgent>();
        this.agent.speed = this.MaxSpeed;

        this.agentMaker = GetComponent<AgentMaker>();
        if (this.agentMaker == null)
        {
            Debug.LogError("You have to specify an AgentMaker component if you want to reproduce your agents.");
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
