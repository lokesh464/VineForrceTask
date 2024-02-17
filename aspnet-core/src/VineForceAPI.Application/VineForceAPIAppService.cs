using System;
using System.Collections.Generic;
using System.Text;
using VineForceAPI.Localization;
using Volo.Abp.Application.Services;

namespace VineForceAPI;

/* Inherit your application services from this class.
 */
public abstract class VineForceAPIAppService : ApplicationService
{
    protected VineForceAPIAppService()
    {
        LocalizationResource = typeof(VineForceAPIResource);
    }
}
