using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    GameObject player;
    Stats stats;
    Rigidbody rb;
    public bool grounded,dashing;
    public float maxVelocity,gravity,jump,dashTimer,dashTime,dashSpeed,dashCDTimer,dashCD;
    Animator anim;

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
        }
        if (Input.GetKey(KeyCode.A)&& rb.velocity.x >= -maxVelocity)
        {
            player.transform.eulerAngles = new Vector3(0, 90, 0);
            anim.SetBool("walking", true);
            rb.velocity += new Vector3(-1, 0, 0);
            if (dashing)
                rb.velocity = new Vector3(-maxVelocity * dashSpeed, rb.velocity.y, rb.velocity.z);
        }
        /*if(Input.GetKey(KeyCode.S))
        {
            rb.velocity += new Vector3(0, -1, 0);
        }*/
        if(Input.GetKey(KeyCode.D)&& rb.velocity.x <= maxVelocity)
        {
            player.transform.eulerAngles = new Vector3(0, -90, 0);
            anim.SetBool("walking", true);
            rb.velocity += new Vector3(1, 0, 0);
            if(dashing)
                rb.velocity = new Vector3(maxVelocity * dashSpeed, rb.velocity.y, rb.velocity.z);
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
        if (Input.GetKey(KeyCode.J))
        {
            if (stats.hp > 0) {
                stats.hp -= 10;
                if (stats.hp < 0)
                    stats.hp = 0;
            }
        }
        if (Input.GetKey(KeyCode.K))
        {
            if (stats.mana > 0)
            {
                stats.mana -= 10;
                if (stats.mana < 0)
                    stats.mana = 0;
            }
            if (stats.realMana >= 10)
            {
                stats.realMana -= 10;
            }
        }
        if (Input.GetKey(KeyCode.L))
        {
            stats.xp += 1;

            if (stats.realMana >= 30)
            {
                stats.realMana -= 30;
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
}
