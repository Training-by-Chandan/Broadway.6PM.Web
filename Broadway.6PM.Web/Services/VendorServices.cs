using Broadway._6PM.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Broadway._6PM.Web.ViewModel.Admin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Broadway._6PM.Web.ViewModel;

namespace Broadway._6PM.Web.Services
{
    public class VendorServices
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public VendorsCreateResponseViewModel CreateVendors(VendorsCreateRequestViewModel model)
        {
            var res = new VendorsCreateResponseViewModel();

            try
            {
                //todo : create a vendor and its user
                if (!(db.Users.Any(u => u.UserName == model.EmailAddress)))
                {
                    var userStore = new UserStore<ApplicationUser>(db);
                    var userManager = new UserManager<ApplicationUser>(userStore);
                    var userToInsert = new ApplicationUser { UserName = model.EmailAddress, PhoneNumber = model.MobileNUmber, Email = model.EmailAddress };
                    userManager.Create(userToInsert, model.Password);

                    userManager.AddToRole(userToInsert.Id, ConstString.Roles.Vendors);

                    var vendor = new Vendors()
                    {
                        Address = model.Address,
                        Email = model.EmailAddress,
                        MobileNumber = model.MobileNUmber,
                        Name = model.Name,
                        UserId = userToInsert.Id
                    };

                    db.Vendors.Add(vendor);
                    db.SaveChanges();
                    res.Status = true;
                    res.Message = "Successfully Created the Vendor User";
                }
                else
                {
                    res.Message = "User with same email address already exists";
                }
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
            }

            return res;
        }

        public List<VendorViewModel> GetAllVendors()
        {
            var data = db.Vendors.Select(p => new VendorViewModel
            {
                Address = p.Address,
                EmailAddress = p.Email,
                Id = p.Id,
                MobileNUmber = p.MobileNumber,
                Name = p.Name
            });

            return data.ToList();
        }

        public VendorViewModel GetVendorById(int id)
        {
            var vendor = db.Vendors.Find(id);
            if (vendor != null)
            {
                return new VendorViewModel()
                {
                    Address = vendor.Address,
                    EmailAddress = vendor.Email,
                    Id = vendor.Id,
                    MobileNUmber = vendor.MobileNumber,
                    Name = vendor.Name
                };
            }
            else
            {
                return null;
            }
        }

        public ResponseViewModel EditVendor(VendorViewModel model)
        {
            var res = new ResponseViewModel();
            try
            {
                var existingVendor = db.Vendors.Find(model.Id);
                if (existingVendor==null)
                {
                    res.Message = "Vendor not found";
                }
                else
                {
                    existingVendor.Name = model.Name;
                    existingVendor.MobileNumber = model.MobileNUmber;
                    existingVendor.Address = model.Address;
                    existingVendor.Email = model.EmailAddress;
                    db.Entry(existingVendor).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    res.Status = true;
                    res.Message = "Successfully updated the vendor";
                }
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
            }
            return res;
        }
    }
}