using UnityEngine;

public class AircraftThreatHandler : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private FlightController flightController;
    [SerializeField] private AudioSource crashAudioSource;
    [SerializeField] private AudioClip crashSoundClip;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Missile"))
        {
            if (examManager != null)
            {
                examManager.ShowMissionFailed();
            }

            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, transform.rotation);
            }

            if (crashAudioSource != null && crashSoundClip != null)
            {
                crashAudioSource.PlayOneShot(crashSoundClip);
            }

            if (flightController != null)
            {
                flightController.StopEngine();
                flightController.enabled = false;
            }

            MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer renderer in renderers)
            {
                renderer.enabled = false;
            }

            Destroy(collision.gameObject);
        }
    }
}