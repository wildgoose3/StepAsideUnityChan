using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemGenerator : MonoBehaviour
{

    public GameObject carPrefab;
    public GameObject coinPrefab;
    public GameObject conePrefab;
    public GameObject unitychan;
    public GameObject myCamera;
    private int startPos = -160;
    private int goalPos = 120;
    private float posRange = 3.4f;
    private float generatedZ;//オブジェクト生成位置情報

    // Use this for initialization
    void Start()
    {
        this.unitychan = GameObject.Find("unitychan");//unityちゃんの情報取得
        generatedZ = this.unitychan.transform.position.z;

        //ゲーム開始時に生成（バックアップ用）
        /* for (int i = startPos; i < goalPos; i += 15)
        {
            int num = Random.Range(0, 10);
            if (num <= 1)
            {
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab) as GameObject;
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                }
            }
            else
            {
                for (int j = -1; j < 2; j++)
                {
                    int item = Random.Range(1, 11);
                    int offsetZ = Random.Range(-5, 6);
                    if (1 <= item && item <= 6)
                    {
                        GameObject coin = Instantiate(coinPrefab) as GameObject;
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        GameObject car = Instantiate(carPrefab) as GameObject;
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                    }
                }
            }
        }*/
    }

    // Update is called once per frame
    void Update()
    {

        int offsetU = 40;//unityちゃんの40m先にアイテムを生成
        int i = (int)this.unitychan.transform.position.z;//unityちゃんの位置を整数化
        if (Mathf.Abs(i-generatedZ)>=1)//前回のアイテム生成位置と現在位置の差が1m以上ならば以下を実行
        {
            if (i % 15 == 0 && i + offsetU < goalPos)//goalPosまで15m置きに生成
            {
                generatedZ = this.unitychan.transform.position.z;//アイテム生成した際のZ座標を代入

                int num = Random.Range(0, 10);
                if (num <= 1)
                {
                    for (float j = -1; j <= 1; j += 0.4f)
                    {
                        GameObject cone = Instantiate(conePrefab) as GameObject;
                        cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i + offsetU);
                    }
                }
                else
                {
                    for (int j = -1; j < 2; j++)
                    {
                        int item = Random.Range(1, 11);
                        int offsetZ = Random.Range(-5, 6);
                        if (1 <= item && item <= 6)
                        {
                            GameObject coin = Instantiate(coinPrefab) as GameObject;
                            coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetU + offsetZ);
                        }
                        else if (7 <= item && item <= 9)
                        {
                            GameObject car = Instantiate(carPrefab) as GameObject;
                            car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetU + offsetZ);
                        }
                    }
                }
            }

        }
    }
}