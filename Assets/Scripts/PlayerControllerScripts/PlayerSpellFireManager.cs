using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSpellFireManager : MonoBehaviour
{
    public bool hasFired;
    public GameObject spell;
    PlayerRefferenceMaster playerRefMaster;
    [SerializeField] Transform spellSpawnPos;
    [SerializeField] float cooldownCasting = 1f;
    [SerializeField] bool canCast = true;
    private void Start() {
        playerRefMaster = GetComponent<PlayerRefferenceMaster>();
    }
    void OnFire() {
        if(hasFired && canCast) {
            Debug.Log("HasFired");
            StartCoroutine(Cooldown());
            GameObject spellFired = Instantiate(spell, spellSpawnPos.position, Quaternion.identity);
            ProjectileComponent spellFiredProperties = spellFired.GetComponent<ProjectileComponent>();
            spellFiredProperties.dirFacing = playerRefMaster.dirFacing;
        }
    }

    IEnumerator Cooldown() {
        canCast = false;    
        yield return new WaitForSecondsRealtime(cooldownCasting);
        canCast = true;

    }
    private void Update() {
        OnFire();   
    }
}
