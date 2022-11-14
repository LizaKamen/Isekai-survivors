using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 5f;
    private float horizontalInput;
    private float verticalInput;
    public bool facingRight = true;
    private Vector3 scale; 
    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput < 0 && facingRight)
        {
            Flip();
            facingRight = false;
        }
        else if (horizontalInput > 0 && !facingRight)
        {
            Flip();
            facingRight = true;
        }
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(Time.deltaTime * movementSpeed * horizontalInput, Time.deltaTime * movementSpeed * verticalInput));
    }
    void Flip()
    {
        scale.x *= -1;
        transform.localScale = scale;
    }
}
