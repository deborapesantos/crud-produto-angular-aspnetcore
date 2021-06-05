using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solution_CrudProduto.Data;
using Solution_CrudProduto.Domain;
using Solution_CrudProduto.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Solution_CrudProduto.Controllers
{
    [Route("api/Produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly BaseContext _baseContext;

        public ProdutoController(BaseContext baseContext)
        {
            _baseContext = baseContext;
        }


        [HttpGet]
        [Route("GetAllProdutos")]
        public ActionResult<Object> GetAllProdutos()
        {
            Result resultado = new Result();
            Produto filter = new Produto();
            var produtos = new ProdutoService(_baseContext).GetAllProdutos(filter, ref resultado);

            if (!resultado.Success)
                return StatusCode(StatusCodes.Status500InternalServerError,resultado);

            return Ok(produtos); 
        }


        [HttpGet]
        [Route("GetProdutoById")]
        public ActionResult<Object> GetProdutoById(long pId)
        {
            Result resultado = new Result();

            Produto filter = new Produto()
            {
                ProdutoId = pId
            };

            var produto = new ProdutoService(_baseContext).GetProduto(filter, ref resultado);

            if (!resultado.Success)
                return StatusCode(StatusCodes.Status500InternalServerError, resultado);

            return Ok(produto);
        }

        [HttpPost]
        [Route("CreateProduto")]
        public ActionResult<Result> CreateProduto(Produto pModel)
        {
            Result resultado = new Result();
            resultado = new ProdutoService(_baseContext).CreateProduto(pModel, ref resultado);

            if (!resultado.Success)
                return StatusCode(StatusCodes.Status500InternalServerError, resultado);

            return Ok(resultado);
        }

        [HttpPost]
        [Route("UpdateProduto")]
        public ActionResult<Result> UpdateProduto(Produto pModel)
        {
            Result resultado = new Result();
            resultado = new ProdutoService(_baseContext).UpdateProduto(pModel, ref resultado);

            var req =  Request.Form.Files.First();

            if (!resultado.Success)
                return StatusCode(StatusCodes.Status500InternalServerError, resultado);

            return Ok(resultado);
        }


        [HttpGet]
        [Route("DeleteProdutoById")]
        public ActionResult<Result> DeleteProdutoById(long pId)
        {
            Result resultado = new Result();
            Produto filter = new Produto()
            {
                ProdutoId = pId
            };

            resultado = new ProdutoService(_baseContext).DeleteProduto(filter, ref resultado);

            if (!resultado.Success)
                return StatusCode(StatusCodes.Status500InternalServerError, resultado);

            return Ok(resultado);
        }


        [HttpPost]
        [Route("UploadImageProduto")]
        public ActionResult<Object> UploadImageProduto()
        {
            Result resultado = new Result();
            string dbPathImage = "";
            List<string> permitedExtensions = new List<string>()
            {
                ".JPG",".JPEG",".PNG"
            };
           

            try
            {
              
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    string fileExtension = Path.GetExtension(file.FileName).ToUpper();

                    if (permitedExtensions.Contains(fileExtension))
                    {

                        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        var fullPath = Path.Combine(pathToSave, fileName);
                        dbPathImage = Path.Combine(folderName, fileName);
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }

                    }
                    else
                    {
                        throw new Exception("Tipo de arquivo inválido");
                    }
                }
                else
                {
                    throw new Exception("Arquivo inválido");
                }



            }
            catch (Exception ex)
            {
                resultado.GravarLog(ex);

                throw new Exception("Erro ao gravar o arquivo");

            }

            if (!resultado.Success)
                return StatusCode(StatusCodes.Status500InternalServerError, resultado);

            return Ok(dbPathImage);
        }


    }
}
