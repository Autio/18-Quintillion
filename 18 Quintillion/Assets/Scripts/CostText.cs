using UnityEngine;
using System.Collections;

public class CostText : MonoBehaviour {
    float speed = 8.0f;
	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 3.4f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0, Time.deltaTime * speed, 0));
	
	}
}
