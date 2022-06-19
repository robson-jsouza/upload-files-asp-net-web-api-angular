# Uploading a list of attachments using ASP .Net Web API and Angular

## In order to test this HttpPost method from Postman, it is necessary to call this URL (after running the backend project): http://localhost:62966/file

## On Postman, this request example may be followed, considering the DTO below and that 2 files are sent by each DTO:
```
public class FileDto
{
	public string Body { get; set; }
	public IEnumerable<IFormFile> Files { get; set; }
	public string Message { get; set; }
} 
```
On Postman, it is necessary to select Post for the request, put this URL http://localhost:62966/file, click on Body, select form-data and add the parameters.
This is an example:

Key 												Value
(hover the cursor and select 'text' or 'file')

files[0].body										body1
files[0].Files										'Browse and choose file'
files[0].Files										'Browse and choose a second file (you choose how many files to upload)'
files[0].message									message1
files[1].body										body2
files[1].files										'Browse and choose file'
files[1].files										'Browse and choose a second file (you choose how many files to upload)'
files[1].message									message2


