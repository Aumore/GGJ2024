using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemsGenerator : MonoBehaviour
{
    public List<GameObject> itemPrefabs; // 道具预制体的列表
    public float spawnRadius = 5f; // 生成道具的最大半径
    public float spawnInterval = 10f; // 生成道具的间隔时间（秒）

    void Start()
    {
        StartCoroutine(GenerateItemsPeriodically());
    }

    IEnumerator GenerateItemsPeriodically()
    {
        while (true) // 无限循环
        {
            yield return new WaitForSeconds(spawnInterval); // 等待指定的时间

            // 在指定半径内生成随机位置
            Vector3 randomPosition = transform.position + Random.insideUnitSphere * spawnRadius;
            randomPosition.y = 0; // 根据需要调整y坐标，例如设置为0使道具生成在地面上

            if (itemPrefabs.Count > 0)
            {
                // 从列表中随机选择一个预制体
                GameObject itemToSpawn = itemPrefabs[Random.Range(0, itemPrefabs.Count)];

                // 生成道具
                Instantiate(itemToSpawn, randomPosition, Quaternion.identity);
            }
        }
    }
}
