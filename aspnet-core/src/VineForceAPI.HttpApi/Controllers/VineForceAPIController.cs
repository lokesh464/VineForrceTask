using VineForceAPI.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace VineForceAPI.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class VineForceAPIController : AbpControllerBase
{
    protected VineForceAPIController()
    {
        LocalizationResource = typeof(VineForceAPIResource);
    }
}
