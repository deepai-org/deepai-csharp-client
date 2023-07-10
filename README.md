# DeepAI CSharp Client
Simple CSharp Client Library for [Deep AI's](https://deepai.org) APIs

## Installation:

Get this package from NuGet: https://www.nuget.org/packages/DeepAI.Client/

Or clone and build this repository with Visual Studio 2013 or later.

## Build notes:

# Push to NuGet
(Update AssemblyInfo.cs bumping the version number)
(Switch to the DeepAI solution before build)
(Build)
cd '/c/users/kevin/documents/visual studio 2013/projects/deepai.client/deepai.client/'

/c/Users/kevin/Desktop/nuget.exe pack DeepAI.csproj
/c/Users/kevin/Desktop/nuget.exe push DeepAI.Client.1.3.0.nupkg -Timeout 3000 -Source https://www.nuget.org

Log into NuGet and point the package to the new version.

(Update readme with generated docs from: C:\Users\kevin\Documents\Visual Studio 2013\Projects\DeepAI.Client\DeepAI.Client\bin\Debug\DeepAI.md)
or just upload in the web ui



# Reference
(generated from XMLDOC with [Vsxmd](https://github.com/lijunle/Vsxmd)):

<a name='contents'></a>
# Contents [#](#contents 'Go To Here')

- [BrandsafeJob](#T-DeepAI-BrandsafeJob 'DeepAI.BrandsafeJob')
- [BrandsafeJobResults](#T-DeepAI-BrandsafeJobResults 'DeepAI.BrandsafeJobResults')
- [DeepAI_API](#T-DeepAI-DeepAI_API 'DeepAI.DeepAI_API')
  - [#ctor(apiKey)](#M-DeepAI-DeepAI_API-#ctor-System-String- 'DeepAI.DeepAI_API.#ctor(System.String)')
  - [realtimeStreamUtilities](#F-DeepAI-DeepAI_API-realtimeStreamUtilities 'DeepAI.DeepAI_API.realtimeStreamUtilities')
  - [callStandardApi(model,inputs_and_options)](#M-DeepAI-DeepAI_API-callStandardApi-System-String,System-Object- 'DeepAI.DeepAI_API.callStandardApi(System.String,System.Object)')
  - [callStandardApiWithBinaryResponse(model,inputs_and_options)](#M-DeepAI-DeepAI_API-callStandardApiWithBinaryResponse-System-String,System-Object- 'DeepAI.DeepAI_API.callStandardApiWithBinaryResponse(System.String,System.Object)')
  - [getAccountInfo()](#M-DeepAI-DeepAI_API-getAccountInfo 'DeepAI.DeepAI_API.getAccountInfo')
  - [getAvailableModelOptionsForModelName(modelName)](#M-DeepAI-DeepAI_API-getAvailableModelOptionsForModelName-System-String- 'DeepAI.DeepAI_API.getAvailableModelOptionsForModelName(System.String)')
  - [getBrandsafeJob(id)](#M-DeepAI-DeepAI_API-getBrandsafeJob-System-String- 'DeepAI.DeepAI_API.getBrandsafeJob(System.String)')
  - [getRealtimeStream(id)](#M-DeepAI-DeepAI_API-getRealtimeStream-System-Int32- 'DeepAI.DeepAI_API.getRealtimeStream(System.Int32)')
  - [getRealtimeStreams()](#M-DeepAI-DeepAI_API-getRealtimeStreams 'DeepAI.DeepAI_API.getRealtimeStreams')
  - [getVideoJob(id)](#M-DeepAI-DeepAI_API-getVideoJob-System-Int32- 'DeepAI.DeepAI_API.getVideoJob(System.Int32)')
  - [modifyRealtimeStream(id,output_bitrate_kbps)](#M-DeepAI-DeepAI_API-modifyRealtimeStream-System-Int32,System-Int32,System-Collections-Generic-Dictionary{System-String,System-Object},System-String- 'DeepAI.DeepAI_API.modifyRealtimeStream(System.Int32,System.Int32,System.Collections.Generic.Dictionary{System.String,System.Object},System.String)')
  - [objectAsJsonString(a)](#M-DeepAI-DeepAI_API-objectAsJsonString-System-Object- 'DeepAI.DeepAI_API.objectAsJsonString(System.Object)')
  - [startRealtimeStream(model,input_type,output_type,fps,width,height,output_bitrate_kbps,model_options)](#M-DeepAI-DeepAI_API-startRealtimeStream-System-String,System-String,System-String,System-Single,System-Int32,System-Int32,System-Int32,System-Collections-Generic-Dictionary{System-String,System-Object}- 'DeepAI.DeepAI_API.startRealtimeStream(System.String,System.String,System.String,System.Single,System.Int32,System.Int32,System.Int32,System.Collections.Generic.Dictionary{System.String,System.Object})')
  - [startVideoJob(model,video,fps,model_options)](#M-DeepAI-DeepAI_API-startVideoJob-System-String,System-Object,System-Single,System-Object- 'DeepAI.DeepAI_API.startVideoJob(System.String,System.Object,System.Single,System.Object)')
  - [stopRealtimeStream(id)](#M-DeepAI-DeepAI_API-stopRealtimeStream-System-Int32- 'DeepAI.DeepAI_API.stopRealtimeStream(System.Int32)')
  - [submitBrandsafeJob(url,extra_options)](#M-DeepAI-DeepAI_API-submitBrandsafeJob-System-String,System-Collections-Generic-Dictionary{System-String,System-Object}- 'DeepAI.DeepAI_API.submitBrandsafeJob(System.String,System.Collections.Generic.Dictionary{System.String,System.Object})')
- [DeepAIAccountInfo](#T-DeepAI-DeepAIAccountInfo 'DeepAI.DeepAIAccountInfo')
- [ObjectDictionary](#T-DeepAI-DeepAI_API-ObjectDictionary 'DeepAI.DeepAI_API.ObjectDictionary')
  - [#ctor(a_source)](#M-DeepAI-DeepAI_API-ObjectDictionary-#ctor-System-Object- 'DeepAI.DeepAI_API.ObjectDictionary.#ctor(System.Object)')
  - [ParseObject(a_source)](#M-DeepAI-DeepAI_API-ObjectDictionary-ParseObject-System-Object- 'DeepAI.DeepAI_API.ObjectDictionary.ParseObject(System.Object)')
- [RealtimeStream](#T-DeepAI-RealtimeStream 'DeepAI.RealtimeStream')
  - [input_url](#P-DeepAI-RealtimeStream-input_url 'DeepAI.RealtimeStream.input_url')
  - [model_options](#P-DeepAI-RealtimeStream-model_options 'DeepAI.RealtimeStream.model_options')
  - [output_url](#P-DeepAI-RealtimeStream-output_url 'DeepAI.RealtimeStream.output_url')
  - [state_change_reason](#P-DeepAI-RealtimeStream-state_change_reason 'DeepAI.RealtimeStream.state_change_reason')
  - [status](#P-DeepAI-RealtimeStream-status 'DeepAI.RealtimeStream.status')
- [RealtimeStreamUtilities](#T-DeepAI-RealtimeStreamUtilities 'DeepAI.RealtimeStreamUtilities')
  - [#ctor()](#M-DeepAI-RealtimeStreamUtilities-#ctor 'DeepAI.RealtimeStreamUtilities.#ctor')
  - [getPlayerCmdForRealtimeStream(stream)](#M-DeepAI-RealtimeStreamUtilities-getPlayerCmdForRealtimeStream-DeepAI-RealtimeStream- 'DeepAI.RealtimeStreamUtilities.getPlayerCmdForRealtimeStream(DeepAI.RealtimeStream)')
  - [getVideoCaptureDevices()](#M-DeepAI-RealtimeStreamUtilities-getVideoCaptureDevices 'DeepAI.RealtimeStreamUtilities.getVideoCaptureDevices')
  - [getVideoStreamFormatsForDeviceName(deviceName)](#M-DeepAI-RealtimeStreamUtilities-getVideoStreamFormatsForDeviceName-System-String- 'DeepAI.RealtimeStreamUtilities.getVideoStreamFormatsForDeviceName(System.String)')
  - [launchPlayerForStream(stream,showWindow)](#M-DeepAI-RealtimeStreamUtilities-launchPlayerForStream-DeepAI-RealtimeStream,System-Boolean- 'DeepAI.RealtimeStreamUtilities.launchPlayerForStream(DeepAI.RealtimeStream,System.Boolean)')
  - [launchWebcamSenderForStream()](#M-DeepAI-RealtimeStreamUtilities-launchWebcamSenderForStream-DeepAI-RealtimeStream,System-String,System-Int32,System-Boolean,System-Int32,System-Int32- 'DeepAI.RealtimeStreamUtilities.launchWebcamSenderForStream(DeepAI.RealtimeStream,System.String,System.Int32,System.Boolean,System.Int32,System.Int32)')
- [Resources](#T-DeepAI-Properties-Resources 'DeepAI.Properties.Resources')
  - [Culture](#P-DeepAI-Properties-Resources-Culture 'DeepAI.Properties.Resources.Culture')
  - [ffmpeg](#P-DeepAI-Properties-Resources-ffmpeg 'DeepAI.Properties.Resources.ffmpeg')
  - [ffplay](#P-DeepAI-Properties-Resources-ffplay 'DeepAI.Properties.Resources.ffplay')
  - [ResourceManager](#P-DeepAI-Properties-Resources-ResourceManager 'DeepAI.Properties.Resources.ResourceManager')
- [StandardApiResponse](#T-DeepAI-StandardApiResponse 'DeepAI.StandardApiResponse')
  - [output](#P-DeepAI-StandardApiResponse-output 'DeepAI.StandardApiResponse.output')
  - [output_url](#P-DeepAI-StandardApiResponse-output_url 'DeepAI.StandardApiResponse.output_url')
- [VideoJob](#T-DeepAI-VideoJob 'DeepAI.VideoJob')
  - [est_total_cost](#P-DeepAI-VideoJob-est_total_cost 'DeepAI.VideoJob.est_total_cost')
  - [results](#P-DeepAI-VideoJob-results 'DeepAI.VideoJob.results')
  - [status](#P-DeepAI-VideoJob-status 'DeepAI.VideoJob.status')
- [VideoStreamFormat](#T-DeepAI-RealtimeStreamUtilities-VideoStreamFormat 'DeepAI.RealtimeStreamUtilities.VideoStreamFormat')

<a name='assembly'></a>
# DeepAI [#](#assembly 'Go To Here') [=](#contents 'Back To Contents')

<a name='T-DeepAI-BrandsafeJob'></a>
## BrandsafeJob [#](#T-DeepAI-BrandsafeJob 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

DeepAI

##### Summary

Represents the status and results of a Brandsafe Job.

<a name='T-DeepAI-BrandsafeJobResults'></a>
## BrandsafeJobResults [#](#T-DeepAI-BrandsafeJobResults 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

DeepAI

##### Summary

Represents the results of a Brandsafe Job.

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

<a name='M-DeepAI-DeepAI_API-callStandardApi-System-String,System-Object-'></a>
### callStandardApi(model,inputs_and_options) `method` [#](#M-DeepAI-DeepAI_API-callStandardApi-System-String,System-Object- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Call a standard API to run a model on a single image or other input, such as text file.

##### Returns

Reponse object with either URL or immediate data.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| model | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the model to run. |
| inputs_and_options | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | An anonymous object containing the inputs and options needed by the model, such as "image" or "style" |

<a name='M-DeepAI-DeepAI_API-callStandardApiWithBinaryResponse-System-String,System-Object-'></a>
### callStandardApiWithBinaryResponse(model,inputs_and_options) `method` [#](#M-DeepAI-DeepAI_API-callStandardApiWithBinaryResponse-System-String,System-Object- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Call a standard API to run a model on a single image or other input, such as text file. Returns raw bytes of the output, such as JPEG data.

##### Returns

Byte array representing the output of the model, typically in JPEG format.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| model | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the model to run. |
| inputs_and_options | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | An anonymous object containing the inputs and options needed by the model, such as "image" or "style" |

<a name='M-DeepAI-DeepAI_API-getAccountInfo'></a>
### getAccountInfo() `method` [#](#M-DeepAI-DeepAI_API-getAccountInfo 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Get basic infomation about the account associated with the API Key

##### Returns

DeepAIAccountInfo object

##### Parameters

This method has no parameters.

<a name='M-DeepAI-DeepAI_API-getAvailableModelOptionsForModelName-System-String-'></a>
### getAvailableModelOptionsForModelName(modelName) `method` [#](#M-DeepAI-DeepAI_API-getAvailableModelOptionsForModelName-System-String- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Get the available model options for a given model name

##### Returns

Object representing the possible choices of various fields

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| modelName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Name of the model to get options for |

<a name='M-DeepAI-DeepAI_API-getBrandsafeJob-System-String-'></a>
### getBrandsafeJob(id) `method` [#](#M-DeepAI-DeepAI_API-getBrandsafeJob-System-String- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Get the status and output of a brandsafe job

##### Returns

A BrandsafeJob object with the status of the job. Results will not be present unless the job is complete

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The ID string of the job to get info for |

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

<a name='M-DeepAI-DeepAI_API-getVideoJob-System-Int32-'></a>
### getVideoJob(id) `method` [#](#M-DeepAI-DeepAI_API-getVideoJob-System-Int32- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Get status and basic information about a video job.

##### Returns

VideoJob information object

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The numeric Job ID of the video to get. |

<a name='M-DeepAI-DeepAI_API-modifyRealtimeStream-System-Int32,System-Int32,System-Collections-Generic-Dictionary{System-String,System-Object},System-String-'></a>
### modifyRealtimeStream(id,output_bitrate_kbps) `method` [#](#M-DeepAI-DeepAI_API-modifyRealtimeStream-System-Int32,System-Int32,System-Collections-Generic-Dictionary{System-String,System-Object},System-String- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Modify a single realtime stream.

##### Returns

RealtimeStream object

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | ID of the stream to modify |
| output_bitrate_kbps | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | If provided, set the output bitrate of the stream to this value. |

<a name='M-DeepAI-DeepAI_API-objectAsJsonString-System-Object-'></a>
### objectAsJsonString(a) `method` [#](#M-DeepAI-DeepAI_API-objectAsJsonString-System-Object- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Simple helper method to pretty-print an object response of any API call for easier viewing.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| a | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |

<a name='M-DeepAI-DeepAI_API-startRealtimeStream-System-String,System-String,System-String,System-Single,System-Int32,System-Int32,System-Int32,System-Collections-Generic-Dictionary{System-String,System-Object}-'></a>
### startRealtimeStream(model,input_type,output_type,fps,width,height,output_bitrate_kbps,model_options) `method` [#](#M-DeepAI-DeepAI_API-startRealtimeStream-System-String,System-String,System-String,System-Single,System-Int32,System-Int32,System-Int32,System-Collections-Generic-Dictionary{System-String,System-Object}- 'Go To Here') [=](#contents 'Back To Contents')

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
| output_bitrate_kbps | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Bitrate of the output video stream in kbps. If not provided, the system default will be used. |
| model_options | [System.Collections.Generic.Dictionary{System.String,System.Object}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.Dictionary 'System.Collections.Generic.Dictionary{System.String,System.Object}') | Dictionary of options to send to the processing model. Possible values may be retrieved with api.getAvailableModelOptionsForModelName(...) |

<a name='M-DeepAI-DeepAI_API-startVideoJob-System-String,System-Object,System-Single,System-Object-'></a>
### startVideoJob(model,video,fps,model_options) `method` [#](#M-DeepAI-DeepAI_API-startVideoJob-System-String,System-Object,System-Single,System-Object- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Creates a new single-model video job using either a file upload or a URL of the video to process.

##### Returns

Object with the ID and status of the new video job.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| model | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The model name to process the video with |
| video | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The FileStream of video data to process, or a URL to download. |
| fps | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') | Frames per second to process. If not given, the frame rate will be chosen automatically, typically the same as the input video, or 2fps for object detection models. |
| model_options | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Dictionary of options to pass to the given model, such as {"style": "YOUR_STYLE_CHOICE"} |

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

<a name='M-DeepAI-DeepAI_API-submitBrandsafeJob-System-String,System-Collections-Generic-Dictionary{System-String,System-Object}-'></a>
### submitBrandsafeJob(url,extra_options) `method` [#](#M-DeepAI-DeepAI_API-submitBrandsafeJob-System-String,System-Collections-Generic-Dictionary{System-String,System-Object}- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Submit a new brandsafe job

##### Returns

A BrandsafeJob object with the status of the new job. Use the "id" field to query the status until it is finished.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| url | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The URL to scan |
| extra_options | [System.Collections.Generic.Dictionary{System.String,System.Object}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.Dictionary 'System.Collections.Generic.Dictionary{System.String,System.Object}') | An optional dictionary of extra options to pass to the API |

<a name='T-DeepAI-DeepAIAccountInfo'></a>
## DeepAIAccountInfo [#](#T-DeepAI-DeepAIAccountInfo 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

DeepAI

##### Summary

Basic information about a DeepAI account

<a name='T-DeepAI-DeepAI_API-ObjectDictionary'></a>
## ObjectDictionary [#](#T-DeepAI-DeepAI_API-ObjectDictionary 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

DeepAI.DeepAI_API

<a name='M-DeepAI-DeepAI_API-ObjectDictionary-#ctor-System-Object-'></a>
### #ctor(a_source) `constructor` [#](#M-DeepAI-DeepAI_API-ObjectDictionary-#ctor-System-Object- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Construct.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| a_source | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Source object. |

<a name='M-DeepAI-DeepAI_API-ObjectDictionary-ParseObject-System-Object-'></a>
### ParseObject(a_source) `method` [#](#M-DeepAI-DeepAI_API-ObjectDictionary-ParseObject-System-Object- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Create a dictionary from the given object (`a_source`).

##### Returns

Created dictionary.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| a_source | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Source object. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if `a_source` is null. |

<a name='T-DeepAI-RealtimeStream'></a>
## RealtimeStream [#](#T-DeepAI-RealtimeStream 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

DeepAI

##### Summary

Represents the status and configuration for a single Realtime video stream.

<a name='P-DeepAI-RealtimeStream-input_url'></a>
### input_url `property` [#](#P-DeepAI-RealtimeStream-input_url 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

URL at which you should send your input. This URL is compatible with ffmpeg and tools based upon it.

<a name='P-DeepAI-RealtimeStream-model_options'></a>
### model_options `property` [#](#P-DeepAI-RealtimeStream-model_options 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Currently active model options of the stream.

<a name='P-DeepAI-RealtimeStream-output_url'></a>
### output_url `property` [#](#P-DeepAI-RealtimeStream-output_url 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

URL at which the results can be streamed back. This URL is compatible with ffmpeg and tools based upon it, like Ventuz.

<a name='P-DeepAI-RealtimeStream-state_change_reason'></a>
### state_change_reason `property` [#](#P-DeepAI-RealtimeStream-state_change_reason 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

The description of the reason for the change in status if it is known. For example, if transitioned to STOPPED due to inactivity, or FAILED due to DeepAI internal error.

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

<a name='M-DeepAI-RealtimeStreamUtilities-launchWebcamSenderForStream-DeepAI-RealtimeStream,System-String,System-Int32,System-Boolean,System-Int32,System-Int32-'></a>
### launchWebcamSenderForStream() `method` [#](#M-DeepAI-RealtimeStreamUtilities-launchWebcamSenderForStream-DeepAI-RealtimeStream,System-String,System-Int32,System-Boolean,System-Int32,System-Int32- 'Go To Here') [=](#contents 'Back To Contents')

##### Returns

Windows Process handle

##### Parameters

This method has no parameters.

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

<a name='T-DeepAI-StandardApiResponse'></a>
## StandardApiResponse [#](#T-DeepAI-StandardApiResponse 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

DeepAI

<a name='P-DeepAI-StandardApiResponse-output'></a>
### output `property` [#](#P-DeepAI-StandardApiResponse-output 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

The immediate output of the model

<a name='P-DeepAI-StandardApiResponse-output_url'></a>
### output_url `property` [#](#P-DeepAI-StandardApiResponse-output_url 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

The private URL at which the results are available, if present.

<a name='T-DeepAI-VideoJob'></a>
## VideoJob [#](#T-DeepAI-VideoJob 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

DeepAI

##### Summary

Represents the status and output for a single Video job.

<a name='P-DeepAI-VideoJob-est_total_cost'></a>
### est_total_cost `property` [#](#P-DeepAI-VideoJob-est_total_cost 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

The estimated cost of the job if it runs to completion.

<a name='P-DeepAI-VideoJob-results'></a>
### results `property` [#](#P-DeepAI-VideoJob-results 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

The private URL at which the results are available, if present.

<a name='P-DeepAI-VideoJob-status'></a>
### status `property` [#](#P-DeepAI-VideoJob-status 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

One of: complete, in-progress, failed

<a name='T-DeepAI-RealtimeStreamUtilities-VideoStreamFormat'></a>
## VideoStreamFormat [#](#T-DeepAI-RealtimeStreamUtilities-VideoStreamFormat 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

DeepAI.RealtimeStreamUtilities

##### Summary

Represents the framerate and frame size of a video stream.

