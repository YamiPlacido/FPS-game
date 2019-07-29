using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int amount;
    [SerializeField] private int range;
    [SerializeField] private float cooldown;

    private int count;
    
    private void Start()
    {
        StartCoroutine(SpawnCooldown(range,cooldown));
    }

    private IEnumerator SpawnCooldown(int range, float cooldown)
    {
        while(count < amount)
        {
            yield return new WaitForSeconds(cooldown);

            float posX = transform.position.x + Random.Range(0, range);
            float posZ = transform.position.z + Random.Range(0, range);

            Instantiate(prefab, new Vector3(posX, 0.25f, posZ), transform.rotation);

            count++;
        }
    }
}
