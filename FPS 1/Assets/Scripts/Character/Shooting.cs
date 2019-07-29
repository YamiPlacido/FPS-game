using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private Animator _anim => GetComponent<Animator>();

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) /*&&*/ /*!EventSystem.current.IsPointerOverGameObject()*/)
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                _anim.SetTrigger("Attack");

                Interactable hitobj = hit.transform.GetComponent<Interactable>();

                if (hitobj != null && hit.transform.tag == "Enemy")
                {
                    hitobj.HitReaction();
                }
            }
        }
    }

    void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }
}
