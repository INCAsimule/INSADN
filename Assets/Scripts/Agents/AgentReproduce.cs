using System;
using System.Collections.Generic;
using UnityEngine;

public partial class Agent : MonoBehaviour
{
    private float lastReproduceTime = 0.0f;
    public bool IsWantingReproduce = false;

    public void Reproduce(Agent otherAgent)
    {   
        if (otherAgent == null)
        {
            return;
        }

        if (this.Energy < this.MaxEnergy*0.8f)
        {
            return;
        }
        if (otherAgent.Energy < otherAgent.MaxEnergy*0.8f)
        {
            return;
        }
        this.Energy -= this.MaxEnergy / 2;
        otherAgent.Energy -= otherAgent.MaxEnergy / 2;
        var child = Instantiate(this.gameObject, this.transform.position, Quaternion.identity);
        child.GetComponent<Agent>().Energy = 0;
        child.GetComponent<Agent>().IsWantingReproduce = false;
        child.GetComponent<Agent>().lastReproduceTime = Time.time;
        child.GetComponent<Agent>().FertilityRate = this.FertilityRate;
        child.GetComponent<Agent>().MaxEnergy = this.MaxEnergy;
        child.GetComponent<Agent>().Speed = this.Speed;
        child.GetComponent<Agent>().VisionRadius = this.VisionRadius;

        otherAgent.IsWantingReproduce = false;
        this.IsWantingReproduce = false;
        this.lastReproduceTime = Time.time;
        otherAgent.lastReproduceTime = Time.time;
}

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
            this.Reproduce(closestAgent);
        }

    }

    private void ReproduceUpdate()
    {
        if (this.lastReproduceTime + this.FertilityRate < Time.time)
        {
            this.IsWantingReproduce = true;
        }
        if (this.IsWantingReproduce)
        {
            this.TryToReproduce();
        }
    }
}

