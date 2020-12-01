using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject spaceInvader;

    private float x1 = -1.5f;
    private float x2 = 1f;
    private float x3 = 3.5f;

    private float z1 = -13.125f;
    private float z2 = -9.375f;
    private float z3 = -5.625f;
    private float z4 = -1.875f;
    private float z5 = 1.875f;
    private float z6 = 5.625f;
    private float z7 = 9.375f;
    private float z8 = 13.125f;

    [SerializeField] private float xFinal;
    [SerializeField] private float yFinal;
    [SerializeField] private float zFinal;

    [SerializeField] private int xDrawn;
    [SerializeField] private int zDrawn;
    [SerializeField] private int spawnCount;
    [SerializeField] private float lvlDifficulty;
    [SerializeField] private float zAdjustment;

    void Start()
    {
        yFinal = 0f;

        zAdjustment = this.transform.position.z;

        if (zAdjustment == 0)
            zAdjustment = -30f;

        AdjustEnemyCountToSpawn();
    }

    private void AdjustEnemyCountToSpawn()
    {
        //check difficulty
        lvlDifficulty = LevelController.Singleton.difficultyLevel;

        if ((this.transform.position.z <= 270f) && (this.transform.position.z != 0f))
        {
            lvlDifficulty += this.transform.position.z / 30f;
        }
        else if (this.transform.position.z == 0f)
            lvlDifficulty = 0f;
                
        //randomize how many enemies are going to spawn in this tile
        if ((1 <= lvlDifficulty) &&
            (5 >= lvlDifficulty))
        {
            spawnCount = Random.Range(1,3);
        }
        else if ((6 <= lvlDifficulty) &&
                 (10 >= lvlDifficulty))
        {
            spawnCount = Random.Range(2,4);
        }
        else if ((11 <= lvlDifficulty) &&
                 (20 >= lvlDifficulty))
        {
            spawnCount = Random.Range(3,5);
        }
        else if ((20 <= lvlDifficulty) &&
                 (25 >= lvlDifficulty))
        {
            spawnCount = Random.Range(3,6);
        }
        else if ((26 <= lvlDifficulty) &&
                 (35 >= lvlDifficulty))
        {
            spawnCount = Random.Range(5,10);
        }        
        else if (36 >= lvlDifficulty)
            spawnCount = Random.Range(5,12);

        //randomize where each one will spawn, checking for redundant locations
        SpawnInvaders(spawnCount);
    }

    private void SpawnInvaders(int vaders)
    {
        for (int i = 0; vaders > i; i++)
        {
            xDrawn = Random.Range(1,4);
            zDrawn = Random.Range(1,9);

            switch(xDrawn)
            {
                case 1:
                    xFinal = x1;
                    break;
                case 2:
                    xFinal = x2;
                    break;
                case 3:
                    xFinal = x3;
                    break;
            }

            switch (zDrawn)
            {
                case 1:
                    zFinal = z1;
                    break;
                case 2:
                    zFinal = z2;
                    break;
                case 3:
                    zFinal = z3;
                    break;
                case 4:
                    zFinal = z4;
                    break;
                case 5:
                    zFinal = z5;
                    break;
                case 6:
                    zFinal = z6;
                    break;
                case 7:
                    zFinal = z7;
                    break;
                case 8:
                    zFinal = z8;
                    break;
            }

            Instantiate<GameObject>(spaceInvader,
                new Vector3(xFinal, yFinal, zFinal + zAdjustment),
                new Quaternion(0f, 0f, 0f, 0f));
        }
    }
}
