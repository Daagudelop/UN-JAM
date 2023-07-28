using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.IMGUI.Controls.PrimitiveBoundsHandle;

public class PlayersController : MonoBehaviour
{
    private Vector3 playerStartPosition;

    private bool correr = false;
    private bool tomar  = false;
    private bool accion = false;

    private float ejeHorizontal;
    private float ejeVertical;

    Vector3 moveDirection;
    Vector2 facingDirection;

    [SerializeField] float moveSpeed;
    [SerializeField] int NumberOfThePlayer;

    private Rigidbody2D playeRigidBody;
    private Animator playeAnimator;
    private SpriteRenderer playeSpriteRenderer;

    private void Awake()
    {
        playeRigidBody = GetComponent<Rigidbody2D>();
        playeAnimator = GetComponent<Animator>();
        playeSpriteRenderer = GetComponent<SpriteRenderer>();
        playerStartPosition = this.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.sharedInstanceGameManager.currentGameState == GameState.inGame)
        {
            ActionCollector();
        }
        else if (GameManager.sharedInstanceGameManager.currentGameState == GameState.gameOver)
        {

            playeRigidBody.velocity = Vector2.zero;
        
        }

        //playeAnimator.SetBool(STATE_IS_MOVING, IsMoving());
    }

    private void FixedUpdate()
    {
        if (GameManager.sharedInstanceGameManager.currentGameState == GameState.inGame)
        {
            ToMove();
        }
        else if (GameManager.sharedInstanceGameManager.currentGameState == GameState.gameOver)
        {

        }
    }

    void ActionCollector()
    {
        if (NumberOfThePlayer == 1)
        {
            //--------------------------------
            //walking.
            ejeHorizontal = Input.GetAxis("Horizontal player 1");
            ejeVertical = Input.GetAxis("Vertical player 1");
            moveDirection.x = ejeHorizontal;
            moveDirection.y = ejeVertical;
            //--------------------------------
            //Running
            correr = Input.GetButton("correr player 1");
            //--------------------------------
            //acciones
            tomar = Input.GetButton("tomar player 1");
            accion = Input.GetButton("accion player 1");
        }
        else if (NumberOfThePlayer == 2)
        {
            
            //--------------------------------
            //walking.
            ejeHorizontal = Input.GetAxis("Horizontal player 2");
            ejeVertical = Input.GetAxis("Vertical player 2");
            moveDirection.x = ejeHorizontal;
            moveDirection.y = ejeVertical;
            //--------------------------------
            //Running
            correr = Input.GetButton("correr player 2");
            //--------------------------------
            //acciones
            tomar = Input.GetButton("tomar player 2");
            accion = Input.GetButton("accion player 2");

            Debug.Log("nani");
        }
    }

    private void RestartPosition()
    {
        this.transform.position = playerStartPosition;
    }

    void ToMove()
    {
        if (correr)
        {
            playeRigidBody.velocity = new Vector3(moveDirection.x, moveDirection.y, 0) * moveSpeed * 2;
            transform.rotation = Quaternion.identity;
        }
        else
        {
            playeRigidBody.velocity = new Vector3(moveDirection.x, moveDirection.y, 0) * moveSpeed;

        }
        LookingDirection();
    }
    void LookingDirection()
    {
        if (moveDirection.x < 0)
        {
            playeSpriteRenderer.flipX = true;
        }
        else if (moveDirection.x > 0)
        {
            playeSpriteRenderer.flipX = false;
        }
    }

    void Recoger()
    {
        if (tomar)
        {
            
        }
    }

    void Craft() 
    {
        if (accion)
        {

        }
    }

    public void StartGame()
    {
        if (GameManager.sharedInstanceGameManager.currentGameState == GameState.gameOver)
        {
            Invoke("RestartPosition", 0.2f);

        }
    }

}
