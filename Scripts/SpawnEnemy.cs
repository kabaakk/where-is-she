using System.Collections;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject zombie;
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
            Instantiate(zombie, new Vector3(xPos, -1, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }
}
