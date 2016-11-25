using UnityEngine;
using System.Collections;

public class ItemDestroy : MonoBehaviour {

    private GameObject myCamera;
    
    // Use this for initialization
    void Start () {
        this.myCamera = GameObject.Find("Main Camera");//カメラ情報を取得
    }
	
	// Update is called once per frame
	void Update () {
            if (this.transform.position.z < this.myCamera.transform.position.z)//アイテムの位置がカメラのZ座標より後ろになったらアイテムを破棄
            {
                Destroy(this.gameObject);
            }
        }

}
