using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulScript : MonoBehaviour
{
    
    public GameObject soulCatcher;
    private void OnTriggerEnter2D(Collider2D other) {
        
        


        StartCoroutine(SoulFloat(soulCatcher));
    }

    private IEnumerator SoulFloat(GameObject obj)
    {
        	//Get the positions
		Vector3 startingPos = this.transform.position;
		Vector3 endPos = obj.transform.position;

		//Get the timers
		float duration = 1;
		float elapsedTime = 0f;

		//Get the sizes


		while (elapsedTime < duration) {
			transform.position = Vector3.Lerp (startingPos, endPos, (elapsedTime / duration));
			elapsedTime += Time.deltaTime;
            endPos = obj.transform.position;
			yield return new WaitForEndOfFrame ();
		}
        SoulScore.Instance.SoulAmount++;
        Destroy(this.gameObject);
    }
}
