using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enable/disable plasma stream button
public class plasma_switch : MonoBehaviour
{
    public GameObject streamparticles;
    static private bool ps_enabled = false; 
    void OnMouseDown()
    {
        var part = streamparticles.GetComponent<ParticleSystem>();
        if (ps_enabled == false)
        {
            part.Play();
            ps_enabled = !ps_enabled;
        }
        else
        {
            part.Stop();
            ps_enabled = !ps_enabled;
        }
    }

}
