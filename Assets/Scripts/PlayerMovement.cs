using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private LayerMask groundLayer, spikesLayer;
    [SerializeField]
    private Transform visualTransform;

    private float rotationSpeed = 180 / 0.5f;

    private InputAction jumpAction;
    private Rigidbody2D rb;

    private bool isGrounded;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        jumpAction = InputSystem.actions.FindAction("Jump");

        visualTransform = transform.GetChild(2);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            if (jumpAction.IsPressed())
            {
                rb.AddForceY(jumpForce, ForceMode2D.Impulse);

                isGrounded = false;
            }
        }
        else
        {
            visualTransform.Rotate(rotationSpeed * Time.deltaTime * Vector3.back);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((groundLayer.value & (1 << collision.gameObject.layer)) != 0)
        {
            isGrounded = true;

            //Snap to nearest 90 degrees
            float currRotation = visualTransform.eulerAngles.z;
            float snappedRotation = Mathf.Round(currRotation / 90) * 90;
            visualTransform.eulerAngles = snappedRotation * Vector3.forward;
        }
    }
}
