using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DocumentDesigner.WebApi.Service
{
	public interface ICustomViewRendererService
	{
		Task<string> RenderViewToStringAsync(ControllerContext actionContext, string viewPath,
            object model);
	}
}
