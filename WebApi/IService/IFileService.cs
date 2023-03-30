using Entities.Entities;

namespace ApiTiqets.IService
{
    public interface IFileService
    {
        int InsertFile(FileEntity fileItem);
        List<FileEntity> GetAllFiles();
    }
}
