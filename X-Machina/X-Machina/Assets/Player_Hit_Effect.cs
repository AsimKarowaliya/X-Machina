using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Hit_Effect : MonoBehaviour
{
    void ResetMat()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
       
        if (coll.gameObject.tag == ("Bullet") || coll.gameObject.tag == ("Enemy"))
        {
            //Instantiate(DeathEffect, transform.position, Quaternion.identity);
            //Destroy(gameObject);
            GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine("immune");
            this.transform.Translate(Vector2.right * 30 * Time.deltaTime);
            Invoke("ResetMat", 1.0f);
            IEnumerator coroutine = immune();
            StartCoroutine(coroutine);
            //IgnoreCollision(gameObject.GetComponent<Collider2D>(), coll.gameObject.GetComponent<Collider2D>(), true);
            // HealthSystem SN = coll.GetComponent<HealthSystem>();
            // SN.playerHealth -= 1;
        }

    }
    IEnumerator immune()
    {
        Physics2D.IgnoreLayerCollision(9, 12, true);
        yield return new WaitForSecondsRealtime(1.5f);
        Physics2D.IgnoreLayerCollision(9, 12, false);
    }
}
