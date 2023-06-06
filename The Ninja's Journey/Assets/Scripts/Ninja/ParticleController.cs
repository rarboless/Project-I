using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] ParticleSystem _particleSystemMain;
    [SerializeField] ParticleSystem _particleSystemSecondary;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_particleSystemMain == true && Input.GetKey(KeyCode.K))
        {
            _particleSystemMain.Stop();
            _particleSystemSecondary.Play();
        }
        else if(Input.GetKey(KeyCode.K)) 
        {
            _particleSystemMain.Play();
            _particleSystemSecondary.Stop();
        }

    }
}
