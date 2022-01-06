using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speedMove = 25f;
    private float speedBall = 15f;
    private float xMin = -8f;
    private float xMax =  8f;
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject ballPrefab;
    public bool isLaunch = false;



    // Start is called before the first frame update
    void Start()
    {
        SpawnBall();
    }
    private void FixedUpdate()
    {
        IsInput();
        ball.GetComponent<Rigidbody>().velocity = speedBall * (ball.GetComponent<Rigidbody>().velocity.normalized);
    }

    private void IsInput()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            if (this.transform.position.x > xMin)
            {
                this.transform.Translate(Vector3.left * speedMove * Time.fixedDeltaTime);
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (this.transform.position.x < xMax)
            {
                this.transform.Translate(Vector3.right * speedMove * Time.fixedDeltaTime);
            }
        }
        if(isLaunch == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("space pressed");
                ball.transform.parent = null;
                LauchBall();
                isLaunch = true;
            }
        }
        

    }

    private void LauchBall()
    {
        ball.GetComponent<Rigidbody>().AddForce(Vector3.up * speedBall, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            Vector3 dir = transform.position - collision.gameObject.transform.position;
            dir.y = 0;
            dir.z = 0;

            //positive = left
            //negative = right
            Debug.Log(dir);

            if(dir.x < -0.1)
            {
                ball.GetComponent<Rigidbody>().AddForce(15f, 0, 0,ForceMode.Impulse);
                Debug.Log("ball go right");
            }
            else if (dir.x > 0.1)
            {
                Debug.Log("ball go left");
                ball.GetComponent<Rigidbody>().AddForce(-15f, 0, 0,ForceMode.Impulse);
            }
            else
            {
                //middle
                ball.GetComponent<Rigidbody>().AddForce(0f, 0, 0, ForceMode.Impulse);
                Debug.Log("ball go middle");
            }
        }
    }

    public void SpawnBall()
    {
        ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        ball.transform.parent = gameObject.transform;
    }

}
