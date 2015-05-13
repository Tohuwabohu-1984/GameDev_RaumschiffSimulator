using UnityEngine;
using System.Collections;

public class TriggerButtons : MonoBehaviour {

	private bool _run = false;
	private SpielerBewegung _SpielerBewegung;

	// Draws a horizontal slider control that goes from 0 to 100.
	public float hSliderValue  = 0.0f;
		
	void Start(){
		_SpielerBewegung = GameObject.FindGameObjectWithTag("Player").GetComponent<SpielerBewegung>();
	}
	
	void OnGUI () {

		float xmittelPosOnScreen = Screen.width / 2 - 125;
		float ymittelPosOnScreen = Screen.height / 2 - 35;

		if (!_run && GUI.Button (new Rect (xmittelPosOnScreen, ymittelPosOnScreen, 250, 70), "Start")) {

			_SpielerBewegung.status = true;
			_run = true;
		}else if (_run && GUI.Button (new Rect (10,10,100,50), "Stop")) {

			_SpielerBewegung.status = false;
			_run = false;
		}


		if(!_run)
		{
			GUI.Label (new Rect(xmittelPosOnScreen + 10, ymittelPosOnScreen + 70, 250, 25), "Lautstärke:");
			hSliderValue = GUI.HorizontalSlider (new Rect (xmittelPosOnScreen+10, ymittelPosOnScreen + 90, 200, 30), hSliderValue, 0.0f, 100.0f);

			GUI.Label (new Rect(10, 100, 250, 25), "Übersicht Steuerung:");
			GUI.Label (new Rect(10, 125, 250, 25), "W - Gas");
			GUI.Label (new Rect(10, 150, 250, 25), "S - Bremse");
			GUI.Label (new Rect(10, 175, 250, 25), "A - Rotieren Links");
			GUI.Label (new Rect(10, 200, 250, 25), "D - Roteren Rechts");				
			GUI.Label (new Rect(10, 225, 250, 25), "Kamara folgt Maus");
		}	
	}
}
