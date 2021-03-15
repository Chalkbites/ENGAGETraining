using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceFireOnCollision : MonoBehaviour
{
    public Transform fireTransform;
    public int particleCountToExtinguish = 750;

    private float particleCurrentCount = 0;
    private GameObject prevOther;

    private void OnParticleCollision(GameObject other)
    {
        if(other.CompareTag("ExtinguisherParticle"))
        {
            prevOther = other;
            particleCurrentCount += 1;

            if (particleCurrentCount < particleCountToExtinguish)
            {
                float scaleFactor = 1 - (particleCurrentCount / particleCountToExtinguish); 
                fireTransform.localScale = scaleFactor * Vector3.one;
            }
            else
            {
                fireTransform.localScale = Vector3.zero;
            }
        }
    }

    public void ResetFire()
    {
        fireTransform.localScale = Vector3.one;
    }
}
