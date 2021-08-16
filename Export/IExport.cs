using System.Collections;
using System.Threading.Tasks;

namespace DXApplication1.Export
{
    public interface IExport
    {
        Task<string> ExportFile(string fileName,IList list);
    }
}
