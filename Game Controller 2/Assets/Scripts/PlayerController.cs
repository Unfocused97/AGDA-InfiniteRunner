using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float JumpHeight = 2f;
    public float GroundDistance = 0.5f; //doesn't do anything (???)
    public float LanesLength = 12f;
    public int LaneNum = 3;
    public float LaneChangeTime = 0.1f;
    public float Speed = 0.3f;
    public int CurLane = 2;

    private Rigidbody _body;
    private bool _isGrounded = true;
    float TimeCnt = 0;
    bool inMovement = false;
    Vector3 shift;

    void Start()
    {
        _body = gameObject.GetComponent<Rigidbody>();
    }


    void Update()
    {

        _isGrounded = Physics.CheckSphere(gameObject.transform.position, GroundDistance); // a non-working sphere collider :(
        //print("isGrounded? : " + _isGrounded); for some reason always returns true

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _body.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }
        if (inMovement == false) 
        {
            if (Input.GetButtonDown("Left"))
                MoveLeft();
            if (Input.GetButtonDown("Right"))
                MoveRight();
        }

        MoveForward();
        GoToDestination();
    }

    //Set a vector to move to the left
    void MoveLeft()
    {
        if (CurLane != 1)
        {
            inMovement = true;
            shift = new Vector3(-LanesLength / (LaneNum + 1), 0, 0);
            CurLane--;
        }
    }

    //Set a vector to move to the right
    void MoveRight()
    {
        if (CurLane != LaneNum)
        {
            inMovement = true;
            shift = new Vector3(LanesLength / (LaneNum + 1), 0, 0);
            CurLane++;
        }
    }

    //Keep moving forward
    void MoveForward() {
        Vector3 forwardVector = new Vector3(0, 0, Speed);
        _body.MovePosition(_body.position + (Time.deltaTime * forwardVector));
    }

    //Apply the vectors of MoveLeft and MoveRight on the game object _body
    void GoToDestination() {
        if (inMovement) {
            _body.MovePosition(_body.position + (Mathf.Min(LaneChangeTime - TimeCnt, Time.deltaTime) * shift / LaneChangeTime));
            TimeCnt += Time.deltaTime;
            if (TimeCnt >= LaneChangeTime) {
                inMovement = false;
                shift = Vector3.zero;
                TimeCnt = 0;
            }
        }
    }
}
