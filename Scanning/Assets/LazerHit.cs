using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerHit : MonoBehaviour
{
    public ParticleSystem hitEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gotHit(RaycastHit hit)
    {
        ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams();
        emitParams.position = hit.point;
        hitEffect.Emit(emitParams, 1);
        // debug statements
        Debug.Log("Hit point: " + hit.point);
        Debug.Log("Particle system position: " + hitEffect.transform.position);
        Debug.Log("Particle count: " + hitEffect.particleCount);
    }
}
