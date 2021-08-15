using Broadway._6PM.Web.ViewModel;
using Broadway._6PM.Web.ViewModel.Admin;
using System.Collections.Generic;

namespace Broadway._6PM.Web.Services
{
    public interface IVendorServices
    {
        VendorsCreateResponseViewModel CreateVendors(VendorsCreateRequestViewModel model);
        ResponseViewModel EditVendor(VendorViewModel model);
        List<VendorViewModel> GetAllVendors();
        VendorViewModel GetVendorById(int id);
    }
}