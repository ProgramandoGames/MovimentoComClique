using UnityEngine;

public class GoToClickPosition : MonoBehaviour {

    public GameObject markerPrefab;

    public LayerMask collision;
    public float responsiveness = 0.01f;
    
    public float minStopDistance = 0.3f;
    public float maxSpeed = 3.5f;
    public float acceleration = 1f;

    float speed = 0f;
    Vector3 target;
    Vector3 direction;

    public float GetSpeed => speed;

    void Start() {

        target = transform.position;
        direction = transform.forward;

    }

    void Update() {

        if(Input.GetKeyDown(KeyCode.Mouse0)) {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, collision)) {
                target = new Vector3(hit.point.x, 0.01f, hit.point.z);

                Instantiate(markerPrefab, target, Quaternion.Euler(90, 45, 0));

            }

        }

        direction = Vector3.MoveTowards(direction, (target - transform.position).normalized, responsiveness);

        transform.forward = direction;

        if((transform.position - target).sqrMagnitude <= minStopDistance * minStopDistance) {
            speed = Mathf.Lerp(maxSpeed, 0, acceleration);
        } else {
            speed = Mathf.Lerp(0, maxSpeed, acceleration);
        }

        transform.position += transform.forward * speed * Time.deltaTime;


        

    }

    // private void OnDrawGizmos() {
    // 
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawSphere(target, 0.5f);
    // 
    // }


}




    