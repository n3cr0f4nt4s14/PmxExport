using UnityEngine;
using BepInEx;

[BepInPlugin(GUID, NAME, VERSION)]
[BepInDependency(KKAPI.KoikatuAPI.GUID, KKAPI.KoikatuAPI.VersionConst)]
public class PmxExport : BaseUnityPlugin {
	/** <summary>The pulugin's globally unique id.</summary> */
	public const string GUID = "com.n3cr0f4nt4s14.pmxexport";
	/** <summary>The plugin's name.</summary> */
	public const string NAME = "PmxExport";
	/** <summary>The pluginn's version.</summary> */
	public const string VERSION = "0.0.1";

	private static PmxExport instance;
	private PmxBuilder pmxBuilder;
	private PmxExportWindow window;

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
		return pmxBuilder;
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

	/**
	 * <summary>
	 * Awake is called when the script instance is being loaded.
	 * <para>
	 * Awake is always called before any <see cref="Start">Start</see> Start functions. This allows you to order initialization of scripts.
	 * Awake is called even if the script is a disabled component of an active GameObject.<br></br>
	 * <b>Note:</b> Use Awake instead of the constructor for initialization, as the serialized state of the component is undefined at construction time.
	 * Awake is called once, just like the constructor.
	 * </para>
	 * For more see <see href="https://docs.unity3d.com/ScriptReference/MonoBehaviour.Awake.html">MonoBehaviour.Awake()</see>.
	 * </summary>
	 */
	void Awake() {
		if(KKAPI.Maker.MakerAPI.InsideMaker) {
			//Only initialize the plugin if we are inside the maker (character editor).
			PmxExport.instance = this;
			this.pmxBuilder = new PmxBuilder();
		}
	}

	/**
	 * <summary>
	 * Start is called on the frame when a script is enabled just before any of the Update methods are called the first time.
	 * <para>
	 * Like the <see cref="Awake">Awake</see> function, Start is called exactly once in the lifetime of the script. However, Awake is called when
	 * the script object is initialised, regardless of whether or not the script is enabled. Start may not be called on the same frame as Awake if
	 * the script is not enabled at initialisation time.
	 * </para>
	 * For more see <see href="https://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html">MonoBehaviour.Start()</see>.
	 * </summary>
	 */
	void Start() {

	}
}
