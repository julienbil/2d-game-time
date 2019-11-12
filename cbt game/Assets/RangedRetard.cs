using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedRetard : Retard
{
    public GameObject Projectile;
    bool shooting = false;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x < pTransform.position.x && !shooting)
            ShootRight();
        else if (transform.position.x > pTransform.position.x && !shooting)
            ShootLeft();
            if (Input.GetKey(KeyCode.T))
            {
                TakeDamage(1, 1, 1);
            }

    }

    Projectile Create(int i)
    {
        Projectile bullet = Projectile.GetComponent<Projectile>();
        bullet.direction = i;
        bullet.lvl = lvl;
        bullet.damage = power;
        return bullet;
    }


    IEnumerator Shoot(int i)
    {
        shooting = true;
        Instantiate(Create(i), gameObject.transform.position, gameObject.transform.rotation);
        yield return new WaitForSeconds(4f);
        shooting = false;
    }

    void ShootRight()
    {
        StartCoroutine(Shoot(1));
    }

    void ShootLeft()
    {
        StartCoroutine(Shoot(-1));
    }
}
