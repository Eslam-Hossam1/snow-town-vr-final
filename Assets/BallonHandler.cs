using UnityEngine;

public class BalloonControl : MonoBehaviour
{
    public float scaleFactor = 1.1f; // عامل التكبير والتصغير
    public float minSize = 0.5f; // الحد الأدنى للحجم
    public float maxSize = 3f; // الحد الأقصى للحجم
    public float floatSpeed = 0.5f; // سرعة الحركة العمودية
    public float floatHeight = 0.5f; // ارتفاع الحركة العمودية

    private Vector3 startPos;
    private float floatTimer;

    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //// تكبير البالون عند الضغط على السهم للأعلى
        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    if (transform.localScale.x < maxSize) // التأكد من أن الحجم مش هيتعدى الحد الأقصى
        //    {
        //        transform.localScale *= scaleFactor;
        //    }
        //}

        //// تصغير البالون عند الضغط على السهم للأسفل
        //if (Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    if (transform.localScale.x > minSize) // التأكد من أن الحجم مش هينزل تحت الحد الأدنى
        //    {
        //        transform.localScale /= scaleFactor;
        //    }
        //}

        // حركة البالون العمودية البطيئة
        floatTimer += Time.deltaTime * floatSpeed;
        float newY = startPos.y + Mathf.Sin(floatTimer) * floatHeight;
        transform.position = new Vector3(transform.position.x, newY+1, transform.position.z);
    }
}