using UnityEngine;
using System.Collections;

public class PartikelGeschwindigkeit : MonoBehaviour {

	private SpielerBewegung _spieler;
	private float speed;
	
	// Use this for initialization
	void Start () {
		_spieler = GameObject.FindGameObjectWithTag("Player").GetComponent<SpielerBewegung>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (_spieler.status) {
			if (_spieler.momentaneGeschwindigkeit <= 2){
				
				GetComponent<ParticleEmitter> ().emit = false;
			}
			else {
				GetComponent<ParticleEmitter> ().emit = true;
				
				Vector3 aux = GetComponent<ParticleEmitter> ().localVelocity;
				aux.z = -(_spieler.momentaneGeschwindigkeit * 50) / 20;
				
				GetComponent<ParticleEmitter> ().localVelocity = aux;
			}
		} else {
			GetComponent<ParticleEmitter> ().emit = false;
		}
	}
}
