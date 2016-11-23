using UnityEngine;
using System.Collections;

public class ItemDestroyer : MonoBehaviour {

    private GameObject myCamera;

    // Use this for initialization
    void Start () {
        myCamera = GameObject.Find("Main Camera");
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.myCamera.transform.position.z);//カメラと同じZ座標
	}
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
