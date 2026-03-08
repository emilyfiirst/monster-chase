using System;
using System.Collections;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference;

    private GameObject spawnedMonster;

    [SerializeField]
    private Transform leftPosition, rightPosition;


    private int randomIndex;
    private int randomSide;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        while(true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(1, 5));

            randomIndex = UnityEngine.Random.Range(0, monsterReference.Length);
            randomSide = UnityEngine.Random.Range(0, 2);

            spawnedMonster = Instantiate(monsterReference[randomIndex]); //create a copy of a game object 

            // left side
            if (randomSide == 0)
            {
                spawnedMonster.transform.position = leftPosition.position;
                spawnedMonster.GetComponent<Monster>().speed = UnityEngine.Random.Range(4, 10);
            }
            else //right side
            {
                spawnedMonster.transform.position = rightPosition.position;
                spawnedMonster.GetComponent<Monster>().speed = -UnityEngine.Random.Range(4, 10);
                spawnedMonster.transform.localScale = new Vector3(-1, 1f, 1f);
            }
        }

    }

} // class
