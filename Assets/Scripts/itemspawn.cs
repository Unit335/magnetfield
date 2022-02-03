using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//for button spawning dipoles in glassroom1
public class itemspawn : MonoBehaviour
{
    public GameObject magnet_sphere;
    void OnMouseDown()
    {
        Color32 spherecolor = new Color32(
            (byte)Random.Range(0, 255),
            (byte)Random.Range(0, 255),
            (byte)Random.Range(0, 255),
            255
        );
        var newsphere = Instantiate(magnet_sphere, new Vector3((float)-5, (float)3, (float)-26), Quaternion.identity);
        newsphere.GetComponent<Renderer>().material.color = spherecolor;
       // Vector3 randomDirection = new Vector3(Random.Range(-359, 359),Random.Range(-359, 359),Random.Range(-359, 359));  
       // newsphere.GetComponent<Transform>().Rotate(randomDirection);
       // newsphere.GetComponent<Rigidbody>().AddForce(transform.forward * 200);
        newsphere.GetComponent<Rigidbody>().velocity = Random.onUnitSphere * 20;
    }
}