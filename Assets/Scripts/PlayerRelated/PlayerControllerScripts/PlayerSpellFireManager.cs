using System.Collections;
using UnityEngine;
//Implemented by Andrei
public class PlayerSpellFireManager : MonoBehaviour
{
    public bool hasFired;
    public GameObject spell;
    PlayerRefferenceMaster playerRefMaster;
    [SerializeField] Transform spellSpawnPos;
    [SerializeField] float cooldownCasting = 1f;
    [SerializeField] bool canCast = true;
    AudioManager audioManager;
    [SerializeField] AudioClip SFX_SpellCast;
    private void Start() { // Grabs references
        playerRefMaster = GetComponent<PlayerRefferenceMaster>();
        audioManager = AudioManager.Instance;
    }
    void OnFire() { // Fires projectile and depending on the player's magic property it will assign automatically Light or Dark
        if(hasFired && canCast) {
            StartCoroutine(Cooldown());
            audioManager.PlaySFX(SFX_SpellCast);
            GameObject tempObject = Instantiate(spell, spellSpawnPos.position, Quaternion.identity);
            ProjectileComponent spellFiredProperties = tempObject.GetComponent<ProjectileComponent>();
            spellFiredProperties.player = playerRefMaster;
            spellFiredProperties.dirFacing = playerRefMaster.dirFacing;
        }
    }

    IEnumerator Cooldown() { // Puts it on cooldown
        canCast = false;    
        yield return new WaitForSecondsRealtime(cooldownCasting);
        canCast = true;

    }
    private void Update() {
        OnFire();   
    }
}
