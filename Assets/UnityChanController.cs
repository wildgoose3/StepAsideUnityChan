using UnityEngine;
using System.Collections;

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

    // Use this for initialization
    void Start()
    {
        this.myAnimator = GetComponent<Animator>();
        this.myAnimator.SetFloat("Speed", 1);
        this.myRigidbody = GetComponent<Rigidbody>();
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
        /*if (this.myRigidbody == null)
        {
            Debug.Log("myRigidbodyがnullだよ" + gameObject.name);
        }
        else
        {
            Debug.Log("myRigidbodyがあるよ" + gameObject.name);
        }*/

        this.myRigidbody.AddForce(this.transform.forward * forwardForce);

        if (Input.GetKey(KeyCode.LeftArrow)  && -this.movableRange < this.transform.position.x)
        {
            this.myRigidbody.AddForce(-turnForce, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && this.movableRange > this.transform.position.x)
        {
            this.myRigidbody.AddForce(turnForce, 0, 0);
        }
        if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            this.myAnimator.SetBool("Jump", false);
        }
        if (Input.GetKey(KeyCode.Space) && this.transform.position.y < 0.5f)
        {
            this.myAnimator.SetBool("Jump", true);
            this.myRigidbody.AddForce(this.transform.up * this.upForce);
        }

    }
    void OntriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);

        if (other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag")
        {
            this.isEnd = true;
        }
        if (other.gameObject.tag == "GoalTag")
        {
            this.isEnd = true;
        }
        if (other.gameObject.tag == "CoinTag")
        {
            GetComponent<ParticleSystem>().Play();
            Destroy(other.gameObject);
        }
    }


}
