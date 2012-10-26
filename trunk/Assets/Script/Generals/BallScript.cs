using UnityEngine;
using System.Collections;

/// <summary>
/// Script de comportement de la bille
/// </summary>
public class BallScript : MonoBehaviour {
	#region Static Elements
	// Instance de la classe
    private static BallScript _instance;
	
	/// <summary>
	/// Propriété pour accéder publiquement à l'instance de la classe
	/// </summary>
    public static BallScript Instance {
        get {
			// Si l'instance n'existe pas, on la crée
            if (BallScript._instance == null) {
                BallScript._instance = new BallScript();
			}
            return BallScript._instance;
        }
    }
	#endregion
	
	#region Attributes
	/// <summary>
	/// La caméra qui film la bille
	/// </summary>
	public GameObject _theCamera;
	/// <summary>
	/// Force maximale sur l'objet
	/// </summary>
    public Vector3 _absolueVectorForceBall = new Vector3(2,2,2);
	/// <summary>
	/// La hauteur de la caméra par rapport à la bille
	/// </summary>
	public float _cameraHigh = 8f;
	/// <summary>
	/// Le recul de la caméra par rapport à la bille
	/// </summary>
	public float _cameraRetreat = 8f;
	#endregion
	
	#region Unity Methods
	// Méthode appelée lors du "réveil" de l'objet (avant même le Start)
	// Il est important de créer les singleton dans le Awake pour être sûr qu'ils soient créé avant le Start des autres objets
	void Awake () {
		// Unity créera l'objet même si le constructeur est privé donc on doit initialiser l'instance de notre singleton ici
        if (BallScript._instance == null) {
            BallScript._instance = this;
        } else if (BallScript._instance != this) {
            Destroy(this.gameObject);
        }
	}
	
	// Use this for initialization
	void Start () {
		// Si aucune caméra n'est liée à la bille, on le signale dans les logs
		if(this._theCamera == null) {
			UtilsScript.WarningMessageWhenNoGameObjectAssigned("camera", this.GetType().ToString(), this.gameObject.name);
		}
		PlayerPrefs.DeleteAll(); // Pour ne pas poluer le PlayerPrefs pendant les tests
	}
	
	// Update is called once per frame
	void Update () {
		if(this._theCamera != null) {
			// On place la caméra derrière la bille
			this._theCamera.transform.position = new Vector3(this.gameObject.transform.position.x,
															 this.gameObject.transform.position.y + this._cameraHigh,
															 this.gameObject.transform.position.z - this._cameraRetreat);
		}
		// On affiche le temps à chaque frame
		DisplayTimeScript.Instance.DisplayTime();
	}
	#endregion
}
