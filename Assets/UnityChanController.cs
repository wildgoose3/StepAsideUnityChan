﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UnityChanController : MonoBehaviour
{
    private Animator myAnimator;
    private AnimatorStateInfo animState;
    private Rigidbody myRigidbody;
    private float forwardForce = 800.0f;
    private float turnForce = 500.0f;
    private float upForce = 500.0f;
    private float movableRange = 3.4f;
    private float coefficient = 0.95f;
    private bool isEnd = false;
    private GameObject stateText;
    private GameObject scoreText;
    private GameObject restart;
    private int score;
    private bool isLButtonDown = false;
    private bool isRButtonDown = false;
    private bool restartButtonDown = false;//Restartボタンの設定

    // Use this for initialization
    void Start()
    {
        this.myAnimator = GetComponent<Animator>();
        this.myAnimator.SetFloat("Speed", 1);
        this.myRigidbody = GetComponent<Rigidbody>();
        this.stateText = GameObject.Find("GameResultText");
        this.scoreText = GameObject.Find("ScoreText");
        restart = GameObject.Find("Restart");//Restartボタンの読み込み
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isEnd)
        {
            this.forwardForce *= this.coefficient;
            this.turnForce *= this.coefficient;
            this.upForce *= this.coefficient;
            this.myAnimator.speed *= this.coefficient;
        }
        //unityちゃんに前方向の力を加える
        this.myRigidbody.AddForce(this.transform.forward * forwardForce);


        if ((Input.GetKey(KeyCode.LeftArrow)||this.isLButtonDown)  && -this.movableRange < this.transform.position.x)
        {
            this.myRigidbody.AddForce(-turnForce, 0, 0);
        }
        else if ((Input.GetKey(KeyCode.RightArrow)||this.isRButtonDown) && this.movableRange > this.transform.position.x)
        {
            this.myRigidbody.AddForce(turnForce, 0, 0);
        }

        //Jumpステートの場合はJumpにfalseをセットする
        if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            this.myAnimator.SetBool("Jump", false);
        }

        if (Input.GetKeyDown(KeyCode.Space)&& this.transform.position.y < 0.5f)
        {
            this.myAnimator.SetBool("Jump", true);
            this.myRigidbody.AddForce(this.transform.up * this.upForce);
        }
        //Restartボタンが押されるかEnterキーが押された場合リスタート
        if(this.restartButtonDown || Input.GetKey(KeyCode.Return))
            {
            SceneManager.LoadScene("GameScene");
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag")
        {
            this.isEnd = true;
            this.stateText.GetComponent<Text>().text = "GAME OVER";
        }
        if (other.gameObject.tag == "GoalTag")
        {
            this.isEnd = true;
            this.stateText.GetComponent<Text>().text = "CLEAR!!";
        }
        if (other.gameObject.tag == "CoinTag")
        {
            GetComponent<ParticleSystem>().Play();
            score += 10;
            this.scoreText.GetComponent<Text>().text = "SCORE "+score+"Pt";
            Destroy(other.gameObject);
        }
    }
    public void GetMyJumpButtonDown()
    {
        if (this.transform.position.y < 0.5f)
        {
            this.myAnimator.SetBool("Jump", true);
            this.myRigidbody.AddForce(this.transform.up * this.upForce);
        }
    }
    public void GetMyLeftButtonDown()
    {
        this.isLButtonDown = true;
    }
    public void GetMyLeftButtonUp()
    {
        this.isLButtonDown = false;
    }
    public void GetMyRightButtonDown()
    {
        this.isRButtonDown = true;
    }
    public void GetMyRightButtonUp()
    {
        this.isRButtonDown = false;
    }
    public void GetMyRestartButton()
    {
        this.restartButtonDown = true;
    }
}
