using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeScript : MonoBehaviour
{

    private float vertMovement = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Duck();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Unduck();
        }

    }

    void Duck()
    {
        this.transform.Translate(new Vector3(0, -vertMovement, 0));
    }

    void Unduck()
    {
        this.transform.Translate(new Vector3(0, vertMovement, 0));
    }
}
