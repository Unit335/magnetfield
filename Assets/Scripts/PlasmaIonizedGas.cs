using UnityEngine;
using System.Collections;

//ioniz gas
public class PlasmaIonizedGas : MonoBehaviour {
    public GameObject electromagneticFieldController = null;
    private ElectromagneticFieldControllerScript controller;

    public float chargeOverMass = 1000.0f;  //Couloumb/kg
    public int maxParticles = 256;   

    private ParticleSystem theParticleSystem;
    private ParticleSystem.Particle[] particles;

	void Start() {
	    if (!electromagneticFieldController) {
	        electromagneticFieldController = GameObject.Find("ElectromagneticFieldController");
	    }
	    controller = electromagneticFieldController.GetComponent<ElectromagneticFieldControllerScript>();
	    
        theParticleSystem = gameObject.GetComponent<ParticleSystem>();
        particles = new ParticleSystem.Particle[maxParticles];
	}
	
	void FixedUpdate() {
	    //particle acceleration from external forces
	    
        int numParticles = theParticleSystem.GetParticles(particles);
        for (int i = 0;  i < numParticles;  i++) {
            Vector3 E = controller.ElectricField(particles[i].position);
            Vector3 B = controller.MagneticField(particles[i].position);
            particles[i].velocity += chargeOverMass * (E + Vector3.Cross(particles[i].velocity, B));
        }
        theParticleSystem.SetParticles(particles, numParticles);
	}
}
