using UnityEngine;
using System.Collections;

public class TrayScript : MonoBehaviour {
    public float _rotationSpeedTray = 0.3f;
    public float _repulsionForce = 0.01f;
	
    // Définition du type d'évènement
    public delegate void ActionEvent();

    static public event ActionEvent OnLeft;
    static public event ActionEvent OnRight;
	
	// Evènement déclanché lors de l'appui sur le bouton gauche
    void OnLeftEventReceived()
    {
        this.transform.RotateAround(Vector3.forward, _rotationSpeedTray * Time.deltaTime);
    }
	// Evènement déclanché lors de l'appui sur le bouton droite
    void OnRightEventReceived()
    {
        this.transform.RotateAround(Vector3.back, _rotationSpeedTray * Time.deltaTime);
    }
	
	// Use this for initialization
	void Start () {
        OnLeft += new ActionEvent(OnLeftEventReceived);
        OnRight += new ActionEvent(OnRightEventReceived);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Left")) {
            OnLeft();
		}
		if(Input.GetButton("Right")) {
            OnRight();
		}
	}
	
	// Ajout d'une force de répulsion
	void OnCollisionStay(Collision collision) {
		collision.gameObject.rigidbody.AddForce(Vector3.up * _repulsionForce);
	}
}
