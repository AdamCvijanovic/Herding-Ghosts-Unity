using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DrinkType
{
    BOBA,
    SUGAR,
    JUICE
}


public class LiquidParticle : MonoBehaviour
{
    public DrinkType drinkType;

    public BottleMovement bottleMovement;
    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnParticleTrigger()
    {
      
        var particles = new List<ParticleSystem.Particle>();
        int numEnter = GetComponent<ParticleSystem>().GetTriggerParticles(ParticleSystemTriggerEventType.Enter, particles);

        for (int i = 0; i < numEnter; i++)
        {
            bottleMovement.Tip(true);

            if (drinkType == DrinkType.JUICE)
            {
                ParticleSystem.Particle p = particles[i];
                p.remainingLifetime = 0;
                particles[i] = p;
            }
        }
        
        if (drinkType == DrinkType.JUICE)
        {
            GetComponent<ParticleSystem>().SetTriggerParticles(ParticleSystemTriggerEventType.Enter, particles);
        }


    }
}
