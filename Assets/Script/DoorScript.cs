using UnityEngine;
using System.Collections;

/// <summary>
/// Script de comportement d'une porte
/// </summary>
public class DoorScript : ElementScript {
	/// <summary>
	/// La position Y, afin de pouvoir refermer la porte comme il faut
	/// </summary>
	private float _savedPositionY;
	
	// Use this for initialization
	void Start () {
		this._savedPositionY = this.gameObject.transform.localPosition.y;
	}
	
	// Update is called once per frame
	void Update () {
		base.UpdateState();
		if(this._isButtonActivated) {
			this.gameObject.transform.localPosition += new Vector3(0, this._elementSpeed, 0);
		} else if(this._savedPositionY < this.gameObject.transform.position.y) {
			this.gameObject.transform.localPosition += new Vector3(0, -this._elementSpeed, 0);
		}
	}
}
