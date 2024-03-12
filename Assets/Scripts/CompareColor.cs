using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CompareColor : MonoBehaviour
{
    [SerializeField] private float timer = 14f;
    [SerializeField] private Vector3 respanwPoint;

    private FinishGane ballnumber;
    private Rigidbody rb;    
    private bool iscollided = false;
    [SerializeField]private Renderer myRenderer;
    private Renderer otherRenderer;
    private Color myColor;
    private Color otherColor;


    private void Awake()
    {
        myColor = myRenderer.material.color;
        respanwPoint = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        ballnumber = FindAnyObjectByType<FinishGane>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        otherRenderer = collision.gameObject.GetComponent<Renderer>();
        otherColor = otherRenderer.material.color;
        iscollided = true;
    }

    private void Update()
    {
        if (timer < 0) 
        {
            if (iscollided == true)
            {
                if (myColor == otherColor)
                {
                    ballnumber.increasescore();                   
                    transform.position = respanwPoint;
                    rb.useGravity = false;
                }
                else if (myColor != otherColor)
                {                   
                    ballnumber.decreaseball();
                    DestroyImmediate(gameObject);
                    
                }
            }
            else if (iscollided == false)
            {               
                ballnumber.decreaseball();
                DestroyImmediate(gameObject);
            }

            timer = 14f;
        }
        else if(timer > 0f)
        {
            timer -= Time.deltaTime;
        } 

    }

    
}
