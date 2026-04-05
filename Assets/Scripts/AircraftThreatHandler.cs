using UnityEngine;

public class AircraftThreatHandler : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
   

    private void OnTriggerEnter(Collider collision)
    {
       
        if (collision.CompareTag("Missile"))
        {
            Debug.Log("GÖREV BAÞARISIZ: Füze Uçaða Çarptý!");

            // Füzeyi patlat
            Destroy(collision.gameObject);

           
        }
    }
}