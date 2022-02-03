using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//for button spawning dipoles in glassroom2
public class itemspawn2 : MonoBehaviour
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
        var newsphere = Instantiate(magnet_sphere, new Vector3((float)24.41135, (float)5.435988, (float)-20.80681), Quaternion.identity);
        newsphere.GetComponent<Renderer>().material.color = spherecolor;
        //newsphere.GetComponent<Rigidbody>().AddForce(transform.forward * 80);
    }
}