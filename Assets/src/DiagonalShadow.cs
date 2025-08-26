using UnityEngine;
using System.Collections;

public class DiagonalShadow : MonoBehaviour
{
    private Vector2 direction = new Vector2(1f, 1f);
    private float speed = 3f;
    public CatsPaw catsPaw;

    private bool canFollow = false;
    private SpriteRenderer sr;
    private Color c;
    private bool canMove = false;

    private float timeOutsideShelter = 0f;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        c = sr.color;
        c.a = 0f;
        sr.color = c;
    }

    void Update()
    {
        if (!Teleportation.isInShelter)
        {
            timeOutsideShelter += Time.deltaTime;
            if (timeOutsideShelter >= 60f && !canMove)
            {
                ActivateShadow();
            }
        }
        else
        {
            timeOutsideShelter = 0f;
            canMove = false;
            c.a = 0f;
            sr.color = c;
        }
        if (canFollow && canMove)
        {
            transform.Translate(direction * speed * Time.deltaTime);
            Vector2 pos = transform.position;
            if (pos.x <= -8 || pos.x >= 8)
                direction.x *= -1;
            if (pos.y <= -5 || pos.y >= 3.5)
                direction.y *= -1;
        }
    }

    private void ActivateShadow()
    {
        transform.position = new Vector2(1f, 1f);
        c.a = 0.75f;
        sr.color = c;
        canMove = true;
        StartCoroutine(CallCatsPawRoutine());
    }

    IEnumerator CallCatsPawRoutine()
    {
        while (canMove)
        {
            canFollow = false;
            c.a = 0f;
            sr.color = c;

            yield return StartCoroutine(catsPaw.CatsPawFalls2());

            canFollow = true;
            c.a = 0.75f;
            sr.color = c;

            yield return new WaitForSeconds(1f);
        }
    }
}
