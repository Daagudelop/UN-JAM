using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//using static UnityEditor.IMGUI.Controls.PrimitiveBoundsHandle;

public class PlayersController : MonoBehaviour
{
    const string STATE_IS_UP = "isUp";
    const string STATE_IS_DOWN = "isDown";
    const string STATE_IS_HORIZONTAL = "isHorizontal";


    [SerializeField] public bool poseeSierra= false;
    [SerializeField] public bool poseeVenda= false;
    [SerializeField] public bool poseeMezclaCura= false;
    [SerializeField] public bool poseeMezclaPosion = false;
    [SerializeField] public bool poseeMezclaMuerte = false;
    [SerializeField] public bool poseeResultadoMezcla= false;

    private Vector3 playerStartPosition;

    public bool correr = false;
    public bool tomar  = false;
    public bool accion = false;

    private float ejeHorizontal;
    private float ejeVertical;

    Vector3 moveDirection;
    Vector3 DashDir;
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
            if( Input.GetButtonDown("correr player 1"))
            {
                correr = true;
            }
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
            if (Input.GetButtonDown("correr player 2"))
            {
                correr = true;
            }
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
        
        if (correr == true)
        {
            StartCoroutine(Dash());
            if (moveDirection.x == 0 && moveDirection.y == 0)
            {
                playeRigidBody.velocity = Vector3.zero;
            }
        }
        else
        {
            playeRigidBody.velocity = new Vector3(moveDirection.x, moveDirection.y, 0) * moveSpeed;
            if (moveDirection.x == 0 && moveDirection.y == 0)
            {
                playeRigidBody.velocity = Vector3.zero;
            }
        }


        DefineSpriteAnim();
        LookingDirection();

        var Clamp = transform.position;
        Clamp.x = Mathf.Clamp(transform.position.x, -8.2f, 8.2f);
        Clamp.y = Mathf.Clamp(transform.position.y, -4.2f, 4.2f);
        transform.position = Clamp;
    }

    private IEnumerator Dash()
    {
        playeRigidBody.velocity = new Vector3(moveDirection.x, moveDirection.y, 0) * moveSpeed * 3;
        yield return new WaitForSeconds(0.1f);
        playeRigidBody.velocity = new Vector3(moveDirection.x, moveDirection.y, 0) * moveSpeed;
        correr = false;

    }
    private void DefineSpriteAnim()
    {
        if (moveDirection.x == 0 && moveDirection.y == 0)
        {
            playeAnimator.SetBool(STATE_IS_HORIZONTAL, false);
            playeAnimator.SetBool(STATE_IS_UP, false);
            playeAnimator.SetBool(STATE_IS_DOWN, false);
        }
        else if (moveDirection.x != 0)
        {
            playeAnimator.SetBool(STATE_IS_HORIZONTAL, true);
            playeAnimator.SetBool(STATE_IS_UP, false);
            playeAnimator.SetBool(STATE_IS_DOWN, false);
        }

        if (moveDirection.y > 0)
        {
            playeAnimator.SetBool(STATE_IS_HORIZONTAL, false);
            playeAnimator.SetBool(STATE_IS_UP, true);
            playeAnimator.SetBool(STATE_IS_DOWN, false);
        }
        else if (moveDirection.y < 0)
        {
            playeAnimator.SetBool(STATE_IS_HORIZONTAL, false);
            playeAnimator.SetBool(STATE_IS_UP, false);
            playeAnimator.SetBool(STATE_IS_DOWN, true);
        }
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

    public void ToHide()
    {
        
    }

}
