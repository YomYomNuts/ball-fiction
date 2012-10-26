using UnityEngine;

/// <summary>
/// Script gérant l'affichage du temps
/// </summary>
public class DisplayTimeScript : MonoBehaviour {
	#region Static Elements
	// Instance de la classe
    private static DisplayTimeScript _instance;
	
	/// <summary>
	/// Propriété pour accéder publiquement à l'instance de la classe
	/// </summary>
    public static DisplayTimeScript Instance {
        get {
			// Si l'instance n'existe pas, on la crée
            if (DisplayTimeScript._instance == null) {
                DisplayTimeScript._instance = new DisplayTimeScript();
			}
            return DisplayTimeScript._instance;
        }
    }
	#endregion
	
	#region Attributes
	// Le texte pour afficher le temps
    private TextMesh _textMesh;
	#endregion
	
	#region Unity Methods
	// Méthode appelée lors du "réveil" de l'objet (avant même le Start)
	// Il est important de créer les singleton dans le Awake pour être sûr qu'ils soient créé avant le Start des autres objets
	void Awake () {
		// Unity créera l'objet même si le constructeur est privé donc on doit initialiser l'instance de notre singleton ici
        if (DisplayTimeScript._instance == null) { // S'il n'y pas d'instance
            DisplayTimeScript._instance = this; // L'objet courant devient l'instance
			// On récupère le textMesh associé
	        this._textMesh = this.GetComponent<TextMesh>();
	        if (this._textMesh == null) { // S'il n'y a pas de TextMesh, on ne peut pas afficher le score
	            Destroy(this.gameObject);
			}
        	this.DisplayTime(); // On affiche le temps de jeu
        } else if (DisplayTimeScript._instance != this) { // S'il y a déjà une instance
            Destroy(this.gameObject); // On détruit l'objet courant
        }
	}
	#endregion
	
	#region Methods
	// Constructeur privé pour être sûr qu'il n'y ait qu'une seule instance
    private DisplayTimeScript() {}
	
	/// <summary>
	/// Permet d'afficher le temps de jeu
	/// </summary>
	public void DisplayTime() {
        if (this._textMesh != null) {
            this._textMesh.text = GameClasseScript.Instance.FormatedGameTime;
		}
	}
	#endregion
}
