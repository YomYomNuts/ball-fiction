using UnityEngine;
using System.Collections;

/// <summary>
/// Script de comportement du navigateur de page (qui permet de naviguer d'une page à l'autre dans la vue Info)
/// </summary>
public class PagesNavigatorScript : MonoBehaviour {
	#region Static Elements
	private static PagesNavigatorScript _instance;
	
	public static PagesNavigatorScript Instance {
		get {
			if(PagesNavigatorScript._instance == null) {
				PagesNavigatorScript._instance = new PagesNavigatorScript();
			}
			return PagesNavigatorScript._instance;
		}
	}
	#endregion
	
	#region Attributes
	// Le numéro de la page courant
	// On l'initialise à 1 pour qu'au lancement de la vue, on le modifie à 0 et ça cache le bouton Previous
	private int _currentPage = 1;
	
	/// <summary>
	/// Propriété liée à la page courante
	/// Lorsqu'on la modifie, on affiche ou cache les boutons Next et Previous et on met à jour le numéro de page
	/// </summary>
	public int CurrentPage {
		get {
			return this._currentPage;
		}
		private set {
			// On vérifie que la valeur donnée est valide
			if(value >= 0 && value < this._pages.Length) {
				// Bouton Previous
				if(this._previousButton != null) {
					if(this.CurrentPage == 0 && value > 0) {
					// Si on était sur la première page et qu'on passe à la suivante, on affiche le bouton
						UtilsScript.ShowObject(this._previousButton);
					} else if(this.CurrentPage > 0 && value == 0) {
					// Si on était sur une page autre que la première et qu'on revient à la première, on cache le bouton
						UtilsScript.HideObject(this._previousButton);
					}
				}
				// Bouton Next
				if(this._nextButton != null) {
					if(this.CurrentPage == this._pages.Length - 1 && value < this._pages.Length - 1) {
					// Si on était sur la dernière page et qu'on passe à la précédente, on affiche le bouton
						UtilsScript.ShowObject(this._nextButton);
					} else if(this.CurrentPage < this._pages.Length - 1 && value == this._pages.Length - 1) {
					// Si on était sur une page autre que la dernière et qu'on vas à la dernière, on cache le bouton
						UtilsScript.HideObject(this._nextButton);
					}
				}
				this._currentPage = value;
				// On modifie le numéro de page
				if(this._textMesh != null) {
					this._textMesh.text = string.Format("{0}/{1}", this.CurrentPage+1, this._pages.Length);
				}
			}
		}
	}
	/// <summary>
	/// LEs pages à gérer
	/// </summary>
	public GameObject[] _pages;
	/// <summary>
	/// Le bouton pour passer à la page suivante
	/// </summary>
	public GameObject _nextButton;
	/// <summary>
	/// Le bouton pour passer à la page précédent
	/// </summary>
	public GameObject _previousButton;
	/// <summary>
	/// L'objet contenant le text pour le numéro de page
	/// </summary>
	public GameObject _textPageNumber;
	
	// Le text pour le numéro de page
	private TextMesh _textMesh;
	#endregion
	
	// Méthode appelée lors du "réveil" de l'objet (avant même le Start)
	// Il est important de créer les singleton dans le Awake pour être sûr qu'ils soient créé avant le Start des autres objets
	void Awake() {
		// Unity créera l'objet même si le constructeur est privé donc on doit initialiser l'instance de notre singleton ici
        if (PagesNavigatorScript._instance == null) {
            PagesNavigatorScript._instance = this;
			// On vérirife s'il manque quelque chose, si c'est le cas, on le dit dans les logs
			if(this._nextButton == null) {
				UtilsScript.WarningMessageWhenNoGameObjectAssigned("next button", this.GetType().ToString(), this.gameObject.name);
			}
			if(this._previousButton == null) {
				UtilsScript.WarningMessageWhenNoGameObjectAssigned("previous button", this.GetType().ToString(), this.gameObject.name);
			}
			if(this._textPageNumber == null || this._textPageNumber.GetComponent<TextMesh>() == null) {
				UtilsScript.WarningMessageWhenNoGameObjectAssigned("text for page number", this.GetType().ToString(), this.gameObject.name);
			} else {
				// Si l'objet contenant le text pour les numéros de page est présent, on l'enregistre dans l'objet TextMesh
				this._textMesh = this._textPageNumber.GetComponent<TextMesh>();
			}
			if(this._pages == null || this._pages.Length == 0) {
				UtilsScript.WarningMessageWhenNoGameObjectAssigned("pages", this.GetType().ToString(), this.gameObject.name);
			} else {
				// S'il y a des pages à gérer, on les cache toute et on ne montre que la première
				this.HideAllPages();
				this.CurrentPage = 0;
				this.ShowCurrentPage();
			}
        } else if (PagesNavigatorScript._instance != this) {
            Destroy(this.gameObject);
        }
	}
	
	// Permet d'afficher la page donnée
	private bool ShowPage(int index) {
		// On vérifie si les pages existent
		if(this._pages == null) {
			Debug.LogError("Trying to access to the nonexistant collection pages");
			return false;
		}
		// On vérifie la validité de l'index donné
		if(index < 0 || index >= this._pages.Length) {
			Debug.LogError("Trying to access out of bounds");
			return false;
		}
		// On vérifie que la page à laquelle on souahite accéder existe
		if(this._pages[index] == null) {
			Debug.LogError("Trying to show an nonexistent page");
			return false;
		}
		// On affiche la page
		UtilsScript.ShowObject(this._pages[index]);
		return true;
	}
	
	// Permet de cacher la page donnée
	private bool HidePage(int index) {
		// On vérifie si les pages existent
		if(this._pages == null) {
			Debug.LogError("Trying to access to the nonexistant collection pages");
			return false;
		}
		// On vérifie la validité de l'index donné
		if(index < 0 || index >= this._pages.Length) {
			Debug.LogError("Trying to access out of bounds");
			return false;
		}
		// On vérifie que la page à laquelle on souahite accéder existe
		if(this._pages[index] == null) {
			Debug.LogError("Trying to show an nonexistent page");
			return false;
		}
		// On cache la page
		UtilsScript.HideObject(this._pages[index]);
		return true;
	}
	
	
	// Permet de cacher toutes les pages
	private bool HideAllPages() {
		// On vérifie si les pages existent
		if(this._pages == null) {
			Debug.LogError("Trying to access to the nonexistant collection pages");
			return false;
		}
		// On boucle pour cacher toutes les pages
		bool isSuccess = true;
		for(int i = 0; i < this._pages.Length; i++) {
			isSuccess = isSuccess && this.HidePage(i);
		}
		return isSuccess;
	}
	
	// Affiche la page courante
	private bool ShowCurrentPage() {
		return this.ShowPage(this.CurrentPage);
	}
	
	// Cache la page courante
	private bool HideCurrentPage() {
		return this.HidePage(this.CurrentPage);
	}
	
	/// <summary>
	/// Passe à la page suivante
	/// </summary>
	/// <returns>
	/// true si tout s'est bien passé
	/// </returns>
	public bool NextPage() {
		// On vérifie si les pages existent
		if(this._pages == null) {
			Debug.LogError("Trying to access to the nonexistant collection pages");
			return false;
		}
		// On vérifie la validité de la page courante
		if(this.CurrentPage < 0 || this.CurrentPage >= this._pages.Length) {
			Debug.LogError("Current page out of bounds");
			return false;
		}
		// On vérifie que la page courante n'est pas la dernière
		if(this.CurrentPage == this._pages.Length-1) {
			return false;
		}
		this.HideCurrentPage(); // On cache l'ancienne page courante
		this.CurrentPage++; // On modifie la page courante
		this.ShowCurrentPage(); // On affiche la nouvelle page courante
		return true;
	}
	
	
	/// <summary>
	/// Revient à la page précédente
	/// </summary>
	/// <returns>
	/// true si tout s'est bien passé
	/// </returns>
	public bool PreviousPage() {
		// On vérifie si les pages existent
		if(this._pages == null) {
			Debug.LogError("Trying to access to the nonexistant collection pages");
			return false;
		}
		// On vérifie la validité de la page courante
		if(this.CurrentPage < 0 || this.CurrentPage >= this._pages.Length) {
			Debug.LogError("Current page out of bounds");
			return false;
		}
		// On vérifie que la page courante n'est pas la première
		if(this.CurrentPage == 0) {
			return false;
		}
		this.HideCurrentPage(); // On cache l'ancienne page courante
		this.CurrentPage--; // On modifie la page courante
		this.ShowCurrentPage(); // On affiche la nouvelle page courante
		return true;
	}
}




























