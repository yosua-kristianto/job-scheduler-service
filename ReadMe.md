# Batch Job Scheduler Controller

This repository contains all logic needed to be used in Batch Job Scheduler for image processing. My first motivation on creating this repository is because I consider how annoying is preparing and standardizing Image files in first place. 

## Pre-requisites

### 1. [MySQL Database](https://www.mysql.com/)
Yes I'm using MySQL database to store jobs. This is because I'm too lazy to install or building any other DBMS, and installing MySQL almost instant and can be used right after installation. 

### 2. [`dotnet`](https://dotnet.microsoft.com/en-us/download)
Dotnet command since this repository is using .NET 6.0. 

### 3. [`dotnet-ef`](https://www.bing.com/ck/a?!&&p=79bc71389558ddafJmltdHM9MTY5NTc3MjgwMCZpZ3VpZD0xMmJhYzg4Ni0zYmM0LTZmNzgtMDE3YS1kOWQyM2E5MjZlZTgmaW5zaWQ9NTIxNA&ptn=3&hsh=3&fclid=12bac886-3bc4-6f78-017a-d9d23a926ee8&psq=dotnet-ef&u=a1aHR0cHM6Ly9sZWFybi5taWNyb3NvZnQuY29tL2VuLXVzL2VmL2NvcmUvY2xpL2RvdG5ldA&ntb=1)
This repository uses Entity Framework Core to interact with the database. To use the migrations, you may want to use the Entity Framework.

### 4. [NuGet](https://www.nuget.org/)
For the Package Manager, I use NuGet. In short, I install every external packages / libraries with NuGet.

## Limitations

Yes you're right, I'm still having skill-issue with this technology. I'm currently commented out Swagger because I can't get it running properly. But I will be used it in mean time. 

## API

### 1. Upload Image
This API will upload image with extension of jpg or png. Or can just straight to upload zip file to begin with. All uploaded images will be stored in the server with format of `[JPG/PNG/ZIP]#[TIMESTAMP]`. This API also register the image to the destinated processing schedule.

### Technical Documentation

| Key | Description |
|---|---|
| `method` | POST |
| `uri` | `/api/ocr/file-upload-sync` |
| `Content-Type` | `multipart/form-data` |

### Request

| Key | Type | Required | Description | Example Value |
|---|---|---|---|---|
| `image` | `file` | `true` | The file to upload. Can be either jpg, png, or zip file. | `BLOB FILE` |
| `instant_upload` | `value` | `true` | This request attribute will determine whatever this operation is an instant operation. 1 for true and 0 for false. | `1` |
| `expected_output` | `value` | `false` | If you want to add expected output to determine the Character Error Rate later, you can set your expected output in here. | `"some string"` |
| `schedule_time` | `value` | `false` | This attribute is required if `instant_upload` is set to 0. Set the schedule with format of `yyyy-mm-ddTHH:mm:ss` | `"2023-09-27T17:31"` |
