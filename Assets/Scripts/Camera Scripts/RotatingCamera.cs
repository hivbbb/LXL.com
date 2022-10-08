using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCamera : MonoBehaviour
{

    public float rotateTime = 0.2f;

    private Transform player;

    private bool isRotate = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;
        Rotate();
    }

    void Rotate()
    {
        if(Input.GetKeyDown(KeyCode.Q) && !isRotate){
            StartCoroutine(RotateAround(-45, rotateTime));
        }
        if(Input.GetKeyDown(KeyCode.E) && !isRotate){
            StartCoroutine(RotateAround(45, rotateTime));
        }
    }

    IEnumerator RotateAround(float angle, float time){
        float number = 60 * time;
        float nextAngle = angle / number;
        isRotate = true;

        for (int i = 0; i < number; i++){
            transform.Rotate(new Vector3(0, 0, nextAngle));
            yield return new WaitForFixedUpdate();
        }

        isRotate = false;
    }
}
