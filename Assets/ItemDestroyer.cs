using UnityEngine;
using System.Collections;

public class ItemDestroyer : MonoBehaviour {

    private GameObject unitychan;

    // Use this for initialization
    void Start () {
        this.unitychan = GameObject.Find("unitychan");
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z-2);//unitychanの2m後ろに
	}
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("ログだよ");
        Destroy(other.gameObject);
    }
}
