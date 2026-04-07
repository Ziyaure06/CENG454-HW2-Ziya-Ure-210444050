using UnityEngine;

public class AircraftThreatHandler : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
   

    private void OnTriggerEnter(Collider collision)
    {
       
        if (collision.CompareTag("Missile"))
        {
            if (examManager != null)
            {
                examManager.ShowMissionFailed();
            }
            
            // Füzeyi patlat
            Destroy(collision.gameObject);

           
        }
    }
}