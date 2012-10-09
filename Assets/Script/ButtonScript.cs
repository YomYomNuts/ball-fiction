using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {
    public bool _onEnter = true;
    public GameObject _Element;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// Collision pour activer/désactiver le boutton
	void OnTriggerEnter(Collider collision) {
		if(_onEnter) {
			//_Element.GetComponent<ButtonScript>().active = !_Element.GetComponent<ButtonScript>().active;
			_Element.GetComponent<DoorScript>()._isButtonActivated = true;
		}
	}
	
	// Collision pour activer/désactiver le boutton
	void OnTriggerExit(Collider collision) {
		if(!_onEnter) {
			//_Element.GetComponent<ButtonScript>().active = !_Element.GetComponent<ButtonScript>().active;
		}
	}
}
