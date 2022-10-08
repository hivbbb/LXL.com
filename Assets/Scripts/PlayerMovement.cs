using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public GameObject DefaultBag;
    bool isOpened;
    new private Rigidbody2D rigidbody;
    private Animator animator;
    private float inputX, inputY;
    private float StopX, StopY;
    // Start is called before the first frame update
    void Start()
    {

        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        OpendefautBag();
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        Vector2 direction = (transform.right*inputX+transform.up*inputY).normalized; 
        rigidbody.velocity = direction * speed;

        if (direction != Vector2.zero)
        {
            animator.SetBool("isMoving", true);
            StopX = inputX;
            StopY = inputY;
        }else{
            animator.SetBool("isMoving", false);

        }
        animator.SetFloat("InputX", StopX);
        animator.SetFloat("InputY", StopY);
    }
    void OpendefautBag()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            isOpened = !isOpened;
            DefaultBag.SetActive(isOpened);
        }

    }
}
