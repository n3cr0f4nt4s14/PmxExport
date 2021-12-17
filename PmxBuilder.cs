using System.IO;
using PmxLib;

/**
* <summary>
* The PmxBuilder.<br></br>
* Responsible for building (constructing and saving) the PMX-file.
* </summary>
*/
internal class PmxBuilder {
	/** <summary>The default file path, where the PMX-file will be saved.</summary> */
	const string DEFAULT_SAVE_PATH = "C:\\koikatsu_models\\";
	Pmx pmxFile;

	public PmxBuilder() {
		this.pmxFile = new Pmx();
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
