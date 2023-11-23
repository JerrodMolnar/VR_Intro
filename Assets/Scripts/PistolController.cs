using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PistolController : Basketball
{

    [SerializeField]
    GameObject _muzzleFlashPrefab, _hitPrefab;
    [SerializeField]
    Transform _rayOrigin;
    [SerializeField]
    Vector3 _muzzleFlashOffset;
    AudioSource _audio;
    [SerializeField]
    AudioClip _gunShotClip;
    XRGrabInteractable _interactable;


    private void OnEnable()
    {
        _audio = GetComponent<AudioSource>();
        _interactable = GetComponent<XRGrabInteractable>();
    }

    [ContextMenu("Test Fire")]
    public void TriggerPull()
    {
        Debug.Log("Multiple grab count = " + _interactable.multipleGrabTransformersCount);
        if ((_interactable.multipleGrabTransformersCount == 1 && _interactable.secondaryAttachTransform != null) || _interactable.secondaryAttachTransform == null)
        {
            Instantiate(_muzzleFlashPrefab, _rayOrigin.position + _muzzleFlashOffset, Quaternion.identity);
            if (_gunShotClip != null && _audio != null)
                _audio.PlayOneShot(_gunShotClip);

            if (Physics.Raycast(_rayOrigin.position, _rayOrigin.forward, out RaycastHit hit, Mathf.Infinity) && hit.transform.CompareTag("Target"))
            {
                Instantiate(_hitPrefab, hit.point, Quaternion.identity);
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(_rayOrigin.position, _rayOrigin.forward * 10);
    }
}
