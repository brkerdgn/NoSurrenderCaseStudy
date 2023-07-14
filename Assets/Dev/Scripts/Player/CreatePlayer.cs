using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreatePlayer : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] int spawnPlayerCount;
    public int totalPlayerCount;
    [SerializeField] float spawnRadius;
    [SerializeField] List<Color> colors;
    public bool isMyDead;
    void Start()
    {
        totalPlayerCount = spawnPlayerCount + 1;
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        for(int i = 0; i < spawnPlayerCount; i++)
        {
            Vector3 randomPosition = Random.insideUnitSphere * spawnRadius;
            Vector3 spawnPosition = new Vector3(randomPosition.x, transform.position.y, randomPosition.z);
            spawnPosition += transform.position;

            GameObject newPlayer = Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
            newPlayer.transform.parent = transform;

            //Oyunucuyu rastgele renk veriyoruz
            GameObject childObject = newPlayer.transform.GetChild(1).gameObject;
            Renderer renderer = childObject.GetComponent<Renderer>();
            Material material = renderer.material;
            material.color = colors[Random.Range(0, colors.Count)];   
            renderer.material = material;

        }
    }

}
