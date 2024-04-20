using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeDrawer : MonoBehaviour
{
    Renderer renderer;
    Material originalMaterial;
    Material hoverMaterial;

    bool isClosed = true;
    bool isAnimationPlaying = false;

    Vector3 closedPosition;
    Vector3 openPosition;

    public float animPlaytiem = 0.5f;
    public float animDistance = 0.3f;

    void Start()
    {
        renderer = this.GetComponent<Renderer>();
        originalMaterial = renderer.material;
        hoverMaterial = new Material(originalMaterial);
        hoverMaterial.color = new Color(0f, 1f, 0f);

        closedPosition = this.transform.position;
        openPosition = closedPosition - Vector3.forward * animDistance;
    }

    public void HoverIn()
    {
        renderer.material = hoverMaterial;
    }
    public void HoverOut()
    {
        renderer.material = originalMaterial;
    }

    public void Select()
    {

        if (!isAnimationPlaying)
        {
            isAnimationPlaying = true;
            StartCoroutine("PlayAnimation");
        }

    }

    IEnumerator PlayAnimation()
    {
        Vector3 startPosition;
        Vector3 endPosition;

        if (isClosed)
        {
            startPosition = closedPosition;
            endPosition = openPosition;
        }
        else
        {
            startPosition = openPosition;
            endPosition = closedPosition;
        }

        float curTime = 0f;
        while (curTime / animPlaytiem < 1.0f)
        {
            curTime += Time.deltaTime;
            Vector3 currentPosition = Vector3.Lerp(startPosition, endPosition, curTime / animPlaytiem);
            this.transform.position = currentPosition;
            yield return null;
        }

        isAnimationPlaying = false;
        isClosed = !isClosed;

    }
}
