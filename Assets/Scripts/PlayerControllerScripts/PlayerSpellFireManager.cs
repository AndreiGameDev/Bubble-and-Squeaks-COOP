using System.Collections;
using UnityEngine;

public class PlayerSpellFireManager : MonoBehaviour
{
    public bool hasFired;
    public GameObject spell;
    PlayerRefferenceMaster playerRefMaster;
    [SerializeField] Transform spellSpawnPos;
    [SerializeField] float cooldownCasting = 1f;
    [SerializeField] bool canCast = true;
    [SerializeField] GameObject spellGameObject;
    private void Start() {
        playerRefMaster = GetComponent<PlayerRefferenceMaster>();
    }
    void OnFire() {
        if(hasFired && canCast && spellGameObject == null) {
            Debug.Log("HasFired");
            StartCoroutine(Cooldown());
            spellGameObject = Instantiate(spell, spellSpawnPos.position, Quaternion.identity);
            ProjectileComponent spellFiredProperties = spellGameObject.GetComponent<ProjectileComponent>();
            spellFiredProperties.player = playerRefMaster;
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
