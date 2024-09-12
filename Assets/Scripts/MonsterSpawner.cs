using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    // Array to hold references to different monster prefabs
    [SerializeField]
    private GameObject[] monsterReference;

    private GameObject spawnedMonster; // Variable to store the currently spawned monster

    // Transforms to define the left and right spawn positions
    [SerializeField]
    private Transform leftPos, rightPos;

    // Variables to store random index and side for spawning
    private int randomIndex;
    private int randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters()); // Start the coroutine to spawn monsters
    }

    // Coroutine to spawn monsters at random intervals
    IEnumerator SpawnMonsters() {
        while (true) 
        {
            yield return new WaitForSeconds(Random.Range(1, 5)); // Wait for a random amount of time between 1 and 5 seconds
            randomIndex = Random.Range(0, monsterReference.Length); // Select a random monster from the array
            randomSide = Random.Range(0, 2); // Select a random side (0 for left, 1 for right)

            spawnedMonster = Instantiate(monsterReference[randomIndex]); // Instantiate the selected monster

            // left side
            if (randomSide == 0) 
            {
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 10); // Set a random speed for the monster
            }
            else 
            {
                // right side
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4, 10); // Set a random speed for the monster
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f); // Flip the monster sprite for right side spawns
            }
        }
    }


 
}
