using System;
using UnityEngine;

public partial class Agent : MonoBehaviour
{
    void LookForFood() {
        if (this.IsWantingReproduce) {
            return;
        }

        NextDestination = this.transform.position;

        GameObject[] objs = GameObject.FindGameObjectsWithTag("Food");
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetDestinationToMousePosition();
        }
        this.ReproduceUpdate();
        this.Energy -= Time.deltaTime;
        this.Energy = Math.Max(this.Energy, 0.0f);
        if (this.Energy <= 0.0f)
        {
            this.Speed = this.MaxSpeed / 3;
        } 
        else
        {
            this.Speed = this.MaxSpeed;
        }
        
    }
}

