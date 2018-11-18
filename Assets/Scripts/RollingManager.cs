using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollingManager : MonoBehaviour
{
    private int state;

    private int count;
    public Text countText;
    public Text expText;
    public GameObject ball2;

    public float forcePower = 400.0f;

    void Start()
    {
        state = 0;
        count = 0;
    }

    void Update()
    {
        if (state == 0) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                Rigidbody rigidbody = this.GetComponent<Rigidbody>();
                rigidbody.AddForce(new Vector3(-forcePower, 0, 0));
                state = 1;
                expText.text = "Started";
            }
        }

        if (state == 1) {
            Rigidbody rigidbody = this.GetComponent<Rigidbody>();
            if (Mathf.Abs(rigidbody.velocity.x) >= Mathf.Epsilon) {
                state = 2;
                expText.text = "Rotating...";
            }
        }

        if (state == 2) {
            Rigidbody rigidbody = this.GetComponent<Rigidbody>();
            if (Mathf.Abs(rigidbody.velocity.x) <= Mathf.Epsilon) {
                state = 3;
                expText.text = "Stopped. Push Space Key to Init.";
            }
        }

        if (state == 3) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                this.transform.position = new Vector3(3.5f, 0, 0);
                ball2.transform.position = new Vector3(0, 0, 0);
                state = 0;
                count = 0;
                countText.text = "Count: " + count;
                expText.text = "Push Space Key";
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball2") {
            count++;
            countText.text = "Count: " + count;
        }
    }
}
