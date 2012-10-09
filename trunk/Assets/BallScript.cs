using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {
	public float _maxSpeed = 3f;
	
	public GameObject mainCamera;
	
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
