using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private GameObject enemy;

    private GameObject[] enemyList;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find("Hard Enemy(Clone)");
        MovingToEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MovingToEnemy()
    {
        Vector3 whereTo = enemy.gameObject.transform.position - transform.position;
        gameObject.GetComponent<Rigidbody>().AddForce(whereTo * speed, ForceMode.Impulse);

    }
}
