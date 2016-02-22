using System;
using System.Web;
using System.IO;
using System.Linq;

namespace EGestora.GestoraControlAdm.Infra.CrossCutting.Utils
{
    public class ImagemUtil
    {
        public static bool SalvarImagem(HttpPostedFileBase img, Guid id, string path)
        {
            if (img == null || img.ContentLength <= 0) return false;

            var directory = path;
            var fileName = id + Path.GetExtension(img.FileName);
            img.SaveAs(Path.Combine(directory, fileName));
            return File.Exists(Path.Combine(directory, fileName));
        }

        public static string ObterImagem(Guid id, string path)
        {
            var root = path;
            var foto = Directory.GetFiles(root, id + "*").FirstOrDefault();

            if (foto != null && !foto.StartsWith(root))
            {
                // Validando qualquer acesso indevido além da pasta permitida
                throw new HttpException(403, "Acesso Negado");
            }

            return foto;
        }
    }
}
