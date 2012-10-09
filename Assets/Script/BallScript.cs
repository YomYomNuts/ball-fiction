using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {
	public GameObject mainCamera;
	
	/// <summary>
	/// Force maximale sur l'objet
	/// </summary>
    public Vector3 _absolueVectorForceBall = new Vector3(2,2,2);
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.mainCamera.transform.position = new Vector3(this.gameObject.transform.position.x,
														 this.gameObject.transform.position.y + 4f,
														 this.gameObject.transform.position.z - 3f);
	}
}
