using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    [SerializeField] float destroyDelay = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Package") && !hasPackage)
        {
            hasPackage = true;

            Destroy(collision.gameObject, destroyDelay);

            GetComponent<ParticleSystem>().Play();
        } else if(collision.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("Delivered!");
            hasPackage = false;

            Destroy(collision.gameObject, destroyDelay);
            GetComponent<ParticleSystem>().Stop();
        }
    }
}
