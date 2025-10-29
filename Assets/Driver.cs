using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 1.5f;
    [SerializeField] float translationSpeed = 0.2f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed);
        transform.Translate(0, translationSpeed, 0);
    }
}
