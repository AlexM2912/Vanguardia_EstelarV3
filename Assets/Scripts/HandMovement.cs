using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    private SpriteRenderer srArm;
    private SpriteRenderer weapon;
    private Transform weaponT;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        srArm = GameObject.FindGameObjectWithTag("Arm").GetComponent<SpriteRenderer>();
        weapon = GameObject.FindGameObjectWithTag("Weapon").GetComponent<SpriteRenderer>();
        weaponT = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 localPosition = weaponT.localPosition;
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0,0,rotZ);

        bool mirandoIzquierda = rotZ > 90 || rotZ < -90;

        if (mirandoIzquierda)
        {
            srArm.flipY = true;
            weapon.flipY = true;
            
            if(localPosition.y > 0)
            {
                localPosition.y *= -1;
                weaponT.localPosition = localPosition;
            }
            
        }
        else
        {
            srArm.flipY = false;
            weapon.flipY = false;
            if (localPosition.y < 0)
            {
                localPosition.y *= -1;
                weaponT.localPosition = localPosition;
            }
        }

        if (!canFire)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            Instantiate(bullet, bulletTransform.position + bulletTransform.right * 0.5f, bulletTransform.rotation);
        }
    }
}
