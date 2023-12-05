using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rd;
    //
    public float speed;

    public string playerTag = "Player";


    // Start is called before the first frame update
    void Start()
    {
        rd = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMov;
        float yMov;
        if (this.CompareTag(playerTag))
        {
            xMov = Input.GetAxisRaw("Horizontal");
            yMov = Input.GetAxisRaw("Vertical");

            rd.velocity = new Vector2(xMov * speed, yMov * speed);

            Vector3 movement = new Vector3(xMov, yMov, 0.0f );
            //transform.rotation = Quaternion.LookRotation(movement, -Vector3.forward);
            transform.up = movement;

            //transform.Translate(movement * speed * Time.deltaTime, Space.Self);

            

        }
    }
}
