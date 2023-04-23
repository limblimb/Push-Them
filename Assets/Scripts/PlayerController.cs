using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;


    public GameObject powerupIndicator;
    public GameObject bullet;

    public float speed = 5.0f;
    public bool hasPowerup1 = false;
    public bool hasPowerup2 = false;

    private float powerupStrenght = 15f;

    private int enemyCount;
    private int bulletCount;
    private int bulletHowMany;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerupIndicator.transform.position = transform.position;

        enemyCount = GameObject.Find("SpawnObject").GetComponent<SpawnManager>().enemyCount;
        bulletHowMany = enemyCount;

        //ÝÒÎÒ ÊÎÄ ÍÅ ÐÀÁÎÒÀÅÒ ÏÅÐÅÄÅËÀÒÜ
        if (hasPowerup2 && bulletHowMany >= bulletCount)
        {
            for (int i = 0; i <= enemyCount; i++)
            {
                hereComesTheBullet();
                bulletCount++;
            }

        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup1 = true;
            Destroy(other.gameObject);
            powerupIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerupCountDown());
        }

        if (other.CompareTag("Powerup Bullet"))
        {
            hasPowerup2 = true;
            Destroy(other.gameObject);
            powerupIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerupCountDown());
        }
    }

    IEnumerator PowerupCountDown()
    {
        yield return new WaitForSeconds(7);
        hasPowerup1 = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasPowerup1 && collision.gameObject.CompareTag("Enemy"))
        {
            Vector3 awayFromAPlayer = collision.gameObject.transform.position - transform.position;
            Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + hasPowerup1);
            collision.rigidbody.AddForce(awayFromAPlayer * powerupStrenght, ForceMode.Impulse);
        }

        
    }

    void hereComesTheBullet()
    {
        Instantiate(bullet, transform.position + new Vector3(0, 0, 0), bullet.transform.rotation);          
    }
}
