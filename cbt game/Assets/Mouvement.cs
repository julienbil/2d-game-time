using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    GameObject player;
    Stats stats;
    Rigidbody rb;
    public bool grounded,dashing,attacking,attackCD;
    public float maxVelocity,gravity,jump,dashTimer,dashTime,dashSpeed,dashCDTimer,dashCD,airDivider;
    Animator anim;
    public Sword sword;

    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;
        rb = this.gameObject.GetComponent<Rigidbody>();
        stats = this.gameObject.GetComponent<Stats>();
        grounded = true;
        anim = this.gameObject.GetComponent<Animator>();
        Physics.gravity = new Vector3(0, -gravity, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W)&&grounded)
        {
            rb.velocity += new Vector3(0, jump, 0);
            grounded = false;
            anim.SetBool("jumping", true);
        }
        if (Input.GetKey(KeyCode.A) && !attacking)
        {
            if(rb.velocity.x >= -maxVelocity)
            {
                player.transform.eulerAngles = new Vector3(0, 90, 0);
                anim.SetBool("walking", true);
                rb.velocity += new Vector3(-1, 0, 0);
            }
            if (dashing)
            {
                if (grounded)
                    rb.velocity = new Vector3(-maxVelocity * dashSpeed, rb.velocity.y, rb.velocity.z);
                else
                    rb.velocity = new Vector3(-maxVelocity * dashSpeed/airDivider, rb.velocity.y, rb.velocity.z);
            }
        }
        if (Input.GetKey(KeyCode.S) && grounded && !attacking)
        {
            rb.velocity += new Vector3(0, -1, 0);
            anim.SetBool("crouching", true);
        }
        if (!Input.GetKey(KeyCode.S) || !grounded)
        {
            anim.SetBool("crouching", false);
        }
        if (grounded)
        {
            anim.SetBool("jumping", false);
        }
        if(Input.GetKey(KeyCode.D) && !attacking)
        {
            if (rb.velocity.x <= maxVelocity)
            {
                player.transform.eulerAngles = new Vector3(0, -90, 0);
                anim.SetBool("walking", true);
                rb.velocity += new Vector3(1, 0, 0);
            }
            if (dashing)
            {
                if(grounded)
                    rb.velocity = new Vector3(maxVelocity * dashSpeed, rb.velocity.y, rb.velocity.z);
                else
                    rb.velocity = new Vector3(maxVelocity * dashSpeed/airDivider, rb.velocity.y, rb.velocity.z);
            }
        }
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            anim.SetBool("walking", false);
        }
        if (Input.GetKey(KeyCode.Space) && !dashing&&dashCDTimer<=0)
        {
            dashing = true;
            dashCDTimer = dashCD;
            dashTimer = dashTime;
        }
        if (Input.GetKeyDown(KeyCode.J) && grounded && !attackCD)
        {
            StartCoroutine(Attacking(Attack.J));
        }
        if (Input.GetKey(KeyCode.K) && !attackCD)
        {
            if (stats.realMana >= 10)
            {
                stats.realMana -= 10;
                StartCoroutine(Attacking(Attack.K));
            }
        }
        if (Input.GetKey(KeyCode.L) && !attackCD)
        {
            if (stats.realMana >= 30)
            {
                stats.realMana -= 30;
                StartCoroutine(Attacking(Attack.L));
            }
        }
        if (Input.GetKey(KeyCode.R))
        {
            stats.hp = stats.maxHp;
            stats.mana = stats.maxMana;
            stats.xp = stats.maxXp;
        }
        if (dashing)
        {
            dashTimer -= 1 * Time.deltaTime;
            if (dashTimer <= 0)
                dashing = false;
        }
        if (dashCDTimer > 0)
            dashCDTimer -= 1 * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }

    IEnumerator Attacking(Attack attackType)
    {
        attackCD = true;
        attacking = true;
        anim.SetBool("attacking", true);
        sword.attackType = attackType;
        yield return new WaitForSeconds(0.7f);
        attacking = false;
        anim.SetBool("attacking", false);
        sword.attackType = Attack.Null;
        yield return new WaitForSeconds(0.3f);
        attackCD = false;
    }
}
