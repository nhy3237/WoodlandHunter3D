using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VianArrowShoot : MonoBehaviour
{
    private float shootForce = 1f;
    Rigidbody arrowRigidbody;
    static float gravity = -9.8f;
    Vector3 newPosition;
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        arrowRigidbody = GetComponent<Rigidbody>();
        if (arrowRigidbody == null)
        {
            arrowRigidbody = gameObject.AddComponent<Rigidbody>();
        }

        velocity = transform.forward;

       // StartCoroutine(Shoot());
    }

    private void Update()
    {
        newPosition.x = transform.position.x +  velocity.x * Time.deltaTime;
        newPosition.y = transform.position.y + velocity.y * Time.deltaTime - gravity * Time.deltaTime * Time.deltaTime / 2;
        newPosition.z = transform.position.z + velocity.z * Time.deltaTime - gravity * Time.deltaTime * Time.deltaTime / 2;

        transform.position = newPosition;

        //arrowRigidbody.AddForce(gravity, ForceMode.Acceleration); // 중력을 적용하여 화살을 아래로 가속
        //arrowRigidbody.AddForce(transform.forward * shootForce, ForceMode.Impulse); // 초기 발사 속도를 힘으로 적용

        // 화살 위치 업데이트

        //arrowRigidbody.velocity += gravity * Time.deltaTime;
        //transform.position += arrowRigidbody.velocity * Time.deltaTime;
    }

    IEnumerator Shoot()
    {
        arrowRigidbody.velocity = transform.forward * shootForce;

        //arrowRigidbody.velocity += Physics.gravity * Time.deltaTime * Time.deltaTime;
        yield return new WaitForSeconds(2f);

        Destroy(this); // 2초 후에 화살을 삭제합니다. 조절 가능
    }
}

   
