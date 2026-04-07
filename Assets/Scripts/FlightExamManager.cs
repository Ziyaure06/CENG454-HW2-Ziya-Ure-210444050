using UnityEngine;
using TMPro;
using System.Collections;

public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private TMP_Text warningText;

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
    }

    public void ShowMissionFailed()
    {
        missionComplete = false;
        if (warningText != null)
        {
            warningText.text = "GÖREV BAÞARISIZ: Vuruldun!";
            warningText.color = Color.red;
        }
    }

    private IEnumerator ClearTextDelay()
    {
        yield return new WaitForSeconds(3f);
        if (!isPlayerInDangerZone && warningText != null)
        {
            warningText.text = "";
        }
    }
}