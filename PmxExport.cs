using UnityEngine;
using BepInEx;

[BepInPlugin(GUID, NAME, VERSION)]
public class PmxExport : BaseUnityPlugin {
	/** <summary>The pulugin's globally unique id.</summary> */
	public const string GUID = "com.n3cr0f4nt4s14.pmxexport";
	/** <summary>The plugin's name.</summary> */
	public const string NAME = "PmxExport";
	/** <summary>The pluginn's version.</summary> */
	public const string VERSION = "0.0.1";

	private static PmxExport instance;
	private PmxBuilder builder;
	private PmxExportWindow window;

	public PmxExport() {
		builder = new PmxBuilder();
		instance = this;
	}

	/**
	 * <summary>Returns the PmxExport instance.</summary>
	 * <returns>The PmxExport instance</returns>
	 */
	public static PmxExport GetInstance() {
		return instance;
	}

	/**
	 * <summary>Returns the PmxBuilder.</summary>
	 * <returns>The PmxBuilder</returns>
	 */
	public PmxBuilder GetPmxBuilder() {
		return builder;
	}

	/**
	 * <summary>Returns the PmxExportWindow.</summary>
	 * <returns>The PmxExportWindow</returns>
	 */
	public PmxExportWindow GetPmxExportWindow() {
		return window;
	}

	public void OnGUI() {
		if(window == null) {
			window = new PmxExportWindow();
		}

		window.DrawWindow();
	}

	public void Update() {
		if(Input.GetKeyDown(PmxExportWindow.KEY)) {
			window.Show();
		}
	}
}
