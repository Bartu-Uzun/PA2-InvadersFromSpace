using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMaster : MonoBehaviour
{
    [SerializeField] private GameObject enemyBulletPrefab;
    public static List<GameObject> allAliens = new List<GameObject>();
    
    private Vector3 horizontalMoveDistance = new Vector3(0.05f, 0, 0);
    private Vector3 verticalMoveDistance = new Vector3(0, 0.15f, 0);

    private bool movingRight;
    private float moveTimer = 0.01f;
    private float moveTime = 0.005f;


    private const float MAX_LEFT = -2;
    private const float MAX_RIGHT = 2;
    private const float MAX_MOVING_SPEED = 0.02f;


    // Start is called before the first frame update
    void Start()
    {

        foreach (GameObject alien in GameObject.FindGameObjectsWithTag("Alien")) { //find all aliens

            allAliens.Add(alien);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        if (moveTimer <= 0) {

            MoveEnemies();
        }

        moveTimer -= Time.deltaTime;
        
    }

    private void MoveEnemies() {

        int hitMax = 0;
        for (int i = 0; i < allAliens.Count; i++) {

            if (movingRight) {

                allAliens[i].transform.position += horizontalMoveDistance;
            }
            else {
                allAliens[i].transform.position -= horizontalMoveDistance;
            }

            if (allAliens[i].transform.position.x > MAX_RIGHT || allAliens[i].transform.position.x < MAX_LEFT) {

                Debug.Log(allAliens[i].transform.position.x);
                hitMax++;
            }
        }

        if (hitMax > 0) {
            
            for (int i = 0; i < allAliens.Count; i++) {

                allAliens[i].transform.position -= verticalMoveDistance;
            }
            movingRight = !movingRight;

        }
        // timer
        moveTimer = GetMoveSpeed();
    }


    private float GetMoveSpeed() {

        float f = allAliens.Count * moveTime;

        if (f < MAX_MOVING_SPEED) {

            f = MAX_MOVING_SPEED;
        }
        
        return f;
    }
}
