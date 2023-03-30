using ApiTiqets.IService;
using ApiTiqets.Service;
using Entities.Entities;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO.Compression;
using System.Web.Http.Cors;

namespace ApiTiqets.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]

    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IProductService _productService;
        public ProductController(IProductService productService, IFileService fileService)
        {
            _productService = productService;
            _fileService = fileService;
        }

        [HttpPost(Name = "PostBase64")]
        public int PostBase64([FromBody] NewProductBase64Request newProductBase64RequestModel)
        {
            try
            {
                var fileItem = new FileEntity();

                fileItem.FileName = newProductBase64RequestModel.Base64FileModel.FileTitle;
                if (newProductBase64RequestModel.Base64FileModel.Extension == "image/jpeg")
                {
                    fileItem.FileExtension = Enums.FileExtensionEnum.JPG;
                }
                else if (newProductBase64RequestModel.Base64FileModel.Extension == "image/png")
                {
                    fileItem.FileExtension = Enums.FileExtensionEnum.PGN;
                }
                else
                {
                    throw new InvalidDataException();
                }
                fileItem.FileContent = Convert.FromBase64String(newProductBase64RequestModel.Base64FileModel.Base64FileContent);
                //fileItem.Base64Content()
                var fileId = _fileService.InsertFile(fileItem);

                var productItem = newProductBase64RequestModel.Product;
                productItem.IdPhotoFile = fileId;

                return _productService.InsertProduct(productItem);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet(Name = "GetFullProductsInfo")]
        public List<FullProductInfoModel> GetFullProductsInfo()
        {
            var productsList = _productService.GetAllProducts();
            var fileList = _fileService.GetAllFiles();

            List<FullProductInfoModel> resultList = new List<FullProductInfoModel>();

            foreach (var prod in productsList)
            {
                FullProductInfoModel resultItem = new FullProductInfoModel();

                resultItem.Product = prod;

                var fileItem = fileList.Where(f => f.Id == prod.IdPhotoFile).First();

                Base64FileModel base64FileModel = new Base64FileModel();

                base64FileModel.FileTitle = fileItem.FileName;
                base64FileModel.Base64FileContent = fileItem.Base64Content;
                if (fileItem.FileExtension == Enums.FileExtensionEnum.JPG)
                {
                    base64FileModel.Extension = "image/jpeg";
                }
                else if (fileItem.FileExtension == Enums.FileExtensionEnum.PGN)
                {
                    base64FileModel.Extension = "image/png";
                }
                else
                {
                    throw new NotImplementedException();
                }

                resultItem.Base64FileModel = base64FileModel;

                resultList.Add(resultItem);
            }

            return resultList;
        }
    }

}
