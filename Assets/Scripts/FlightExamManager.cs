using UnityEngine;
using TMPro;
using System.Collections;

public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private TMP_Text warningText;
    [SerializeField] private AudioSource uiAudioSource;
    [SerializeField] private AudioClip dangerZoneClip;
    [SerializeField] private AudioClip clearZoneClip;
    [SerializeField] private AudioClip missionFailedClip;

    public bool isPlayerInDangerZone = false;
    public bool threatCleared = false;
    public bool missionComplete = false;

    private void Start()
    {
        if (warningText != null)
        {
            warningText.text = "";
        }
    }

    public void EnterDangerZone()
    {
        isPlayerInDangerZone = true;
        if (warningText != null)
        {
            warningText.color = Color.red;
        }
        if (uiAudioSource != null && dangerZoneClip != null)
        {
            uiAudioSource.PlayOneShot(dangerZoneClip);
        }
    }

    public void UpdateCountdown(int timeLeft)
    {
        if (warningText != null)
        {
            warningText.text = "Entered a Dangerous Zone! " + timeLeft;
        }
    }

    public void ShowMissileLaunched()
    {
        if (warningText != null)
        {
            warningText.text = "Füze ateþlendi!";
        }
    }

    public void ExitDangerZone()
    {
        isPlayerInDangerZone = false;
        threatCleared = true;

        if (warningText != null)
        {
            warningText.text = "Threat Cleared!";
            warningText.color = Color.green;
            StartCoroutine(ClearTextDelay());
        }
        if (uiAudioSource != null && clearZoneClip != null)
        {
            uiAudioSource.PlayOneShot(clearZoneClip);
        }
    }

    public void ShowMissionFailed()
    {
        missionComplete = false;
        if (warningText != null)
        {
            warningText.text = "GÖREV BAÞARISIZ: Vuruldun!";
            warningText.color = Color.red;
        }
        if (uiAudioSource != null && missionFailedClip != null)
        {
            uiAudioSource.PlayOneShot(missionFailedClip);
        }
    }

    public void ShowMissionComplete()
    {
        missionComplete = true;
        if (warningText != null)
        {
            warningText.text = "Mission Completed!";
            warningText.color = Color.blue;
        }
    }

    private IEnumerator ClearTextDelay()
    {
        yield return new WaitForSeconds(3f);
        if (!isPlayerInDangerZone && warningText != null && !missionComplete)
        {
            warningText.text = "";
        }
    }
}