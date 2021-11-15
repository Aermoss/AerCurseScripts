using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockInteraction : MonoBehaviour {
    public Camera playercamera;

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            removeBlock();
        }

        if (Input.GetMouseButtonDown(1)) {
            addBlock();
        }
    }

    void removeBlock() {
        Ray ray = playercamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 13f)) {
            Destroy(hit.collider.gameObject);
        }
    }

    void addBlock() {
        Ray ray = playercamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 13f)) {
            Vector3 newPos = hit.transform.position;

            GameObject newBlock = Instantiate(hit.collider.gameObject);

            newBlock.transform.position = newPos;
            newBlock.transform.Translate(hit.normal * 1f);
        }
    }
}
