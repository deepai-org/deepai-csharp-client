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
  - [getRealtimeStream(id)](#M-DeepAI-DeepAI_API-getRealtimeStream-System-Int32- 'DeepAI.DeepAI_API.getRealtimeStream(System.Int32)')
  - [getRealtimeStreams()](#M-DeepAI-DeepAI_API-getRealtimeStreams 'DeepAI.DeepAI_API.getRealtimeStreams')
  - [objectAsJsonString(a)](#M-DeepAI-DeepAI_API-objectAsJsonString-System-Object- 'DeepAI.DeepAI_API.objectAsJsonString(System.Object)')
  - [startRealtimeStream(model,input_type,output_type,fps,width,height)](#M-DeepAI-DeepAI_API-startRealtimeStream-System-String,System-String,System-String,System-Single,System-Int32,System-Int32- 'DeepAI.DeepAI_API.startRealtimeStream(System.String,System.String,System.String,System.Single,System.Int32,System.Int32)')
  - [stopRealtimeStream(id)](#M-DeepAI-DeepAI_API-stopRealtimeStream-System-Int32- 'DeepAI.DeepAI_API.stopRealtimeStream(System.Int32)')

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

Stream Info object containing URLs which may be used to connect to the stream by sending input and receiving output.

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

Stream Info object

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | ID of the stream to stop |
