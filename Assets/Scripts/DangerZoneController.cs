using UnityEngine;
using System.Collections; 

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private float missileDelay = 5f;

    private Coroutine activeCountdown;

    
    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.CompareTag("Player"))
        {
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
                Debug.Log("Tehlike geçiþtirildi: 5 saniyelik füze sayacý ÝPTAL EDÝLDÝ!");
            }
        }
    }

   
    private IEnumerator MissileCountdownRoutine()
    {
        Debug.Log("Füze fýrlatma sayacý baþladý: 5 saniye bekleniyor...");
        yield return new WaitForSeconds(missileDelay);

        Debug.Log(" 5 Saniye doldu, füze ateþlenmeli!");
    }
}