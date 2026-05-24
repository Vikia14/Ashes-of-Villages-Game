using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    [Header("Поворот")]
    [SerializeField] private Transform swordTransform;

    private void Start()
    {
        if (swordTransform == null)
            swordTransform = transform.Find("Sword");

    }

    private void Update()
    {
        if (swordTransform == null) return;


        float horizontal = Input.GetAxisRaw("Horizontal");

        if (Mathf.Abs(horizontal) > 0.1f)
        {
            if (horizontal > 0) // Движение вправо
            {
                swordTransform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (horizontal < 0) // Движение влево
            {
                swordTransform.rotation = Quaternion.Euler(0, 0, 90);
            }
        }
    }
}