using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderSpawn : MonoBehaviour
{
    public GameObject spider;
    public float xPos;
    public float zPos;
    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(enemySpawn());
    }

    IEnumerator enemySpawn()
    {
        while(enemyCount < 500)
        {
            xPos = Random.Range(2, 1000);
            zPos = Random.Range(2, 1000);
            Instantiate(spider, new Vector3(xPos, -1, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }
}
