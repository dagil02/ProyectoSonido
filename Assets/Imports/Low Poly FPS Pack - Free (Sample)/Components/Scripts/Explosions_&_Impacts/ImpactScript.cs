using UnityEngine;
using System.Collections;

// ----- Low Poly FPS Pack Free Version -----
public class ImpactScript : MonoBehaviour {

	[Header("Impact Despawn Timer")]
	//How long before the impact is destroyed
	public float despawnTimer = 1.0f;

	private void Start () {
		// Start the despawn timer
		StartCoroutine (DespawnTimer ());

		FMOD.Studio.EventInstance impact = FMODUnity.RuntimeManager.CreateInstance("event:/others/Impacts");
		FMODUnity.RuntimeManager.AttachInstanceToGameObject(impact, this.transform);
		impact.start();
		impact.release();
	}
	
	private IEnumerator DespawnTimer() {
		//Wait for set amount of time
		yield return new WaitForSeconds (despawnTimer);
		//Destroy the impact gameobject
		Destroy (gameObject);
	}
}
// ----- Low Poly FPS Pack Free Version -----