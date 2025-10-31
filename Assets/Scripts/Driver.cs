using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 200f;
    [SerializeField] float currentTranslationSpeed = 4f;
    [SerializeField] float boostSpeed = 8f;
    [SerializeField] float regularSpeed = 4f;

    void Update()
    {
        float rotation = 0f;
        float translation = 0f;

        if(Keyboard.current.wKey.isPressed)
        {
            translation = 1f;
        } else if (Keyboard.current.sKey.isPressed)
        {
            translation = -1f;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            rotation = 1f;
        } else if (Keyboard.current.dKey.isPressed)
        {
            rotation = -1f;
        }

        float rotateAmount = rotation * rotationSpeed * Time.deltaTime;
        float translateAmount = translation * currentTranslationSpeed * Time.deltaTime;

        transform.Rotate(0, 0, rotateAmount);
        transform.Translate(0, translateAmount, 0);

        if(currentTranslationSpeed > regularSpeed)
        {
            currentTranslationSpeed -= 0.2f * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Boost"))
        {
            currentTranslationSpeed = boostSpeed;
            Destroy(collision.gameObject, 0.5f);
        }
    }
}
