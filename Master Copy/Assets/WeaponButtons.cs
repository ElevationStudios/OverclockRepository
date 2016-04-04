using UnityEngine;
using System.Collections;

public class WeaponButtons : MonoBehaviour {
    [SerializeField] GameObject PistolSection =null;
    [SerializeField] GameObject BlasterSection =null;
    [SerializeField] GameObject SwordSection =null;

	// Use this for initialization
    public void Pistol()
    {
        PistolSection.SetActive(true);
        BlasterSection.SetActive(false);
        SwordSection.SetActive(false);
    }
    public void Blaster()
    {
        PistolSection.SetActive(false);
        BlasterSection.SetActive(true);
        SwordSection.SetActive(false);
    }
    public void Sword()
    {
        PistolSection.SetActive(false);
        BlasterSection.SetActive(false);
        SwordSection.SetActive(true);
    }
}
