using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using Business.Interfaces;
using Business.Mappers;
using DTOs;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Model.RequestParams;

namespace Business.Accounts
{
    public class VkAccount : IAccount
    {
        public VkAccount(AccountDTO acc)
        {
            _api = new VkApi();
            _accountInfo = acc;
            _pts = Convert.ToUInt64(acc.LastUpdate);
        }

        private AccountDTO _accountInfo;

        private VkNet.Model.LongPollServerResponse _longPoll;
        private VkNet.Model.LongPollHistoryResponse _longPollHistory;
        private ulong? _pts;

        private const int AppId = 5678626;
        private readonly VkApi _api;

        private static string code;
        private Func<string> _code = () =>
        {
            return code;
        };

        //Func<string> code = () =>
        //{
        //    Console.Write("Please enter code: ");
        //    string value = Console.ReadLine();

        //    return value;
        //};

        public void Authorize(string codeValue)
        {
            code = codeValue;
            try
            {
                _api.Authorize(new ApiAuthParams
                {
                    ApplicationId = AppId,
                    Login = _accountInfo.Login,
                    Password = _accountInfo.Password,
                    Settings = Settings.All,
                    TwoFactorAuthorization = _code
                });
            }
            catch (CaptchaNeededException cEx)
            {
                ExceptionDispatchInfo.Capture(cEx).Throw();
            }

        }

        public void Authorize(string captcha, long sid)
        {
            _api.Authorize(new ApiAuthParams
            {
                ApplicationId = AppId,
                Login = _accountInfo.Login,
                Password = _accountInfo.Password,
                Settings = Settings.All,
                CaptchaKey = captcha,
                CaptchaSid = sid
            });
        }

        public IEnumerable<ContactDTO> GetAllContacts()
        {
            return _api.Friends.Get(new FriendsGetParams {Order = FriendsOrder.Hints, UserId = _accountInfo.AccountId}).Select(EntitiesMapper.Map).ToList();
        }
        

        public void SendMessage(MessageDTO message)
        {
            try
            {
                _api.Messages.Send(new MessagesSendParams
                {
                    UserId = _api.UserId,
                    //Message = message.Text
                });
            }
            catch (CaptchaNeededException cEx)
            {
                ExceptionDispatchInfo.Capture(cEx).Throw();
            }
        }
        public void SendMessage(MessageDTO message, string captcha, long sid)
        {
            _api.Messages.Send(new MessagesSendParams
            {
                UserId = _api.UserId,
                //Message = message.Text,
                CaptchaKey = captcha,
                CaptchaSid = sid
            });
        }

        //public IEnumerable<MessageDTO> GetNewMessages()
        //{
        //    _longPoll = _api.Messages.GetLongPollServer(useSsl: false, needPts: true);

        //    _longPollHistory = _api.Messages.GetLongPollHistory(new MessagesGetLongPollHistoryParams
        //    {
        //        Ts = _longPoll.Ts,
        //        Onlines = false,
        //        Pts = _pts
        //    });
        //    _pts = _longPollHistory.NewPts;
        //    _accountInfo.LastUpdate = _pts.ToString();
        //    return EntitiesMapper.Map(_longPollHistory.Messages).ToList();
        //}

        public void NewContactAdded(ContactDTO contact)//TODO post contact
        {
            throw new NotImplementedException();
        }
    }
}
