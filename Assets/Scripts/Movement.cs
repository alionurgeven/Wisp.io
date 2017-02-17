using UnityEngine;
using System.Collections;
using CnControls;

public class Movement : MonoBehaviour {

    Vector2 direction;
    Vector2 velocity;
    float horizontalInput, verticalInput;

    /// <summary>
    /// Uses given horizontal and vertical inputs to move the referenced Rigidbody2D
    /// </summary>
    /// <param name="horizontalInput"></param>
    /// <param name="verticalInput"></param>
    /// <param name="movementSpeed"></param>
    /// <param name="rgb"></param>
    /// 
    public void Move(float horizontalInput , float verticalInput, float movementSpeed, Rigidbody2D rgb)
    {
        direction = Vector2.right * horizontalInput + Vector2.up * verticalInput;
        velocity = direction.normalized * movementSpeed;
        rgb.AddForce(velocity);
    }

    /// <summary>
    /// Uses CN Input Manager inputs to move the referenced Rigidbody2D
    /// </summary>
    /// <param name="movementSpeed"></param>
    /// <param name="rgb"></param>
    public void Move(float movementSpeed, Rigidbody2D rgb)
    {
        horizontalInput = CnInputManager.GetAxisRaw("Horizontal");
        verticalInput = CnInputManager.GetAxisRaw("Vertical");
        Move(horizontalInput, verticalInput, movementSpeed, rgb);
    }
}
