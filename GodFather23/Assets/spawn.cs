using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class spawn : MonoBehaviour
{


    public GameObject insectesPrefab;
    public GameObject spawnPoint;
    public GameObject respawn;

    public float spawnCooldown = 3f;
    public bool Cooldown = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N)  && Cooldown)
        {
            random();
        }
    }

    public void random ()
    {
        spawnPoint.transform.position = Random.insideUnitCircle * 5;
        respawn = Instantiate(insectesPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        Cooldown = false;
        StartCoroutine(spawnTime());
    }

    private IEnumerator spawnTime()
    {
        yield return new WaitForSeconds(spawnCooldown);
        Cooldown = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("nonnnn");
        if (collision.gameObject.tag == "bouffe")
        {
            random();
            Destroy(respawn);
            Debug.Log("ouiiii");
        }
    }
}
