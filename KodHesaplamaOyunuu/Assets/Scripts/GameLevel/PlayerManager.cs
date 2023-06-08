using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private Transform gun;

    float angle;
    float donusHizi = 5f;
   
    void Update()
    {
        RotateDegistir();
    }

    void RotateDegistir()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gun.transform.position;

            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        }

      

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        gun.transform.rotation = Quaternion.Slerp(gun.transform.rotation, rotation, donusHizi * Time.deltaTime);
    }
}
