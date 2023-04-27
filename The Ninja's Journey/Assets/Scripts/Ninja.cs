using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Ninja : MonoBehaviour
{
    [SerializeField] private float velocity;
    private Vector3 movement;
    private Rigidbody2D rigidBody;
    private Animator animator;

    [SerializeField] private InputScript inputScript;

    [SerializeField] private float shakeIntensity;
    [SerializeField] private float shakeFrequency;
    [SerializeField] private float shakeTime;

    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        MovementProcess();
    }

    private void Update() {

    }

    void MovementProcess() {
        movement = inputScript.InputDetect();

        if(movement != Vector3.zero) {
            rigidBody.MovePosition(transform.position + movement * velocity * Time.deltaTime);

            /*if (movement.x != 0 && movement.y != 0)
            {
                rigidBody.MovePosition(transform.position + movement * (velocity / 2) * Time.deltaTime);
            }
            else
            {
                rigidBody.MovePosition(transform.position + movement * velocity * Time.deltaTime);
            }*/

            animator.SetFloat("moveX", movement.x);
            animator.SetFloat("moveY", movement.y);
            animator.SetBool("isWalking", true);
        }
        else {
            animator.SetBool("isWalking", false);
        }

        if (Input.GetMouseButtonDown(0)) {
            CineMachineShake.Instance.ShakeCamera(shakeIntensity, shakeFrequency, shakeTime);
        }
    }
 }
