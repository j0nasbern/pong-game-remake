using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject ballPrefab;
    private GameObject ballInstance;

    public Text score1Text, score2Text;
    private float goal1 = 5.0f, goal2 = 635.0f;
    private int score1 = 0, score2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        ballInstance = Instantiate(ballPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        if (ballInstance.transform.position.x < goal1)
        {
            score2++;
            score2Text.text = string.Format("{0:00}", score2);
            Destroy(ballInstance);
            ballInstance = Instantiate(ballPrefab);
        } else if (ballInstance.transform.position.x > goal2)
        {
            score1++;
            score1Text.text = string.Format("{0:00}", score1);
            Destroy(ballInstance);
            ballInstance = Instantiate(ballPrefab);
        }
    }
}
