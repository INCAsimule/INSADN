using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class AgentMaker : MonoBehaviour
{
	public double MaxHealthSigma = 5.0;
    public double MaxEnergySigma = 5.0;
    public double MaxSpeedSigma = 1.0;
    public double VisionRadiusSigma = 5.0;

    private Agent PickRandomParent(Agent parent1, Agent parent2)
	{
		if (Random.Range(0.0f, 0.0f) <= 0.5f)
		{
			return parent1;
		}
		else
		{
			return parent2;
		}
	}

    public Agent Reproduce(Agent parent1, Agent parent2)
    {
        // for each property 50% of chance that the property of the child is of the parent1 and the second half for the second parent
        // To each property mutate the property based on a normal distribution
		Agent child = new();
        var gaussian = new Gaussian();


        child.MaxEnergy = this.PickRandomParent(parent1, parent2).MaxEnergy;
		child.MaxEnergy += (float)gaussian.RandomGauss(0.0, this.MaxEnergySigma);

		child.MaxHealth = this.PickRandomParent(parent1, parent2).MaxHealth;
		child.MaxHealth += (float)gaussian.RandomGauss(0.0, this.MaxHealthSigma);

        child.MaxSpeed = this.PickRandomParent(parent1, parent2).MaxSpeed;
        child.MaxSpeed += (float)gaussian.RandomGauss(0.0, this.MaxSpeedSigma);

        child.VisionRadius = this.PickRandomParent(parent1, parent2).VisionRadius;
        child.VisionRadius += (float)gaussian.RandomGauss(0.0, this.VisionRadiusSigma);


        return child;
    }
}

