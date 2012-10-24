using UnityEngine;
using System;

/// <summary>
/// Script de comportement d'une porte
/// </summary>
public class DoorScript : MonoBehaviour {
	// La position d'origine, afin de pouvoir refermer la porte comme il faut
	private Vector3 _savedPosition;
	
	/// <summary>
	/// Permet de savoir si la porte est ouverte
	/// </summary>
	public bool _isOpened = false;
	/// <summary>
	/// Propriété liée à isOpened
	/// </summary>
	public bool IsOpened {
		get {
			return this._isOpened;
		}
		private set {
			this._isOpened = value;
		}
	}
	/// <summary>
	/// La position maximale pour la porte
	/// </summary>
	public float _maxPosition = 0;
	/// <summary>
	/// Vitesse de l'action effectué lors de l'activation du bouton
	/// </summary>
	public float _elementSpeed = 0.1f;
	/// <summary>
	/// La direction dans laquelle la porte s'ouvre
	/// </summary>
    public Utils.Direction _doorDirection = Utils.Direction.Up;
	
	// Use this for initialization
	void Start () {
		this._savedPosition = this.transform.localPosition;
	}
	
	// Ouvre la porte
	public void OpenTheDoor() {
		if(!this.IsOpened) {
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
	}
	// Ferme la porte
	public void CloseTheDoor() {
		if(this.IsOpened) {
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
	}
	
	// Les ouvertures selon la direction de la porte
	private void OpenTheDoorToLeft() {
		if(this.transform.localPosition.x >= this._maxPosition) {
			this.transform.localPosition -= new Vector3(this._elementSpeed, 0, 0);
		} else {
			this.IsOpened = true;
		}
	}
	private void OpenTheDoorToRight() {
		if(this.transform.localPosition.x <= this._maxPosition) {
			this.transform.localPosition += new Vector3(this._elementSpeed, 0, 0);
		} else {
			this.IsOpened = true;
		}
	}
	private void OpenTheDoorToUp() {
		if(this.transform.localPosition.y <= this._maxPosition) {
			this.transform.localPosition += new Vector3(0, this._elementSpeed, 0);
		} else {
			this.IsOpened = true;
		}
	}
	private void OpenTheDoorToDown() {
		if(this.transform.localPosition.y >= this._maxPosition) {
			this.transform.localPosition -= new Vector3(0, this._elementSpeed, 0);
		} else {
			this.IsOpened = true;
		}
	}
	private void OpenTheDoorToForward() {
		if(this.transform.localPosition.z <= this._maxPosition) {
			this.transform.localPosition += new Vector3(0, 0, this._elementSpeed);
		} else {
			this.IsOpened = true;
		}
	}
	private void OpenTheDoorToBack() {
		if(this.transform.localPosition.z >= this._maxPosition) {
			this.transform.localPosition -= new Vector3(0, 0, this._elementSpeed);
		} else {
			this.IsOpened = true;
		}
	}
	
	// Les fermeture selon la direction de la porte
	private void CloseTheDoorFromLeft() {
		if (this._savedPosition.x > Math.Round(this.transform.localPosition.x, 2)) {
			this.transform.localPosition += new Vector3(this._elementSpeed, 0, 0);
		} else {
			this.transform.localPosition = this._savedPosition;
			this.IsOpened = false;
		}
	}
	private void CloseTheDoorFromRight() {
		if (this._savedPosition.x < Math.Round(this.transform.localPosition.x, 2)) {
			this.transform.localPosition -= new Vector3(this._elementSpeed, 0, 0);
		} else {
			this.transform.localPosition = this._savedPosition;
			this.IsOpened = false;
		}
	}
	private void CloseTheDoorFromUp() {
		if (this._savedPosition.y < Math.Round(this.transform.localPosition.y, 2)) {
			this.transform.localPosition -= new Vector3(0, this._elementSpeed, 0);
		} else {
			this.transform.localPosition = this._savedPosition;
			this.IsOpened = false;
		}
	}
	private void CloseTheDoorFromDown() {
		if (this._savedPosition.y > Math.Round(this.transform.localPosition.y, 2)) {
			this.transform.localPosition += new Vector3(0, this._elementSpeed, 0);
		} else {
			this.transform.localPosition = this._savedPosition;
			this.IsOpened = false;
		}
	}
	private void CloseTheDoorFromForward() {
		if (this._savedPosition.z < Math.Round(this.transform.localPosition.z, 2)) {
			this.transform.localPosition -= new Vector3(0, 0, this._elementSpeed);
		} else {
			this.transform.localPosition = this._savedPosition;
			this.IsOpened = false;
		}
	}
	private void CloseTheDoorFromBack() {
		if (this._savedPosition.z > Math.Round(this.transform.localPosition.z, 2)) {
			this.transform.localPosition += new Vector3(0, 0, this._elementSpeed);
		} else {
			this.transform.localPosition = this._savedPosition;
			this.IsOpened = false;
		}
	}
}
