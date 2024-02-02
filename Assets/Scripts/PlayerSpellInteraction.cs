using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpellInteraction : MonoBehaviour , ISpellInteraction
{
    [SerializeField] float radius = 5f;
    
    public void SpellInteraction() {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(new Vector2(transform.position.x, transform.position.y), radius, Vector2.right, radius,LayerMask.GetMask("Obstacles"));
        foreach(RaycastHit2D hit in hits) {
            Destroy(hit.transform.gameObject);
            Destroy(gameObject);
        }
        
    }
}
