using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//provides for objects property of magnetization
public class MagnetizableMaterial : MonoBehaviour {
    public GameObject electromagneticFieldController = null;
    protected ElectromagneticFieldControllerScript controller;
    
    public float strength = 1e-14f;  // susceptibility/(1 + susceptibility) times volume
    public bool applyExternalForce = false; //solenoid = external force
    public bool applyDipoleForce = true;

    private Dictionary<int,SpringJoint> sjToDipole = new Dictionary<int,SpringJoint>();
    private Dictionary<int,SpringJoint> sjFromDipole = new Dictionary<int,SpringJoint>();

	void Start() {
	    if (!electromagneticFieldController) {
	        electromagneticFieldController = GameObject.Find("ElectromagneticFieldController");
	    }
	    controller = electromagneticFieldController.GetComponent<ElectromagneticFieldControllerScript>();
	}
	
	void FixedUpdate() {
	    controller.ApplyForcesOnMagnetizable(applyExternalForce, applyDipoleForce, strength, gameObject, ref sjToDipole, ref sjFromDipole);
	}
}
