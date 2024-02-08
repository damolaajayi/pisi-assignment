using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using MySqlX.XDevAPI.Common;
using PISI.Domain.Entities.Subscription;
using PISI.Domain.Interfaces.IRepository;
using PISI.Domain.Interfaces.Subscription;
using PISI.Domain.Models.Service;
using PISI.Domain.Models.Subscription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PISI.Application.Services.Subscription
{
    public class SubscriptionService : ISubscription
    {
        private readonly ISubscribeRepository _subscribeRepo;
        public SubscriptionService(ISubscribeRepository subscribeRepo)
        {
            _subscribeRepo = subscribeRepo;
        }
        public async Task<ResponseDto> CheckStatus(SubscribeDto subscribeDto, CancellationToken token)
        {
            var response = new ResponseDto();
            var sub = new Subscribe();
            try
            {
                var getsubscription = await _subscribeRepo.GetByExpressionAsync(x => x.PhoneNumber == subscribeDto.phoneNumber, token);
                if (getsubscription == null)
                {
                    response.ResponseMessage = "user subscription does not exist";
                    response.ResponseCode = 404;
                    return response;
                }
                if(getsubscription.IsSubcribed)
                {
                    response.ResponseMessage = "user is currently subscribed";
                    response.ResponseCode = 200;
                    return response;
                }
                else
                {
                    response.ResponseMessage = "user is not currently subscribed";
                    response.ResponseCode = 200;
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.ResponseMessage = $"Error occurred trying to check subscription status: {ex}";
                response.ResponseCode = 500;
                return response;
            }
        }

        public async Task<ResponseDto> Subscribe(SubscribeDto subscribeDto, CancellationToken token)
        {
            var response = new ResponseDto();
            var sub = new Subscribe();
            try
            {
                var checknumber = FormatMobileNumber("234", subscribeDto.phoneNumber, 10);
                var getsubscription = await _subscribeRepo.GetByExpressionAsync(x => x.PhoneNumber == subscribeDto.phoneNumber, token);
                if (getsubscription != null) 
                {
                    response.ResponseMessage = "user is already subscribed";
                    response.ResponseCode = 200;
                    return response;
                }
                sub.PhoneNumber = subscribeDto.phoneNumber;
                sub.ServiceId = subscribeDto.ServiceId;
                sub.IsSubcribed = true;
                sub.CreatedBy = subscribeDto.ServiceId;
                sub.DateCreated = DateTime.Now;
                _subscribeRepo.Create(sub);
                if (await _subscribeRepo.CompleteAsync() > 0)
                {
                    response.ResponseMessage = "user is subscribed successfully";
                    response.ResponseCode = 200;
                    return response;
                }
                else
                {
                    response.ResponseMessage = "user subscription failed";
                    response.ResponseCode = 500;
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.ResponseMessage = $"user subscription failed: {ex}";
                response.ResponseCode = 500;
                return response;
            }
            
        }

        public async Task<ResponseDto> UnSubscribe(SubscribeDto subscribeDto, CancellationToken token)
        {
            var response = new ResponseDto();
            var sub = new Subscribe();
            try
            {
                var getsubscription = await _subscribeRepo.GetByExpressionAsync(x => x.PhoneNumber == subscribeDto.phoneNumber, token);
                if (getsubscription == null)
                {
                    response.ResponseMessage = "user subscription does not exist";
                    response.ResponseCode = 404;
                    return response;
                }
                getsubscription.IsSubcribed = false;
                _subscribeRepo.Update(getsubscription);
                if (await _subscribeRepo.CompleteAsync() > 0)
                {
                    response.ResponseMessage = "user is unsubscribed";
                    response.ResponseCode = 200;
                    return response;
                }
                else
                {
                    response.ResponseMessage = "user unsubscription failed";
                    response.ResponseCode = 500;
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.ResponseMessage = $"user unsubscription failed: {ex}";
                response.ResponseCode = 500;
                return response;
            }
        }
        

        private static string FormatMobileNumber(string CountryIsd, string MobileNumber, int Length)
        {
            if (!string.IsNullOrEmpty(MobileNumber))
            {
                string VMobileNumber = MobileNumber.Trim();
                VMobileNumber = VMobileNumber.Replace("+", "");
                VMobileNumber = VMobileNumber.Replace(" ", "");
                string ExPrefix = CountryIsd + "0";
                if (VMobileNumber.Length == Length)
                {
                    VMobileNumber = CountryIsd + VMobileNumber;
                }
                else if (VMobileNumber.Length > Length)
                {
                    int tail_length = Length;
                    VMobileNumber = VMobileNumber.Substring(VMobileNumber.Length - tail_length);
                    VMobileNumber = CountryIsd + VMobileNumber;
                }
                else
                {
                    VMobileNumber = CountryIsd + VMobileNumber;
                }
                return VMobileNumber;
            }
            else
            {
                return MobileNumber;
            }
        }
    }
}
