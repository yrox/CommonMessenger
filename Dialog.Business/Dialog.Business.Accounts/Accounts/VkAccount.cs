using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using AutoMapper;
using Dialog.Business.Accounts.Interfaces;
using Dialog.Business.Accounts.Util;
using Dialog.Business.DTO;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Model.RequestParams;

namespace Dialog.Business.Accounts.Accounts
{
    public class VkAccount : BaseAccountEvents, IAccount
    {
        private const int AppId = 5678626;

        private readonly IMapper _mapper;

        private static string code;

        private readonly AccountDto _accountInfo;
        private readonly VkApi _api;

        private readonly Func<string> _code = () =>
        {
            return code;
        };

        public VkAccount(AccountDto acc, IMapper mapper)
        {
            _api = new VkApi();
            _accountInfo = acc;
            _api.OnTokenExpires += ApiOnOnTokenExpires;
            _mapper = mapper;
            //_pts = Convert.ToUInt64(acc.LastUpdate);
        }

        public void AuthorizeFromToken()
        {
            try
            {
                _api.Authorize(_accountInfo.AccessToken);
            }
            catch (AccessTokenInvalidException)
            {
                Authorize(CodeNeededHandler());
            }
            GetUpdatesFromServer().Wait();
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
                CaptchaNeededHandler(cEx.Img, cEx.Sid);
            }
            _accountInfo.AccessToken = _api.Token;
            GetUpdatesFromServer().Wait();
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
            GetUpdatesFromServer().Wait();
        }

        public IEnumerable<ContactDto> GetAllContacts()
        {
            return _mapper.Map<IEnumerable<ContactDto>>
                (_api.Friends.Get(new FriendsGetParams
                {
                    Order = FriendsOrder.Hints,
                    UserId = _accountInfo.AccountId
                }));
        }

        public void SendMessage(MessageDto message)
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

        public void SendMessage(MessageDto message, string captcha, long sid)
        {
            _api.Messages.Send(new MessagesSendParams
            {
                UserId = _api.UserId,
                //Message = message.Text,
                CaptchaKey = captcha,
                CaptchaSid = sid
            });
        }

        //private readonly Func<string> _code = () =>
        //{
        //    Console.Write("Please enter code: ");
        //    string value = Console.ReadLine();

        //    return value;
        //};

        private void ApiOnOnTokenExpires(VkApi api)
        {
            //TODO refresh token
        }

        private async Task GetUpdatesFromServer()
        {
            var longPollServer = _api.Messages.GetLongPollServer(true);
            var ts = longPollServer.Ts;
            await Task.Run(async () =>
            {
                string url = $"https://{longPollServer.Server}?act=a_check&key={longPollServer.Key}&ts={ts}&wait=100&version=1";
                using (var http = new HttpClient())
                {
                    var response = await http.GetStringAsync(url).ConfigureAwait(false);
                    var updates = VkUpdatesParser.DeserializeUpdates(response);
                    ts = updates.Ts;
                    var newMessages = VkUpdatesParser.GetMessagesFromUpdate(updates).ToList();
                    if (newMessages.Any())
                    {
                        MessageRecivedHandler(_mapper.Map<IEnumerable<MessageDto>>(newMessages));
                    }
                }
                await GetUpdatesFromServer();
            });
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
            _accountInfo.AccessToken = _api.Token;
            GetUpdatesFromServer().Wait();
        }
    }
}
