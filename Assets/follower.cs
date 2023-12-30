using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class follower : MonoBehaviour
{
    [SerializeField ] GameObject following ;
    float steps = 0.5f;
    float next_action = 0.0f;
    public Vector3 Last_position = new Vector3(1, 0, 0);



    public void update_position(Vector3 position)
    {

        transform.position = position;
    }
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = following.
    }
}
