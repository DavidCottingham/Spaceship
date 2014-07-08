using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

	public GameObject startObj;
	public GameObject otherObj;
	
	private Vector3 startPosi;
	private Vector3 otherPos;
	private TextMesh startText;
	private TextMesh otherText;
	
	private bool onStartObject = false;
	
	private string[] textStrings;

	// Use this for initialization
	void Start () {		
		textStrings = new string[] {
					"<size=125>Made by:</size><size=100>\nDavid Cottingham</size>",
					"<size=80>It was made in one month for the\nJuly 2013 One Game A Month</size>",
					"<size=80>It was my first time using Unity3d\nso I had a lot of learning to do</size>",
					"<size=80>But I've learned a lot, so\nnext month will be even better</size>",
					"<size=100>3d ship model:</size><size=80>\nwww.psionic3d.co.uk/</size>",
					"<size=100>Engine Sound:</size><size=80>\nPhreaKsAccount\nwww.freesound.org/people/PhreaKsAccount/sounds/46504/</size>",
					"<size=100>Music:</size><size=80>\nThe Way Out  -  Kevin MacLeod</size><size=60>\nincompetech.com/music/royalty-free/index.html?isrc=USUAN1100045</size>",					
		};
		
		startPosi = startObj.transform.position;
		otherPos = otherObj.transform.position;
		
		startText = startObj.GetComponent<TextMesh>();
		otherText = otherObj.GetComponent<TextMesh>();
		
		StartCoroutine(TextChange());
	}
	
	void Update() {
	}
	
	IEnumerator TextChange() {
		for (int i = 0; i < textStrings.Length; ++i) {
			nextText().text = textStrings[i];
			yield return StartCoroutine(RotateCamera());
			yield return new WaitForSeconds(4.0f);
			onStartObject = !onStartObject;
		}
		Application.LoadLevel("MainScene");
	}
	
	IEnumerator RotateCamera() {
		//I don't understand why I need to subtract transform.position from all the nextPos's but it works. yay?
		//while statement is complicated way of testing to see whether the difference in magnitudes of where the rotation "should" be and where it currently is, is within a margin of error (0.2). Hopefully rounding errors don't throw this off too much
		while((Quaternion.LookRotation(nextPos()-transform.position).eulerAngles - transform.rotation.eulerAngles).sqrMagnitude > 0.2f) {
			Vector3 newDir = Vector3.RotateTowards(transform.forward, nextPos()-transform.position, 0.75f * Time.deltaTime, 0.0f);
			transform.rotation = Quaternion.LookRotation(newDir);
			yield return null;
		}
	}
	
	private Vector3 nextPos() {
		return onStartObject ? otherPos : startPosi;
	}
	
	private TextMesh nextText() {
		return onStartObject ? otherText : startText;
	}
}