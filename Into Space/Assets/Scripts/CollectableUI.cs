using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectableUI : MonoBehaviour
{
    TextMeshProUGUI collactableText;
    // Start is called before the first frame update
    void Start()
    {
        collactableText = GetComponent<TextMeshProUGUI>();
    }
    public void UpdateText(Collactables collactables) {
        collactableText.text = collactables.numInput.ToString();
    }
}
