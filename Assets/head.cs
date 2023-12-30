using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class head : MonoBehaviour
{

     [SerializeField] public GameObject OG_Follower;
     [SerializeField] public GameObject OG_food;

    [SerializeField] public GameObject HIT_TAIL;
    [SerializeField] public GameObject HIT_EDGE;
    float distance_per_second = 1.0f;

    Vector3 current_direction = new Vector3(1, 0, 0);
    Vector3 update_dir = new Vector3(1, 0, 0);
    float steps = 0.5f;
    float next_action = 0.0f;
   
   public List<Vector3> Last_position = new List<Vector3>();
    List<follower> followers = new List<follower>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "food")
        {
            create_follower();
            Destroy(other.gameObject);
            Vector3 randpos = new Vector3(Random.Range(-14.0f, 14.0f), Random.Range(-4.0f, 4.0f), 0);
            Quaternion radomrot = Random.rotation;
            Instantiate(OG_food, randpos, radomrot);
            Time.timeScale *= 1.05f;

        }

        if (other.gameObject.tag == "edge")
        {
            Time.timeScale = 0.0f;
            HIT_EDGE.SetActive(true);

        }
        if (other.gameObject.tag == "tail")
        {
            Time.timeScale = 0.0f;
            HIT_TAIL.SetActive(true);

        }
    }


    // Start is called before the first frame update
    void Start()
    {


    }

void create_follower()
    {

        GameObject go = Instantiate(OG_Follower);
        followers.Add(go.GetComponent<follower>());

    }

    // Update is called once per frame
    void Update()
    {


        if (Time.time > next_action)
        {
            next_action += steps;
            Last_position.Add(transform.position);
            current_direction = update_dir;
           transform.position= transform.position + current_direction;
            for (int i = 0; i < followers.Count; i++)
            {
                followers[i].update_position(Last_position[Last_position.Count - i-1]);
            }
        }
  
        if (Input.GetKeyDown("a"))
        {
            if(current_direction!= new Vector3(-1, 0, 0) && current_direction != new Vector3(1, 0, 0))
                update_dir = new Vector3(-1,0,0);
  
        }
        if (Input.GetKeyDown("d"))
        {
            if (current_direction != new Vector3(-1, 0, 0) && current_direction != new Vector3(1, 0, 0))
                update_dir = new Vector3(1, 0, 0);

        }
        if (Input.GetKeyDown("w"))
        {
            if (current_direction != new Vector3(0, 1, 0) && current_direction != new Vector3(0, -1, 0))
                update_dir = new Vector3(0, 1, 0);
       
        }
        if (Input.GetKeyDown("s"))
        {
            if (current_direction != new Vector3(0, 1, 0) && current_direction != new Vector3(0, -1, 0))
                update_dir = new Vector3(0, -1, 0);
   
        }


    }
}
