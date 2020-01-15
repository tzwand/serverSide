using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using BLL;

namespace WEB_API.Controllers
{
    public class FileController : ApiController
    {
        
        
            [Route("api/File/SaveFileByBase64/{fileName}/{reqId}/{groupName}")]
            [HttpPost]
            public IHttpActionResult SaveFileByBase64(string fileName,int reqId,string groupName, [FromBody] Base64 base64File)
            {
            var newfileName=FileLogic.handleNewGroup(base64File, fileName, reqId, groupName);


                return Ok(newfileName);
            }

        [Route("api/TestExport/DownloadAttachment")]
        [AcceptVerbs("GET")]
        public HttpResponseMessage DownloadAttachment(string fileName)
        {
            //below code locate physical file on server 
            //var localFilePath = HttpContext.Current.Server.MapPath("../../uploadFiles/" + fileName);
            var localFilePath = "C:\\Users\\tzipp\\BTProject\\cheshvanProject\\WEB_API\\WEB_API\\Files\\OtzarHalimud.xlsx";
             HttpResponseMessage response = null;
            if (!File.Exists(localFilePath))
            {
                //if file not found than return response as resource not present 
                response = Request.CreateResponse(HttpStatusCode.Gone);
            }

            else
            {
                //if file present than read file 
                var fStream = new FileStream(localFilePath, FileMode.Open, FileAccess.Read);

                //compose response and include file as content in it
                response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    // Content = new StreamContent(fStream)
                    Content = new StreamContent(fStream)
                };

                //set content header of reponse as file attached in reponse
                response.Content.Headers.ContentDisposition =
                            new ContentDispositionHeaderValue("attachment")
                            {
                                FileName = Path.GetFileName(fStream.Name)
                            };
                //set the content header content type as application/octet-stream as it      
                //returning file as reponse 
                response.Content.Headers.ContentType = new
                              MediaTypeHeaderValue("application/octet-stream");


                response.Content.Headers.ContentLength = fStream.Length;
                response.Headers.Add("fileName", fileName);
            }
            return response;
        }
    }

}

