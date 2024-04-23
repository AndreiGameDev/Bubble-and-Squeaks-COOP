using UnityEngine;
using UnityEngine.SceneManagement;
//Implemented by Andrei
public class MazeReset : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) {
        // Check for layer or tag instead of whatever here once we can optimise
        PlayerRefferenceMaster player = collision.collider.GetComponentInParent<PlayerRefferenceMaster>();
        if(player != null) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            // Might want to trigger some reset animations or something as well to juice it up..
        }
    }
}
