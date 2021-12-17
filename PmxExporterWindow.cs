using UnityEngine;

namespace PmxExport {
	class PmxExporterWindow {
		private readonly Color WHITE = new Color(1f, 1f, 1f, 1f);
		private readonly Color GREY = new Color(0.5f, 0.5f, 0.5f, 1f);

		private const string TITLE = PmxExporter.NAME + " " + PmxExporter.VERSION;
		private const string BUTTON_SAVE_TEXT = "Save";
		private const string BUTTON_CANCLE_TEXT = "Cancle";
		private const int SIZE_WINDOW = 500;
		private const int MARGIN_PX = 18;
		/** <summary>The key that opens the export window.</summary> */
		public const KeyCode KEY = KeyCode.F8;

		/** <summary>Onscreen rectangle denoting the window's position and size.</summary> */
		private Rect window;
		/** <summary>The rectangle denoting the save button's position and size.</summary> */
		private Rect buttonSave;
		/** <summary>The rectangle denoting the cancle button's position and size.</summary> */
		private Rect buttonCancle;
		/** <summary>Indicates whether or no the export window should be shown.</summary> */
		private bool showExportWindow;

		public PmxExporterWindow() {
			window = new Rect(Screen.width / 2, Screen.height / 2, SIZE_WINDOW, SIZE_WINDOW);
			//buttonSave = new Rect(...);
			buttonCancle = new Rect(MARGIN_PX, SIZE_WINDOW - MARGIN_PX, SIZE_WINDOW - 2*MARGIN_PX,MARGIN_PX);
			showExportWindow = false;
		}

		public void Show() {
			showExportWindow = true;
		}

		public void DrawWindow() {
			if(showExportWindow) {
				GUI.ModalWindow(0, window, DoExporterWindow, TITLE);
			}
		}

		/**
		 * <summary>
		 * Script function to display the window's contents.
		 * </summary>
		 * <param name="windowId">ID number of the window (can be any value as long as it is unique)</param>
		 */
		private void DoExporterWindow(int windowId) {
			//https://docs.unity3d.com/ScriptReference/GUI.Window.html
			//https://github.com/suiginsoft/COM3D2.ModelExportMMD/blob/master/COM3D2.ModelExportMMD.Gui/ModelExportWindow.cs
			//https://github.com/suiginsoft/COM3D2.ModelExportMMD/blob/master/COM3D2.ModelExportMMD.Plugin/ModelExportPlugin.cs

			/*if(GUI.Button(buttonSave, BUTTON_SAVE_TEXT)) {

			}
			else */if(GUI.Button(buttonCancle, BUTTON_CANCLE_TEXT)) {
				showExportWindow = false;
			}
		}
	}
}
