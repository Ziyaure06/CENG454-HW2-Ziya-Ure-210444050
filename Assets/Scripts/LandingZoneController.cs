using UnityEngine;

public class LandingZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private AudioSource landingAudioSource;
    [SerializeField] private AudioClip successClip;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (examManager != null && examManager.threatCleared && !examManager.missionComplete)
            {
                examManager.ShowMissionComplete();

                if (landingAudioSource != null && successClip != null)
                {
                    landingAudioSource.PlayOneShot(successClip);
                }
            }
        }
    }
}