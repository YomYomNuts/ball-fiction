using UnityEngine;
using System;

/// <summary>
/// Script de comportement d'une porte qui s'ouvre à la première activation du bouton puis se ferme à la seconde
/// </summary>
public class PonctualButtonForDoorScript : PonctualButtonScript {
	/// <summary>
	/// La position maximale pour la porte
	/// </summary>
	public float _maxPosition = 0;
	/// <summary>
	/// Vitesse de l'action effectué lors de l'activation du bouton
	/// </summary>
	public float _elementSpeed = 0.1f;
	/// <summary>
	/// La porte que le bouton ouvre
	/// </summary>
    public GameObject _theDoor;
	/// <summary>
	/// La porte que le bouton ouvre
	/// </summary>
    public Utils.Direction _doorDirection = Utils.Direction.Up;
	
	// True s'il faut ouvrir la porte
	private bool _hasToBeOpened = false;
	// True s'il faut fermer la porte
	private bool _hasToBeClosed = false;
	// La position d'origine, afin de pouvoir refermer la porte comme il faut
	private Vector3 _savedPosition;
	
	// Use this for initialization
	void Start () {
		if(this._theBall == null) {
			Utils.WarningMessageWhenNoGameObjectAssigned("ball", this.GetType().ToString(), this.gameObject.name);
		}
		if(this._theDoor == null) {
			Utils.WarningMessageWhenNoGameObjectAssigned("door", this.GetType().ToString(), this.gameObject.name);
		} else {
			this._savedPosition = this._theDoor.transform.localPosition;
		}
	}
	
	// Action effectuée lorsque le bouton est activé
	override protected void ActionWhenActivated() {
		this._hasToBeOpened = true;
	}
	// Action effectuée lorsque le bouton est activé
	override protected void ActionWhenNonActivated() {
		this._hasToBeClosed = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(this._theDoor != null) {
			if(this._hasToBeOpened) {
				this.OpenTheDoor();
			} else if(this._hasToBeClosed) {
				this.CloseTheDoor();
			}
		}
	}
	
	// Ouvre la porte
	private void OpenTheDoor() {
		if(this._doorDirection == Utils.Direction.Up) {
			this.OpenTheDoorToUp();
		} else if(this._doorDirection == Utils.Direction.Down) {
			this.OpenTheDoorToDown();
		} else if(this._doorDirection == Utils.Direction.Left) {
			this.OpenTheDoorToLeft();
		} else if(this._doorDirection == Utils.Direction.Right) {
			this.OpenTheDoorToRight();
		} else if(this._doorDirection == Utils.Direction.Forward) {
			this.OpenTheDoorToForward();
		} else if(this._doorDirection == Utils.Direction.Back) {
			this.OpenTheDoorToBack();
		}
	}
	// Ferme la porte
	private void CloseTheDoor() {
		if(this._doorDirection == Utils.Direction.Up) {
			this.CloseTheDoorFromUp();
		} else if(this._doorDirection == Utils.Direction.Down) {
			this.CloseTheDoorFromDown();
		} else if(this._doorDirection == Utils.Direction.Left) {
			this.CloseTheDoorFromLeft();
		} else if(this._doorDirection == Utils.Direction.Right) {
			this.CloseTheDoorFromRight();
		} else if(this._doorDirection == Utils.Direction.Forward) {
			this.CloseTheDoorFromForward();
		} else if(this._doorDirection == Utils.Direction.Back) {
			this.CloseTheDoorFromBack();
		}
	}
	
	// Les ouvertures selon la direction de la porte
	private void OpenTheDoorToLeft() {
		if(this._theDoor.transform.localPosition.x >= this._maxPosition) {
			this._theDoor.transform.localPosition -= new Vector3(this._elementSpeed, 0, 0);
		} else {
			this._hasToBeOpened = false;
		}
	}
	private void OpenTheDoorToRight() {
		if(this._theDoor.transform.localPosition.x <= this._maxPosition) {
			this._theDoor.transform.localPosition += new Vector3(this._elementSpeed, 0, 0);
		} else {
			this._hasToBeOpened = false;
		}
	}
	private void OpenTheDoorToUp() {
		if(this._theDoor.transform.localPosition.y <= this._maxPosition) {
			this._theDoor.transform.localPosition += new Vector3(0, this._elementSpeed, 0);
		} else {
			this._hasToBeOpened = false;
		}
	}
	private void OpenTheDoorToDown() {
		if(this._theDoor.transform.localPosition.y >= this._maxPosition) {
			this._theDoor.transform.localPosition -= new Vector3(0, this._elementSpeed, 0);
		} else {
			this._hasToBeOpened = false;
		}
	}
	private void OpenTheDoorToForward() {
		if(this._theDoor.transform.localPosition.z <= this._maxPosition) {
			this._theDoor.transform.localPosition += new Vector3(0, 0, this._elementSpeed);
		} else {
			this._hasToBeOpened = false;
		}
	}
	private void OpenTheDoorToBack() {
		if(this._theDoor.transform.localPosition.z >= this._maxPosition) {
			this._theDoor.transform.localPosition -= new Vector3(0, 0, this._elementSpeed);
		} else {
			this._hasToBeOpened = false;
		}
	}
	// Les fermeture selon la direction de la porte
	private void CloseTheDoorFromLeft() {
		if (this._savedPosition.x > Math.Round(this._theDoor.transform.localPosition.x, 2)) {
			this._theDoor.transform.localPosition += new Vector3(this._elementSpeed, 0, 0);
		} else {
			this._hasToBeClosed = false;
		}
	}
	private void CloseTheDoorFromRight() {
		if (this._savedPosition.x < Math.Round(this._theDoor.transform.localPosition.x, 2)) {
			this._theDoor.transform.localPosition -= new Vector3(this._elementSpeed, 0, 0);
		} else {
			this._hasToBeClosed = false;
		}
	}
	private void CloseTheDoorFromUp() {
		if (this._savedPosition.y < Math.Round(this._theDoor.transform.localPosition.y, 2)) {
			this._theDoor.transform.localPosition -= new Vector3(0, this._elementSpeed, 0);
		} else {
			this._hasToBeClosed = false;
		}
	}
	private void CloseTheDoorFromDown() {
		if (this._savedPosition.y > Math.Round(this._theDoor.transform.localPosition.y, 2)) {
			this._theDoor.transform.localPosition += new Vector3(0, this._elementSpeed, 0);
		} else {
			this._hasToBeClosed = false;
		}
	}
	private void CloseTheDoorFromForward() {
		if (this._savedPosition.z < Math.Round(this._theDoor.transform.localPosition.z, 2)) {
			this._theDoor.transform.localPosition -= new Vector3(0, 0, this._elementSpeed);
		} else {
			this._hasToBeClosed = false;
		}
	}
	private void CloseTheDoorFromBack() {
		if (this._savedPosition.z > Math.Round(this._theDoor.transform.localPosition.z, 2)) {
			this._theDoor.transform.localPosition += new Vector3(0, 0, this._elementSpeed);
		} else {
			this._hasToBeClosed = false;
		}
	}
}
