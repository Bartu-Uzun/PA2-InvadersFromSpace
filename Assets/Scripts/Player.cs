using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private GameObject bulletPrefab;

    Camera cam;

    public float width;
    private float speed = 3f;

    private bool isShooting = false;

    private float coolDown = 0.5f;


    private void Awake() {
        
        cam = Camera.main;
        // SCREEN BOYUTUNA GÖRE AYARLANAN SAĞ SOL LİMİTLERİ
        width = (1 / (cam.WorldToViewportPoint(new Vector3(1,1,0)).x - .5f) / 2);

        width = width - 0.25f; //geminin eninin yarısını çıkardık
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.A) && transform.position.x > - width) {

            transform.Translate(Vector2.left * Time.deltaTime * speed); // TO LEFT MOVEMENT

        }
        else if (Input.GetKey(KeyCode.D) && transform.position.x < width) {

            transform.Translate(Vector2.right * Time.deltaTime * speed); // TO LEFT MOVEMENT

        }

        if (Input.GetKey(KeyCode.Space) && !isShooting) {

            StartCoroutine(Shoot());
        }
#endif
    }

    //coroutine
    private IEnumerator Shoot() {

        isShooting = true;
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(coolDown);

        isShooting = false;
    }
}
