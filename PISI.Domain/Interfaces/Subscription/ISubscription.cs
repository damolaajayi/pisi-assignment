using PISI.Domain.Models.Service;
using PISI.Domain.Models.Subscription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PISI.Domain.Interfaces.Subscription
{
    public interface ISubscription
    {
        Task<ResponseDto> Subscribe(SubscribeDto subscribeDto, CancellationToken token);
        Task<ResponseDto> UnSubscribe(SubscribeDto subscribeDto, CancellationToken token);
        Task<ResponseDto> CheckStatus(SubscribeDto subscribeDto, CancellationToken token);
    }
}
