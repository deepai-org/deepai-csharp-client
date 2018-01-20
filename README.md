# DeepAI CSharp Client
Simple CSharp Client Library for [Deep AI's](https://deepai.org) APIs

## Installation:

Get this package from NuGet: https://www.nuget.org/packages/DeepAI.Client/

Or clone and build this repository with Visual Studio 2013 or later.

# Reference
(generated from XMLDOC with [Vsxmd](https://github.com/lijunle/Vsxmd)):

<a name='contents'></a>
# Contents [#](#contents 'Go To Here')

- [DeepAI_API](#T-DeepAI-DeepAI_API 'DeepAI.DeepAI_API')
  - [#ctor(apiKey)](#M-DeepAI-DeepAI_API-#ctor-System-String- 'DeepAI.DeepAI_API.#ctor(System.String)')
  - [realtimeStreamUtilities](#F-DeepAI-DeepAI_API-realtimeStreamUtilities 'DeepAI.DeepAI_API.realtimeStreamUtilities')
  - [getRealtimeStream(id)](#M-DeepAI-DeepAI_API-getRealtimeStream-System-Int32- 'DeepAI.DeepAI_API.getRealtimeStream(System.Int32)')
  - [getRealtimeStreams()](#M-DeepAI-DeepAI_API-getRealtimeStreams 'DeepAI.DeepAI_API.getRealtimeStreams')
  - [objectAsJsonString(a)](#M-DeepAI-DeepAI_API-objectAsJsonString-System-Object- 'DeepAI.DeepAI_API.objectAsJsonString(System.Object)')
  - [startRealtimeStream(model,input_type,output_type,fps,width,height)](#M-DeepAI-DeepAI_API-startRealtimeStream-System-String,System-String,System-String,System-Single,System-Int32,System-Int32- 'DeepAI.DeepAI_API.startRealtimeStream(System.String,System.String,System.String,System.Single,System.Int32,System.Int32)')
  - [stopRealtimeStream(id)](#M-DeepAI-DeepAI_API-stopRealtimeStream-System-Int32- 'DeepAI.DeepAI_API.stopRealtimeStream(System.Int32)')
- [RealtimeStream](#T-DeepAI-RealtimeStream 'DeepAI.RealtimeStream')
  - [input_url](#P-DeepAI-RealtimeStream-input_url 'DeepAI.RealtimeStream.input_url')
  - [output_url](#P-DeepAI-RealtimeStream-output_url 'DeepAI.RealtimeStream.output_url')
  - [status](#P-DeepAI-RealtimeStream-status 'DeepAI.RealtimeStream.status')
- [RealtimeStreamUtilities](#T-DeepAI-RealtimeStreamUtilities 'DeepAI.RealtimeStreamUtilities')
  - [#ctor()](#M-DeepAI-RealtimeStreamUtilities-#ctor 'DeepAI.RealtimeStreamUtilities.#ctor')
  - [getPlayerCmdForRealtimeStream(stream)](#M-DeepAI-RealtimeStreamUtilities-getPlayerCmdForRealtimeStream-DeepAI-RealtimeStream- 'DeepAI.RealtimeStreamUtilities.getPlayerCmdForRealtimeStream(DeepAI.RealtimeStream)')
  - [getVideoCaptureDevices()](#M-DeepAI-RealtimeStreamUtilities-getVideoCaptureDevices 'DeepAI.RealtimeStreamUtilities.getVideoCaptureDevices')
  - [getVideoStreamFormatsForDeviceName(deviceName)](#M-DeepAI-RealtimeStreamUtilities-getVideoStreamFormatsForDeviceName-System-String- 'DeepAI.RealtimeStreamUtilities.getVideoStreamFormatsForDeviceName(System.String)')
  - [launchPlayerForStream(stream,showWindow)](#M-DeepAI-RealtimeStreamUtilities-launchPlayerForStream-DeepAI-RealtimeStream,System-Boolean- 'DeepAI.RealtimeStreamUtilities.launchPlayerForStream(DeepAI.RealtimeStream,System.Boolean)')
  - [launchWebcamSenderForStream(stream,cameraName,bitrateKbps,showWindow)](#M-DeepAI-RealtimeStreamUtilities-launchWebcamSenderForStream-DeepAI-RealtimeStream,System-String,System-Int32,System-Boolean- 'DeepAI.RealtimeStreamUtilities.launchWebcamSenderForStream(DeepAI.RealtimeStream,System.String,System.Int32,System.Boolean)')
- [Resources](#T-DeepAI-Properties-Resources 'DeepAI.Properties.Resources')
  - [Culture](#P-DeepAI-Properties-Resources-Culture 'DeepAI.Properties.Resources.Culture')
  - [ffmpeg](#P-DeepAI-Properties-Resources-ffmpeg 'DeepAI.Properties.Resources.ffmpeg')
  - [ffplay](#P-DeepAI-Properties-Resources-ffplay 'DeepAI.Properties.Resources.ffplay')
  - [ResourceManager](#P-DeepAI-Properties-Resources-ResourceManager 'DeepAI.Properties.Resources.ResourceManager')
- [VideoStreamFormat](#T-DeepAI-RealtimeStreamUtilities-VideoStreamFormat 'DeepAI.RealtimeStreamUtilities.VideoStreamFormat')

<a name='assembly'></a>
# DeepAI [#](#assembly 'Go To Here') [=](#contents 'Back To Contents')

<a name='T-DeepAI-DeepAI_API'></a>
## DeepAI_API [#](#T-DeepAI-DeepAI_API 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

DeepAI

##### Summary

Main API Client class - create an instance of the api by calling: DeepAI_API api = new DeepAI_API(apiKey: "...");

<a name='M-DeepAI-DeepAI_API-#ctor-System-String-'></a>
### #ctor(apiKey) `constructor` [#](#M-DeepAI-DeepAI_API-#ctor-System-String- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Call this to create a new DeepAI_API instance.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| apiKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Your DeepAI key as found in your DeepAI dashboard. |

<a name='F-DeepAI-DeepAI_API-realtimeStreamUtilities'></a>
### realtimeStreamUtilities `constants` [#](#F-DeepAI-DeepAI_API-realtimeStreamUtilities 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Object with helper utilities for sending input to and playing back a realtime stream.

<a name='M-DeepAI-DeepAI_API-getRealtimeStream-System-Int32-'></a>
### getRealtimeStream(id) `method` [#](#M-DeepAI-DeepAI_API-getRealtimeStream-System-Int32- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Get the info for a single realtime stream. Useful for continuously polling the status of a stream.

##### Returns

Stream Info object

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | ID of the stream to get |

<a name='M-DeepAI-DeepAI_API-getRealtimeStreams'></a>
### getRealtimeStreams() `method` [#](#M-DeepAI-DeepAI_API-getRealtimeStreams 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Get the full list of your active realtime streams, plus streams started or stopped in the last hour

##### Returns

List of stream info objects

##### Parameters

This method has no parameters.

<a name='M-DeepAI-DeepAI_API-objectAsJsonString-System-Object-'></a>
### objectAsJsonString(a) `method` [#](#M-DeepAI-DeepAI_API-objectAsJsonString-System-Object- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Simple helper method to pretty-print an object response of any API call for easier viewing.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| a | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |

<a name='M-DeepAI-DeepAI_API-startRealtimeStream-System-String,System-String,System-String,System-Single,System-Int32,System-Int32-'></a>
### startRealtimeStream(model,input_type,output_type,fps,width,height) `method` [#](#M-DeepAI-DeepAI_API-startRealtimeStream-System-String,System-String,System-String,System-Single,System-Int32,System-Int32- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Creates a new real-time stream. The status field will initially be "PENDING" which will transition to "RUNNING" within 5 minutes. If the provided stream does not match the width and height values passed, it will be rescaled.

##### Returns

RealtimeStream object containing URLs which may be used to connect to the stream by sending input and receiving output.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| model | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Name of the model to process the video with, such as "deepdream" or "fast-style-transfer" |
| input_type | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Stream descriptor of in the input video stream. Possible values are "tcp/mpegts" or "udp/mpegts". |
| output_type | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Stream descriptor of in the output video stream. Possible values are "tcp/mpegts" or "udp/mpegts". |
| fps | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') | Frames per second of the input video stream. The output stream will be the same frame rate. |
| width | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | width of the video to process in pixels |
| height | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | height of the video to process in pixels |

<a name='M-DeepAI-DeepAI_API-stopRealtimeStream-System-Int32-'></a>
### stopRealtimeStream(id) `method` [#](#M-DeepAI-DeepAI_API-stopRealtimeStream-System-Int32- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Abort a single realtime stream.

##### Returns

RealtimeStream object

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | ID of the stream to stop |

<a name='T-DeepAI-RealtimeStream'></a>
## RealtimeStream [#](#T-DeepAI-RealtimeStream 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

DeepAI

##### Summary

Represents the status and configuration for a single Realtime video stream.

<a name='P-DeepAI-RealtimeStream-input_url'></a>
### input_url `property` [#](#P-DeepAI-RealtimeStream-input_url 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

URL at which you should send your input. This URL is compatible with ffmpeg tools based upon it.

<a name='P-DeepAI-RealtimeStream-output_url'></a>
### output_url `property` [#](#P-DeepAI-RealtimeStream-output_url 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

URL at which the results can be streamed back. This URL is compatible with ffmpeg and tools based upon it, like Ventuz.

<a name='P-DeepAI-RealtimeStream-status'></a>
### status `property` [#](#P-DeepAI-RealtimeStream-status 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

One of PENDING, RUNNING, STOPPED, FAILED

<a name='T-DeepAI-RealtimeStreamUtilities'></a>
## RealtimeStreamUtilities [#](#T-DeepAI-RealtimeStreamUtilities 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

DeepAI

##### Summary

A collection of helper functions for use with real time streams, such as sending webcam input to a stream, or playing the output of a stream.

<a name='M-DeepAI-RealtimeStreamUtilities-#ctor'></a>
### #ctor() `constructor` [#](#M-DeepAI-RealtimeStreamUtilities-#ctor 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Construct a new instance - this is done automatically as this object will be available on all DeepAI_API objects.

##### Parameters

This constructor has no parameters.

<a name='M-DeepAI-RealtimeStreamUtilities-getPlayerCmdForRealtimeStream-DeepAI-RealtimeStream-'></a>
### getPlayerCmdForRealtimeStream(stream) `method` [#](#M-DeepAI-RealtimeStreamUtilities-getPlayerCmdForRealtimeStream-DeepAI-RealtimeStream- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Get the program name and arguments to launch a process that will play the output of a realtime stream.

##### Returns

program name and arguments as array

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| stream | [DeepAI.RealtimeStream](#T-DeepAI-RealtimeStream 'DeepAI.RealtimeStream') | The realtime stream to play. |

<a name='M-DeepAI-RealtimeStreamUtilities-getVideoCaptureDevices'></a>
### getVideoCaptureDevices() `method` [#](#M-DeepAI-RealtimeStreamUtilities-getVideoCaptureDevices 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Get a list of availabe video capture device names.

##### Returns

List of string device names

##### Parameters

This method has no parameters.

<a name='M-DeepAI-RealtimeStreamUtilities-getVideoStreamFormatsForDeviceName-System-String-'></a>
### getVideoStreamFormatsForDeviceName(deviceName) `method` [#](#M-DeepAI-RealtimeStreamUtilities-getVideoStreamFormatsForDeviceName-System-String- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Get the frame rate and frame size combinations that the given input device supports.

##### Returns

Array of supported formats for the device.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| deviceName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The input device to get capabilities for. |

<a name='M-DeepAI-RealtimeStreamUtilities-launchPlayerForStream-DeepAI-RealtimeStream,System-Boolean-'></a>
### launchPlayerForStream(stream,showWindow) `method` [#](#M-DeepAI-RealtimeStreamUtilities-launchPlayerForStream-DeepAI-RealtimeStream,System-Boolean- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Launches a new process to play the output of a realtime stream in a window.

##### Returns

Windows Process handle

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| stream | [DeepAI.RealtimeStream](#T-DeepAI-RealtimeStream 'DeepAI.RealtimeStream') | The stream to play back. |
| showWindow | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Set to false to hide the command prompt. (Not recommended.) |

<a name='M-DeepAI-RealtimeStreamUtilities-launchWebcamSenderForStream-DeepAI-RealtimeStream,System-String,System-Int32,System-Boolean-'></a>
### launchWebcamSenderForStream(stream,cameraName,bitrateKbps,showWindow) `method` [#](#M-DeepAI-RealtimeStreamUtilities-launchWebcamSenderForStream-DeepAI-RealtimeStream,System-String,System-Int32,System-Boolean- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Launches a new process to play the output of a realtime stream in a window.

##### Returns

Windows Process handle

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| stream | [DeepAI.RealtimeStream](#T-DeepAI-RealtimeStream 'DeepAI.RealtimeStream') | The stream to play back. |
| cameraName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Name of the directshow device to capture. |
| bitrateKbps | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Bitrate of the stream to send. |
| showWindow | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Set to false to hide the command prompt. (Not recommended.) |

<a name='T-DeepAI-Properties-Resources'></a>
## Resources [#](#T-DeepAI-Properties-Resources 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

DeepAI.Properties

##### Summary

A strongly-typed resource class, for looking up localized strings, etc.

<a name='P-DeepAI-Properties-Resources-Culture'></a>
### Culture `property` [#](#P-DeepAI-Properties-Resources-Culture 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Overrides the current thread's CurrentUICulture property for all resource lookups using this strongly typed resource class.

<a name='P-DeepAI-Properties-Resources-ffmpeg'></a>
### ffmpeg `property` [#](#P-DeepAI-Properties-Resources-ffmpeg 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Looks up a localized resource of type System.Byte[].

<a name='P-DeepAI-Properties-Resources-ffplay'></a>
### ffplay `property` [#](#P-DeepAI-Properties-Resources-ffplay 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Looks up a localized resource of type System.Byte[].

<a name='P-DeepAI-Properties-Resources-ResourceManager'></a>
### ResourceManager `property` [#](#P-DeepAI-Properties-Resources-ResourceManager 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Returns the cached ResourceManager instance used by this class.

<a name='T-DeepAI-RealtimeStreamUtilities-VideoStreamFormat'></a>
## VideoStreamFormat [#](#T-DeepAI-RealtimeStreamUtilities-VideoStreamFormat 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

DeepAI.RealtimeStreamUtilities

##### Summary

Represents the framerate and frame size of a video stream.

