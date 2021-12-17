﻿using UnityEngine;

/**
 * <summary>
 * The PmxExportWindow.
 * </summary>
 */
class PmxExportWindow {
	private readonly Color WHITE = new Color(1f, 1f, 1f, 1f);
	private readonly Color GREY = new Color(0.5f, 0.5f, 0.5f, 1f);

	private const string TITLE = PmxExport.NAME + " " + PmxExport.VERSION;
	private const string TEXT_LABEL_SAVE_PATH = "Save path";
	private const string TEXT_BUTTON_SAVE = "Save";
	private const string TEXT_BUTTON_CANCLE = "Cancle";

	private const int SIZE_WINDOW = 500;
	private const int MARGIN = 20;
	/** <summary>The key that opens the export window.</summary> */
	public const KeyCode KEY = KeyCode.F8;

	/** <summary>Onscreen rectangle denoting the window's position and size.</summary> */
	private Rect window;
	/** <summary>The rectangle denoting the save path label's position and size.</summary> */
	private Rect labelSavePath;

	/** <summary>The rectangle denoting the save path textfield's position and size.</summary> */
	private Rect textFieldSavePath;

	/** <summary>The rectangle denoting the save button's position and size.</summary> */
	private Rect buttonSave;
	/** <summary>The rectangle denoting the cancle button's position and size.</summary> */
	private Rect buttonCancle;

	/** <summary>Indicates whether or no the export window should be shown.</summary> */
	private bool showExportWindow;
	private string savePath;

	public PmxExportWindow() {
		const int sizeHalf = SIZE_WINDOW / 2;
		window = new Rect(Screen.width / 2 - sizeHalf, Screen.height / 2 - sizeHalf, SIZE_WINDOW, SIZE_WINDOW);

		//Folder, Browse, Name, Format, Save texture, Save position, Apply T-pose, Save, Close
		labelSavePath = new Rect(MARGIN, 2 * MARGIN, SIZE_WINDOW * 0.2f - MARGIN, MARGIN);
		textFieldSavePath = new Rect(labelSavePath.x + labelSavePath.width, labelSavePath.y, SIZE_WINDOW * 0.6f - MARGIN, MARGIN);

		//Cancle and save button layout is calculated from the bottom of the window.
		const int buttonWidth = SIZE_WINDOW - 2 * MARGIN;
		buttonCancle = new Rect(MARGIN, buttonWidth, buttonWidth, MARGIN);
		buttonSave = new Rect(MARGIN, buttonCancle.y - 2 * MARGIN, buttonWidth, MARGIN);

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

		GUI.Label(labelSavePath, TEXT_LABEL_SAVE_PATH);
		savePath = GUI.TextField(textFieldSavePath, savePath);

		if(GUI.Button(buttonSave, TEXT_BUTTON_SAVE)) {

		}
		else if(GUI.Button(buttonCancle, TEXT_BUTTON_CANCLE)) {
			showExportWindow = false;
		}
	}
}
