using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BigfootDS;

namespace BigfootDS {
	public enum ColourType {Default, Matte, Metallic};
	[ExecuteInEditMode]
	public class ColourChangerTester : MonoBehaviour {

		public ColourType thisColourType;
		public int currentColourIndex = 0;
		Renderer thisRenderer;
		public string currentMaterialName;
		public Text materialNameDisplayer;

		void Awake () {
			thisRenderer = GetComponent<Renderer> ();
		}

		void Update () {
			ColourAssigner ();
			currentMaterialName = thisRenderer.sharedMaterial.name;
			if (materialNameDisplayer != null) {
				materialNameDisplayer.text = currentMaterialName;
			}
		}

		/// <summary>
		/// Selects a random colour from the appropriate SingletonScriptableObject that contains references to web-friendly colours.
		/// </summary>
		[ContextMenu("Select Random Colour From List")]
		public void SelectRandomColour () {
			switch (thisColourType) {
			case ColourType.Default:
				currentColourIndex = Random.Range (0, BigfootWebColoursDefault.data.materialsDefault.Count);
				thisRenderer.material = BigfootWebColoursDefault.data.materialsDefault [currentColourIndex];
				break;
			case ColourType.Matte:
				currentColourIndex = Random.Range (0, BigfootWebColoursMatte.data.materialsMatte.Count);
				thisRenderer.material = BigfootWebColoursMatte.data.materialsMatte [currentColourIndex];
				break;
			case ColourType.Metallic:
				currentColourIndex = Random.Range (0, BigfootWebColoursMetallic.data.materialsMetallic.Count);
				thisRenderer.material = BigfootWebColoursMetallic.data.materialsMetallic [currentColourIndex];
				break;
			default:
				Debug.Log ("Colour Tester couldn't find colour library properly.");
				break;
			}

		}

		/// <summary>
		/// Clamps the currentColourIndex value to fit within an appropritate material list and then assigns that material to the object containing this script.
		/// </summary>
		public void ColourAssigner () {
			switch (thisColourType) {
			case ColourType.Default:
				if (currentColourIndex < 0) {
					currentColourIndex = BigfootWebColoursDefault.data.materialsDefault.Count; // Seamlessly looping list
					// currentColourIndex = 0; // Clamps the list to remain inside specific values
				} else if (currentColourIndex > BigfootWebColoursDefault.data.materialsDefault.Count) {
					currentColourIndex = 0; // Seamlessly looping list
					// currentColourIndex = BigfootWebColoursDefault.data.materialsDefault.Count; // Clamps the list to remain inside specific values
				}
				thisRenderer.material = BigfootWebColoursDefault.data.materialsDefault [currentColourIndex];
				break;
			case ColourType.Matte:
				if (currentColourIndex < 0) {
					currentColourIndex = BigfootWebColoursMatte.data.materialsMatte.Count; // Seamlessly looping list
					// currentColourIndex = 0; // Clamps the list to remain inside specific values
				} else if (currentColourIndex > BigfootWebColoursMatte.data.materialsMatte.Count) {
					currentColourIndex = 0; // Seamlessly looping list
					// currentColourIndex = BigfootWebColoursDefault.data.materialsDefault.Count; // Clamps the list to remain inside specific values
				}
				thisRenderer.material = BigfootWebColoursMatte.data.materialsMatte [currentColourIndex];
				break;
			case ColourType.Metallic:
				if (currentColourIndex < 0) {
					currentColourIndex = BigfootWebColoursMetallic.data.materialsMetallic.Count; // Seamlessly looping list
					// currentColourIndex = 0; // Clamps the list to remain inside specific values
				} else if (currentColourIndex > BigfootWebColoursMetallic.data.materialsMetallic.Count) {
					currentColourIndex = 0; // Seamlessly looping list
					// currentColourIndex = BigfootWebColoursDefault.data.materialsDefault.Count; // Clamps the list to remain inside specific values
				}
				thisRenderer.material = BigfootWebColoursMetallic.data.materialsMetallic [currentColourIndex];
				break;
			default:
				Debug.Log ("Colour Tester couldn't find colour library properly.");
				break;
			}
		}

		/// <summary>
		/// Changes the colour index value and immediately calls the ColourAssigner function to change the colour of this object.
		/// </summary>
		[ContextMenu("Select Previous Colour From List")]
		public void SelectPreviousColour () {
			currentColourIndex--;
			ColourAssigner ();
		}

		/// <summary>
		/// Changes the colour index value and immediately calls the ColourAssigner function to change the colour of this object.
		/// </summary>
		[ContextMenu("Select Next Colour From List")]
		public void SelectNextColour () {
			currentColourIndex++;
			ColourAssigner ();
		}


	}
}