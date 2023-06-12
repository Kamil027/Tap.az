public static class FileManager
{
	public static string SaveFile(string webroot, string folder, IFormFile imageFile)
	{
		string name = imageFile.FileName;

		if (name.Length > 64)
		{
			name = name.Substring(name.Length - 64, 64);
		}

		name = Guid.NewGuid().ToString() + name;

		string path = Path.Combine(webroot, folder, name);

		using (FileStream fs = new FileStream(path, FileMode.Create))
		{
			imageFile.CopyTo(fs);
		}

		return name;
	}

	public static void Delete(string webroot, string folder, string imageUrl)
	{
		string DeletePath = Path.Combine(webroot, folder, imageUrl);
		if (System.IO.File.Exists(DeletePath))
		{
			System.IO.File.Delete(DeletePath);
		}
	}


}

