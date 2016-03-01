using EGestora.GestoraControlAdm.Domain.Entities;
using System.IO;
using System.Web;

namespace EGestora.GestoraControlAdm.Infra.CrossCutting.Utils
{
    public class AnexoUtil
    {
        public static Anexo GetEntityFromHttpPostedFileBase(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var anexo = new Anexo()
                {
                    FileName = Path.GetFileName(file.FileName),
                    ContentType = file.ContentType
                };
                using (var reader = new BinaryReader(file.InputStream))
                {
                    anexo.Content = reader.ReadBytes(file.ContentLength);
                }
                return anexo;
            }
            return null;
        }
    }
}
