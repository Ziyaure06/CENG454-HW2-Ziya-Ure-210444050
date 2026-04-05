using UnityEngine;
using System.Collections;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private MissileLauncher missileLauncher; 
    [SerializeField] private float missileDelay = 5f;

    private Coroutine activeCountdown;
    private Transform playerTransform; 

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerTransform = collision.transform; 
            examManager.EnterDangerZone();
            activeCountdown = StartCoroutine(MissileCountdownRoutine());
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            examManager.ExitDangerZone();

            if (activeCountdown != null)
            {
                StopCoroutine(activeCountdown);
                activeCountdown = null;
            }

            
            if (missileLauncher != null)
            {
                missileLauncher.DestroyActiveMissile();
            }
        }
    }

    private IEnumerator MissileCountdownRoutine()
    {
        yield return new WaitForSeconds(missileDelay);

      
        if (missileLauncher != null && playerTransform != null)
        {
            missileLauncher.Launch(playerTransform);
        }
        else
        {
            Debug.LogWarning("HATA: Fýrlatýcý (Missile Launcher) slota eklenmemiþ!");
        }
    }
}