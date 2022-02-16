using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class TestImage : MonoBehaviour
{
    public RawImage image;
    private IEnumerator<Texture2D> textures;

    private void Start() => updateEnumerator();

    public void Next()
    {
        if (textures.MoveNext())
        {
            image.texture = textures.Current;
        }
        else
        {
            updateEnumerator();
            Next();
        }
    }

    private void updateEnumerator()
        => textures = GetFilesToPath().Where(IsImage).Select(fi => GetTexture(fi)).Where(x=> x != null).GetEnumerator();

    private IEnumerable<FileInfo> GetFilesToPath() 
        => new DirectoryInfo(Application.streamingAssetsPath).EnumerateFiles();
    private bool IsImage(FileInfo fi)
        => fi.Extension == ".jpg" || fi.Extension == ".png";

    private Texture2D GetTexture(FileInfo fi)
    {
        Texture2D result = new Texture2D(2, 2);
        return ImageConversion.LoadImage(result, File.ReadAllBytes(fi.FullName)) ? result : null;
    }


}