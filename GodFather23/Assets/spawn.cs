using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class spawn : MonoBehaviour
{

    public float size;
    public GameObject insectesPrefab;
    public GameObject spawnPoint;
    public GameObject respawn;

    public float margin;

    public List<Vector2>  spawnList = new List<Vector2>();

    public float spawnCooldown = 3f;
    public bool Cooldown = true;
 

    void Update()
    {
        if (Cooldown)
        {
            random();
        }
    }

    public void random ()
    {
        Vector3 position = Random.insideUnitCircle * size;
        position.z = 8f;
       
        spawnPoint.transform.position =position;
        Cooldown = false;
        StartCoroutine(spawnTime());

        bool succeed = true;

        if(spawnList.Count == 0)
        {
            SpawnEnnemy();
        }

        foreach (Vector2 trez in spawnList)
        {
            print(trez);

            if (Vector2.Distance(trez, spawnPoint.transform.position) < margin)
            {
                succeed = false;
                break;
            }

        }


        if (succeed)
        {
            SpawnEnnemy();
        }
        else random();
    }

    private void SpawnEnnemy()
    {
        spawnList.Add(spawnPoint.transform.position);

        respawn = Instantiate(insectesPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        foreach (Vector2 truc in spawnList)
        {
            print(truc);
            print(spawnList.Count);
        }
    }

    private IEnumerator spawnTime()
    {
        yield return new WaitForSeconds(spawnCooldown);
        Cooldown = true;
    }
}
