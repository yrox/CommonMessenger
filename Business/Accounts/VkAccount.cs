using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.Mappers;
using DTOs;
using Newtonsoft.Json.Linq;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Model.RequestParams;

namespace Business.Accounts
{
    public class VkAccount : BaseAccountEvents, IAccount
    {
        public VkAccount(AccountDTO acc)
        {
            _api = new VkApi();
            _accountInfo = acc;
            _api.OnTokenExpires += ApiOnOnTokenExpires;
            _notificationHandler = notificationHandler;
            //_pts = Convert.ToUInt64(acc.LastUpdate);
        }

       private readonly AccountDTO _accountInfo;

        private const int AppId = 5678626;
        private readonly VkApi _api;

        private static string code;
        //private Func<string> _code = () =>
        //{
        //    return code;
        //};

        private readonly Func<string> _code = () =>
        {
            Console.Write("Please enter code: ");
            string value = Console.ReadLine();

            return value;
        };

        private void ApiOnOnTokenExpires(VkApi api)
        {
            throw new NotImplementedException();
        }

        public void AuthorizeFromToken()
        {
            _api.Authorize(_accountInfo.AccessToken);
        }
        public void Authorize()
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
               //TODO captcha event
            }
            _accountInfo.AccessToken = _api.Token;
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
            _accountInfo.AccessToken = _api.Token;
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

        public async Task GetUpdatesFromServer()//TODO answer parsing
        {
            var longPollServer = _api.Messages.GetLongPollServer(true);
            var ts = longPollServer.Ts;
            await Task.Run(async () =>
            {
                string url = $"https://{longPollServer.Server}?act=a_check&key={longPollServer.Key}&ts={ts}&wait=100&version=1";
                using (var http = new HttpClient())
                {
                    var json = await http.GetStringAsync(url).ConfigureAwait(false);
                    var jAnswer = JObject.Parse(json);
                    //ts = jAnswer.Ts;
                    //if (updates.Updates.Count > 0)
                    {
                        //await SendUpdate.Invoke(updates.Updates);
                    }
                }
                await GetUpdatesFromServer();
            });
        }

    }
}
