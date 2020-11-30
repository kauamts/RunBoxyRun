using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Singleton { get; private set; }

    [SerializeField]
    private enum Direction {Left, Right};
    [SerializeField]
    private Direction moving;
    [SerializeField]
    private bool playerMoving;
    [SerializeField]
    private float curPosition;
    [SerializeField]
    private float sideMoveSpeed;

    private bool setDelay;

    void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        setDelay = false;
        sideMoveSpeed = 50f;
        playerMoving = false;
        moving = Direction.Right;
        curPosition = this.transform.position.x;
    }

    void FixedUpdate()
    {
        if(!setDelay)
        {
            if (Time.timeSinceLevelLoad > 1f)
            {
                setDelay = true;
            }                
            else
                playerMoving = false;
        }
        

        if(!playerMoving)
        {
            if ((Input.GetKeyDown(KeyCode.D) ||
                 Input.GetKeyDown(KeyCode.RightArrow) ||
                 Input.GetKeyDown(KeyCode.Keypad6))
                 &&
                 curPosition < 2.5f && !playerMoving)
            {
                playerMoving = true;
                moving = Direction.Right;
                curPosition = this.transform.position.x;
            }
            
            if ((Input.GetKeyDown(KeyCode.A) ||
                 Input.GetKeyDown(KeyCode.LeftArrow) ||
                 Input.GetKeyDown(KeyCode.Keypad4))
                 &&
                 curPosition > -2.5f && !playerMoving)
            {
                playerMoving = true;
                moving = Direction.Left;
                curPosition = this.transform.position.x;
            }
        }
        
        if(playerMoving)
        {
            switch (moving)
            {
                case Direction.Right:
                    if(this.transform.position.x < (curPosition + 2.5f))
                    {
                        this.transform.Translate(sideMoveSpeed*Time.deltaTime, 0f, 0f);
                    }
                    else
                    {
                        this.transform.position = new Vector3((curPosition + 2.5f),
                            this.transform.position.y, this.transform.position.z);
                        curPosition = this.transform.position.x;
                        playerMoving = false;
                    }
                    break;
                case Direction.Left:
                    if (this.transform.position.x > (curPosition - 2.5f))
                    {
                        this.transform.Translate(sideMoveSpeed * Time.deltaTime * -1f, 0f, 0f);
                    }
                    else
                    {
                        this.transform.position = new Vector3((curPosition - 2.5f),
                            this.transform.position.y, this.transform.position.z);
                        curPosition = this.transform.position.x;
                        playerMoving = false;
                    }
                    break;
            }
        }
        
    }

    internal void MoveChar(TouchCollider.Side side)
    {
        if (!playerMoving)
        {
            //RIGHT
            if (side == TouchCollider.Side.Right &&
                 curPosition < 2.5f && !playerMoving)
            {
                playerMoving = true;
                moving = Direction.Right;
                curPosition = this.transform.position.x;
            }

            //LEFT
            if (side == TouchCollider.Side.Left &&
                 curPosition > -2.5f && !playerMoving)
            {
                playerMoving = true;
                moving = Direction.Left;
                curPosition = this.transform.position.x;
            }
        }
    }
}
