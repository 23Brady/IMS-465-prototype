using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject posOne;
    [SerializeField] private GameObject posTwo;
    [SerializeField] private GameObject posThree;
    [SerializeField] private GameObject posFour;
    [SerializeField] private GameObject projectileOne;
    [SerializeField] private GameObject projectileTwo;

    private int[] spawnPoints = { 1, 2, 3, 4};
    private int[] projectiles = { 1, 2 };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ChangePos());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChangePos()
    {
        int randomPos = Random.Range(0,spawnPoints.Length);
        int randomProj = Random.Range(0,projectiles.Length);
        if (randomPos == 0)
        {
            transform.position = posOne.transform.position;
            transform.rotation = Quaternion.Euler(0,0,-140);
            if (randomProj == 0)
            {
                Instantiate(projectileOne, transform.position, transform.rotation);
            }
            else
            {
                Instantiate(projectileTwo, transform.position, transform.rotation);
            }

        }
        if (randomPos == 1)
        {
            transform.position = posTwo.transform.position;
            transform.rotation = Quaternion.Euler(0, 0, -45);
            if (randomProj == 0)
            {
                Instantiate(projectileOne, transform.position, transform.rotation);
            }
            else
            {
                Instantiate(projectileTwo, transform.position, transform.rotation);
            }
        }
        if (randomPos == 2)
        {
            transform.position = posThree.transform.position;
            transform.rotation = Quaternion.Euler(0, 0, 45);
            if (randomProj == 0)
            {
                Instantiate(projectileOne, transform.position, transform.rotation);
            }
            else
            {
                Instantiate(projectileTwo, transform.position, transform.rotation);
            }
        }
        if (randomPos == 3)
        {
            transform.position = posFour.transform.position;
            transform.rotation = Quaternion.Euler(0, 0, 140);
            if (randomProj == 0)
            {
                Instantiate(projectileOne, transform.position, transform.rotation);
            }
            else
            {
                Instantiate(projectileTwo, transform.position, transform.rotation);
            }
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(ChangePos());
    }
}
