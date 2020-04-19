using UnityEngine;

public class TestController : MonoBehaviour
{
    public static bool IsTesting = false;

    [SerializeField] private bool isTesting = false;

    private void Awake()
    {
        if (isTesting)
        {
            IsTesting = true;
        }
    }
}
