using UnityEngine;
using System.Collections;

/// <summary>
/// Script de récupération de click
/// </summary>
public class ClickListenerScript : MonoBehaviour {
	
    // Définition du type d'évènement
    public delegate void ActionEventClick();
	
	/// <summary>
	/// Liste des méthodes à appeler au click
	/// </summary>
	public event ActionEventClick OnClicked;
	
	// Update is called once per frame
	void Update() {
		if(Input.GetButton("LeftClick")) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(this.collider.bounds.IntersectRay(ray)) {
				Click();
			}
		}
	}
	
	// Méthode appelé lors du click
	public void Click() {
		if(OnClicked != null) {
			OnClicked();
		}
	}
	
}
