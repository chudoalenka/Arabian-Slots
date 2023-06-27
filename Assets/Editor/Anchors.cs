using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

public class Anchors : EditorWindow
{
	[MenuItem ("Anchors/Set Anchors to Corners for Selected GameObject %&z")]
	static void AnchorsToCorners_per_object ()
	{
		if (Selection.activeGameObject.GetComponent<RectTransform> () == null)
			return;
		RectTransform t = Selection.activeTransform as RectTransform;
		RectTransform pt = Selection.activeTransform.parent as RectTransform;

		if (t == null || pt == null)
			return;

		Vector2 newAnchorsMin = new Vector2 (t.anchorMin.x + t.offsetMin.x / pt.rect.width,
			                        t.anchorMin.y + t.offsetMin.y / pt.rect.height);
		Vector2 newAnchorsMax = new Vector2 (t.anchorMax.x + t.offsetMax.x / pt.rect.width,
			                        t.anchorMax.y + t.offsetMax.y / pt.rect.height);

		t.anchorMin = newAnchorsMin;
		t.anchorMax = newAnchorsMax;
		t.offsetMin = t.offsetMax = new Vector2 (0, 0);
	}

	[MenuItem ("Anchors/Set Anchors to Corners for Selected GameObjects %&x")]
	static void AnchorsToCorners_per_multiple_selected_Objects ()
	{
		if (Selection.activeGameObject.GetComponent<RectTransform> () == null)
			return;
		GameObject[] temp = Selection.gameObjects;
		RectTransform[] t = new RectTransform[temp.Length];
		for (int i = 0; i < temp.Length; i++) {
			t [i] = temp [i].GetComponent<RectTransform> ();
		}

		if (t == null)
			return;

		for (int i = 0; i < t.Length; i++) {
			Vector2 newAnchorsMin = new Vector2 (t [i].anchorMin.x + t [i].offsetMin.x / t [i].parent.GetComponent<RectTransform> ().rect.width,
				                        t [i].anchorMin.y + t [i].offsetMin.y / t [i].parent.GetComponent<RectTransform> ().rect.height);
			Vector2 newAnchorsMax = new Vector2 (t [i].anchorMax.x + t [i].offsetMax.x / t [i].parent.GetComponent<RectTransform> ().rect.width,
				                        t [i].anchorMax.y + t [i].offsetMax.y / t [i].parent.GetComponent<RectTransform> ().rect.height);

			t [i].anchorMin = newAnchorsMin;
			t [i].anchorMax = newAnchorsMax;
			t [i].offsetMin = t [i].offsetMax = new Vector2 (0, 0);
		}
	}

}
