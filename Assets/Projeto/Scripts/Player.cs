using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject player;
    public int playerNum;

    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player.transform.Translate(new Vector3(0.0f, Input.GetAxis("Vertical" + playerNum) * speed * Time.deltaTime, 0.0f));

        Vector3 position = player.transform.position;

        if (position.y > 309.0f)
        {
            position.y = 309.0f;
        } else if (position.y < 51.0f)
        {
            position.y = 51.0f;
        }

        player.transform.position = position;
    }
}
