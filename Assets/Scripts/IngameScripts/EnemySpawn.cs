using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Stage_Data stage;
    public GameObject N_Enemy;
    private GameObject Prefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Normal_Enemy_Spawn");
    }


    IEnumerator Normal_Enemy_Spawn()
    {
        while (true)
        {
            Vector3 SpawnPosition = new Vector3(Random.Range(stage.LimitMin.x,stage.LimitMax.x), 
                                                stage.LimitMax.y + 1);
            Prefab = Instantiate(N_Enemy,SpawnPosition , transform.rotation);
            yield return new WaitForSeconds(0.6f);
        }
    }
}
