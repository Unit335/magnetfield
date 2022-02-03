using UnityEngine;
using System.Collections;

public class ElectromagneticInfinitesimal : MonoBehaviour {
    public GameObject electromagneticFieldController = null;
    protected ElectromagneticFieldControllerScript controller;

    protected int rigidbodyId;

	public int GetRigidbodyId() {
	    return rigidbodyId;
	}
	
	//collision of objects
	void OnTriggerEnter(Collider other) {
	    ElectromagneticInfinitesimal otherScript = other.gameObject.GetComponent<MagneticDipoleScript>();
	    if (otherScript) {
	        controller.UpdateCollisionState(rigidbodyId, otherScript.GetRigidbodyId(), 1);
	    }
	}
	void OnTriggerExit(Collider other) {
	    ElectromagneticInfinitesimal otherScript = other.gameObject.GetComponent<MagneticDipoleScript>();
	    if (otherScript) {
	        controller.UpdateCollisionState(rigidbodyId, otherScript.GetRigidbodyId(), 0);
	    }
	}
}

public class MagneticDipoleScript : ElectromagneticInfinitesimal {
    public float strength = 300.0f;  //Ampere-square meters 
    public bool applyTorqueOnly = false;
    public float overrideColliderPoof = -1.0f;

    private Transform parentTransform;
    private Rigidbody parentRigidbody;
    private Collider parentCollider;
    private int magneticDipoleId;

	void Start () {
	    if (!electromagneticFieldController) {
	        electromagneticFieldController = GameObject.Find("ElectromagneticFieldController");
	    }
	    controller = electromagneticFieldController.GetComponent<ElectromagneticFieldControllerScript>();

        parentTransform = gameObject.transform.parent;        
        parentCollider = parentTransform.gameObject.GetComponent<Collider>();
        parentRigidbody = parentTransform.GetComponent<Rigidbody>();
        while (!parentRigidbody) {
            parentTransform = parentTransform.parent;
            if (!parentCollider) {
                parentCollider = parentTransform.gameObject.GetComponent<Collider>();
            }
            parentRigidbody = parentTransform.GetComponent<Rigidbody>();
        }
	    
	    controller.AssignMagneticDipoleId(gameObject, parentRigidbody, parentCollider, overrideColliderPoof, applyTorqueOnly, out rigidbodyId, out magneticDipoleId);
	    
	    controller.UpdateMagneticDipole(rigidbodyId, magneticDipoleId, transform.position, transform.TransformDirection(strength * Vector3.forward));
	}
	
	void FixedUpdate() {
	    controller.UpdateMagneticDipole(rigidbodyId, magneticDipoleId, transform.position, transform.TransformDirection(strength * Vector3.forward));
	}

	~MagneticDipoleScript() {
	    controller.RemoveMagneticDipole(rigidbodyId, magneticDipoleId);
	}
}
