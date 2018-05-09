using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BigfootDS;

namespace BigfootDS {
	public class BigfootGeneralLocationFinder : MonoBehaviour {

		/// <summary>
		/// The raw data retrieved by the reverse-geocoding query.
		/// </summary>
		[Tooltip("The raw data retrieved by the reverse-geocoding query.")]
		public string rawRGOutput = "";

		/// <summary>
		/// True/false flag for the status of the reverse-geocoding query.
		/// </summary>
		[Tooltip("True/false flag for the status of the reverse-geocoding query.")]
		public bool successfulRG = false;

		/// <summary>
		/// The user's country based on their internet connection location. May be fooled by VPN setups.
		/// </summary>
		[Tooltip("The user's country based on their internet connection location. May be fooled by VPN setups.")]
		public string userCountry;

		/// <summary>
		/// The user's country code as per ISO 3166.
		/// </summary>
		[Tooltip("The user's country code as per ISO 3166.")]
		public string userCountryCode;

		/// <summary>
		/// The code for the user's region or state.
		/// </summary>
		[Tooltip("The code for the user's region or state.")]
		public string userRegionCode;

		/// <summary>
		/// The name of the user's region or state.
		/// </summary>
		[Tooltip("The name of the user's region or state.")]
		public string userRegionName;

		/// <summary>
		/// The name of the user's city or town.
		/// </summary>
		[Tooltip("The name of the user's city or town.")]
		public string userCity;

		/// <summary>
		/// The ZIP or postal code of the user's town or city.
		/// </summary>
		[Tooltip("The ZIP or postal code of the user's town or city.")]
		public string userZipCode;

		/// <summary>
		/// The user's latitude values. Due to the nature of IP-based requests, this will be very poor compared to a GPS coordinate.
		/// </summary>
		[Tooltip("The user's latitude values. Due to the nature of IP-based requests, this will be very poor compared to a GPS coordinate.")]
		public string userLatitude;

		/// <summary>
		/// The user's longitude values. Due to the nature of IP-based requests, this will be very poor compared to a GPS coordinate.
		/// </summary>
		[Tooltip("The user's longitude values. Due to the nature of IP-based requests, this will be very poor compared to a GPS coordinate.")]
		public string userLongitude;

		/// <summary>
		/// The timezone for the user based on their location (not the built-in device timezone).
		/// </summary>
		[Tooltip("The timezone for the user based on their location (not the built-in device timezone).")]
		public string userTimeZone;

		/// <summary>
		/// The user's internet provider.
		/// </summary>
		[Tooltip("The user's internet provider.")]
		public string userISPName;

		/// <summary>
		/// The user's internet organization (usually the same as the ISP).
		/// </summary>
		[Tooltip("The user's internet organization (usually the same as the ISP).")]
		public string userOrganizationName;

		/// <summary>
		/// The user's internet autonomous system number and name.
		/// </summary>
		[Tooltip("The user's internet autonomous system number & name.")]
		public string userAutonomousSystemCode;

		/// <summary>
		/// The IP address used for the reverse-geocoding query.
		/// </summary>
		[Tooltip("The IP address used for the reverse-geocoding query.")]
		public string userIPAddress;

		/// <summary>
		/// Alternative way to trigger the reverse-geocoding data-fetching coroutine -- incredibly important for UI & button-based access.
		/// </summary>
		public void StartRGRetrieval () {
			StartCoroutine (GetRawRGData ());
		}

		/// <summary>
		/// Retrieves the raw reverse-geocoding data about the player, based on their IP address. Requires internet access.
		/// </summary>
		public IEnumerator GetRawRGData () {
			WWW revGeoData = new WWW ("http://www.ip-api.com/csv");
			while (!revGeoData.isDone) {
				yield return null;
			}
			rawRGOutput = revGeoData.text.ToString ();
			Debug.Log ("Successfully retrieved reverse-geocoding data about the user based on their IP address & internet connection. Data will be processed next. Raw data is as follows: " 
				+ System.Environment.NewLine 
				+ rawRGOutput);
			string stringToDisplay = rawRGOutput;
			stringToDisplay = stringToDisplay.Replace (",", "\n");
			Text textOnThisObject = GetComponent<Text> ();
			if (textOnThisObject != null) {
				textOnThisObject.text = stringToDisplay;
			}
			ProcessRGData ();
		}

		/// <summary>
		/// Processes the data retrieved by the reverse-geocoding query and stores it as variables. Does not persist between sessions, so the query & processing must be run at least once per session.
		/// 
		/// Automatically sanitizes outputs (eg. removing quotation marks) so any & all information can be instantly used by other scripts & functions.
		/// </summary>
		public void ProcessRGData () {
			if (rawRGOutput == "") {
				return;
			}

			string[] RGOutputSplit = rawRGOutput.Split (new string[] { "," }, System.StringSplitOptions.None);
			if (RGOutputSplit[0] == "success"){ 
				successfulRG = true;
			};
			userCountry = RGOutputSplit [1];
			userCountryCode = RGOutputSplit [2];
			userRegionCode = RGOutputSplit [3];
			userRegionName = RGOutputSplit [4];
			userCity = RGOutputSplit [5];
			userZipCode = RGOutputSplit [6];
			userLatitude = RGOutputSplit [7];
			userLongitude = RGOutputSplit [8];
			userTimeZone = RGOutputSplit [9];
			userISPName = RGOutputSplit [10];
			userOrganizationName = RGOutputSplit [11];
			userAutonomousSystemCode = RGOutputSplit [12];
			userIPAddress = RGOutputSplit [13];

		}


	}
}


//BigfootGeneralLocationFinder