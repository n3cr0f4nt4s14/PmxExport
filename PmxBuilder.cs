using System;
using System.IO;
using PmxLib;

/**
* <summary>
* The PmxBuilder.<br></br>
* Responsible for building (constructing and saving) the pmx-file.
* </summary>
*/
public class PmxBuilder {
	/** <summary>The default file path, where the pmx-file will be saved.</summary> */
	public const string DEFAULT_SAVE_PATH = "C:\\koikatsu_models\\";
	/** <summary>The default file name, under wich the pmx-file will be saved.</summary> */
	public const string DEFAULT_FILE_NAME = "New model";
	/** <summary>The pmx-file file ending.</summary> */
	public const string PMX_FILE_ENDING = ".pmx";
	/** <summary>The success message, that is returned if the model could be exported without issues.</summary> */
	public const string MSG_SUCCESS = "\n";

	/** <summary>The current file path, where the pmx-file will be saved.</summary> */
	private string savePath;
	/** <summary>The name of the pmx-file.</summary> */
	private string fileName;
	/** <summary>The name of the model.</summary> */
	private string modelName;
	Pmx pmxFile;

	public PmxBuilder() {
		this.savePath = DEFAULT_SAVE_PATH;
		this.fileName = DEFAULT_FILE_NAME;
		this.modelName = "";
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
	 * <summary>Returns the file name.</summary>
	 */
	public string GetFileName() {
		return fileName;
	}

	/**
	 * <summary>Sets the file name.</summary>
	 * <param name="fileName">The new file name</param>
	 */
	public void SetFileName(string fileName) {
		this.fileName = fileName;
	}

	/**
	* <summary>
	* Builds the PMX-file.<br></br>
	* TODO: specify result message.
	* </summary>
	* <returns>The result message.</returns>
	*/
	public string BuildStart() {
		string msg = CreateDirectories();
		if(msg.Equals(MSG_SUCCESS)) {
			//Only export the model if the directories could be created successfully.
			CreatePmxModelInfo();
			CreatePmxHeader();
			Save();
		}

		return msg;
	}

	/**
	* <summary>
	* Creates all needed directories for the PMX-file.
	* </summary>
	*/
	private string CreateDirectories() {
		string msg = MSG_SUCCESS;

		try {
			string path = GetSavePath() + GetFileName() + "\\";
			Directory.CreateDirectory(path);
			Directory.CreateDirectory(path + "tex\\");
			Directory.CreateDirectory(path + "sph\\");
			Directory.CreateDirectory(path + "toon\\");
		}
		catch(IOException e) {
			msg = e.ToString() + msg;
		}

		return msg;
	}

	/**
	 * <summary>
	 * Creates the PmxHeader.<br></br>
	 * Should only be called after the models data has been fetched/prepared.
	 * </summary>
	 */
	private void CreatePmxHeader() {
		PmxElementFormat pmxElementFormat = new PmxElementFormat(2.1f);
		pmxElementFormat.VertexSize = PmxElementFormat.GetUnsignedBufSize(pmxFile.VertexList.Count);

		int max = int.MinValue;
		for(int i = 0; i < pmxFile.BoneList.Count; i++) {
			max = Math.Max(max, Math.Abs(pmxFile.BoneList[i].IK.LinkList.Count));
		}
		max = Math.Max(max, pmxFile.BoneList.Count);

		pmxElementFormat.BoneSize = PmxElementFormat.GetSignedBufSize(max);
		if(pmxElementFormat.BoneSize < 2) pmxElementFormat.BoneSize = 2;
		pmxElementFormat.MorphSize = PmxElementFormat.GetUnsignedBufSize(pmxFile.MorphList.Count);
		pmxElementFormat.MaterialSize = PmxElementFormat.GetUnsignedBufSize(pmxFile.MaterialList.Count);
		pmxElementFormat.BodySize = PmxElementFormat.GetUnsignedBufSize(pmxFile.BodyList.Count);

		PmxHeader pmxHeader = new PmxHeader(2.1f);
		pmxFile.Header.FromElementFormat(pmxElementFormat);
	}

	/**
	 * <summary>
	 * Creates the PmxModelInfo.<br></br><br></br>
	 * Uses the current model name as specified by <see cref="GetModelName"/>.
	 * </summary>
	 */
	private void CreatePmxModelInfo() {
		//TODO: Add ability to specify the comment.
		PmxModelInfo pmxModelInfo = new PmxModelInfo();
		pmxModelInfo.ModelName = GetModelName();
		pmxModelInfo.ModelNameE = GetModelName();
		pmxModelInfo.Comment = "";
		pmxModelInfo.CommentE = "";
		pmxFile.ModelInfo.FromModelInfo(pmxModelInfo);
	}

	/**
	 * <summary>
	 * Saves the pmx-file.
	 * </summary>
	 */
	private void Save() {
		pmxFile.ToFile(GetSavePath() + GetFileName() + "\\" + GetFileName() + PMX_FILE_ENDING);
	}
}
