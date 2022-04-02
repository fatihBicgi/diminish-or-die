using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    static Animator anim;
    public CharacterController2D controller;
	public Joystick joystick;

	[SerializeField] float runSpeed=65;

	float horizontalMove = 0f, mobileMove, x=56f;
	bool jump = false;
	bool crouch = false;
    public bool jumpAbility;
    public bool runAbility;
    public bool fightAbility;

    
    private void Awake()
    {


    }
    private void Start()
    {
        jumpAbility = true;
        runAbility = true;
        fightAbility = true;

        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if(!jumpAbility && !runAbility && !fightAbility)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        RunAbilityControl();

        DescribeToAxis();

        InputsForMovement();

        AttackingAnimControl();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
       
        //when player die it works
        


    }
       
    

    private void AttackingAnimControl()
    {
        if (fightAbility)
        {
            anim.SetBool("isAttacking", true);
        }
        else anim.SetBool("isAttacking", false);
    }

    private void RunAbilityControl()
    {
        if (runAbility)
        {
            runSpeed = 90;
        }
        else runSpeed = 65;
    }

    void FixedUpdate()
    {
        // Move our character
        CharMove();
    }

    private void DescribeToAxis()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        mobileMove = joystick.Horizontal * runSpeed;
        float verticalMove = joystick.Vertical;
    }

    private void InputsForMovement()
    {
        if (Input.GetButtonDown("Jump")&&jumpAbility)
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    

    private void CharMove()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        controller.Move(mobileMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public void jumpbutton()
    {
        if (jumpAbility) jump = true;


    }




}