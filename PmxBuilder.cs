using System.IO;
using PmxLib;

/**
* <summary>
* The PmxBuilder.<br></br>
* Responsible for building (constructing and saving) the PMX-file.
* </summary>
*/
public class PmxBuilder {
	/** <summary>The default file path, where the PMX-file will be saved.</summary> */
	public const string DEFAULT_SAVE_PATH = "C:\\koikatsu_models\\";
	/** <summary>The current file path, where the PMX-file will be saved.</summary> */
	private string savePath;
	/** <summary>The name of the model.</summary> */
	private string modelName;
	Pmx pmxFile;

	public PmxBuilder() {
		this.savePath = DEFAULT_SAVE_PATH;
		this.modelName = "New model";
		this.pmxFile = new Pmx();
	}

	/**
	 * <summary>Returns the current save path.</summary>
	 */
	public string GetSavePath() {
		return savePath;
	}

	/**
	 * <summary>Sets the current save path.</summary>
	 * <param name="savePath">The new save path</param>
	 */
	public void SetSavePath(string savePath) {
		this.savePath = savePath;
	}

	/**
	 * <summary>Returns the model name.</summary>
	 */
	public string GetModelName() {
		return modelName;
	}

	/**
	 * <summary>Sets the model name.</summary>
	 * <param name="modelName">The new model name</param>
	 */
	public void SetModelName(string modelName) {
		this.modelName = modelName;
	}

	/**
	* <summary>
	* Builds the PMX-file.<br></br>
	* TODO: specify result message.
	* </summary>
	* <returns>The result message.</returns>
	*/
	public string BuildStart() {
		string msg = CreateDirectories("TODO");

		return msg;
	}

	/**
	* <summary>
	* Creates all needed directories for the PMX-file.
	* </summary>
	*/
	private string CreateDirectories(string path) {
		string msg = "\n";

		try {
			Directory.CreateDirectory(path);
			//TODO:
		}
		catch(IOException e) {
			msg = e.ToString() + msg;
		}

		return msg;
	}
}
