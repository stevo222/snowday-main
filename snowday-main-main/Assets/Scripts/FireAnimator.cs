using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAnimator : MonoBehaviour
{
    public ParticleSystem fireParticle;
    private Animator fireAnim;

    // Start is called before the first frame update
    void Start()
    {
        fireAnim = GetComponent<Animator>();
        fireParticle.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
