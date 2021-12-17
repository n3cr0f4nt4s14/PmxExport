﻿using UnityEngine;
using BepInEx;

namespace PmxExport {
	[BepInPlugin(GUID, NAME, VERSION)]
	public class PmxExporter : BaseUnityPlugin {
		/**
		 * <summary>
		 * The pulugin's globally unique id.<br></br>
		 * It will continue to be listed under the original GUID.
		 * </summary>
		 */
		public const string GUID = "com.bepis.bepinex.pmxexporter";
		/** <summary>The plugin's name.</summary> */
		public const string NAME = "PmxExporter";
		/** <summary>The pluginn's version.</summary> */
		public const string VERSION = "1.2.1";

		/**
		 * <summary>
		 * The PmxBuilder.<br></br>
		 * Responsible for building (constructing and saving) the PMX-file.
		 * </summary>
		 */
		private PmxBuilder builder;
		/** <summary>The PmxExportWindow.</summary> */
		private PmxExporterWindow window;

		public void OnGUI() {
			if(window == null) {
				window = new PmxExporterWindow();
			}

			window.DrawWindow();
		}

		public void Update() {
			if(Input.GetKeyDown(PmxExporterWindow.KEY)) {
				window.Show();
			}
		}
	}
}
