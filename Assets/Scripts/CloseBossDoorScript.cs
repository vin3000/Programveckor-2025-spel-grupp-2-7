using UnityEngine;

public class CloseBossDoorScript : MonoBehaviour
{
    [SerializeField] private MeshRenderer doorMeshRenderer;
    [SerializeField] private BoxCollider doorBoxCollider;
    [SerializeField] private AudioClip goblinSoundEffect;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            doorMeshRenderer.enabled = true;
            doorBoxCollider.isTrigger = false;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            SoundFXManager.instance.PlaySoundFXClip(goblinSoundEffect, this.transform, 0.75f, 500);
        }
    }
}
