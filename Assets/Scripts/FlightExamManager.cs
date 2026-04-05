using UnityEngine;

public class FlightExamManager : MonoBehaviour
{
    // Oyun durumlarý
    public bool isPlayerInDangerZone = false;
    public bool threatCleared = false;
    public bool missionComplete = false;

    
    public void EnterDangerZone()
    {
        isPlayerInDangerZone = true;
        Debug.Log("Sýnav Yöneticisi: Uçak tehlikeli bölgeye GÝRDÝ!");
    }

  
    public void ExitDangerZone()
    {
        isPlayerInDangerZone = false;
        threatCleared = true; 
        Debug.Log("Sýnav Yöneticisi: Uçak bölgeden ÇIKTI. Tehlike atlatýldý.");
    }
}