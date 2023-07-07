using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputScript : MonoBehaviour
{
    public CarScript carScript;
    // Start is called before the first frame update
    void Start()
    {
        carScript = GetComponent<CarScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vector = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            vector.y = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            vector.y = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            vector.x = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            vector.x = 1;
        }

        carScript.input(vector);
    }
}
