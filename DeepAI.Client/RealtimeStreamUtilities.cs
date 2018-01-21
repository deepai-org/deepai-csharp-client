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
using AForge.Video.DirectShow;
using System.Diagnostics;

namespace DeepAI
{
    /// <summary>
    /// A collection of helper functions for use with real time streams, such as sending webcam input to a stream, or playing the output of a stream.
    /// </summary>
    public class RealtimeStreamUtilities
    {
        private static Boolean extracted = false;
        private static Dictionary<String, String> progNameToFilePath = new Dictionary<String, String>();

        /// <summary>
        /// Construct a new instance - this is done automatically as this object will be available on all DeepAI_API objects.
        /// </summary>
        public RealtimeStreamUtilities()
        {

        }

        /// <summary>
        /// Represents the framerate and frame size of a video stream.
        /// </summary>
        public class VideoStreamFormat
        {
            public readonly int FrameRate;
            public readonly System.Drawing.Size FrameSize;
            public VideoStreamFormat(int frameRate, System.Drawing.Size frameSize)
            {
                FrameRate = frameRate;
                FrameSize = frameSize;
            }
        }

        private static String extractEmbeddedResource(String intname, String outname)
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

        private static void extractEmbeddedResourcesIfNeeded()
        {
            if (extracted)
            {
                return;
            }
            progNameToFilePath["ffplay"] = extractEmbeddedResource("DeepAI.Resources.ffplay.exe", "deepaiclient-ffplay.exe");
            progNameToFilePath["ffmpeg"] = extractEmbeddedResource("DeepAI.Resources.ffmpeg.exe", "deepaiclient-ffmpeg.exe");
            extracted = true;
        }

        private String[] getWebcamInputStreamCmdForSettings(String cameraName, int bitrateKbps, String output_url, String output_format, float fps, int width=-1, int height=-1)
        {
            // output_format = mpegts
            extractEmbeddedResourcesIfNeeded();

            string size_string = "";
            if (width > 0 && height > 0)
            {
                size_string = "-video_size "+width+"x"+height;
            }

            return new String[] { progNameToFilePath["ffmpeg"], " -f dshow " + size_string + " -framerate " + fps + " -i video=\"" + cameraName + "\" -b:v " + bitrateKbps + "k -f " + output_format + " " + output_url };
        }

        private String[] getPlayerCmdForSettings(String input_format, String input_url)
        {
            // input_format = mpegts
            extractEmbeddedResourcesIfNeeded();
            return new String[]{progNameToFilePath["ffplay"] , " -probesize 1000 -f mpegts " + input_url};
        }

        /// <summary>
        /// Get the program name and arguments to launch a process that will send webcam input to a realtime stream.
        /// </summary>
        /// <param name="stream">The stream to send input to.</param>
        /// <param name="cameraName"Name of the directShow device to capture.</param>
        /// <param name="bitrateKbps">Bitrate of the compressed video stream to send.</param>
        /// <returns>program name and arguments as array</returns>
        public String[] getWebcamInputStreamCmdForRealtimeStream(DeepAI.RealtimeStream stream, String cameraName, int bitrateKbps, int width = -1, int height = -1)
        {
            String output_format = "mpegts"; //make ths adjustable
            return getWebcamInputStreamCmdForSettings(cameraName, bitrateKbps, stream.input_url, output_format, stream.fps, width: width, height: height);
        }

        /// <summary>
        /// Get the program name and arguments to launch a process that will play the output of a realtime stream.
        /// </summary>
        /// <param name="stream">The realtime stream to play.</param>
        /// <returns>program name and arguments as array</returns>
        public String[] getPlayerCmdForRealtimeStream(DeepAI.RealtimeStream stream)
        {
            String input_format = "mpegts";
            return getPlayerCmdForSettings(input_format, stream.output_url);
        }

        /// <summary>
        /// Get a list of availabe video capture device names.
        /// </summary>
        /// <returns>List of string device names</returns>
        public String[] getVideoCaptureDevices()
        {
            FilterInfoCollection VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            var names = new List<String>();
            foreach (FilterInfo VideoCaptureDevice in VideoCaptureDevices)
            {
                names.Add(VideoCaptureDevice.Name);
            }
            return names.ToArray();
        }



        /// <summary>
        /// Get the frame rate and frame size combinations that the given input device supports.
        /// </summary>
        /// <param name="deviceName">The input device to get capabilities for.</param>
        /// <returns>Array of supported formats for the device.</returns>
        public VideoStreamFormat[] getVideoStreamFormatsForDeviceName(string deviceName)
        {
            var capabilities = new List<VideoStreamFormat>();
            FilterInfoCollection VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo VideoCaptureDevice in VideoCaptureDevices)
            {
                if (VideoCaptureDevice.Name.Equals(deviceName))
                {
                    VideoCaptureDevice videoDevice = new VideoCaptureDevice(VideoCaptureDevice.MonikerString);
                    foreach (VideoCapabilities videoCapabilities in videoDevice.VideoCapabilities)
                    {
                        capabilities.Add(new VideoStreamFormat(videoCapabilities.AverageFrameRate, videoCapabilities.FrameSize));
                    }
                    break;
                }
            }
            return capabilities.ToArray();
        }


        /// <summary>
        /// Launches a new process to play the output of a realtime stream in a window.
        /// </summary>
        /// <param name="stream">The stream to play back.</param>
        /// <param name="showWindow">Set to false to hide the command prompt. (Not recommended.)</param>
        /// <returns>Windows Process handle</returns>
        public Process launchPlayerForStream(DeepAI.RealtimeStream stream, Boolean showWindow=true)
        {
            String[] cmdAndArgs = getPlayerCmdForRealtimeStream(stream);
            var processInfo = new ProcessStartInfo
            {
                UseShellExecute = false,
                CreateNoWindow = (!showWindow),
                FileName = cmdAndArgs[0],
                Arguments = cmdAndArgs[1]
            };
            var process = Process.Start(processInfo);
            return process;
        }



        /// <summary>
        /// Launches a new process to play the output of a realtime stream in a window.
        /// </summary>
        /// <param name="stream">The stream to play back.</param>
        /// <param name="cameraName">Name of the directshow device to capture.</param>
        /// <param name="bitrateKbps">Bitrate of the stream to send.</param>
        /// <param name="showWindow">Set to false to hide the command prompt. (Not recommended.)</param>
        /// <param name="width">Width of the video to capture. (Not Set = Device Default)</param>
        /// <param name="width">Height of the video to capture. (Not Set = Device Default)</param>

        /// <returns>Windows Process handle</returns>
        public Process launchWebcamSenderForStream(DeepAI.RealtimeStream stream, String cameraName, int bitrateKbps, Boolean showWindow = true, int width=-1, int height=-1)
        {
            String[] cmdAndArgs = getWebcamInputStreamCmdForRealtimeStream(stream, cameraName, bitrateKbps, width:width, height:height);
            var processInfo = new ProcessStartInfo
            {
                UseShellExecute = false,
                CreateNoWindow = (!showWindow),
                FileName = cmdAndArgs[0],
                Arguments = cmdAndArgs[1]
            };
            var process = Process.Start(processInfo);
            return process;
        }

    }
}