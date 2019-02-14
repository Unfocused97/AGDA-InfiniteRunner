using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    // Ball Variables
    private float BodyHeight = 1f;
    public float JumpHeight = 2f;
    private Rigidbody _body;
    public float Speed = 4f;

    // Lane Variables
    public float LanesLength = 12f;
    public int LaneNum = 3;
    public float LaneChangeTime = 0.05f;
    public int CurLane = 2;

    // Ground Object
    public GameObject ground;

    float TimeCnt = 0;
    bool inMovement = false;
    Vector3 shift;

    void Start()
    {
        _body = gameObject.GetComponent<Rigidbody>();
    }


    void Update(){
        if (inMovement == false && (_body.position.y == (ground.transform.position.y + BodyHeight)))
        {
            if (Input.GetButtonDown("Jump"))
                Jump();
            if (Input.GetButtonDown("Left"))
                MoveLeft();
            if (Input.GetButtonDown("Right"))
                MoveRight();
        }
        MoveForward();
        GoToDestination();
        GameOver();
    }

    void Jump()
    { 
        _body.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
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
    void MoveRight(){
        if (CurLane != LaneNum){
            inMovement = true;
            shift = new Vector3(LanesLength / (LaneNum + 1), 0, 0);
            CurLane++;
        }
    }
    void GameOver()
    {
        if (Speed <= 0.5f)
        {
            SceneManager.LoadScene(1);
        }
    }




    //Keep moving forward
    void MoveForward() {
        _body.MovePosition(_body.position + (Time.deltaTime * new Vector3(0, 0, Speed)));
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
