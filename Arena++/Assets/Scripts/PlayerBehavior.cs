using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public delegate void JumpingEvent();
    public event JumpingEvent playerJump;

    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;
    public bool demoKinematicMovement = false;

    public float jumpVelocity = 10f;
    public float distanceToGround = 0.1f;
    public LayerMask groundlayer;

    public GameObject bullet;
    public GameObject topHat;
    public float bulletSpeed = 100f;

    private float vInput;
    private float hInput;
    private Rigidbody _rb;
    private CapsuleCollider _col;
    private GameBehavior _gameManager;

    private bool doJump = false;
    private bool doShoot = false;

    // Start is called before the first frame update
    void Start()
    {
        _col = GetComponent<CapsuleCollider>();
        _rb = GetComponent<Rigidbody>();

        _gameManager = GameObject.Find("GameBehavior").GetComponent<GameBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;

        if (demoKinematicMovement)
        {
            MoveKinematically();
        }

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            doJump = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (_gameManager.ammo > 0)
            {
                doShoot = true;
                _gameManager.ammo -= 1;
            }
           
        }
    }

    private void FixedUpdate()
    {
        if (demoKinematicMovement)
        {
            return;
        }

        if (doJump)
        {
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
            doJump = false;
            playerJump();
        }

        Vector3 rotation = Vector3.up * hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        _rb.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);

        if (doShoot)
        {
            GameObject newBullet = Instantiate(bullet, this.transform.position + this.transform.right, this.transform.rotation) as GameObject;
            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
            bulletRB.velocity = this.transform.forward * bulletSpeed;
            doShoot = false;
        }
    }

    void MoveKinematically()
    {
        this.transform.Translate(Vector3.forward * vInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);
    }

    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);
        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, distanceToGround, groundlayer, QueryTriggerInteraction.Ignore);
        return grounded;
    }

    private float jumpMultiplier;
    private float speedMultiplier;
    public void JumpBoost(float multiplier, float seconds)
    {
        jumpMultiplier = multiplier;
        jumpVelocity *= multiplier;
        Invoke("EndJumpBoost", seconds);
    }

    public void EndJumpBoost()
    {
        Debug.Log("speed boost ended");
        jumpVelocity /= jumpMultiplier;
    }

    public void BoostSpeed(float multiplier, float seconds)
    {
        speedMultiplier = multiplier;
        moveSpeed *= multiplier;
        Invoke("EndSpeedBoost", seconds);
    }

    public void EndSpeedBoost()
    {
        Debug.Log("speed boost ended");
        moveSpeed /= speedMultiplier;
    }

    public void showHat()
    {
        topHat.SetActive(true);
    }

    void OnCollisionEnter(Collision collisioninfo)
    {
        if (collisioninfo.collider.tag == "Enemy")
        {
            _gameManager.HP -= 1;
        }
    }
}
