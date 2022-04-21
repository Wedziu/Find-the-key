using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField]float inputX;
    [SerializeField]float inputZ;
    [SerializeField] float xMultiplier;
    [SerializeField] float zMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");
       // if (inputX!=0)
        
            Rotate();
        
       // if(inputZ!=0)
        
            Move();
        
    }
    private void Rotate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0f, -1* Time.deltaTime *xMultiplier, 0f));
        }
        if(Input.GetKey(KeyCode.E))
        {
            transform.Rotate(new Vector3(0f, 1 * Time.deltaTime * xMultiplier, 0f));
        }
    }
    private void Move()
    {
        transform.position += transform.forward * inputZ *Time.deltaTime * zMultiplier;
        transform.position += transform.right * inputX * Time.deltaTime * xMultiplier;
    }
}
