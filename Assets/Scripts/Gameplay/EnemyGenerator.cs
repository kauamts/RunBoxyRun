using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
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

    [SerializeField] private bool enemyCanSpawn;
    [SerializeField] private int[] enemySpawnRuleX;
    [SerializeField] private int[] enemySpawnRuleZ;
    private int enemyLineCounter;

    /*
    void Awake()
    {
        spaceInvader = Resources.Load<GameObject>("Prefabs/SpaceInvander");
    }
    */

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
        enemySpawnRuleX = new int[vaders] ;
        enemySpawnRuleZ = new int[vaders];

        for (int i = 0; vaders > i; i++) //Possible can be made with foreach, but IDKH *El
        {
            xDrawn = Random.Range(1, 4);
            zDrawn = Random.Range(1, 9);

            for (int valueZ = 0; vaders > valueZ; valueZ++)
            {
                if (enemySpawnRuleZ[valueZ] == zDrawn)
                {
                    Debug.Log(valueZ); // TEST
                    enemyLineCounter = 0; //Resets counter.
                    for (int valueX = 0; vaders > valueX; valueX++)
                    {
                        // if there is a obj in the same location. Do not Spawn
                        if (enemySpawnRuleX[valueX] == xDrawn)
                        {
                            Debug.Log("Same Location");
                            enemyCanSpawn = false;
                            break;
                        }
                        else
                        {
                            // If there is less than 2 enemys in the same line. add 1 to counter and spawn. If there is 2 or more, do not spawn.
                            if (enemyLineCounter <= 1)
                            {
                                Debug.Log(enemySpawnRuleZ[i] + ", " + enemySpawnRuleX[i]);
                                enemyLineCounter++;
                                enemyCanSpawn = true;
                                break;
                            }
                            else
                            {
                                Debug.Log("Already 2 Objs in the same line! Do Not Spawn");
                                enemyCanSpawn = false;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    enemyCanSpawn = true;
                    continue;
                }
            }
            enemySpawnRuleX[i] = xDrawn;
            enemySpawnRuleZ[i] = zDrawn;

            #region Old Enemy Spawn ver2
            /*
            for (int i = 0; vaders > i; i++) //Possible can be made with foreach, but IDKH *El
            {
                xDrawn = Random.Range(1, 4);
                zDrawn = Random.Range(1, 9);

                enemySpawnRuleX[i] = xDrawn;
                enemySpawnRuleZ[i] = zDrawn;

                for (int valueZ = 0; vaders > valueZ; valueZ++)
                {
                    if (enemySpawnRuleZ[i] == 0 || enemySpawnRuleX[i] == 0)
                    {
                        Debug.Log(0 + ", " + 0);
                        enemyCanSpawn = true; // See if is working as intented
                        continue;
                    } 

                    if (enemySpawnRuleZ[valueZ] == enemySpawnRuleZ[i] && enemySpawnRuleZ[i] != 0)
                    {
                        Debug.Log(valueZ); // TEST
                        enemyLineCounter = 0; //Resets counter.
                        for(int valueX = 0; vaders > valueX; valueX++)
                        {
                            // if there is a obj in the same location. Do not Spawn
                            if (enemySpawnRuleX[valueX] == enemySpawnRuleX[i] && enemySpawnRuleX[i] != 0)
                            {
                                Debug.Log("Same Location");
                                enemyCanSpawn = false;
                                break;
                            }
                            else
                            {
                                // If there is less than 2 enemys in the same line. add 1 to counter and spawn. If there is 2 or more, do not spawn.
                                if (enemyLineCounter <= 1)
                                {
                                    Debug.Log(enemySpawnRuleZ[i] + ", " + enemySpawnRuleX[i]);
                                    enemyLineCounter++;
                                    enemyCanSpawn = true;
                                    break;
                                }
                                else
                                {
                                    Debug.Log("2 Objs in the same line! Do Not Spawn");
                                    enemyCanSpawn = false;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        enemyCanSpawn = true;
                        continue;
                    }
                }
            */

            #endregion
            #region Old Enemy Spawn ver1
            /* Old Test (DELETE)
            foreach(int value in enemySpawnRuleZ)
            {
                if(enemySpawnRuleZ[value] == enemySpawnRuleZ[i])
                {
                    Debug.Log(value);
                }
            }
            */
            #endregion

            switch (xDrawn)
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

            if (enemyCanSpawn == true)
            {
                Instantiate<GameObject>(Resources.Load("Prefabs/SpaceInvader") as GameObject,
                    new Vector3(xFinal, yFinal, zFinal + zAdjustment),
                    new Quaternion(0f, 0f, 0f, 0f));
            }
        }


        #region Spawn 1 Coin.
        xDrawn = Random.Range(1, 4);
        zDrawn = Random.Range(1, 9);

        for (int valueZ = 0; vaders > valueZ; valueZ++)
        {
            if (enemySpawnRuleZ[valueZ] == zDrawn)
            {
                Debug.Log(valueZ); // TEST
                enemyLineCounter = 0; //Resets counter.
                for (int valueX = 0; vaders > valueX; valueX++)
                {
                    // if there is a obj in the same location. Do not Spawn
                    if (enemySpawnRuleX[valueX] == xDrawn)
                    {
                        Debug.Log("Same Location");
                        enemyCanSpawn = false;
                        break;
                    }
                    else
                    {
                        enemyCanSpawn = true;
                    }
                }
            }
            else
            {
                enemyCanSpawn = true;
                continue;
            }
        }

        switch (xDrawn)
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

        GetComponent<CoinGenerator>().SpawnCoin(enemyCanSpawn, xFinal,yFinal,zFinal,zAdjustment);
        #endregion
    }
}
