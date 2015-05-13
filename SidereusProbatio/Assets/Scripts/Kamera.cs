using UnityEngine;
using System.Collections;

public class Kamera : MonoBehaviour {

	public Ray ray;		
	public Vector2 mousePos;
	
	private Transform _target;
	private GameObject _player;
	private Vector3 _wantedPosition;
	private bool FirstPersonStatus = false;
	
	public float distance = 50.0f;
	public float height = 3.0f;
	public float damping = 15.0f;
	public float rotationDamping = 1.0f;
	
	void Start(){
		_player = GameObject.FindGameObjectWithTag("Player");
		_target=_player.transform;
	}
	
	void Update () {

		if (Input.GetKey (KeyCode.C) && !FirstPersonStatus) {

			ray = Camera.main.ScreenPointToRay(mousePos);
			FirstPersonStatus = true;

		} else if (Input.GetKey (KeyCode.C) && FirstPersonStatus) {

			FirstPersonStatus = false;
		}

	}
	
	void LateUpdate(){

		if (!FirstPersonStatus) {

			SmoothFollow();
			GameObject.FindGameObjectWithTag("FirstPersonCam").GetComponent<Camera>().enabled = false;
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().enabled = true;

		} else {

			GameObject.FindGameObjectWithTag("FirstPersonCam").GetComponent<Camera>().enabled = true;
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().enabled = false;
		}
	}


	//weiche Kamera-Verfolgung 3rd Person
	void SmoothFollow(){

		//Spieler verfolgen.
		_wantedPosition = _target.TransformPoint(0, height, -distance);
		transform.position = Vector3.Lerp (transform.position, _wantedPosition, Time.deltaTime * damping);
		
		Quaternion _wantedRotation = Quaternion.LookRotation(_target.position - transform.position, _target.up);
		
		transform.rotation = Quaternion.Slerp (transform.rotation, _wantedRotation, Time.deltaTime * rotationDamping);
		
		transform.LookAt (_target, _target.up);	
	}


}
