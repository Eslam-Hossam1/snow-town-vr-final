using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Include TextMeshPro namespace
using UnityEngine.XR.Interaction.Toolkit;


public class BoxScoreHandler : MonoBehaviour
{
    public static int giftCount = 0; // Keeps track of collected gifts
    private AudioSource audioSource;
    private Collider boxCollider; // Reference to the box collider

    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        boxCollider = GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gift")) // Ensure the object has the "Gift" tag
        {

            // Disable XR Grab Interaction for the gift
               boxCollider.enabled = false; // Disable the collider of the box
            DisableGrabInteraction(other.gameObject);

            if (audioSource != null)
            {
                audioSource.Play();
            }

            // Find the Canvas by name
            GameObject canvas = GameObject.Find("Canvas");
            if (canvas != null)
            {
                // Update the progress bar
                Transform progressBarTransform = canvas.transform.GetChild(0).GetChild(2); // Adjust based on the exact hierarchy
                Image progressBar = progressBarTransform.GetComponent<Image>();

                if (progressBar != null)
                {
                    
                    progressBar.fillAmount += 0.1f;

                    //if (progressBar.fillAmount > 1f)
                    //{
                    //    progressBar.fillAmount = 1f;
                    //}
                }
                else
                {
                    Debug.LogWarning("ProgressBar Image component not found!");
                }

                // Update the gift count text
                Transform panel = canvas.transform.GetChild(0); // Assuming the panel is the first child of Canvas
                TextMeshProUGUI textTMP = panel.GetChild(panel.childCount - 1).GetComponent<TextMeshProUGUI>(); // Last child of the panel

                if (textTMP != null)
                {
                    // Increase gift count and update the text
                    giftCount++;
                    
                    textTMP.text = "10/" + giftCount.ToString(); // Update the TMP text to display the new count
                 
                }
                else
                {
                    Debug.LogWarning("Text (TMP) component not found!");
                }
            }
            else
            {
                Debug.LogWarning("Canvas not found in the scene!");
            }

            Debug.Log("Gift Collected!");
        }

    }

    private void DisableGrabInteraction(GameObject gift)
    {
        // Disable the XR Grab Interaction component
        var grabInteraction = gift.GetComponent<XRGrabInteractable>();

        if (grabInteraction != null)
        {
            grabInteraction.enabled = false; // Disables the grab interaction
        }
        else
        {
            Debug.LogWarning("XR Grab Interaction component not found on the gift!");
        }

    }

    
}
