using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMovement : MonoBehaviour
{
    [SerializeField] private float lightSpeed = 3f;
    [SerializeField] private Transform playerPosition;
    [SerializeField] private float lightOffset = 1f;
    private bool followingMouse = true;

    private void Update()
    {
        //Logic to check if the light is following the Player or the Mouse Button
        if ((Input.GetKeyDown(KeyCode.Mouse1) && followingMouse) || DialogueManager.GetInstance().playingDialogue)
        {
            followingMouse = false;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && !followingMouse)
        {
            followingMouse = true;
        }

        if (followingMouse)
        {
            followMouse();
        }
        else
        {
            followPlayer();
        }
    }

    public void followMouse()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, mousePosition, lightSpeed * Time.deltaTime);
    }
    public void followPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(playerPosition.position.x, playerPosition.position.y + lightOffset), lightSpeed * Time.deltaTime);
    }
}
