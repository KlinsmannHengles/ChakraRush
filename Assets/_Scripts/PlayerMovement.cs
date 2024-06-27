using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum ActualChakra { NONE, DARK_BLUE, LIGHT_BLUE, PURPLE}
public class PlayerMovement : MonoBehaviour
{
    [Header("Essential")]  
    [SerializeField] private Rigidbody2D rb;
    private Vector2 movement;

    [Header("Attributes")]
    [SerializeField] private float moveSpeed;

    [Header("Animation")]
    public ActualChakra actualChakra;
    public Animator animator;
    public AnimatorOverrideController darkBlue_skin;
    public AnimatorOverrideController lightBlue_skin;
    public AnimatorOverrideController purple_skin;

    [Header("Chakras")]
    public bool[] hasChakra;

    private void Start()
    {
        ChakraPowerUp.addChakraEvent += ChangeChakraSkinOnTake;
    }

    private void OnDisable()
    {
        ChakraPowerUp.addChakraEvent -= ChangeChakraSkinOnTake;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("MoveY", movement.y);

        // it makes the character moves on the same speed in diagonals
        movement = new Vector2(movement.x, movement.y).normalized;

        if (Input.GetButtonDown("ChangeChakra"))
        {
            ChangeChakraOnButton();
        }
    }

    public void ChangeChakraOnButton()
    {
        if (actualChakra == ActualChakra.PURPLE)
        {
            if (hasChakra[1] == true)
            {
                ChangeToDarkBlueSkin();
                actualChakra = ActualChakra.DARK_BLUE;
            } else if (hasChakra[2] == true)
            {
                ChangeToLightBlueSkin();
                actualChakra = ActualChakra.LIGHT_BLUE;
            }
        } else if (actualChakra == ActualChakra.DARK_BLUE)
        {
            if (hasChakra[2] == true)
            {
                ChangeToLightBlueSkin();
                actualChakra = ActualChakra.LIGHT_BLUE;
            } else if (hasChakra[0] == true)
            {               
                ChangeToPurpleSkin();
                actualChakra = ActualChakra.PURPLE;
            }
        } else if (actualChakra == ActualChakra.LIGHT_BLUE)
        {
            if (hasChakra[0] == true)
            {
                ChangeToPurpleSkin();
                actualChakra = ActualChakra.PURPLE;
            } else if (hasChakra[1] == true)
            {
                ChangeToDarkBlueSkin();
                actualChakra = ActualChakra.PURPLE;
            }
        }
    }

    public void ChangeChakraSkinOnTake(CHAKRA_COLOR color)
    {
        if (color == CHAKRA_COLOR.PURPLE)
        {
            ChangeToPurpleSkin();
            actualChakra = ActualChakra.PURPLE;
            hasChakra[0] = true;
        }
        else if (color == CHAKRA_COLOR.DARK_BLUE)
        {
            ChangeToDarkBlueSkin();
            actualChakra = ActualChakra.DARK_BLUE;
            hasChakra[1] = true;
        }
        else if (color == CHAKRA_COLOR.LIGHT_BLUE)
        {
            ChangeToLightBlueSkin();
            actualChakra = ActualChakra.LIGHT_BLUE;
            hasChakra[2] = true;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void ChangeToDarkBlueSkin()
    {
        animator.runtimeAnimatorController = darkBlue_skin as RuntimeAnimatorController;
    }

    public void ChangeToPurpleSkin()
    {
        animator.runtimeAnimatorController = purple_skin as RuntimeAnimatorController;
    }

    public void ChangeToLightBlueSkin()
    {
        animator.runtimeAnimatorController = lightBlue_skin as RuntimeAnimatorController;
    }
}
