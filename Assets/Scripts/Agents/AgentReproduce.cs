using System;
using System.Collections.Generic;
using UnityEngine;

public partial class Agent : MonoBehaviour
{
    private float lastReproduceTime = 0.0f;
    public bool IsWantingReproduce = false;



    // look for another Agent to reproduce and if want to reproduce too, reproduce
    private void TryToReproduce()
    {
        if (this.Energy < this.MaxEnergy)
        {
            IsWantingReproduce = false;
            return;
        }

        GameObject[] objs = GameObject.FindGameObjectsWithTag("Agent");
        if (objs.Length == 0)
        {
            return;
        }
        Agent closestAgent = objs[0].GetComponent<Agent>();
        bool wantToReproduce = false;
        float closestDistance = (this.transform.position - objs[0].transform.position).magnitude;
        foreach (var obj in objs)
        {
            var agent = obj.GetComponent<Agent>();
            if ((this.transform.position - obj.transform.position).magnitude < closestDistance )
            {
                if (agent.IsWantingReproduce)
                {
                    wantToReproduce = true;
                    closestAgent = agent;
                    closestDistance = (this.transform.position - obj.transform.position).magnitude;
                }
            }
        }

        if (wantToReproduce)
        {
            this.NextDestination = closestAgent.transform.position;
            var child = this.agentMaker.Reproduce(this, closestAgent);
            var entity = Instantiate(child);
            this.IsWantingReproduce = false;
            closestAgent.IsWantingReproduce = false;
        }
    }

    private void ReproduceUpdate()
    {
        if (this.IsWantingReproduce)
        {
            this.TryToReproduce();
        }
    }
}

