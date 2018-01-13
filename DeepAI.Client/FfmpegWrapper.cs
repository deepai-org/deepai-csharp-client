using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Reflection;


//            FfmpegWrapper.extractEmbeddedResourcesIfNeeded();


class FfmpegWrapper
{
    public static Boolean extracted = false;
    public static Dictionary<String, String> progNameToFilePath = new Dictionary<String,String>();

    public static String extractEmbeddedResource(String intname, String outname)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        String[] res = assembly.GetManifestResourceNames();
        Stream stream = assembly.GetManifestResourceStream(intname);
        string fileName = System.IO.Path.GetTempPath() + outname;
        using (FileStream fsDst = new FileStream(fileName, FileMode.Create, FileAccess.Write))
        {
            stream.CopyTo(fsDst);
            fsDst.Close();
            fsDst.Dispose();
        }
        return fileName;
    }

    public static void extractEmbeddedResourcesIfNeeded()
    {
        if (extracted)
        {
            return;
        }
        progNameToFilePath["ffplay"]=extractEmbeddedResource("DeepAI.Resources.ffplay.exe", "deepaiclient-ffplay.exe");
        progNameToFilePath["ffmpeg"]=extractEmbeddedResource("DeepAI.Resources.ffmpeg.exe", "deepaiclient-ffmpeg.exe");
        extracted = true;
    }

}

