using UnityEngine;

/// <summary>
/// Script gérant l'affichage du score
/// </summary>
public class DisplayScoreScript : MonoBehaviour {
	#region Static elements
	// Instance de la classe
    private static DisplayScoreScript _instance;
	
	/// <summary>
	/// Propriété pour accéder publiquement à l'instance de la classe
	/// </summary>
    public static DisplayScoreScript Instance {
        get {
			// Si l'instance n'existe pas, on la crée
            if (DisplayScoreScript._instance == null) {
                DisplayScoreScript._instance = new DisplayScoreScript();
			}
            return DisplayScoreScript._instance;
        }
    }
	#endregion
	
	#region Unity Methods
	// Le texte pour afficher le score
    private TextMesh _textMesh;
	
	// Méthode appelée lors du "réveil" de l'objet (avant même le Start)
	// Il est important de créer les singleton dans le Awake pour être sûr qu'ils soient créé avant le Start des autres objets
	void Awake () {
		// Unity créera l'objet même si le constructeur est privé donc on doit initialiser l'instance de notre singleton ici
        if (DisplayScoreScript._instance == null) { // S'il n'y pas d'instance
            DisplayScoreScript._instance = this; // L'objet courant devient l'instance
			// On récupère le textMesh associé
	        this._textMesh = this.GetComponent<TextMesh>();
	        if (this._textMesh == null) { // S'il n'y a pas de TextMesh, on ne peut pas afficher le score
	            Destroy(this.gameObject);
			}
	        this.DisplayScore(); // On affiche le score
        } else if (DisplayScoreScript._instance != this) { // S'il y a déjà une instance
            Destroy(this.gameObject); // On détruit l'objet courant
        }
	}
	#endregion
	
	#region Methods
	// Constructeur privé pour être sûr qu'il n'y ait qu'une seule instance
    private DisplayScoreScript() {}
	
	/// <summary>
	/// Méthode pour afficher le score
	/// </summary>
	public void DisplayScore() {
        if (this._textMesh != null) {
            this._textMesh.text = GameClasseScript.Instance.FormatedScore;
		}
	}
	#endregion
}
