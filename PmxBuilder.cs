﻿using System;
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
	/** <summary>The success message, that is returned if the model could be exported without issues.</summary> */
	public const string MSG_SUCCESS = "\n";
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
		string msg = CreateDirectories();
		if(msg.Equals(MSG_SUCCESS)) {
			//Only export the model if the directories could be created successfully.
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
			string path = savePath + modelName + "\\";
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
}
