using UnityEngine;

public class Body : MonoBehaviour
{
    public static Body Instance;

    private void Awake()
    {
        Instance = this;
    }
}
