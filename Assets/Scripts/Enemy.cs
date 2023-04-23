using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5.0f;
    private GameObject player;
    private Rigidbody enemyRb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookkDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookkDirection * speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
