using UnityEngine;

public class thiefDetectedFlashlight : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Light 2D")
        {
            Debug.Log("detected Flash");
        }
    }
}
